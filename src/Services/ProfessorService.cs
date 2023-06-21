using Entities;
using Entities.Exceptions;

namespace Services;

public class ProfessorService
{
    private readonly ProfessorRepository _professorRepository;

    public ProfessorService(ProfessorRepository professorRepository)
    {
        _professorRepository = professorRepository;
    }


    public (string, bool) SaveProfessor(Professor professor)
    {
        try
        {
            _professorRepository.Save(professor);
            return ("se ha guardado con exito", true);
        }
        catch (PersonExeption e)
        {
            return (e.Message, false);
        }
    }

    public Professor? SearchProfessor(string document)
    {
        return _professorRepository.Find(professor =>
            professor.Document == document);
    }

    public List<Professor> SearchProfessorByPosition(string position)
    {
        return _professorRepository.Filter(professor =>
            professor.Position != null &&
            professor.Position == position);
    }

    public List<Professor> GetAllProfessors()
    {
        return _professorRepository.GetAll();
    }


}
