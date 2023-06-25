using Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers.ResearchLines;
[ApiController]
[Route("research-lines")]
public class ResearchLinesController : ControllerBase
{
    private readonly ResearchLineService _researchLineService;

    public ResearchLinesController(ResearchLineService researchLineService)
    {
        _researchLineService = researchLineService;
    }

    [HttpPost]
    public ActionResult RegisterResearchLine(
        [FromBody] CreateLineRequest createLineRequest)
    {
        try
        {
            var    line    = createLineRequest.Adapt<ResearchLine>();
            string message = _researchLineService.SaveLine(line);
            return Ok(new Response<Void>(message, false));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpGet("{code}")]
    public ActionResult GetResearchLine([FromRoute] string code)
    {
        ResearchLine? researchLine =
            _researchLineService.SearchLine(code);
        if (researchLine!.Code == null)
        {
            return BadRequest(
                new Response<Void>("No se encontro linea de investigacion con ese codigo "));
        }else
        {
            return Ok(
                new Response<ResearchLinesResponse>(researchLine?
                    .Adapt<ResearchLinesResponse>()));
        }
    }

    [HttpGet("get-research-lines")]
    public ActionResult GetResearchLine()
    {
        List<ResearchLine> researchLines =
            _researchLineService.GetLines();
        if (researchLines.Count < 0)
        {
            return BadRequest(
                new Response<Void>("No se encontraron lineas de investigacion"));
        }

        return Ok(new Response<List<ResearchLinesResponse>>(
            researchLines?.Adapt<List<ResearchLinesResponse>>()));
    }
}
