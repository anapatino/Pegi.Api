using Entities;

namespace Api.Controllers.People;

public record CreatePersonRequest
(
    string Document,
    string IdentificationType,
    string FirstName,
    string SecondName,
    string FirstLastName,
    string SecondLatName,
    string CivilState,
    string Sex,
    DateTime BirthDate,
    string Nationality,
    string Phone,
    string InstitutionalMail,
    string AcademicProgram,
    string Type,
    string Position,
    ICollection<Study> Studies,
    ICollection<Experience> Experiences
);
