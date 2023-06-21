using Entities;

namespace Api.Controllers.Students;

public record CreateStudentRequest(
    string Document,
    string AcademicProgramCode,
    string AmountCredits
    );
