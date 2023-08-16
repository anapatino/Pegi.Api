using Data.Repository;
using Entities;
using Entities.Exceptions;

namespace Services;

public class ProjectService
{
    private readonly ProjectRepository _projectRepository;
    private readonly ProposalService _proposalService;

    public ProjectService(ProjectRepository projectRepository,ProposalService proposalService)
    {
        _projectRepository = projectRepository;
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
            return ("Se ha guardado con exito el proyecto", true);
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
            return ("se actualizó con exito el proyecto", true);
        }
        catch (AuthException e)
        {
            return ("error: "+e.Message, false);
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
            return ("Se modificó el estado del proyecto con exito",true);
        }
        catch(AuthException e)
        {
            return ("error: "+e.Message,false);
        }
    }

    public (string,bool?) UpdateEvaluatorDocumentProject(string code,string document)
    {
        try
        {
            Project? project = _projectRepository.Find(project => project.Code == code);
            project!.EvaluatorDocument = document;
            _projectRepository.Update(project);
            return ("Se asigno con exito al evaluador en el proyecto",true);
        }
        catch(AuthException e)
        {
            return ("error: "+e.Message,false);
        }
    }

    public (string,bool?) UpdateTutorDocumentProject(string code,string document)
    {
        try
        {
            Project? project = _projectRepository.Find(project => project.Code == code);
            project!.TutorDocument = document;
            _projectRepository.Update(project);
            return ("se asigno con exito al tutor en el proyecto",true);
        }
        catch(AuthException e)
        {
            return ("error: "+e.Message,false);
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

    public Project? SearchProject(string proprosalCode)
    {
        return _projectRepository.Find(project =>
            (project.ProposalCode == proprosalCode && project.ProposalCode != null));
    }

    public string DeleteProject(string code)
    {
        try
        {
            Project? project =
                _projectRepository.Find(project => project.Code == code);
            _projectRepository.Delete(project!);
            return "Se ha eliminado con exito el proyecto";
        }
        catch (AuthException e)
        {
            return ("error: " +e.Message);
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

    public List<Project> GetProjectsByProposalCode(string code)
    {
        return _projectRepository.Filter(project => project.ProposalCode == code);
    }

    public object filterListProject(List<Project> project)
    {
        int pendiente = 0, aprobado = 0, corregir = 0, rechazado = 0,total = 0;
        foreach (Project p in project)
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
        List<Project> projects = _projectRepository.Filter(project =>
            (project.EvaluatorDocument == personDocument ||
             project.TutorDocument == personDocument) && (project.EvaluatorDocument != null  ||
                project.TutorDocument != null));
        return filterListProject(projects);
    }

    public object GeneralStatisticsProjectStudent(string personDocument)
    {
        List<Project> projects = _projectRepository.Filter(project =>
            (project.PersonDocument1 == personDocument ||
             project.PersonDocument2 == personDocument) && (project.PersonDocument1 != null  ||
                project.PersonDocument2 != null));
        return filterListProject(projects);
    }

    public object GeneralStatisticsProjects()
    {
        List<Project> projects = _projectRepository.GetAll();
        return filterListProject(projects);
    }


}
