using Api.Controllers.HistorialProposal;
using Entities;
using Entities.Exceptions;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers.HistorialProject;

[ApiController]
[Route("HistorialProject")]
public class HistorialProjectController : ControllerBase
{
    private readonly ProjectFeedBackService _projectFeedBackService;
    private readonly HistoryProjectService _historyProjectService;
    private readonly ProjectService _projectService;

    public HistorialProjectController(
        ProjectFeedBackService projectFeedBackService,
        HistoryProjectService historyProjectService,
        ProjectService projectService)
    {
        _projectFeedBackService = projectFeedBackService;
        _historyProjectService = historyProjectService;
        _projectService = projectService;
    }

    [HttpPost("register-feedback")]
    [Authorize(Roles = "Docente")]
    public ActionResult RegisterFeedback(
        [FromBody] ProjectFeedbackRequest projectFeedbackRequest)
    {
        try
        {
            var feedBack = projectFeedbackRequest.Adapt<ProjectFeedBack>();
            feedBack.Code = Random.Shared.Next();
            _projectFeedBackService.SaveProjectFeedBack(feedBack);
            HistoryProject historialProject =
                new HistoryProject(feedBack.Code,
                    projectFeedbackRequest.ProjectCode);
            historialProject.Code = Random.Shared.Next();
            _historyProjectService.SaveProjectHistory(historialProject);
            _projectService.UpdateStatusProject(historialProject.ProjectCode,
                projectFeedbackRequest.Status, projectFeedbackRequest.Score);
            return Ok(
                new Response<HistorialProjectResponse>(
                    historialProject.Adapt<HistorialProjectResponse>()));
        }
        catch (PersonExeption exeption)
        {
            return BadRequest(new Response<Void>(exeption.Message));
        }
    }

    [HttpGet("{projectCode}")]
    public ActionResult GetHistoryProject([FromRoute] string projectCode)
    {
        try
        {
            List<HistoryProject> historyProjects =
                _historyProjectService.SearchProjectHistory(projectCode);
            foreach (var historyProject in historyProjects)
            {
                historyProject.ProjectFeedBack =
                    _projectFeedBackService.GetProjectFeedBackCode(
                        historyProject.ProjectFeedBackCode);
            }
            if (historyProjects.Count <= 0)
            {
                return BadRequest(
                    new Response<Void>(
                        "No tiene experiencias registradas en proyecto"));
            }

            return Ok(
                new Response<List<HistorialProjectResponse>>(
                    historyProjects.Adapt<List<HistorialProjectResponse>>()));
        }
        catch (ExperienceExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }
}