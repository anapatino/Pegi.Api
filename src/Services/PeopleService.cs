using Data.Repositories;
using Entities;
using Entities.Exceptions;

namespace Services;

public class PeopleService
{
    private readonly PeopleRepository _peopleRepository;

    public PeopleService(PeopleRepository peopleRepository)
    {
        _peopleRepository = peopleRepository;
    }

    public string SavePerson(Person person)
    {
        try
        {
            _peopleRepository.Save(person);
            return "Registro realizado con exito";
        }
        catch (Exception e)
        {
            throw new PersonException(
                $"Ha ocurrido un error al registrar {e.Message}");
        }
    }

    public Person? SearchPerson(string document)
    {
        return _peopleRepository.Find(person => person.Document == document);
    }

    public Person? SearchPersonByUserName(string username)
    {
        return _peopleRepository.Find(person => person.UserName == username);
    }

    public List<Person> GetAllPeople()
    {
        return _peopleRepository.GetAll();
    }

    public List<Person> FilterPeopleType(string type)
    {
        return _peopleRepository.Filter(people =>
            people.Type == type);
    }

    public List<Person> FilterPeoplePosition(string position)
    {
        return _peopleRepository.Filter(people =>
            people.Position == position);
    }

    public string DeletePerson(string document)
    {
        try
        {
            Person? foundPerson = SearchPerson(document);
            if (foundPerson == null)
                throw new PersonException("Persona no encontrada");
            _peopleRepository.Delete(foundPerson);
            return "Registro eliminado";
        }
        catch (Exception e)
        {
            throw new PersonException(
                $"Ha ocurrido un error al eliminar {e.Message}");
        }
    }
}
