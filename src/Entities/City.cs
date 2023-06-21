using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;
[Table("cities")]
public class City
{
    [Key]
    [Column("city_id")]
    public string Id { get; set; }

    [Column("city_name")]
    public string Name { get; set;  }

    public string DepartmentCode { get; set; }
    [ForeignKey("DepartmentCode")]
    public Department? Department { get; set; }
}
