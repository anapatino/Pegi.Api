using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("projects")]
public class Project
{
    [Column("project_code")] public string Code { get; set; }

    [Column("project_title")] public string Title { get; set; }

    [Column("project_content")] public string Content { get; set; }
}
