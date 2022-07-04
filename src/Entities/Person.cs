using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("people")]
public class Person
{
    [Key, Column("person_document")]
    public string Document { get; set; }

    [Column("person_identification")]
    public string Identification { get; set; }

    [Column("person_firstName")]
    public string FirstName { get; set; }

    [Column("person_secondName")]
    public string SecondName { get; set; }

    [Column("person_firstLastName")]
    public string FirstLastName { get; set; }

    [Column("person_secondLastName")]
    public string SecondLastName { get; set; }

    [Column("person_civilState")]
    public string CivilState { get; set; }

    [Column("person_sex")]
    public string Sex { get; set; }

    [Column("person_birthDate")]
    public string BirthDate { get; set; }

    [Column("person_nationality")]
    public string Nationality { get; set; }

    public string CityCode { get; set; }
    [ForeignKey("CityCode")]
    public City City { get; set; }

    [Column("person_birthPlace")]
    public string BirthPlace { get; set; }

    [Column("person_phone")]
    public string Phone { get; set; }

    [Column("person_institutionalMail")]
    public string InstitutionalMail { get; set; }
}
