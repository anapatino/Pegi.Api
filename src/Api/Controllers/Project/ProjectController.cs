using Api.Controllers.Project;
using Entities.Exceptions;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers.Project;

[ApiController]
[Route("Project")]
public class ProjectController : ControllerBase
{
    private readonly ProjectService _projectService;
    private readonly EmailService _emailService;

    public ProjectController(ProjectService projectService,EmailService emailService)
    {
        _projectService = projectService;
        _emailService = emailService;
    }

    [HttpPost]
    [Authorize(Roles = ("Estudiante"))]
    public ActionResult RegisterProject(
        [FromBody] ProjectRequest ProjectRequest)
    {
        try
        {
            Entities.Project? newProject =
                ProjectRequest.Adapt<Entities.Project>();
            newProject.Code = Random.Shared.Next().ToString();
            Entities.Project oldProject =
                _projectService.SearchProject(newProject.Code!)!;
            if (newProject.Code == oldProject?.Code)
            {
                _projectService.UpdateProject(newProject);
            }
            else
            {
                _projectService.SaveProject(newProject);
            }
            _emailService.SendEmailRegistrationProject(newProject.ProposalCode,"Projecto");
            return Ok(new Response<Void>("se ha guardado con exito",
                false));
        }
        catch (PersonExeption exeption)
        {
            return BadRequest(new Response<Void>(exeption.Message));
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
                    new Response<Void>("no se encontro ningún Projecto"));
            }

            return Ok(new Response<List<ProjectResponse>>(
                projects?.Adapt<List<ProjectResponse>>()));
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
            List<Entities.Project> Projects =
                _projectService.GetProjectsProfessorDocument(document);
            if (Projects.Count < 0)
            {
                return BadRequest(
                    new Response<Void>("No existen Projectos registrados con ese documento"));
            }

            return Ok(new Response<List<ProjectResponse>>(
                Projects?.Adapt<List<ProjectResponse>>()));
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
            Entities.Project?
                Project = _projectService.GetProjectCode(code);
            if (Project == null)
            {
                return BadRequest(
                    new Response<Void>("no se encontro Projecto con este codigo"));
            }

            return Ok(
                new Response<ProjectResponse>(
                    Project.Adapt<ProjectResponse>()));
        }
        catch (PersonExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpPut("update-evaluator-project/")]
    [Authorize(Roles = "Administrador")]
    public ActionResult UpdateEvaluatorProject([FromBody] ProjectUpdateRequest ProjectUpdateRequest)
    {
        try
        {
            var (message,response)= _projectService.UpdateEvaluatorDocumentProject(ProjectUpdateRequest.code,ProjectUpdateRequest.ProfessorDocument);
            if (response == false )
            {
                return BadRequest(
                    new Response<Void>(message));

            }

            return Ok(new Response<Void>(message));

        }
        catch (PersonExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpPut("update-tutor-project/")]
    [Authorize(Roles = "Administrador")]
    public ActionResult UpdateTutorProject([FromBody] ProjectUpdateRequest ProjectUpdateRequest)
    {
        try
        {
            var (message,response)= _projectService.UpdateTutorDocumentProject(ProjectUpdateRequest.code,ProjectUpdateRequest.ProfessorDocument);
            if (response == false )
            {
                return BadRequest(
                    new Response<Void>(message));

            }

            return Ok(new Response<Void>(message));

        }
        catch (PersonExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpGet]
    [Authorize(Roles = "Administrador")]
    public ActionResult GetAll()
    {
        try
        {
            List<Entities.Project> Projects =
                _projectService.GetAll();
            if (Projects.Count < 0)
            {
                return BadRequest(
                    new Response<Void>("no se encontro ningún Projecto"));
            }

            return Ok(new Response<List<ProjectResponse>>(
                Projects?.Adapt<List<ProjectResponse>>()));
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
                    new Response<Void>("No hay estadisticas para este estudiante"));
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
                    new Response<Void>("No hay estadisticas"));
            }

            return Ok(new Response<object>(statistics));
        }
        catch (PersonExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }
}
