using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("thematic-areas")]
public class ThematicArea
{
    [Key] [Column("thematic-areas_code")] public string Code { get; set; }

    [Column("thematic-areas_name")] public string Name { get; set; }
}
