using Data.Repository;
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

    public (string, bool) SaveStudent(Student student)
    {
        try
        {
            _studentsRepository.Save(student);
            return ("se ha guardado con exito", true);
        }
        catch (StudentException e)
        {
            return (e.Message, false);
        }
    }

    public Student? SearchStudent(string document)
    {
        return _studentsRepository.Find(student => student.Document == document);
    }
}
