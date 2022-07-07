using Entities;

namespace Api.Controllers.Projects;

public record ProjectResponse
(
    int Code,
    string Title,
    string Content,
    string Status,
    string Feedback,
    string Qualification,
    Proposal Proposal
);
