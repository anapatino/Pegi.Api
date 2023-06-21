namespace Api.Controllers.HistorialProposal;

public record ProposalFeedBackRequest(string? Comment,
    string? Status, DateTime? Date,string? ProposalCode);
