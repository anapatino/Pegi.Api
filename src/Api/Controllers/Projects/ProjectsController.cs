using Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers.Projects;

[ApiController]
[Route("project")]
public class ProjectsController : ControllerBase
{
    private readonly ProjectsService _projectsService;

    public ProjectsController(ProjectsService projectsService)
    {
        _projectsService = projectsService;
    }

    [HttpPost]
    public ActionResult RegisterProject(
        [FromBody] CreateProjectRequest createProjectRequest)
    {
        try
        {
            var project = createProjectRequest.Adapt<Project>();
            var message = _projectsService.SaveProject(project);
            return Ok(new Response<Void>(message, false));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpGet("{title-project}")]
    public ActionResult GetProject([FromBody] string titleProject)
    {
        try
        {
            var project = _projectsService.SearchProject(titleProject);
            if (project == null)
                return BadRequest(
                    new Response<Void>("No existe projecto"));
            return Ok(
                new Response<ProjectResponse>(
                    project.Adapt<ProjectResponse>()));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpGet]
    public ActionResult GetAllProjects()
    {
        try
        {
            var project = _projectsService.GetAllProject();
            if (project == null)
                return BadRequest(
                    new Response<Void>("No existen projectos"));
            return Ok(
                new Response<ProjectResponse>(
                    project.Adapt<ProjectResponse>()));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpGet("{status}")]
    public ActionResult GetFilterProjectsStatus([FromBody] string status)
    {
        try
        {
            var project = _projectsService.SearchProject(status);
            if (project == null)
                return BadRequest(
                    new Response<Void>("No existen projectos con este estado"));
            return Ok(
                new Response<ProjectResponse>(
                    project.Adapt<ProjectResponse>()));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpDelete("{title-project}")]
    public ActionResult DeleteProject([FromRoute] string titleProject)
    {
        try
        {
            var message = _projectsService.DeleteProject(titleProject);
            return Ok(new Response<Void>(message, false));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }
}
