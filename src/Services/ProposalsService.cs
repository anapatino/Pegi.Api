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
            return "Registro realizado con exito";
        }
        catch (Exception e)
        {
            throw new ProposalException(
                $"Ha ocurrido un error al registrar {e.Message}");
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
                throw new StudentException("Studenta no encontrada");
            _proposalsRepository.Delete(foundProposal);
            return "Registro eliminado";
        }
        catch (Exception e)
        {
            throw new StudentException(
                $"Ha ocurrido un error al eliminar {e.Message}");
        }
    }
}
