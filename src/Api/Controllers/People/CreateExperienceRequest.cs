namespace Api.Controllers.People;

public record CreateExperienceRequest(
    string Institution,
    string CityCode,
    DateTime StartDate,
    DateTime EndDate,
    string Type,
    string Position
);
