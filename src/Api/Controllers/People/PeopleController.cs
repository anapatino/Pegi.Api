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
    private readonly LocationsService _locationsService;
    private readonly ProposalService _proposalService;
    private readonly StudentsService _studentService;

    public PeopleController(PeopleService peopleService, UsersService usersService, LocationsService locationsService,ProposalService proposalService, StudentsService studentService)
    {
        _peopleService = peopleService;
        _usersService = usersService;
        _locationsService = locationsService;
        _proposalService = proposalService;
        _studentService = studentService;
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
            var (response, hasErrors) = _usersService.AddPersonDocument(createPersonRequest.Document, createPersonRequest.NameUser);
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
            if (person == null)
            {
                return BadRequest(new Response<Void>("no se encontro a la persona"));
            }

            var personResponse = CreatePersonResponse(person);

            return Ok(new Response<PersonResponse>(personResponse.Adapt<PersonResponse>()));
        }
        catch (PersonExeption e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }


    private object CreatePersonResponse(Entities.Person person)
    {
        var departamentAndCity = _locationsService.GetDepartmentByCityCode(person.CitiesCode);

        var newPerson = new
        {
            Document = person.Document,
            IdentificationType = person.IdentificationType,
            FirstName = person.FirstName,
            SecondName = person.SecondName,
            FirstLastName = person.FirstLastName,
            SecondLastName = person.SecondLastName,
            CivilState = person.CivilState,
            Gender = person.Gender,
            BirthDate = person.BirthDate,
            Phone = person.Phone,
            InstitutionalMail = person.InstitutionalMail,
            CitiesCode = person.CitiesCode,
            CitiesName = departamentAndCity[0],
            DepartamentCode = departamentAndCity[1],
            DepartamentName = departamentAndCity[2]
        };
        return newPerson;
    }


    [HttpGet("get-person-by-user/{name}")]
    [Authorize(Roles = "Estudiante,Docente")]
    public ActionResult GetPersonByUser([FromRoute] string name)
    {
        try
        {
            User user = _usersService.SearchUser(name);

            if (user.PersonDocument == null)
            {
                return BadRequest(new Response<Void>("No se encontró persona asociada"));
            }

            Person person = _peopleService.SearchPerson(user.PersonDocument);

            if (person == null)
            {
                return BadRequest(new Response<Void>("No se encontró la persona asociada"));
            }

            var personResponse = CreatePersonResponse(person);

            return Ok(new Response<PersonResponse>(personResponse.Adapt<PersonResponse>()));
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
            var proposals = _proposalService.GetProposalsDocument(document);
            var student = _studentService.SearchStudent(document);

            if(proposals.Count == 0)
            {
                _usersService.DeletePersonDocument(document);
                string message = _peopleService.DeletePerson(document);
                if(student != null)
                {
                    (string messageStudent, bool response) = _studentService.DeleteStudent(student);
                }
                return Ok(new Response<Void>(message, false));
            }

            return BadRequest(new Response<Void>("No se puede borrar una hoja de vida con propuestas asociadas",true));

        }
        catch (Exception e)
        {
            return BadRequest(new Response<Void>(e.Message));
        }
    }
}
