using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table(("proposals"))]
public class Proposal
{
    [Key] [Column("code")] public string? Code { get; set; }
    public string? PersonDocument1 { get; set; }
    [ForeignKey("PersonDocument1")]
    public Student? Student1 { get; set; }
    public string? PersonDocument2 { get; set; }
    [ForeignKey("PersonDocument2")]
    public Student? Student2 { get; set; }
    public string? EvaluatorDocument { get; set; }
    [ForeignKey("EvaluatorDocument")]
    public Professor? Professor1 { get; set; }
    public string? TutorDocument { get; set; }
    [ForeignKey("TutorDocument")]
    public Professor? Professor2 { get; set; }
    [Column("title")] public string? Title { get; set; }
    [Column("date")] public DateTime? Date { get; set; }
    public string? InvestigationGroup { get; set; }
    [ForeignKey("InvestigationGroup")]
    public ResearchGroup? ResearchGroup { get; set; }
    [Column("approach")] public string? Approach { get; set; }
    [Column("justification")] public string? Justification { get; set; }
    [Column("generalObjective")] public string? GeneralObjective { get; set; }
    [Column("specificObjective")] public string? SpecificObjective { get; set; }
    [Column("biblioGraphical")] public string? Bibliographical { get; set; }
    [Column("status")]public string? Status { get; set; }
    public string? ThematicAreaCode { get; set; }
    [ForeignKey("ThematicAreaCode")]
    public ThematicArea? ThematicArea { get; set; }
}
