using Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers.SublinesInvestigation;

[ApiController]
[Route("investigation-sublines")]
public class SublinesController : ControllerBase
{
    private readonly SublinesInvestigationService _sublinesInvestigationService;

    public SublinesController(
        SublinesInvestigationService sublinesInvestigationService)
    {
        _sublinesInvestigationService = sublinesInvestigationService;
    }

    [HttpPost]
    public ActionResult RegisterSublinesInvestigation(
        [FromBody] CreateSublineRequest createSublineRequest)
    {
        try
        {
            var subline = createSublineRequest.Adapt<InvestigationSubLine>();
            var message = _sublinesInvestigationService.SaveSubline(subline);
            return Ok(new Response<Void>(message, false));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }


    [HttpGet("{sublineCode}")]
    public ActionResult GetSubline([FromRoute] int sublineCode)
    {
        try
        {
            var subline =
                _sublinesInvestigationService.SearchSubline(sublineCode);
            if (subline == null)
                return BadRequest(
                    new Response<Void>("No se ha encontrado  la Sublinea"));
            return Ok(
                new Response<SublineResponse>(
                    subline.Adapt<SublineResponse>()));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }


    [HttpGet]
    public ActionResult GetAllSublines()
    {
        try
        {
            var subline =
                _sublinesInvestigationService.GetAllSublines();
            return Ok(
                new Response<SublineResponse>(
                    subline.Adapt<SublineResponse>()));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpDelete("{sublineCode}")]
    public ActionResult DeleteLine([FromRoute] int sublineCode)
    {
        try
        {
            var message = _sublinesInvestigationService.DeleteLine(sublineCode);
            return Ok(new Response<Void>(message, false));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }
}
