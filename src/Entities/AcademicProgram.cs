using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("academic_programs")]
public class AcademicProgram
{
    [Key]
    [Column("academic_program_code")]
    public int Code { get; set; }

    [Column("academic_program_name")] public string Name { get; set; }
}
