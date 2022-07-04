using Data;
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
            throw new PersonException("Registro realizado con exito");
        }
        catch (Exception e)
        {
            throw new PersonException($"Ha ocurrido un error al registrar {e.Message}");
        }
    }

    public Person? SearchPerson(string document)
    {
        return _peopleRepository.Find(person=> person.Document == document);
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
            throw new PersonException($"Ha ocurrido un error al eliminar {e.Message}");
        }
    }
}
