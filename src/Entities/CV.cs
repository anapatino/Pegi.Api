using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("cv")]
public class CV
{
    [Key] [Column("cv_code")] public string Code { get; set; }

    [Column("cv_attach_files")] public string AttachFiles { get; set; }
}
