namespace Api.Controllers.Projects;

public record CreateProjectRequest
(
    string Code,
    string Title,
    string Content
);
