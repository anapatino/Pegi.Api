using Entities;

namespace Api.Controllers.People;

public record ExperienceResponse(
    int Code,
    string Institution,
    City? City,
    DateTime StartDate,
    DateTime EndDate,
    string Type,
    string Position
);
