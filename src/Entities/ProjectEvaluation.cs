using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("project_evaluation")]
public class ProjectEvaluation : ProposalEvaluation
{
    [Column("project_evaluation_qualification")]
    public string Qualification { get; set; }
}
