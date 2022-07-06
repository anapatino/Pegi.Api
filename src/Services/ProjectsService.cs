using Data.Repositories;
using Entities;
using Entities.Exceptions;

namespace Services;

public class ProjectsService
{
    private readonly ProjectsRepository _projectsRepository;

    public ProjectsService(ProjectsRepository ProjectService)
    {
        _projectsRepository = ProjectService;
    }

    public string SaveProject(Project project)
    {
        try
        {
            _projectsRepository.Save(project);
            return "Proyecto registrado con exito";
        }
        catch (Exception e)
        {
            throw new ProjectException(
                $"Ha ocurrido un error al registrar el proyecto{e.Message}");
        }
    }

    public Project? SearchProject(string code)
    {
        return _projectsRepository.Find(project =>
            project.Code == code);
    }

    public string DeleteProject(string code)
    {
        try
        {
            var foundProject = SearchProject(code);
            if (foundProject == null)
                throw new StudentException("Proyecto no encontrado");
            _projectsRepository.Delete(foundProject);
            return "Proyecto eliminado";
        }
        catch (Exception e)
        {
            throw new StudentException(
                $"Ha ocurrido un error al eliminar el proyecto {e.Message}");
        }
    }
}
