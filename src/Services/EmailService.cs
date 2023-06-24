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

    public void SendEmailRegistrationProposal(Proposal proposal,string type)
    {
        List<string> toAddresses = searchEmailPeople(proposal.PersonDocument1,proposal.PersonDocument2);
        if (toAddresses != null)
        {
            _emailSender.ConfirmationOfRegistration(toAddresses,type);
        }
    }

    public void SendEmailRegistrationProject(string codeProposal,string type)
    {
        var proposal = _proposalService.GetProposalCode(codeProposal);
        if (proposal != null)
        {
            List<string> toAddresses = searchEmailPeople(proposal.PersonDocument1,proposal.PersonDocument2);
            if (toAddresses != null)
            {
                _emailSender.ConfirmationOfRegistration(toAddresses,type);
            }
        }
    }

    public List<string>  searchEmailPeople(string PersonDocument1,string PersonDocument2)
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
