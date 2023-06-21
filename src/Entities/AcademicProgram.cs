using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("academics_program")]
public class AcademicProgram
{
    [Key]
    [Column("code_program")]
    public string? Code { get; set; }

    [Column("name")]
    public string? Name { get; set; }
}
