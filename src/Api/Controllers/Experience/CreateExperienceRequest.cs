using Entities;

namespace Api.Controllers.People;

public record CreateExperienceRequest(
    string Code,
    string Institution,
    DateTime StartDate,
    DateTime EndDate,
    string CitiesCode,
    string PeopleCode,
    string Position);
