using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities;

[Table("research_group")]
public class ResearchGroup
{
    [Key]
    [Column("code")]
    public string Code { get; set; }

    [Column("name")]
    public string Name { get; set;  }

    [Column("teachers_andscribed")]
    public string TeachersAndscribed { get; set; }

    [Column("objetive")]
    public string Objetive { get; set; }

    public string? ResearchLineCode { get; set; }
    [ForeignKey("ResearchLineCode")]
    public ResearchLine? ResearchLine { get; set; }
}
