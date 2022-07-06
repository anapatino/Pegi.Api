using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("proposal_evaluation")]
public class ProposalEvaluation
{
    [Key]
    [Column("proposal_evaluation_code")]
    public string Code { get; set; }

    [Column("proposal_evaluation_status")] public string Status { get; set; }

    [Column("proposal_evaluation_feedback")]
    public string Feedback { get; set; }
}
