using Data.Repositories;
using Entities;
using Entities.Exceptions;

namespace Services;

public class ProposalsEvaluationService
{
    private readonly ProposalsEvaluationRepository
        _proposalsEvaluationRepository;

    public ProposalsEvaluationService(
        ProposalsEvaluationRepository proposalsEvaluationRepository)
    {
        _proposalsEvaluationRepository = proposalsEvaluationRepository;
    }

    public string SaveProposalEvaluation(ProposalEvaluation proposal)
    {
        try
        {
            _proposalsEvaluationRepository.Save(proposal);
            return "Propuesta calificada con exito";
        }
        catch (Exception e)
        {
            throw new ProposalEvaluationException(
                $"Ha ocurrido un error al registrar la calificacion{e.Message}");
        }
    }

    public ProposalEvaluation? SearchProposalEvaluation(string code)
    {
        return _proposalsEvaluationRepository.Find(proposal =>
            proposal.Code == code);
    }

    public string DeleteProposalEvaluation(string code)
    {
        try
        {
            var foundProposalEvaluation = SearchProposalEvaluation(code);
            if (foundProposalEvaluation == null)
                throw new ProposalEvaluationException(
                    "No existe calificacion de esta propuesta ");
            _proposalsEvaluationRepository.Delete(foundProposalEvaluation);
            return "Calificacion eliminada";
        }
        catch (Exception e)
        {
            throw new ProposalEvaluationException(
                $"Ha ocurrido un error al eliminar la calificacion{e.Message}");
        }
    }
}
