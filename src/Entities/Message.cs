using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities;

[Table(("message"))]
public class Message
{
    [Key] [Column("code")] public string? Code { get; set; }
    [Column("personDocument")] public string? PersonDocument { get; set; }
    [Column("name")] public string? Name { get; set; }
    [Column("message")] public string? Content { get; set; }
    [Column("date")] public DateTime? Date { get; set; }
}
