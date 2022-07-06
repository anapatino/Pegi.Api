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

    public Proposal? SearchProposal(string code)
    {
        return _proposalsRepository.Find(proposal =>
            proposal.Code == code);
    }

    public string DeleteProposal(string code)
    {
        try
        {
            var foundProposal = SearchProposal(code);
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
