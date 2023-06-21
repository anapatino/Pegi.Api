using Entities;
using Entities.Exceptions;

namespace Services;

public class HistoryProposalService
{
    private readonly HistoryProposalsRepository _historyProposalsRepository;


    public HistoryProposalService(
        HistoryProposalsRepository historyProposalsRepository)
    {
        _historyProposalsRepository = historyProposalsRepository;
    }

    public (string, bool) SaveProposalHistory(HistoryProposals historyProposals)
    {
        try
        {
            _historyProposalsRepository.Save(historyProposals);
            return ("se ha guardado con exito", true);
        }
        catch (HistoryProposalExeption e)
        {
            return (e.Message, false);
        }
    }

    public List<HistoryProposals> SearchHistoryProposal(string codeProposal)
    {
        return _historyProposalsRepository.Filter(HistoryProposal =>
            HistoryProposal.ProposalCode == codeProposal);
    }
}
