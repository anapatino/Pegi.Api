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

    public Project? SearchProject(string title)
    {
        return _projectsRepository.Find(project =>
            project.Title == title);
    }

    public List<Project?> AllProject()
    {
        return (List<Project?>)_projectsRepository.GetAll();
    }

    public List<Project?> FilterProjectsStatus(string status)
    {
        return (List<Project?>)_projectsRepository.Filter(project =>
            project.Status == status);
    }

    public string DeleteProject(string title)
    {
        try
        {
            var foundProject = SearchProject(title);
            if (foundProject == null)
                throw new ProjectException("Proyecto no encontrado");
            _projectsRepository.Delete(foundProject);
            return "Proyecto eliminado";
        }
        catch (Exception e)
        {
            throw new ProjectException(
                $"Ha ocurrido un error al eliminar el proyecto {e.Message}");
        }
    }
}
