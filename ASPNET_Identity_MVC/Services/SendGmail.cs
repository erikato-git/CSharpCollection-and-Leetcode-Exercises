using ASPNET_Identity_MVC.Interfaces;
using System.Net.Mail;
using System.Net;

namespace ASPNET_Identity_MVC.Services
{
    public class SendGmail : IEmailSender
    {
        private readonly ILogger _logger;

        public SendGmail(ILogger logger)
        {
            _logger = logger;
            // evt. fromMail & fromPassword credentials
        }


        public void SendMail(string mailTo, string subject, string text)
        {
            string fromMail = "erik.kato.ipsen@gmail.com";      // Must be changed to company-email and provided with new password
            string fromPassword = "dbfjyynwohijdnyf";       // Go to gmail-account > app-passwords > select: mail & windows-computer > generer > copy-paste adgangskode

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = subject;
            message.To.Add(new MailAddress("erik.kato.ipsen@gmail.com"));
            message.Body = "<html><body>"+text+"</body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true
            };

            try
            {
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("SendGmail - Error-message: " + ex);
            }

        }

    }
}
