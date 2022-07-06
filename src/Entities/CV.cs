using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("cv")]
public class CV
{
    [Column("cv_attach_files")] public string AttachFiles { get; set; }
}
