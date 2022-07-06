using Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers.ThematicAreas;

[ApiController]
[Route("thematic-areas")]
public class ThematicAreasController : ControllerBase
{
    private readonly ThematicAreasService _thematicAreasService;

    public ThematicAreasController(ThematicAreasService thematicAreasService)
    {
        _thematicAreasService = thematicAreasService;
    }

    [HttpPost]
    public ActionResult RegisterThematicArea(
        [FromBody] CreateThematicAreaRequest createThematicAreaRequest)
    {
        try
        {
            var thematicArea = createThematicAreaRequest.Adapt<ThematicArea>();
            var message = _thematicAreasService.SaveThematicArea(thematicArea);
            return Ok(new Response<Void>(message, false));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpGet("{code-thematic-area}")]
    public ActionResult GetThematicArea([FromRoute] string codeThematicArea)
    {
        try
        {
            var thematicArea =
                _thematicAreasService.SearchThematicArea(codeThematicArea);
            if (thematicArea == null)
                return BadRequest(
                    new Response<Void>(
                        "No se ha encontrado  la area tematica"));
            return Ok(
                new Response<ThematicAreaResponse>(
                    thematicArea.Adapt<ThematicAreaResponse>()));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpGet]
    public ActionResult GetAllThematicArea()
    {
        try
        {
            var thematicArea =
                _thematicAreasService.AllThematicAreas();
            if (thematicArea == null)
                return BadRequest(
                    new Response<Void>(
                        "No se ha encontrado ninguna de las areas tematicas"));
            return Ok(
                new Response<ThematicAreaResponse>(
                    thematicArea.Adapt<ThematicAreaResponse>()));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpDelete("{code-thematic-are}")]
    public ActionResult DeleteThematicArea([FromRoute] string codeThematicArea)
    {
        try
        {
            var message =
                _thematicAreasService.DeleteThematicArea(codeThematicArea);
            return Ok(new Response<Void>(message, false));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }
}
