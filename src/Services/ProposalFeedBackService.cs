using Data.Repository;
using Entities;
using Entities.Exceptions;

namespace Services;

public class ProposalFeedBackService
{
    private readonly ProposalFeedBackRepository _proposalFeedBackRepository;

    public ProposalFeedBackService(ProposalFeedBackRepository proposalFeedBackRepository)
    {
        _proposalFeedBackRepository = proposalFeedBackRepository;
    }

    public (string, bool) SaveProposalFeedBack(ProposalFeedBack proposalFeedBack)
    {
        try
        {
            _proposalFeedBackRepository.Save(proposalFeedBack);
            return ("se ha guardado con exito", true);
        }
        catch (ProposalFeedBackExeption e)
        {
            return (e.Message, false);
        }
    }

    public ProposalFeedBack? GetProposalFeedBackCode(int? code)
    {
        return _proposalFeedBackRepository.Find(ProposalFeedBack => ProposalFeedBack.Code == code);
    }

}
