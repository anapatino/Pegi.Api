using Entities;

namespace Api.Controllers.People;

public record StudyResponse(
    int Code,
    string Institution,
    City? City,
    DateTime StartDate,
    DateTime EndDate,
    string Type
);
