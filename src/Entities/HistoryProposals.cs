using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;
[Table("history_proposals")]
public class HistoryProposals
{
    public HistoryProposals(int? porposalFeedBackCode, string? proposalCode)
    {
        PorposalFeedBackCode = porposalFeedBackCode;
        ProposalCode = proposalCode;
    }

    [Key]
    [Column("code")]
    public int? Code { get; set; }

    public int? PorposalFeedBackCode { get; set; }
    [ForeignKey("PorposalFeedBackCode")]
    public ProposalFeedBack? ProposalFeedBack { get; set; }

    public string? ProposalCode { get; set; }
    [ForeignKey("ProposalCode")]
    public Proposal? Proposal { get; set; }

}
