using System.Net;
using System.Net.Mail;



string fromMail = "erik.kato.ipsen@gmail.com";      // Must be changed to company-email
string fromPassword = "dbfjyynwohijdnyf";       // Go to gmail-account > app-passwords > select: mail & windows-computer > generer > copy-paste adgangskode

MailMessage message = new MailMessage();
message.From = new MailAddress(fromMail);
message.Subject = "Test subject";
message.To.Add(new MailAddress("erik.kato.ipsen@gmail.com"));
message.Body = "<html><body> Test Body </body></html>";
message.IsBodyHtml = true;

var smtpClient = new SmtpClient("smtp.gmail.com")
{
    Port = 587,
    Credentials = new NetworkCredential(fromMail, fromPassword),
    EnableSsl = true
};

smtpClient.Send(message);

Console.WriteLine("Send");
Console.ReadKey();




