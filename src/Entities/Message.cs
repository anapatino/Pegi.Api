using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities;

[Table(("message"))]
public class Message
{
    [Key] [Column("code")] public string? Code { get; set; }
    [Column("title")] public string? Name { get; set; }
    [Column("message")] public string? Content { get; set; }
    [Column("date")] public DateTime? Date { get; set; }
}
