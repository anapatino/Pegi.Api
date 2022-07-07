using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("sublines")]
public class InvestigationSubLine
{
    [Key] [Column("sublines_code")] public int Code { get; set; }

    [Column("sublines_name")] public string Name { get; set; }

    public int LineCode { get; set; }

    [ForeignKey("LineCode")]
    public LineInvestigation LineInvestigation { get; set; }

    public ICollection<ThematicArea> ThematicAreas { get; set; }
}
