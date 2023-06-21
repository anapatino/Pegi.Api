using Entities;
using Entities.Exceptions;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers.Students;


[ApiController]
[Route("students")]
public class StudentController : ControllerBase
{
    private readonly StudentsService _studentsService;
    private readonly PeopleService _peopleService;

    public StudentController(StudentsService studentsService,PeopleService peopleService)
    {
        _studentsService = studentsService;
        _peopleService = peopleService;
    }

    [HttpPost]
    public ActionResult RegisterStudent(
        [FromBody] CreateStudentRequest createStudentRequest)
    {
        try
        {
            if (_peopleService.SearchPerson(createStudentRequest.Document) != null &&
                _studentsService.SearchStudent(createStudentRequest.Document) == null)
            {
                _studentsService.SaveStudent(createStudentRequest.Adapt<Student>());
                return Ok(new Response<Void>("Estudiante creado con exito", false));
            }
            return BadRequest(new Response<Void>("Error al registrar estudiante"));
        }
        catch (PersonExeption exeption)
        {
            return BadRequest(new Response<Void>(exeption.Message));
        }
    }


    [HttpGet("{document}")]
    public ActionResult GetStudent([FromRoute] string document)
    {
        try
        {
            Student? student = _studentsService.SearchStudent(document);
            if(student == null)
            {
                return BadRequest(new Response<Void>("no se encontro a la estudiante"));
            }
            return Ok(new Response<StudentResponse>(student.Adapt<StudentResponse>()));
        }
        catch (PersonExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

}
