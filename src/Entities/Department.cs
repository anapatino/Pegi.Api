using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("departments")]
public class Department
{
    [Key, Column("department_code")]
    public string Code { get; set; }
    [Column("department_name")]
    public string Name { get; set; }
}
