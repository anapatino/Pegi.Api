namespace Api.Controllers.People;

public record CreatePersonRequest
    (
        string Document,
        string Identification,
        string FirstName,
        string SecondName,
        string FirstLastName,
        string SecondLatName,
        string CivilState,
        string Sex,
        string BirthDate,
        string Nationality,
        string CityCode,
        string BirthPlace,
        string Phone,
        string InstitutionalMail
    );
