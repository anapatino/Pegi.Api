using Data.Repositories;
using Entities;
using Entities.Exceptions;

namespace Services;

public class StudentsService
{
    private readonly StudentsRepository _studentsRepository;

    public StudentsService(StudentsRepository studentsRepository)
    {
        _studentsRepository = studentsRepository;
    }

    public string SaveStudent(Student student)
    {
        try
        {
            _studentsRepository.Save(student);
            return "Registro realizado con exito";
        }
        catch (Exception e)
        {
            throw new StudentException(
                $"Ha ocurrido un error al registrar {e.Message}");
        }
    }

    public Student? SearchStudent(string document)
    {
        return _studentsRepository.Find(student =>
            student.Document == document);
    }

    public string DeleteStudent(string document)
    {
        try
        {
            var foundStudent = SearchStudent(document);
            if (foundStudent == null)
                throw new StudentException("Studenta no encontrada");
            _studentsRepository.Delete(foundStudent);
            return "Registro eliminado";
        }
        catch (Exception e)
        {
            throw new StudentException(
                $"Ha ocurrido un error al eliminar {e.Message}");
        }
    }
}
