using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("academic_program")]
public class AcademicProgram
{
    [Key]
    [Column("academic_program_code")]
    public string Code { get; set; }

    [Column("academic_program_name")] public string Name { get; set; }
}
