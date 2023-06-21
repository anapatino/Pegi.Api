using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table(("research_lines"))]
public class ResearchLine
{
    [Key] [Column("code")] public string? Code { get; set; }
    [Column("name")] public string? Name { get; set; }
}
