namespace Api.Controllers.People;

public record CreateStudyRequest(
    string Institution,
    string CityCode,
    DateTime StartDate,
    DateTime EndDate,
    string Type
);
