using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("projects")]
public class Project
{
    [Column("project_code")]
    [Key]
    public int Code { get; set; }

    [Column("project_content")]
    public string Content { get; set; }

    [Column("project_status")]
    public string Status { get; set; }

    [Column("project_feedback")]
    public string Feedback { get; set; }

    [Column("project_qualification")]
    public string Qualification { get; set; }

    public int ProposalCode { get; set; }

    [ForeignKey("ProposalCode")]
    public Proposal Proposal { get; set; }
}
