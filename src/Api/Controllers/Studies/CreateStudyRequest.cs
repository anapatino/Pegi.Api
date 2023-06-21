namespace Api.Controllers.People;

public record CreateStudyRequest(
    string Code,
    string Institution,
    DateTime StartDate,
    DateTime EndDate,
    string CitiesCode,
    string PeopleCode
);
