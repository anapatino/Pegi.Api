using System.Net;
using System.Net.Mail;
namespace Entities;

public class EmailSender
{
    private SmtpClient smtp;

    public EmailSender()
    {
        smtp = new SmtpClient();
    }

    public void ConfirmationOfRegistration(List<string> toAddresses,string type)
    {
        string subject = $"Confirmacion Registro de {type}";
        string body = "<b>Estimado Estudiante,</b><br><br>" +
                      $"Este correo es para confirmar que hemos recibido su {type}  " +
                      "le agradecemos esperar que le sean asignado su tutor y evaluador "+
                      "le notificaremos por este medio cuando le sean asignados.";

         SendEmailToMultipleRecipients(toAddresses, subject, body);
    }

    public void ConfirmationAssignmentStudent (List<string> toAddresses,string rol,string type)
    {
        string subject = $"Notificación: Asignacion de {rol} a su {type}";
        string body = "<b>Estimado Estudiante,</b><br><br>" +
                      $"Este correo es para confirmar que se ha asignado un {rol}  " +
                      $"a su {type} dirigase al aplicativo web o movil para ver su {rol}." ;
         SendEmailToMultipleRecipients(toAddresses, subject, body);
    }

    public void ConfirmationQualificationStudent (List<string> toAddresses,string rol,string type)
    {
        string subject = $"Notificación: Calificacion de su {type}";
        string body = "<b>Estimado Estudiante,</b><br><br>" +
                      $"Este correo es para confirmar que se ha calificado su {type}  " +
                      "dirigase al aplicativo web o movil para ver su calificación." ;
         SendEmailToMultipleRecipients(toAddresses, subject, body);
    }

    public void ConfirmationAssignmentDocent (string toAddress,string title,string type)
    {
        string subject = $"Notificación: Usted ha sido Asignado a un/a {type}";
        string body = "<b>Estimado Docente,</b><br><br>" +
                      $"Este correo es para confirmar que se le ha asignado un/a {type}: {title} " +
                      "dirigase al aplicativo web o movil para ver los detalles." ;
         SendEmail(toAddress, subject, body);
    }

    public void ConfirmationQualificationDocent (string toAddress,string title,string type)
    {
        string subject = $"Confirmacion Calificación de {type}";
        string body = "<b>Estimado Docente,</b><br><br>" +
                      $"Este correo es para confirmar que ha calificado un/a {type}: {title}.";
         SendEmail(toAddress, subject, body);
    }

    private void ConfigSmtp()
    {
        NetworkCredential credentials = new NetworkCredential("asofiapatino@unicesar.edu.co", "1632em@nuel");
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;
        smtp.EnableSsl = true;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials =credentials;

    }

    private void SendEmail(string toAddress, string subject, string body)
    {
        try
        {
            ConfigSmtp();
            MailMessage message = new MailMessage("asofiapatino@unicesar.edu.co", toAddress, subject, body);
            message.Priority= MailPriority.High;
            message.IsBodyHtml = true;
            smtp.Send(message);

        }
        catch (Exception ex)
        {

        }
    }

    private void SendEmailToMultipleRecipients(List<string> toAddresses, string subject, string body)
    {
        try
        {
            ConfigSmtp();
            foreach (string toAddress in toAddresses)
            {
                MailMessage message = new MailMessage("asofiapatino@unicesar.edu.co", toAddress, subject, body);
                message.IsBodyHtml = true;
                message.Priority= MailPriority.High;
                smtp.Send(message);
            }

        }
        catch (Exception ex)
        {

        }
    }
}
