namespace Api.Controllers.Projects;

public record CreateProjectRequest
(
    string Content,
    string Status,
    string Feedback,
    string Qualification,
    int ProposalCode
);
