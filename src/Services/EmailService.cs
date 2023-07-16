using Entities;

namespace Services;

public class EmailService
{
    private readonly EmailSender _emailSender;


    public EmailService(EmailSender emailSender)
    {
        _emailSender = emailSender;

    }

    public void SendEmailRegistration(List<string>toAddresses,string type,string title)
    {
        _emailSender.ConfirmationOfRegistration(toAddresses,type,title);
    }

    public void SendEmailAssignmentStudentProposal(List<string>toAddresses,string rol,string title)
    {
        _emailSender.ConfirmationAssignmentStudent(toAddresses,rol,"Propuesta",title);
    }

    public void SendEmailAssignmentStudentProject(List<string>toAddresses,string rol,string title)
    {
        _emailSender.ConfirmationAssignmentStudent(toAddresses,rol,"Proyecto",title);
    }

    public void SendEmailQualificationStudentProposal(List<string> toAddresses ,string title)
    {
        _emailSender.ConfirmationQualificationStudent(toAddresses,"Propuesta",title);
    }

    public void SendEmailQualificationStudentProject(List<string> toAddresses,string title)
    {
        _emailSender.ConfirmationQualificationStudent(toAddresses,"Proyecto",title);
    }

    public void SendEmailAssignmentEvaluatorProposal(string toAdress,string title)
    {
        _emailSender.ConfirmationAssignmentDocent(toAdress,title,"Propuesta");
    }

    public void SendEmailAssignmentTutorProposal(string toAdress,string title)
    {
        _emailSender.ConfirmationAssignmentDocent(toAdress,title,"Propuesta");
    }

    public void SendEmailQualificationDocentProposal(string toAdress,string title)
    {
        _emailSender.ConfirmationQualificationDocent(toAdress,title,"Propuesta");
    }

    public void SendEmailQualificationDocentProject(string toAdress,string title)
    {
        _emailSender.ConfirmationQualificationDocent(toAdress,title,"Proyecto");
    }

}
