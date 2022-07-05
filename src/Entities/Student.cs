using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("student")]
public class Student : Person
{
    [Column("student_program_code")] public string ProgramCode { get; set; }

    [Column("student_credit_number")] public string CreditNumber { get; set; }
}
