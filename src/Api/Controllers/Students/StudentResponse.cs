using Entities;

namespace Api.Controllers.Students;

public record StudentResponse(
    string Document,
    string AcademicProgramCode,
    string AmountCredits);
