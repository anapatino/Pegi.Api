using Entities;

namespace Api.Controllers.Projects;

public record ProjectResponse
(
    string Code,
    string Title,
    string Content,
    ICollection<Student> Students
);
