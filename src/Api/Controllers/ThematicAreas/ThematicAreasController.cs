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
            string message =
                _thematicAreasService.SaveThematicArea(thematicArea);
            return Ok(new Response<Void>(message, false));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpGet("{codeThematicArea}")]
    public ActionResult GetThematicArea([FromRoute] int codeThematicArea)
    {
        try
        {
            ThematicArea? thematicArea =
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
            List<ThematicArea> thematicArea =
                _thematicAreasService.GetAllThematicAreas();
            return Ok(
                new Response<List<ThematicAreaResponse>>(
                    thematicArea.Adapt<List<ThematicAreaResponse>>()));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpGet("subline/{subLineCode}")]
    public ActionResult GetAllThematicAreaBySubLine(int subLineCode)
    {
        try
        {
            List<ThematicArea> thematicArea =
                _thematicAreasService.FilterBySubLine(subLineCode);
            return Ok(
                new Response<List<ThematicAreaResponse>>(
                    thematicArea.Adapt<List<ThematicAreaResponse>>()));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpDelete("{codeThematicArea}")]
    public ActionResult DeleteThematicArea([FromRoute] int codeThematicArea)
    {
        try
        {
            string message =
                _thematicAreasService.DeleteThematicArea(codeThematicArea);
            return Ok(new Response<Void>(message, false));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }
}
