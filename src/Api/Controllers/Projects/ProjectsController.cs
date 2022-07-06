using Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers.Projects;

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

    [HttpGet("{code-project}")]
    public ActionResult GetProject([FromBody] string codeProject)
    {
        try
        {
            var project = _projectsService.SearchProject(codeProject);
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

    [HttpDelete("{code-project}")]
    public ActionResult DeleteProject([FromRoute] string codeProject)
    {
        try
        {
            var message = _projectsService.DeleteProject(codeProject);
            return Ok(new Response<Void>(message, false));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }
}
