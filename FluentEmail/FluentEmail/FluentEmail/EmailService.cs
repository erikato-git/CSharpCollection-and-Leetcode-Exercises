using FluentEmail.Core;
using FluentEmail.Razor;
using FluentEmail.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FluentEmail
{
    internal class EmailService
    {
        int DEFAULT_PORT = 25;

        public async Task SendEmail()
        {
            var sender = new SmtpSender(() => new SmtpClient("localhost")
            {
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                PickupDirectoryLocation = @"C:\Users\erikk\Desktop\CSharpCollection\FluentEmail\FluentEmail",         // Could have changed
                Port = DEFAULT_PORT
            });

            // Stringbuilder is most efficient to concat a string

            StringBuilder template = new();
            template.AppendLine("Dear @Model.FirstName,");
            template.AppendLine("<p><em>Thanks for bla bla bla @Model.ProductName. We hope you enjoy it.</em></p>");
            template.AppendLine("- Hilsen Japanerland hvor bananen gror");

            //NB: For at bruge fluentEmail.Razor remember to set in .csproj: < PreserveCompilationContext > true </ PreserveCompilationContext >

            Email.DefaultSender = sender;
            Email.DefaultRenderer = new RazorRenderer();        //  Email is going to interpret stringbuilder as razor

            var email = await Email
                .From("fluentEmail@ConsoleApp-Demo.com")
                .To("erik.kato@hotmail.com", "Erik")
                .Subject("Email-demo")
                .UsingTemplate(template.ToString(),new { FirstName = "Erik Clausen", ProductName = "Backed Alaska" })
                //.Body("You shouldn't think you're anything special. Welcome to Denmark")
                .SendAsync();


        }



    }
}
