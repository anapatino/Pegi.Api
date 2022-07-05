using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("countries")]
public class Country
{
    [Key]
    [Column("country_code")]
    public string Code { get; set; }

    [Column("country_name")]
    public string Name { get; set; }
}
