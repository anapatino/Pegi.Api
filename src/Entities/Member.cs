using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("members")]
public class Member
{
    [Key] [Column("member_document")] public string Document { get; set; }

    [Column("member_identification_type")]
    public string IdentificationType { get; set; }

    [Column("member_name")] public string Name { get; set; }
    public string ProgramCode { get; set; }

    [ForeignKey("ProgramCode")] public AcademicProgram AcademicProgram { get; set; }

    [Column("member_credit_number")] public string CreditNumber { get; set; }

    [Column("member_phone")] public string Phone { get; set; }

    [Column("member_email")] public string Mail { get; set; }
}
