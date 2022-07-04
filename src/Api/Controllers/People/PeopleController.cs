using Entities;
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
            var person = CreatePerson(createPersonRequest);
            var message = _peopleService.SavePerson(person);
            return Ok(new Response<Void>(message, false));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    private Person CreatePerson(CreatePersonRequest createPersonRequest)
    {
        Person person = new()
        {
            Document = createPersonRequest.Document,
            Identification = createPersonRequest.Identification,
            FirstName = createPersonRequest.FirstName,
            SecondName = createPersonRequest.SecondName,
            FirstLastName = createPersonRequest.FirstLastName,
            SecondLastName = createPersonRequest.SecondLatName,
            CivilState = createPersonRequest.CivilState,
            Sex = createPersonRequest.Sex,
            BirthDate = createPersonRequest.BirthDate,
            Nationality = createPersonRequest.Nationality,
            CityCode = createPersonRequest.CityCode,
            BirthPlace = createPersonRequest.BirthPlace,
            Phone = createPersonRequest.Phone,
            InstitutionalMail = createPersonRequest.InstitutionalMail
        };
        return person;
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
            return Ok(new Response<Person>(person));
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
