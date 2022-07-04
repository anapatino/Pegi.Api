using Services;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.People;

[ApiController]
[Route("people")]
public class PeopleController:ControllerBase
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
            Person person = CreatePerson(createPersonRequest);
            string message = _peopleService.SavePerson(person);
            return Ok(new Response<Void>(message, hasErrors: false));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }

    }

    public Person CreatePerson(CreatePersonRequest createPersonRequest)
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
            CityCode= createPersonRequest.CityCode,
            BirthPlace = createPersonRequest.BirthPlace,
            Phone = createPersonRequest.Phone,
            InstitutionalMail = createPersonRequest.InstitutionalMail
        };
        return person;
    }

    [HttpGet]
    public ActionResult GetPerson([FromRoute] string document)
    {
        try
        {
            Person? person = _peopleService.SearchPerson(document);
            if (person == null)
                return BadRequest(new Response<Void>("No se ha encontrado a la persona"));
            return Ok(new Response<Person>(person));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }

    [HttpDelete]
    public ActionResult DeletePerson([FromRoute] string document)
    {
        try
        {
            string message = _peopleService.DeletePerson(document);
            return Ok(new Response<Void>(message, hasErrors: false));
        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }
}
