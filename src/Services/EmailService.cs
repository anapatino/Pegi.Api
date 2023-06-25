using Entities;

namespace Services;

public class EmailService
{
    private readonly EmailSender _emailSender;
    private readonly PeopleService _peopleService;
    private readonly ProposalService _proposalService;

    public EmailService(EmailSender emailSender,PeopleService peopleService,ProposalService proposalService)
    {
        _emailSender = emailSender;
        _peopleService = peopleService;
        _proposalService = proposalService;
    }

    public void SendEmailRegistration(Proposal proposal,string type)
    {
        List<string> toAddresses = searchEmailPeople(proposal.PersonDocument1,proposal.PersonDocument2);
        if (toAddresses != null)
        {
            _emailSender.ConfirmationOfRegistration(toAddresses,type);
        }
    }

    public void SendEmailAssignmentStudentProposal(Proposal proposal,string rol)
    {
        List<string> toAddresses = searchEmailPeople(proposal.PersonDocument1,proposal.PersonDocument2);
        if (toAddresses != null)
        {
            _emailSender.ConfirmationAssignmentStudent(toAddresses,rol,"Propuesta");
        }
    }

    public void SendEmailAssignmentStudentProject(Project project,string rol)
    {
        List<string> toAddresses = searchEmailPeople(project.PersonDocument1,project.PersonDocument2);
        if (toAddresses != null)
        {
            _emailSender.ConfirmationAssignmentStudent(toAddresses,rol,"Proyecto");
        }
    }

    public void SendEmailQualificationStudentProposal(Proposal proposal)
    {
        List<string> toAddresses = searchEmailPeople(proposal.PersonDocument1,proposal.PersonDocument2);
        if (toAddresses != null)
        {
            _emailSender.ConfirmationQualificationStudent(toAddresses,"Propuesta");
        }
    }

    public void SendEmailQualificationStudentProject(Project project)
    {
        List<string> toAddresses = searchEmailPeople(project.PersonDocument1,project.PersonDocument2);
        if (toAddresses != null)
        {
            _emailSender.ConfirmationQualificationStudent(toAddresses,"Proyecto");
        }
    }
    public void SendEmailAssignmentEvaluatorProposal(Proposal proposal)
    {
        var toAdress = searchOneEmail(proposal.EvaluatorDocument);
        _emailSender.ConfirmationAssignmentDocent(toAdress,proposal.Title,"Propuesta");
    }

    public void SendEmailAssignmentTutorProposal(Proposal proposal)
    {
        var toAdress = searchOneEmail(proposal.TutorDocument);
        _emailSender.ConfirmationAssignmentDocent(toAdress,proposal.Title,"Propuesta");
    }

    public void SendEmailQualificationDocentProposal(Proposal proposal)
    {
        var toAdress = searchOneEmail(proposal.EvaluatorDocument);
        _emailSender.ConfirmationQualificationDocent(toAdress,proposal.Title,"Propuesta");
    }

    public void SendEmailQualificationDocentProject(Project project)
    {
        var proposal = _proposalService.GetProposalCode(project.ProposalCode);
        var toAdress = searchOneEmail(proposal.EvaluatorDocument);
        _emailSender.ConfirmationQualificationDocent(toAdress,proposal.Title,"Proyecto");
    }

    private string searchOneEmail(string document)
    {
        var personFirst = _peopleService.SearchPerson(document);
        string toAdress = personFirst.InstitutionalMail;
        return toAdress;
    }

    private List<string>  searchEmailPeople(string PersonDocument1,string PersonDocument2)
    {
        var personFirst = _peopleService.SearchPerson(PersonDocument1);
        var personSecond = _peopleService.SearchPerson(PersonDocument2);
        if (personFirst != null && personSecond != null)
        {
            List<string> toAddresses = new List<string>
            {
                personFirst.InstitutionalMail,
                personSecond.InstitutionalMail
            };
            return toAddresses;

        }
        return null;

    }

}
