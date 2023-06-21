using Data.Repository;
using Entities;
using Entities.Exceptions;

namespace Services;

public class ProyectService
{
    private readonly ProyectRepository _proyectRepository;

    public ProyectService(ProyectRepository proyectRepository)
    {
        _proyectRepository = proyectRepository;
    }

    public (string, bool) SaveProyect(Proyect proyect)
    {
        try
        {
            _proyectRepository.Save(proyect);
            return ("se ha guardado con exito", true);
        }
        catch (ProposalExeption e)
        {
            return (e.Message, false);
        }
    }

    public (string, bool?) UpdateProyect(Proyect proyect)
    {
        try
        {
            _proyectRepository.Update(proyect);
            return ("se actualizo con exito", true);
        }
        catch (AuthException e)
        {
            return ("error", false);
        }
    }

    public (string,bool?) UpdateStatusProyect(string code,string status,int? score)
    {
        try
        {
            Proyect? proyect = _proyectRepository.Find(proyect => proyect.Code == code);
            proyect!.Status = status;
            proyect!.Score = score;
            _proyectRepository.Update(proyect);
            return ("se modifico con exito",true);
        }
        catch(AuthException e)
        {
            return ("error",false);
        }
    }

    public (string,bool?) UpdateProfessorDocumentProyect(string code,string document)
    {
        try
        {
            Proyect? proyect = _proyectRepository.Find(proyect => proyect.Code == code);
            proyect!.ProfessorDocument = document;
            _proyectRepository.Update(proyect);
            return ("se asigno con exito al docente en el proyecto",true);
        }
        catch(AuthException e)
        {
            return ("error al asignar docente al proyecto",false);
        }
    }


    public List<Proyect> GetProyects(string personDocument)
    {
        return _proyectRepository.Filter(proyect =>
            proyect.PersonDocument != null &&
            proyect.PersonDocument == personDocument);
    }

    public List<Proyect> GetProyectsProfessorDocument(string personDocument)
    {
        return _proyectRepository.Filter(proyect =>
            proyect.ProfessorDocument != null &&
            proyect.ProfessorDocument == personDocument);
    }

    public Proyect? SearchProyect(string personDocument)
    {
        return _proyectRepository.Find(proyect =>
            proyect.PersonDocument == personDocument);
    }

    public string DeleteProyect(string code)
    {
        try
        {
            Proyect? proyect =
                _proyectRepository.Find(proyect => proyect.Code == code);
            _proyectRepository.Delete(proyect!);
            return "se borro con exito";
        }
        catch (Exception e)
        {
            throw new PersonExeption(
                $"Ha ocurrido un error al eliminar {e.Message}");
        }
    }

    public List<Proyect> GetAll()
    {
        return _proyectRepository.GetAll();
    }


    public Proyect? GetProyectCode(string code)
    {
        return _proyectRepository.Find(proyect => proyect.Code == code);
    }

    public object filterListProposal(List<Proyect> proyect)
    {
        int pendiente = 0, aprobado = 0, corregir = 0, rechazado = 0,total = 0;
        foreach (Proyect p in proyect)
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
    public object GeneralStatisticsProyectProfessor(string personDocument)
    {
        List<Proyect> proyects = _proyectRepository.Filter(proyect =>
            proyect.ProfessorDocument != null &&
            proyect.ProfessorDocument == personDocument);
        return filterListProposal(proyects);
    }

    public object GeneralStatisticsProyectStudent(string personDocument)
    {
        List<Proyect> proyects = _proyectRepository.Filter(proyect =>
            proyect.PersonDocument != null &&
            proyect.PersonDocument == personDocument);
        return filterListProposal(proyects);
    }

    public object GeneralStatisticsProyects()
    {
        List<Proyect> proyects = _proyectRepository.GetAll();
        return filterListProposal(proyects);
    }


}
