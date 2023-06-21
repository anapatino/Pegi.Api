namespace Api.Controllers.People;

public record StudiesResponse(
    string Code,
    string Institution,
    DateTime StartDate,
    DateTime EndDate,
    string CitiesCode,
    string PeopleCode
);
