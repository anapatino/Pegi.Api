using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("experiences")]
public class Experience : Study
{
    [Column("experience_position")] public string position { get; set; }
}
