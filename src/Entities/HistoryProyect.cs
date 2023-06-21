using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class HistoryProyect
{
    public HistoryProyect(int? proyectFeedBackCode, string? proyectCode)
    {
        ProyectFeedBackCode = proyectFeedBackCode;
        ProyectCode = proyectCode;
    }

    [Key]
    [Column("code")]
    public int? Code { get; set; }

    public int? ProyectFeedBackCode { get; set; }
    [ForeignKey("ProyectFeedBackCode")]
    public ProyectFeedBack? ProyectFeedBack { get; set; }

    public string? ProyectCode { get; set; }
    [ForeignKey("ProyectCode")]
    public Proyect? Proyect { get; set; }
}
