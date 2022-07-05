using Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers.SublinesInvestigation;

[ApiController]
[Route("sublines-investigation")]
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
            var subline = createSublineRequest.Adapt<SublineInvestigation>();
            var message = _sublinesInvestigationService.SaveSubline(subline);
            return Ok(new Response<Void>(message, false));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }


    [HttpGet("{code-subline}")]
    public ActionResult GetSubline([FromRoute] string codeSubline)
    {
        try
        {
            var subline =
                _sublinesInvestigationService.SearchSubline(codeSubline);
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

    [HttpDelete("{code-subline}")]
    public ActionResult DeleteLine([FromRoute] string codeSubline)
    {
        try
        {
            var message = _sublinesInvestigationService.DeleteLine(codeSubline);
            return Ok(new Response<Void>(message, false));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }
}
