using Data.Repositories;
using Entities;
using Entities.Exceptions;

namespace Services;

public class ProjectsEvaluationService
{
    private readonly ProjectsEvaluationRepository _projectsEvaluationRepository;

    public ProjectsEvaluationService(
        ProjectsEvaluationRepository projectsEvaluationRepository)
    {
        _projectsEvaluationRepository = projectsEvaluationRepository;
    }

    public string SaveProjectEvaluation(ProjectEvaluation project)
    {
        try
        {
            _projectsEvaluationRepository.Save(project);
            return "Proyecto calificado con exito";
        }
        catch (Exception e)
        {
            throw new ProjectEvaluationException(
                $"Ha ocurrido un error al calificar el proyecto {e.Message}");
        }
    }

    public ProjectEvaluation? SearchProjectEvaluation(string code)
    {
        return _projectsEvaluationRepository.Find(project =>
            project.Code == code);
    }

    public string DeleteProjectEvaluation(string code)
    {
        try
        {
            var foundProjectEvaluation = SearchProjectEvaluation(code);
            if (foundProjectEvaluation == null)
                throw new ProjectEvaluationException(
                    "No existe calificacion de este proyecto");
            _projectsEvaluationRepository.Delete(foundProjectEvaluation);
            return "Calificacion eliminada";
        }
        catch (Exception e)
        {
            throw new ProjectEvaluationException(
                $"Ha ocurrido un error al eliminar la calificacion {e.Message}");
        }
    }
}
