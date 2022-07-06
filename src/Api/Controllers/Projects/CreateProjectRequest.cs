namespace Api.Controllers.Projects;

public record CreateProjectRequest
(
    string Code,
    string Title,
    string Content,
    string Status,
    string Feedback,
    string Qualification,
    string Proposal
);
