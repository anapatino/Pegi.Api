
using Services;

class Program
{
    static void Main()
    {
        Console.WriteLine("Iniciaste el Main");
        string fromAddress = "asofiapatino@unicesar.edu.co";
        string password = "1632em@nuel";

        EmailSender emailSender = new EmailSender();

        // Enviar correo con el mensaje 1
        string toAddress1 = "sofipatino614@gmail.com";
        List<string> toAddresses2 = new List<string>
        {
            "sofipatino614@gmail.com",
            "pegi81917@gmail.com"
        };

        var message= emailSender.ConfirmationOfRegistration(toAddresses2,"Propuesta");

        var message2=emailSender.ConfirmationAssignmentStudent(toAddresses2,"Tutor","Propuesta");

        var message3=emailSender.ConfirmationQualificationStudent(toAddresses2,"Tutor","Propuesta");

        var message4=emailSender.ConfirmationAssignmentDocent(toAddress1,"Docker y sus componentes","Tutor");

        var message5=emailSender.ConfirmationQualificationDocent(toAddress1,"Docker y sus componentes","Propuesta");
        Console.WriteLine(message);
        Console.WriteLine(message2);
        Console.WriteLine(message3);
        Console.WriteLine(message4);
        Console.WriteLine(message5);
    }
}
