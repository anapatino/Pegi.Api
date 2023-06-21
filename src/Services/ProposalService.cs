using Data.Repository;
using Entities;
using Entities.Exceptions;

namespace Services;

public class ProposalService
{
    private readonly ProposalRepository _proposalRepository;

    public ProposalService(ProposalRepository proposalRepository)
    {
        _proposalRepository = proposalRepository;
    }

    public (string, bool) SaveProposal(Proposal proposal)
    {
        try
        {
            _proposalRepository.Save(proposal);
            return ("se ha guardado con exito", true);
        }
        catch (ProposalExeption e)
        {
            return (e.Message, false);
        }
    }

    public (string, bool?) UpdateProposal(Proposal proposal)
    {
        try
        {
            _proposalRepository.Update(proposal);
            return ("se actualizo con exito", true);
        }
        catch (AuthException e)
        {
            return ("error", false);
        }
    }

    public (string,bool?) UpdateStatusProposal(string code,string status)
    {
        try
        {
            Proposal? proposal = _proposalRepository.Find(proposal => proposal.Code == code);
            proposal!.Status = status;
            _proposalRepository.Update(proposal);
            return ("se modifico con exito",true);
        }
        catch(AuthException e)
        {
            return ("error",false);
        }
    }

    public (string,bool?) UpdateProfessorDocumentProposal(string code,string document)
    {
        try
        {
            Proposal? proposal = _proposalRepository.Find(proposal => proposal.Code == code);
            proposal!.ProfessorDocument = document;
            _proposalRepository.Update(proposal);
            return ("se asigno con exito al docente en la propuesta",true);
        }
        catch(AuthException e)
        {
            return ("error al asignar docente en la propuesta",false);
        }
    }

    public List<Proposal> GetProposalsDocument(string personDocument)
    {
        return _proposalRepository.Filter(proposal =>
            proposal.PersonDocument != null &&
            proposal.PersonDocument == personDocument);
    }


    public object filterListProposal(List<Proposal> proposals)
    {
        int pendiente = 0, aprobado = 0, corregir = 0, rechazado = 0,total = 0;

        foreach (Proposal p in proposals)
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
   public object GeneralStatisticsProposalProfessor(string personDocument)
    {
        List<Proposal> proposals = _proposalRepository.Filter(proposal =>
            proposal.ProfessorDocument != null &&
            proposal.ProfessorDocument == personDocument);
        return filterListProposal(proposals);
    }

   public object GeneralStatisticsProposalStudent(string personDocument)
   {
       List<Proposal> proposals = _proposalRepository.Filter(proposal =>
           proposal.PersonDocument != null &&
           proposal.PersonDocument == personDocument);
       return filterListProposal(proposals);
   }

    public object GeneralStatisticsProposals()
    {
        List<Proposal> proposals = _proposalRepository.GetAll();
        return  filterListProposal(proposals);
    }

    public List<Proposal> GetProposalsProfessorDocument(string personDocument)
    {
        return _proposalRepository.Filter(proposal =>
            proposal.ProfessorDocument != null &&
            proposal.ProfessorDocument == personDocument);
    }


    public List<Proposal> GetAll()
    {
        return _proposalRepository.GetAll();
    }

    public string DeleteProposal(string code)
    {
        try
        {
            Proposal? proposal =
                _proposalRepository.Find(proposal => proposal.Code == code);
            _proposalRepository.Delete(proposal!);
            return "se borro con exito";
        }
        catch (Exception e)
        {
            throw new PersonExeption(
                $"Ha ocurrido un error al eliminar {e.Message}");
        }
    }

    public Proposal? GetProposalCode(string code)
    {
        return _proposalRepository.Find(proposal => proposal.Code == code);
    }
}
