using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("teachers")]
public class Teacher:Person
{
    [Column ("teacher_position")]
    public string Position { get; set; }
}
