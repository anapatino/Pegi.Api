using Data.Repositories;
using Entities;
using Entities.Exceptions;

namespace Services;

public class ProposalsService
{
    private readonly ProposalsRepository _proposalsRepository;

    public ProposalsService(ProposalsRepository proposalsRepository)
    {
        _proposalsRepository = proposalsRepository;
    }

    public string SaveProposal(Proposal proposal)
    {
        try
        {
            _proposalsRepository.Save(proposal);
            return "Propuesta registrada  con exito";
        }
        catch (Exception e)
        {
            throw new ProposalException(
                $"Ha ocurrido un error al registrar la propuesta {e.Message}");
        }
    }

    public Proposal? SearchProposal(string title)
    {
        return _proposalsRepository.Find(proposal =>
            proposal.Title == title);
    }

    public List<Proposal> GetAllProposals()
    {
        return _proposalsRepository.GetAll();
    }

    public List<Proposal> FilterProposalStatus(string status)
    {
        return _proposalsRepository.Filter(proposal =>
            proposal.Status == status);
    }

    public string DeleteProposal(string title)
    {
        try
        {
            Proposal? foundProposal = SearchProposal(title);
            if (foundProposal == null)
                throw new ProposalException("Propuesta no encontrada");
            _proposalsRepository.Delete(foundProposal);
            return "Propuesta eliminada";
        }
        catch (Exception e)
        {
            throw new ProposalException(
                $"Ha ocurrido un error al eliminar la propuesta {e.Message}");
        }
    }
}
