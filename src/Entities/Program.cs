using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("program")]
public class Program
{
    [Key] [Column("program_code")] public string Code { get; set; }

    [Column("program_name")] public string Name { get; set; }
}
