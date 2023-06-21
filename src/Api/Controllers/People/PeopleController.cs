using Api.Controllers.Auth;
using Entities;
using Entities.Exceptions;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers.People;
[ApiController]
[Route("people")]
public class PeopleController : ControllerBase
{
    private readonly PeopleService _peopleService;
    private readonly UsersService _usersService;


    public PeopleController(PeopleService peopleService, UsersService usersService)
    {
        _peopleService = peopleService;
        _usersService = usersService;
    }

        [HttpPost]
        [Authorize(Roles = "Estudiante,Docente")]
        public ActionResult RegisterPeople(
            [FromBody] CreatePersonRequest createPersonRequest)
        {
            try
            {
                var person = createPersonRequest.Adapt<Person>();
                _peopleService.SavePerson(person);
                var (response,hasErrors) = _usersService.AddPersonDocument(createPersonRequest.Document, createPersonRequest.NameUser);
                return Ok(new Response<Void>("Usuario y persona creada con exito", false));
            }
            catch (PersonExeption exeption)
            {
                return BadRequest(new Response<Void>(exeption.Message));
            }
        }

    [HttpGet("{document}")]
    [Authorize(Roles = "Estudiante,Docente")]
    public ActionResult GetPerson([FromRoute] string document)
    {
        try
        {
            Person? person = _peopleService.SearchPerson(document);
            if(person == null)
            {
                return BadRequest(new Response<Void>("no se encontro a la persona"));
            }
            return Ok(new Response<PersonResponse>(person.Adapt<PersonResponse>()));
        }
        catch (PersonExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpDelete("{document}")]
    [Authorize(Roles = "Estudiante,Docente")]
    public ActionResult DeletePerson([FromRoute] string document)
    {
        try
        {
            _usersService.DeletePersonDocument(document);
            string message = _peopleService.DeletePerson(document);
            return Ok(new Response<Void>(message,false));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }
}
