using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("porposal_feedback")]
public class ProposalFeedBack
{
    [Key] [Column("code")] public int? Code { get; set; }

    [Column("comment")] public string? Comment { get; set; }

    [Column("status")] public string? Status { get; set; }

    [Column("date")] public DateTime? Date { get; set; }
}
