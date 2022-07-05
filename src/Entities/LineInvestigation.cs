using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("lines")]
public class LineInvestigation
{
    [Key] [Column("lines_code")] public string Code { get; set; }

    [Column("lines_name")] public string Name { get; set; }

    public ICollection<SublineInvestigation> SublinesInvestigation { get; set; }
}
