using Api.Controllers.Proposals;

namespace Api.Controllers.Projects;

public record ProjectResponse
(
    int Code,
    string Content,
    string Status,
    string Feedback,
    string Qualification,
    ProposalResponse Proposal
);
