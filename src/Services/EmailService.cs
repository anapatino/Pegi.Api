using Entities;

namespace Services;

public class EmailService
{
    private readonly EmailSender _emailSender;


    public EmailService(EmailSender emailSender)
    {
        _emailSender = emailSender;

    }

    public void SendEmailRegistration(List<string>toAddresses,string type)
    {
        _emailSender.ConfirmationOfRegistration(toAddresses,type);
    }

    public void SendEmailAssignmentStudentProposal(List<string>toAddresses,string rol)
    {
        _emailSender.ConfirmationAssignmentStudent(toAddresses,rol,"Propuesta");
    }

    public void SendEmailAssignmentStudentProject(List<string>toAddresses,string rol)
    {
        _emailSender.ConfirmationAssignmentStudent(toAddresses,rol,"Proyecto");
    }

    public void SendEmailQualificationStudentProposal(List<string> toAddresses )
    {
        _emailSender.ConfirmationQualificationStudent(toAddresses,"Propuesta");
    }

    public void SendEmailQualificationStudentProject(List<string> toAddresses)
    {
        _emailSender.ConfirmationQualificationStudent(toAddresses,"Proyecto");
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
