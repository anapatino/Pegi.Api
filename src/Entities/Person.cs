using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("people")]
public class Person
{
    [Key] [Column("person_document")] public string Document { get; set; }

    [Column("person_identification_type")]
    public string IdentificationType { get; set; }

    [Column("person_first_name")] public string FirstName { get; set; }

    [Column("person_second_name")] public string? SecondName { get; set; }

    [Column("person_first_last_name")] public string FirstLastName { get; set; }

    [Column("person_second_last_name")]
    public string? SecondLastName { get; set; }

    [Column("person_civil_state")] public string CivilState { get; set; }

    [Column("person_sex")] public string Sex { get; set; }

    [Column("person_birth_date")] public DateTime BirthDate { get; set; }

    public string CountryCode { get; set; }

    [ForeignKey("CountryCode")] public Country Nationality { get; set; }

    [Column("person_phone")] public string Phone { get; set; }

    [Column("person_institutional_email")]
    public string InstitutionalMail { get; set; }

    public string ProgramCode { get; set; }

    [ForeignKey("ProgramCode")] public AcademicProgram AcademicProgram { get; set; }

    [Column("person_type")] public string Type { get; set; }

    [Column("person_position")] public string Position { get; set; }

    public ICollection<Study> Studies { get; set; }

    public ICollection<Experience> Experiences { get; set; }
}
