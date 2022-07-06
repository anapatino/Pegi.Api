using Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers.LinesInvestigation;

[ApiController]
[Route("lines-investigation")]
public class LinesController : ControllerBase
{
    private readonly LinesInvestigationService _linesInvestigationService;

    public LinesController(LinesInvestigationService linesInvestigationService)
    {
        _linesInvestigationService = linesInvestigationService;
    }

    [HttpPost]
    public ActionResult RegisterLineInvestigation(
        [FromBody] CreateLineRequest createLineRequest)
    {
        try
        {
            var line = createLineRequest.Adapt<LineInvestigation>();
            var message = _linesInvestigationService.SaveLine(line);
            return Ok(new Response<Void>(message, false));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }


    [HttpGet("{code-line}")]
    public ActionResult GetLine([FromRoute] string codeLine)
    {
        try
        {
            var line = _linesInvestigationService.SearchLine(codeLine);
            if (line == null)
                return BadRequest(
                    new Response<Void>("No se ha encontrado  la linea"));
            return Ok(
                new Response<LineResponse>(line.Adapt<LineResponse>()));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }


    [HttpGet]
    public ActionResult GetAllLine()
    {
        try
        {
            var line = _linesInvestigationService.AllLines();
            if (line == null)
                return BadRequest(
                    new Response<Void>("No se ha encontrado ninguna linea"));
            return Ok(
                new Response<LineResponse>(line.Adapt<LineResponse>()));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpDelete("{code-line}")]
    public ActionResult DeleteLine([FromRoute] string codeLine)
    {
        try
        {
            var message = _linesInvestigationService.DeleteLine(codeLine);
            return Ok(new Response<Void>(message, false));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }
}
