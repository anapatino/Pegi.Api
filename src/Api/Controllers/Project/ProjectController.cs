using Api.Controllers.People;
using Api.Controllers.Project;
using Entities;
using Entities.Exceptions;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers.Proyect;

[ApiController]
[Route("Project")]
public class ProjectController : ControllerBase
{
    private readonly ProjectService _projectService;
    private readonly EmailService _emailService;
    private readonly PeopleService _peopleService;
    private readonly ProposalService _proposalService;

    public ProjectController(ProjectService projectService,EmailService emailService,PeopleService peopleService,ProposalService proposalService)
    {
        _projectService = projectService;
        _emailService = emailService;
        _peopleService = peopleService;
        _proposalService = proposalService;
    }

    [HttpPost]
    [Authorize(Roles = ("Estudiante"))]
    public ActionResult RegisterProject([FromForm] ProjectRequest projectRequest)
    {
        try
        {
            IFormFile? content = Request.Form.Files.GetFile("content");

            Entities.Project? newProject = new()
            {
                Code = Random.Shared.Next().ToString(),
                PersonDocument1 = projectRequest.personDocument1,
                PersonDocument2 = projectRequest.personDocument2,
                Content = GetBytesFromStream(content.OpenReadStream()),
                Status = projectRequest.status,
                Score = projectRequest.score,
                ProposalCode = projectRequest.proposalCode
            };

            Entities.Project oldProject = _projectService.SearchProject(newProject.ProposalCode);
            if (newProject.ProposalCode == oldProject?.ProposalCode)
            {
                newProject.Code = oldProject.Code;
                _projectService.UpdateProject(newProject);
            }
            else
            {
                _projectService.SaveProject(newProject);
            }

            var newProposal = _proposalService.GetProposalCode(newProject.ProposalCode);
            var toAdresses =_peopleService.GetInstitutionalEmailMultiple(newProposal.PersonDocument1,newProposal.PersonDocument2);
            _emailService.SendEmailRegistration(toAdresses,"Proyecto",newProposal.Title);
            return Ok(new Response<Void>("Se ha guardado con éxito el proyecto", false));
        }
        catch (PersonExeption exception)
        {
            return BadRequest(new Response<Void>(exception.Message));
        }
    }

