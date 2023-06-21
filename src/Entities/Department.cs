using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;
[Table("departments")]
public class Department
{
    [Key]
    [Column("department_id")]
    public string Id { get; set; }

    [Column("deparment_name")]
    public string Name { get; set; }



}
