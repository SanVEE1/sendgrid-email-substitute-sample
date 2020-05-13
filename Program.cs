using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace SendGridEmail
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var sendGridClient = new SendGridClient("xxxenter_sendgrid_api_key_herexxx");
            var message = new SendGridMessage()
            {
                From = new EmailAddress("test@example.com")
            };

            var templateData = new Dictionary<string, string>
            {
                { "subject", "SendGrid email with substitutions" },
                { "body_1", "Sara" },
                { "body_2", "Probasics SendGrid Demo" }
            };

            var personalisation = new Personalization
            {
                TemplateData = templateData,
                Tos = new List<EmailAddress>{
                     new EmailAddress("myemail@outlook.com")}
            };

            message.Personalizations = new List<Personalization>
            {
                personalisation
            };

            message.TemplateId = "xxxenter_your_dynamic_template_id_here_from_sendgrid_dashboardxxx";

            try
            {
                var response = await sendGridClient.SendEmailAsync(message);
                var v = await response.Body.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
