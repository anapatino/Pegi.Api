using Api.Controllers.People;
using Entities;
using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services;
using Mapster;

namespace Api.Controllers.AcademicPrograms;

[ApiController]
[Route("AcademicsProgram")]
public class AcademicProgramsController : ControllerBase
{
    private readonly AcademicProgramService _academicProgramService;

    public AcademicProgramsController(
        AcademicProgramService academicProgramService)
    {
        _academicProgramService = academicProgramService;
    }

    [HttpGet("{code}")]
    public ActionResult GetAcademicProgram([FromRoute] string code)
    {
        AcademicProgram? academicProgram =
            _academicProgramService.SearchProfessorAcademicProgram(code);
        if (academicProgram == null)
        {
            return BadRequest(
                new Response<Void>("no se encontro a la persona"));
        }

        return Ok(new Response<AcademicProgramResponse>(academicProgram.Adapt<AcademicProgramResponse>()));
    }

    [HttpGet("GetAllAcademicPrograms")]
    public ActionResult GetAllAcademicPrograms()
    {
        try
        {
            List<AcademicProgram> academicPrograms =
                _academicProgramService.GetAll();
            return Ok(new Response<List<AcademicProgram>>(academicPrograms));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }


    }
}
