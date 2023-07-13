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
            return ("Se ha guardado con exito la propuesta", true);
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
            return ("Se actualizo con exito la propuesta", true);
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
            return ("Se modifico con exito la propuesta",true);
        }
        catch(AuthException e)
        {
            return ("error",false);
        }
    }

    public (string,bool?) UpdateEvaluatorDocumentProposal(string code,string document)
    {
        try
        {
            Proposal? proposal = _proposalRepository.Find(proposal => proposal.Code == code);
            proposal!.EvaluatorDocument = document;
            _proposalRepository.Update(proposal);
            return ("Se asigno con exito al evaluador en la propuesta",true);
        }
        catch(AuthException e)
        {
            return ("error: "+e.Message,false);
        }
    }

    public (string,bool?) UpdateTutorDocumentProposal(string code,string document)
    {
        try
        {
            Proposal? proposal = _proposalRepository.Find(proposal => proposal.Code == code);
            proposal!.TutorDocument = document;
            _proposalRepository.Update(proposal);
            return ("Se asigno con exito al tutor en la propuesta",true);
        }
        catch(AuthException e)
        {
            return ("error: "+e.Message,false);
        }
    }

    public List<Proposal> GetProposalsDocument(string personDocument)
         {
             return _proposalRepository.Filter(proposal =>
                 proposal.PersonDocument1 == personDocument ||
                 proposal.PersonDocument2 == personDocument);
         }

    public List<Proposal> GetProposalsByTitle(string keyword)
    {
        return _proposalRepository.Filter(proposal =>
            proposal.Title.Contains(keyword));
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
            (proposal.EvaluatorDocument == personDocument ||
             proposal.TutorDocument == personDocument) && (proposal.EvaluatorDocument != null ||
                proposal.TutorDocument != null) );
        return filterListProposal(proposals);
    }

   public object GeneralStatisticsProposalStudent(string personDocument)
   {
       List<Proposal> proposals = _proposalRepository.Filter(proposal =>
           (proposal.PersonDocument1 == personDocument ||
           proposal.PersonDocument2 == personDocument) && (proposal.PersonDocument1 != null ||
               proposal.PersonDocument2 != null) );
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
            (proposal.EvaluatorDocument == personDocument ||
             proposal.TutorDocument == personDocument) && (proposal.EvaluatorDocument != null ||
                proposal.TutorDocument != null) );
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
            return "Se ha eliminado con exito la propuesta";
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
