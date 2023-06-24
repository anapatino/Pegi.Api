using Data.Repository;
using Entities;
using Entities.Exceptions;

namespace Services;

public class ProjectService
{
    private readonly ProjectRepository _projectRepository;
    private readonly ProposalService _proposalService;

    public ProjectService(ProjectRepository ProjectRepository,ProposalService proposalService)
    {
        _projectRepository = ProjectRepository;
        _proposalService = proposalService;
    }

    public (string, bool) SaveProject(Project project)
    {
        try
        {
            var proposal =
                _proposalService.GetProposalCode(project.ProposalCode);
            project.PersonDocument1 = proposal.PersonDocument1;
            project.PersonDocument2 = proposal.PersonDocument2;
            _projectRepository.Save(project);
            return ("se ha guardado con exito", true);
        }
        catch (ProposalExeption e)
        {
            return (e.Message, false);
        }
    }

    public (string, bool?) UpdateProject(Project project)
    {
        try
        {
            _projectRepository.Update(project);
            return ("se actualizo con exito el Projecto", true);
        }
        catch (AuthException e)
        {
            return ("error", false);
        }
    }

    public (string,bool?) UpdateStatusProject(string code,string status,int? score)
    {
        try
        {
            Project? project = _projectRepository.Find(project => project.Code == code);
            project!.Status = status;
            project!.Score = score;
            _projectRepository.Update(project);
            return ("se modifico con exito",true);
        }
        catch(AuthException e)
        {
            return ("error",false);
        }
    }

    public (string,bool?) UpdateEvaluatorDocumentProject(string code,string document)
    {
        try
        {
            Project? project = _projectRepository.Find(project => project.Code == code);
            project!.EvaluatorDocument = document;
            _projectRepository.Update(project);
            return ("se asigno con exito al docente en el Projecto",true);
        }
        catch(AuthException e)
        {
            return ("error al asignar docente al Projecto",false);
        }
    }

    public (string,bool?) UpdateTutorDocumentProject(string code,string document)
    {
        try
        {
            Project? project = _projectRepository.Find(project => project.Code == code);
            project!.TutorDocument = document;
            _projectRepository.Update(project);
            return ("se asigno con exito al tutor en el Projecto",true);
        }
        catch(AuthException e)
        {
            return ("error al asignar tutor al Projecto",false);
        }
    }


    public List<Project> GetProjects(string personDocument)
    {
        return _projectRepository.Filter(project =>
            (project.PersonDocument1 == personDocument ||
             project.PersonDocument2 == personDocument) && (project.PersonDocument1 != null  ||
                project.PersonDocument2 != null));
    }

    public List<Project> GetProjectsProfessorDocument(string personDocument)
    {
        return _projectRepository.Filter(project =>
            (project.EvaluatorDocument == personDocument ||
             project.TutorDocument == personDocument) && (project.EvaluatorDocument != null  ||
                project.TutorDocument != null));
    }

    public Project? SearchProject(string personDocument)
    {
        return _projectRepository.Find(project =>
            (project.PersonDocument1 == personDocument ||
             project.PersonDocument2 == personDocument) && (project.PersonDocument1 != null  ||
                project.PersonDocument2 != null));
    }

    public string DeleteProject(string code)
    {
        try
        {
            Project? project =
                _projectRepository.Find(project => project.Code == code);
            _projectRepository.Delete(project!);
            return "se borro con exito";
        }
        catch (Exception e)
        {
            throw new PersonExeption(
                $"Ha ocurrido un error al eliminar {e.Message}");
        }
    }

    public List<Project> GetAll()
    {
        return _projectRepository.GetAll();
    }


    public Project? GetProjectCode(string code)
    {
        return _projectRepository.Find(project => project.Code == code);
    }

    public object filterListProposal(List<Project> projects)
    {
        int pendiente = 0, aprobado = 0, corregir = 0, rechazado = 0,total = 0;
        foreach (Project p  in projects)
        {
            if (p.Status == "Aprobado")
            {
                aprobado++;
            }
            if (p.Status == "Pendiente")
            {
                pendiente++;
            }
            if (p.Status == "Corregir")
            {
                corregir++;
            }
            if (p.Status == "Rechazado")
            {
                rechazado++;
            }

            total++;
        }
        var statistics = new
        {
            Pendiente = pendiente,
            Rechazado = rechazado,
            Aprobado = aprobado,
            Corregir = corregir,
            Total = total
        };
        return statistics;
    }
    public object GeneralStatisticsProjectProfessor(string personDocument)
    {
        List<Project> Projects = _projectRepository.Filter(project =>
            (project.EvaluatorDocument == personDocument ||
             project.TutorDocument == personDocument) && (project.EvaluatorDocument != null  ||
                project.TutorDocument != null));
        return filterListProposal(Projects);
    }

    public object GeneralStatisticsProjectStudent(string personDocument)
    {
        List<Project> project = _projectRepository.Filter(project =>
            (project.PersonDocument1 == personDocument ||
             project.PersonDocument2 == personDocument) && (project.PersonDocument1 != null  ||
                project.PersonDocument2 != null));
        return filterListProposal(project);
    }

    public object GeneralStatisticsProjects()
    {
        List<Project> project = _projectRepository.GetAll();
        return filterListProposal(project);
    }


}
