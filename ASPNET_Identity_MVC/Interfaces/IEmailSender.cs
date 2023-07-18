namespace ASPNET_Identity_MVC.Interfaces
{
    public interface IEmailSender
    {
        void SendMail(string mailTo, string subject, string text);
    }
}
