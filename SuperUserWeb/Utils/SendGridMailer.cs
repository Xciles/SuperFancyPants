using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace SuperUserWeb.Utils
{
    public class SendGridMailer
    {
        public static string SendGridApiKey = "<key>";

        public static Task<Response> SendMessage(string destination, string subject, string body)
        {
            var message = new SendGridMessage();
            message.AddTo(destination);
            message.From = new EmailAddress("info@hotelkamer.nu", "Info @ Je Moeder");
            message.Subject = subject;
            message.HtmlContent = body;

            // Create a Web transport for sending email.
            var transportWeb = new SendGridClient(SendGridApiKey);

            // Send the email.
            return transportWeb.SendEmailAsync(message);
        }
    }
}
