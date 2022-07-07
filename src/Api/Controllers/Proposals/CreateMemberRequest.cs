namespace Api.Controllers.Proposals;

public class CreateMemberRequest
{
    public string Document { get; set; }

    public string IdentificationType { get; set; }

    public string Name { get; set; }

    public int ProgramCode { get; set; }

    public string CreditNumber { get; set; }

    public string Phone { get; set; }

    public string Mail { get; set; }
}
