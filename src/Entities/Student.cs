using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Entities;

[Table("students")]
public class Student
{
    [Key] public string? Document { get; set; }
    [ForeignKey("Document")] public Person? Person { get; set; }

    [Column("amount_credits")]
    public string? AmountCredits { get; set; }

    public string? AcademicProgramCode { get; set; }
    [ForeignKey("AcademicProgramCode")]
    public AcademicProgram? AcademicProgram { get; set; }
}
