using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("thematic_areas")]
public class ThematicArea
{
    [Key]
    [Column("thematic_areas_code")]
    public int Code { get; set; }

    [Column("thematic_areas_name")]
    public string Name { get; set; }

    public int SubLineCode { get; set; }

    [ForeignKey("SubLineCode")]
    public InvestigationSubLine InvestigationSubLine { get; set; }
}
