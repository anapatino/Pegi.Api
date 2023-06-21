namespace Api.Controllers.HistorialProposal;

public record ProposalFeedBackResponse(int? Code, string? Comment,
    string? Status, DateTime? Date);
