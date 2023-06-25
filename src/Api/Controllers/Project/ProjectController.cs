using Api.Controllers.Project;
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

    public ProjectController(ProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpPost]
    [Authorize(Roles = ("Estudiante"))]
    public ActionResult RegisterProject()
    {
        try
        {
            var personDocument = Request.Form["personDocument"];
            var status = Request.Form["status"];
            var score = Convert.ToInt32(Request.Form["score"]);
            var proposalCode = Request.Form["proposalCode"];
            var content = Request.Form.Files.GetFile("content");

            Entities.Project newProject = new Entities.Project
            {
                Code = Random.Shared.Next().ToString(),
                PersonDocument1 = personDocument,
                Content = GetBytesFromStream(content.OpenReadStream()),
                Status = status,
                Score = score,
                ProposalCode = proposalCode
            };

            Entities.Project oldProject = _projectService.SearchProject(newProject.Code)!;
            if (newProject.Code == oldProject?.Code)
            {
                _projectService.UpdateProject(newProject);
            }
            else
            {
                _projectService.SaveProject(newProject);
            }

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
                    new Response<Void>("No se encontro ningún proyecto asociado al documento"));
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
            List<Entities.Project> projects =
                _projectService.GetProjectsProfessorDocument(document);
            if (projects.Count < 0)
            {
                return BadRequest(
                    new Response<Void>("No existen proyectos registradas con ese documento"));
            }

            return Ok(new Response<List<ProjectResponse>>(
                projects?.Adapt<List<ProjectResponse>>()));
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

            var response = new ProjectResponse(
                project.Code,
                project.PersonDocument1,
                project.EvaluatorDocument,
                contentBase64, // Enviar el contenido del archivo como cadena Base64
                project.Status,
                project.Score,
                project.ProposalCode
            );

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

            return Ok(new Response<Void>(message));

        }
        catch (PersonExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
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

            return Ok(new Response<List<ProjectResponse>>(
                projects?.Adapt<List<ProjectResponse>>()));
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
