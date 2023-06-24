using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("projects")]
public class Project
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

    [Column("Content")] public string? Content { get; set; }
    [Column("Status")] public string? Status { get; set; }
    [Column("Score")] public int? Score { get; set; }

    public string? ProposalCode { get; set; }
    [ForeignKey("ProposalCode")]
    public Proposal? Proposal { get; set; }
}
