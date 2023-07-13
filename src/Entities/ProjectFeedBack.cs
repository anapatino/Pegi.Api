using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table(("project_feedbacks"))]
public class ProjectFeedBack
{
    [Key] [Column("code")] public int? Code { get; set; }

    [Column("comment")] public string? Comment { get; set; }

    [Column("status")] public string? Status { get; set; }

    [Column("Score")] public int? Score { get; set; }
}