    private byte[] GetBytesFromStream(Stream stream)
    {
        using (var memoryStream = new MemoryStream())
        {
            stream.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }



    [HttpGet("get-projects-document/{document}")]
    [Authorize(Roles = "Estudiante,Docente,Administrador")]
    public ActionResult GetProjects([FromRoute] string document)
    {
        try
        {
            List<Entities.Project> projects =
                _projectService.GetProjects(document);
            if (projects.Count < 0)
            {
                return BadRequest(
                    new Response<Void>(
                        "No se encontro ningún proyecto asociado al documento"));
            }

           var projectsResponse =RefactorProjects(projects);

           return Ok(new Response<List<ProjectResponse>>(
                projectsResponse?.Adapt<List<ProjectResponse>>()));
        }
        catch (PersonExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    private List<ProjectResponse> RefactorProjects(List<Entities.Project> projects)
    {
        List<ProjectResponse>
            projectsResponse = new List<ProjectResponse>();
        foreach (var p in projects)
        {
            Entities.Proposal proposal =
                _proposalService.GetProposalCode(p.ProposalCode);
            if (proposal != null)
            {
                var newProject = new
                {
                    Code = p.Code,
                    PersonDocument1 = p.PersonDocument1,
                    PersonDocument2 = p.PersonDocument2,
                    EvaluatorDocument = p.EvaluatorDocument,
                    TutorDocument = p.TutorDocument,
                    Content = p.Content,
                    Status = p.Status,
                    Score = p.Score,
                    ProposalCode = p.ProposalCode,
                    Title = proposal.Title,
                };
                projectsResponse.Add(newProject.Adapt<ProjectResponse>());
            }


        };
        return projectsResponse;
    }

    [HttpGet("get-projects-title/{title}")]
    [Authorize(Roles = "Estudiante,Docente,Administrador")]
    public ActionResult GetProjectsByTitleProject([FromRoute] string title)
    {
        try
        {
            List<Entities.Project> projects = _proposalService.GetProposalsByTitle(title)
                .Select(p => _projectService.SearchProject(p.Code))
                .Where(p => p != null)
                .ToList();

            if (projects.Count == 0)
            {
                return BadRequest(new Response<Void>("No se encontró ningún proyecto asociado al título"));
            }
            var projectsResponse =RefactorProjects(projects);

            return Ok(new Response<List<ProjectResponse>>(projectsResponse.Adapt<List<ProjectResponse>>()));
        }
        catch (PersonExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpGet("get-projects-professor/{document}")]
[Authorize(Roles = "Docente,Administrador")]
public ActionResult GetProjectsProfessorDocument([FromRoute] string document)
{
    try
    {
        List<Entities.Project> projects =
            _projectService.GetProjectsProfessorDocument(document);
        if (projects.Count < 0)
        {
            return BadRequest(
                new Response<Void>("No existen proyectos registradas con ese documento"));
        }
        var projectsResponse =RefactorProjects(projects);

        return Ok(new Response<List<ProjectResponse>>(
            projectsResponse?.Adapt<List<ProjectResponse>>()));
    }
    catch (PersonExeption e)
    {
        return BadRequest(new Response<Void>(e.Message));
    }
}

[HttpGet("get-project-code/{code}")]
[Authorize(Roles = "Estudiante,Docente,Administrador")]
public ActionResult GetProjectCode([FromRoute] string code)
{
    try
    {
        Entities.Project? project = _projectService.GetProjectCode(code);
        if (project == null)
        {
            return BadRequest(new Response<Void>("No se encontro proyecto con ese codigo"));
        }

        string contentBase64 = Convert.ToBase64String(project.Content);
        var proposal = _proposalService.GetProposalCode(project.ProposalCode);
        var response = new ProjectResponse(
            project.Code,
            project.PersonDocument1,
            project.PersonDocument2,
            project.EvaluatorDocument,
            project.TutorDocument,
            contentBase64, // Enviar el contenido del archivo como cadena Base64
            project.Status,
            project.Score,
            project.ProposalCode,
            proposal.Title
        );
        var (toAdresses, toAdress,title) = GetAdressesEmailStudentsAndDocent(response.Code,false);
        _emailService.SendEmailRegistration(toAdresses,"Proyecto",title);
        return Ok(new Response<ProjectResponse>(response));
    }
    catch (PersonExeption e)
    {
        return BadRequest(new Response<Void>(e.Message));
    }
}


[HttpPut("update-evaluator-project/")]
[Authorize(Roles = "Administrador")]
public ActionResult UpdateEvaluatorProject([FromBody] ProjectUpdateRequest projectUpdateRequest)
{
    try
    {
        var (message,response)= _projectService.UpdateEvaluatorDocumentProject(projectUpdateRequest.code,projectUpdateRequest.ProfessorDocument);
        if (response == false )
        {
            return BadRequest(
                new Response<Void>(message));
        }
        var (toAdresses, toAdress,title) = GetAdressesEmailStudentsAndDocent(projectUpdateRequest.code,false);
        _emailService.SendEmailAssignmentStudentProposal(toAdresses,"Evaluador",title);
        _emailService.SendEmailAssignmentEvaluatorProposal(toAdress,title);
        return Ok(new Response<Void>(message));

    }
    catch (PersonExeption e)
    {
        return BadRequest(new Response<Void>(e.Message));
    }
}

[HttpPut("update-tutor-proyect/")]
[Authorize(Roles = "Administrador")]
public ActionResult UpdateTutorProject([FromBody] ProjectUpdateRequest projectUpdateRequest)
{
    try
    {
        var (message,response)= _projectService.UpdateTutorDocumentProject(projectUpdateRequest.code,projectUpdateRequest.ProfessorDocument);
        if (response == false )
        {
            return BadRequest(
                new Response<Void>(message));

        }
        var (toAdresses, toAdress,title) = GetAdressesEmailStudentsAndDocent(projectUpdateRequest.code,false);
        _emailService.SendEmailAssignmentStudentProposal(toAdresses,"Tutor",title);
        _emailService.SendEmailAssignmentTutorProposal(toAdress,title);
        return Ok(new Response<Void>(message));

    }
    catch (PersonExeption e)
    {
        return BadRequest(new Response<Void>(e.Message));
    }
}

private (List<string>, string,string) GetAdressesEmailStudentsAndDocent(string codeProject,bool type)
{
    var project =
        _projectService.GetProjectCode(codeProject);
    var proposal =
        _proposalService.GetProposalCode(project.ProposalCode);
    var toAdresses =_peopleService.GetInstitutionalEmailMultiple(proposal.PersonDocument1,proposal.PersonDocument2);
    var toAdress =
        _peopleService.GetInstitutionalEmail(type ? proposal.EvaluatorDocument : proposal.TutorDocument);
    return (toAdresses, toAdress,proposal.Title);
}

[HttpGet]
public ActionResult GetAll()
{
    try
    {
        List<Entities.Project> projects =
            _projectService.GetAll();
        if (projects.Count < 0)
        {
            return BadRequest(
                new Response<Void>("No se encontro ningún proyecto"));
        }

        var projectsResponse =RefactorProjects(projects);

        return Ok(new Response<List<ProjectResponse>>(
            projectsResponse?.Adapt<List<ProjectResponse>>()));
    }
    catch (PersonExeption e)
    {
        return BadRequest(new Response<Void>(e.Message));
    }
}

[HttpDelete("{code}")]
[Authorize(Roles = ("Estudiante"))]
public ActionResult DeleteProject([FromRoute] string code)
{
    try
    {
        string message = _projectService.DeleteProject(code);
        return Ok(new Response<Void>(message, false));
    }
    catch (Exception e)
    {
        return BadRequest(new Response<Void>(e.Message));
    }
}

[HttpGet("general-statistics-project-professor/{document}")]
[Authorize(Roles = "Docente,Administrador")]
public ActionResult GetGeneralStatisticsProjectProfessor([FromRoute] string document)
{
    try
    {
        object statistics =
            _projectService.GeneralStatisticsProjectProfessor(document);
        if (statistics == null)
        {
            return BadRequest(
                new Response<Void>("No hay estadisticas para este docente"));
        }

        return Ok(new Response<object>(statistics));
    }
    catch (PersonExeption e)
    {
        return BadRequest(new Response<Void>(e.Message));
    }
}

[HttpGet("general-statistics-project-student/{document}")]
[Authorize(Roles = "Estudiante,Administrador")]
public ActionResult GetGeneralStatisticsProjectStudent([FromRoute] string document)
{
    try
    {
        object statistics =
            _projectService.GeneralStatisticsProjectStudent(document);
        if (statistics == null)
        {
            return BadRequest(
                new Response<Void>("No hay estadisticas para este docente"));
        }

        return Ok(new Response<object>(statistics));
    }
    catch (PersonExeption e)
    {
        return BadRequest(new Response<Void>(e.Message));
    }
}

[HttpGet("general-statistics-project")]
[Authorize(Roles = "Administrador")]
public ActionResult GetGeneralStatisticsProposals()
{
    try
    {
        object statistics =
            _projectService.GeneralStatisticsProjects();
        if (statistics == null)
        {
            return BadRequest(
                new Response<Void>("No hay estadisticas generales"));
        }

        return Ok(new Response<object>(statistics));
    }
    catch (PersonExeption e)
    {
        return BadRequest(new Response<Void>(e.Message));
    }
}
}
