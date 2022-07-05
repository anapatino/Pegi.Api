using Entities;

namespace Api.Controllers.LinesInvestigation;

public record CreateLineRequest
    (
        string Code,
        string Name ,
        ICollection<SublineInvestigation> SublinesInvestigation
    );
