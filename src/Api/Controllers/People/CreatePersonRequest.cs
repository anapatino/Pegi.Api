namespace Api.Controllers.People;

public record CreatePersonRequest
(
    string Document,
    string IdentificationType,
    string FirstName,
    string? SecondName,
    string FirstLastName,
    string SecondLatName,
    string CivilState,
    string Sex,
    DateTime BirthDate,
    string CountryCode,
    string Phone,
    string InstitutionalMail,
    int ProgramCode,
    string Type,
    string Position,
    ICollection<CreateStudyRequest> Studies,
    ICollection<CreateExperienceRequest> Experiences,
    string UserName
);
