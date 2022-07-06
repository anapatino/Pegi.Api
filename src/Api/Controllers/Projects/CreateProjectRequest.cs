using Entities;

namespace Api.Controllers.Projects;

public record CreateProjectRequest
(
    string Code,
    string Title,
    string Content,
    ICollection<Student> Students
);
