using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("projects")]
public class Project
{
    [Key] [Column("projects_code")] public string Code { get; set; }

    [Column("projects_title")] public string Title { get; set; }

    [Column("projects_content")] public string Content { get; set; }

    [Column("projects_status")] public string Status { get; set; }

    [Column("projects_feedback")] public string Feedback { get; set; }

    [Column("projects_qualification")] public string Qualification { get; set; }

    public string ProposalCode { get; set; }

    [ForeignKey("ProposalCode")] public Proposal Proposal { get; set; }
}
