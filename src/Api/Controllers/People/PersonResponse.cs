namespace Api.Controllers.People;

public record PersonResponse(string Document,
    string IdentificationType,
    string FirstName,
    string SecondName,
    string FirstLastName,
    string SecondLastName,
    string CivilState,
    string Gender,
    DateTime BirthDate,
    string Phone,
    string InstitutionalMail,
    string CitiesCode,
    string DepartamentCode);
