using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("thematic_areas")]
public class ThematicArea
{
    [Key] [Column("code")] public string? Code { get; set; }
    [Column("name")] public string? Name { get; set; }
    public string? ResearchSublineCode { get; set; }
    [ForeignKey("ResearchSublineCode")]
    public ResearchSubline? ResearchSubline { get; set; }
}
