using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("people")]
public class Person
{
    [Key] [Column("document")] public string? Document { get; set; }

    [Column("person_identification_type")]
    public string IdentificationType { get; set; }

    [Column("person_first_name")] public string? FirstName { get; set; }

    [Column("person_second_name")] public string? SecondName { get; set; }

    [Column("person_first_last_name")]
    public string? FirstLastName { get; set; }

    [Column("person_second_last_name")]
    public string? SecondLastName { get; set; }

    [Column("person_civil_state")] public string? CivilState { get; set; }

    [Column("person_gender")] public string? Gender { get; set; }

    [Column("person_birth_date")] public DateTime? BirthDate { get; set; }

    [Column("person_phone")] public string? Phone { get; set; }

    [Column("person_institutional_email")]
    public string? InstitutionalMail { get; set; }

    public string? CitiesCode { get; set; }
    [ForeignKey("CitiesCode")]
    public City? City { get; set; }
}
