using Api.Controllers.HistorialProposal;
using Entities;
using Entities.Exceptions;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers.HistorialProyect;

[ApiController]
[Route("HistorialProyect")]
public class HistorialProyectController : ControllerBase
{
    private readonly ProyectFeedBackService _proyectFeedBackService;
    private readonly HistoryProyectService _historyProyectService;
    private readonly ProyectService _proyectService;

    public HistorialProyectController(
        ProyectFeedBackService proyectFeedBackService,
        HistoryProyectService historyProyectService,
        ProyectService proyectService)
    {
        _proyectFeedBackService = proyectFeedBackService;
        _historyProyectService = historyProyectService;
        _proyectService = proyectService;
    }

    [HttpPost("register-feedback")]
    [Authorize(Roles = "Docente")]
    public ActionResult RegisterFeedback(
        [FromBody] ProyectFeedbackRequest proyectFeedbackRequest)
    {
        try
        {
            var feedBack = proyectFeedbackRequest.Adapt<ProyectFeedBack>();
            feedBack.Code = Random.Shared.Next();
            _proyectFeedBackService.SaveProyectFeedBack(feedBack);
            HistoryProyect historialProyect =
                new HistoryProyect(feedBack.Code,
                    proyectFeedbackRequest.ProyectCode);
            historialProyect.Code = Random.Shared.Next();
            _historyProyectService.SaveProyectlHistory(historialProyect);
            _proyectService.UpdateStatusProyect(historialProyect.ProyectCode,
                proyectFeedbackRequest.Status, proyectFeedbackRequest.Score);
            return Ok(
                new Response<HistorialProyectResponse>(
                    historialProyect.Adapt<HistorialProyectResponse>()));
        }
        catch (PersonExeption exeption)
        {
            return BadRequest(new Response<Void>(exeption.Message));
        }
    }

    [HttpGet("{proyectCode}")]
    public ActionResult GetHistoryProyect([FromRoute] string proyectCode)
    {
        try
        {
            List<HistoryProyect> historyProyects =
                _historyProyectService.SearchProyectHistory(proyectCode);
            foreach (var historyProyect in historyProyects)
            {
                historyProyect.ProyectFeedBack =
                    _proyectFeedBackService.GetProyectFeedBackCode(
                        historyProyect.ProyectFeedBackCode);
            }
            if (historyProyects.Count <= 0)
            {
                return BadRequest(
                    new Response<Void>(
                        "no tiene experiencias registradas en proyecto"));
            }

            return Ok(
                new Response<List<HistorialProyectResponse>>(
                    historyProyects.Adapt<List<HistorialProyectResponse>>()));
        }
        catch (ExperienceExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }
}
