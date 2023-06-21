using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;
[Table("research_sublines")]
public class ResearchSubline
{
    [Key] [Column("code")] public string? Code { get; set; }
    [Column("name")] public string? Name { get; set; }

    public string? ResearchLineCode { get; set; }
    [ForeignKey("ResearchLineCode")]
    public ResearchLine? ResearchLine { get; set; }
}
