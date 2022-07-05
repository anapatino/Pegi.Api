using Data.Repositories;
using Entities;
using Entities.Exceptions;

namespace Services;

public class TeachersService
{
    private readonly TeachersRepository _teachersRepository;

    public TeachersService(TeachersRepository teachersRepository)
    {
        _teachersRepository = teachersRepository;
    }

    public string SaveTeacher(Teacher teacher)
    {
        try
        {
            _teachersRepository.Save(teacher);
            return "Registro realizado con exito";
        }
        catch (Exception e)
        {
            throw new TeacherException(
                $"Ha ocurrido un error al registrar {e.Message}");
        }
    }

    public Teacher? SearchTeacher(string document)
    {
        return _teachersRepository.Find(teacher =>
            teacher.Document == document);
    }

    public string DeleteTeacher(string document)
    {
        try
        {
            var foundTeacher = SearchTeacher(document);
            if (foundTeacher == null)
                throw new PersonException("Persona no encontrada");
            _teachersRepository.Delete(foundTeacher);
            return "Registro eliminado";
        }
        catch (Exception e)
        {
            throw new PersonException(
                $"Ha ocurrido un error al eliminar {e.Message}");
        }
    }
}
