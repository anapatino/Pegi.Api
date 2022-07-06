using Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers.People;

[ApiController]
[Route("people")]
public class PeopleController : ControllerBase
{
    private readonly PeopleService _peopleService;

    public PeopleController(PeopleService peopleService)
    {
        _peopleService = peopleService;
    }

    [HttpPost]
    public ActionResult RegisterPeople(
        [FromBody] CreatePersonRequest createPersonRequest)
    {
        try
        {
            var person = createPersonRequest.Adapt<Person>();
            var message = _peopleService.SavePerson(person);
            return Ok(new Response<Void>(message, false));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpGet("{document}")]
    public ActionResult GetPerson([FromRoute] string document)
    {
        try
        {
            var person = _peopleService.SearchPerson(document);
            if (person == null)
                return BadRequest(
                    new Response<Void>("No se ha encontrado a la persona"));
            return Ok(
                new Response<PersonResponse>(person.Adapt<PersonResponse>()));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpGet]
    public ActionResult GetAllPeople()
    {
        try
        {
            var person = _peopleService.AllPeople();
            if (person == null)
                return BadRequest(
                    new Response<Void>("No se ha encontrado a la persona"));
            return Ok(
                new Response<PersonResponse>(person.Adapt<PersonResponse>()));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpGet("{type}")]
    public ActionResult GetFilterPeopleType([FromRoute] string type)
    {
        try
        {
            var person = _peopleService.FilterPeopleType(type);
            if (person == null)
                return BadRequest(
                    new Response<Void>("No existen personas de este tipo"));
            return Ok(
                new Response<PersonResponse>(person.Adapt<PersonResponse>()));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }


    [HttpGet("{position}")]
    public ActionResult GetFilterPeoplePosition([FromRoute] string position)
    {
        try
        {
            var person = _peopleService.FilterPeoplePosition(position);
            if (person == null)
                return BadRequest(
                    new Response<Void>("No existen personas con este cargo"));
            return Ok(
                new Response<PersonResponse>(person.Adapt<PersonResponse>()));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpDelete("{document}")]
    public ActionResult DeletePerson([FromRoute] string document)
    {
        try
        {
            var message = _peopleService.DeletePerson(document);
            return Ok(new Response<Void>(message, false));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }
}
