using Data;
using Entities;
using Entities.Exceptions;

namespace Services;

public class PersonsService
{
    private readonly PersonsRepository _personsRepository;

    public PersonsService(PersonsRepository personsRepository)
    {
        _personsRepository = personsRepository;
    }

    public string SavePerson(Person person)
    {
        try
        {
            _personsRepository.Save(person);
            throw new PersonException("Registro realizado con exito");
        }
        catch (Exception e)
        {
            throw new PersonException($"Ha ocurrido un error al registrar {e.Message}");
        }
    }

    public Person? SearchPerson(int document)
    {
        return _personsRepository.Find(person=> person.Document == document);
    }

    public string DeletePerson(int document)
    {
        try
        {
            Person? foundPerson = SearchPerson(document);
            if (foundPerson == null)
                throw new PersonException("Persona no encontrada");
            _personsRepository.Delete(foundPerson);
            return "Registro eliminado";
        }
        catch (Exception e)
        {
            throw new PersonException($"Ha ocurrido un error al eliminar {e.Message}");
        }
    }
}
