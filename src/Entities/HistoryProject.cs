using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;
[Table("history_projects")]
public class HistoryProject
{
    public HistoryProject(int? projectFeedBackCode, string? projectCode)
    {
        ProjectFeedBackCode = projectFeedBackCode;
        ProjectCode = projectCode;
    }

    [Key]
    [Column("code")]
    public int? Code { get; set; }

    public int? ProjectFeedBackCode { get; set; }
    [ForeignKey("ProjectFeedBackCode")]
    public ProjectFeedBack? ProjectFeedBack { get; set; }

    public string? ProjectCode { get; set; }
    [ForeignKey("ProjectCode")]
    public Project? Project { get; set; }
}
