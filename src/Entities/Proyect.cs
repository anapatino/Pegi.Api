using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("proyects")]
public class Proyect
{
    [Key] [Column("code")] public string? Code { get; set; }
    public string? PersonDocument { get; set; }
    [ForeignKey("PersonDocument")] public Student? Student { get; set; }

    public string? ProfessorDocument { get; set; }
    [ForeignKey("ProfessorDocument")]
    public Professor? Professor { get; set; }

    [Column("Content")] public string? Content { get; set; }
    [Column("Status")] public string? Status { get; set; }
    [Column("Score")] public int? Score { get; set; }

    public string? ProposalCode { get; set; }
    [ForeignKey("ProposalCode")]
    public Proposal? Proposal { get; set; }
}
