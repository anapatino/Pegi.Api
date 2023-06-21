using Entities;
using Entities.Exceptions;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers.People;

[ApiController]
[Route("studies")]
public class StudiesController : ControllerBase
{
    private readonly StudiesService _studiesService;

    public StudiesController(StudiesService studiesService)
    {
        _studiesService = studiesService;
    }

    [HttpPost]
    public ActionResult RegisterStudy(
        [FromBody] CreateStudyRequest createStudyRequest)
    {
        try
        {
            var study = createStudyRequest.Adapt<Study>();
            _studiesService.SaveStudy(study);
            return Ok(new Response<Void>("el estudio se ha agregado con exito",
                false));
        }
        catch (PersonExeption exeption)
        {
            return BadRequest(new Response<Void>(exeption.Message));
        }
    }

    [HttpGet("{document}")]
    public ActionResult GetStudies([FromRoute] string document)
    {
        try
        {
            var studies = _studiesService.SearchStudies(document);
            if (studies.Count <= 0)
            {
                return BadRequest(
                    new Response<Void>("no se encontro a la persona"));
            }

            return Ok(
                new Response<List<StudiesResponse>>(
                    studies.Adapt<List<StudiesResponse>>()));
        }
        catch (StudyExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }
}
