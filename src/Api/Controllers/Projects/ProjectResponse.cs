using Entities;

namespace Api.Controllers.Projects;

public record ProjectResponse
(
    string Code,
    string Title,
    string Content,
    string Status,
    string Feedback,
    string Qualification,
    Proposal Proposal
);
