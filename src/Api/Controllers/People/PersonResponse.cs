using Entities;

namespace Api.Controllers.People;

public record PersonResponse(
    string Document,
    string IdentificationType,
    string FirstName,
    string SecondName,
    string FirstLastName,
    string SecondLatName,
    string CivilState,
    string Sex,
    DateTime BirthDate,
    Country Nationality,
    string Phone,
    string InstitutionalMail,
    ICollection<Study> Studies,
    ICollection<Experience> Experiences
);
