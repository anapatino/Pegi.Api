using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("lines")]
public class LineInvestigation
{
    [Key] [Column("lines_code")] public int Code { get; set; }

    [Column("lines_name")] public string Name { get; set; }

    public ICollection<InvestigationSubLine> SublinesInvestigation { get; set; }
}
