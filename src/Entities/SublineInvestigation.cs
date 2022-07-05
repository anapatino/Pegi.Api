using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("sublines")]
public class SublineInvestigation
{
    [Key] [Column("sublines_code")] public string Code { get; set; }

    [Column("sublines_name")] public string Name { get; set; }

    public ICollection<ThematicArea> ThematicAreas { get; set; }
}
