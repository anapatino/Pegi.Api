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
            var    person  = createPersonRequest.Adapt<Person>();
            string message = _peopleService.SavePerson(person);
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
            Person? person = _peopleService.SearchPerson(document);
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
            List<Person> person = _peopleService.GetAllPeople();
            return Ok(
                new Response<List<PersonResponse>>(
                    person.Adapt<List<PersonResponse>>()));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpGet("type/{type}")]
    public ActionResult GetFilterPeopleType([FromRoute] string type)
    {
        try
        {
            List<Person> person = _peopleService.FilterPeopleType(type);
            return Ok(
                new Response<PersonResponse>(person.Adapt<PersonResponse>()));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }


    [HttpGet("position/{position}")]
    public ActionResult GetFilterPeoplePosition([FromRoute] string position)
    {
        try
        {
            List<Person> person = _peopleService.FilterPeoplePosition(position);
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
            string message = _peopleService.DeletePerson(document);
            return Ok(new Response<Void>(message, false));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }
}
