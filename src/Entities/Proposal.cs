using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("proposals")]
public class Proposal
{
    [Key] [Column("proposals_code")] public string Code { get; set; }

    [Column("proposals_title")] public string Title { get; set; }

    [Column("proposals_date")] public DateTime Date { get; set; }

    [Column("proposals_research_group")]
    public string ResearchGroup { get; set; }

    [Column("proposals_approach_problem")]
    public string ApproachProblem { get; set; }

    [Column("proposals_formulation_problem")]
    public string FormulationProblem { get; set; }

    [Column("proposals_justification_problem")]
    public string JustificationProblem { get; set; }

    [Column("proposals_general_objective")]
    public string GeneralObjective { get; set; }

    [Column("proposals_specific_objective")]
    public string SpecificObjective { get; set; }

    [Column("proposals_bibliography")] public string Bibliography { get; set; }

    [Column("proposals_evaluation_code")]
    public string CodeEvaluation { get; set; }

    [Column("proposals_evaluation_status")]
    public string Status { get; set; }

    [Column("proposals_evaluation_feedback")]
    public string Feedback { get; set; }

    public ICollection<Member> Members { get; set; }
}
