using Api.Controllers.People;
using Entities;
using Entities.Exceptions;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers.ThematicAreas;

[ApiController]
[Route("Thematic-areas")]
public class ThematicAreasController : ControllerBase
{
    private readonly ThematicAreaService _thematicAreaService;

    public ThematicAreasController(ThematicAreaService thematicAreaService)
    {
        _thematicAreaService = thematicAreaService;
    }

    [HttpPost]
    public ActionResult RegisterThematicArea(
        [FromBody] CreateThematicAreaRequest createThematicAreaRequest)
    {
        try
        {
            var thematicArea = createThematicAreaRequest.Adapt<ThematicArea>();
            string message =
                _thematicAreaService.SaveThematicArea(thematicArea);
            return Ok(new Response<Void>(message, false));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpGet("{code}")]
    public ActionResult GetThematicArea([FromRoute] string code)
    {
        try
        {
            List<ThematicArea> thematicArea =
                _thematicAreaService.SearchThematicArea(code);
            return Ok(
                new Response<List<ThematicAreaResponse>>(thematicArea?
                    .Adapt<List<ThematicAreaResponse>>()));
        }
        catch (ThematicAreaExeption e)
        {
            return BadRequest(new Response<Void>("No se encontraron areas tematicas con ese codigo"));
        }
    }

    [HttpGet("thematic-areas")]
    public ActionResult GetThematicAreas()
    {
        try
        {
            List<ThematicArea> thematicAreas = _thematicAreaService.GetLinesThematicAreas();
            return Ok(new Response<List<ThematicAreaResponse>>(thematicAreas.Adapt<List<ThematicAreaResponse>>()));
        }
        catch (Exception e)
        {
            return BadRequest(
                new Response<Void>("No se encontraron areas tematicas"));
        }

    }
}
