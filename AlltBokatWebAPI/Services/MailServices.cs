using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlltBokatWebAPI.Models;
using SendGrid;
using System.Threading.Tasks;
using SendGrid.Helpers.Mail;

namespace AlltBokatWebAPI.Services
{
    public class MailServices
    {




        public async Task NotifyBookingByMail(MailModels x)

        {
            MailModels mailmodel = new MailModels();
            mailmodel = x;
            //SG.k - 1qp0IET1KI81dkyb7vGg.171FKbfy0Vk3P9i489GLuQaU0A7G49JPjim7NgYoC1U
            //var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");

            mailmodel.subject = "Booking notification";
            mailmodel.plainTextContent = "Hello " + mailmodel.ToName + "!" + " <br/> You have a confirmed reservation at: " + mailmodel.StartTime + " <br/> with" + mailmodel.ApplicationUserFirstName + " " + mailmodel.ApplicationUserLastName + "<br/> Thank you for booking with us" + "<br/> Best Regards AlltBokat customer support";
            mailmodel.htmlContent = "Hello" + mailmodel.ToName + "!" + " <br/> You have a confirmed reservation at: " + mailmodel.StartTime + " <br/> with " + mailmodel.ApplicationUserFirstName + " " + mailmodel.ApplicationUserLastName + "<br/> Thank you for booking with us" + "<br/> Best Regards AlltBokat customer support";
            mailmodel.FromEmail = ("nyqvist.david@gmail.com");
            mailmodel.FromName = ("Alltbokat Support");


            var from = new EmailAddress(mailmodel.FromEmail, mailmodel.FromName);
            var to = new EmailAddress(mailmodel.ToEmail, mailmodel.ToName);

            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");


            var client = new SendGridClient(apiKey);

            var msg = MailHelper.CreateSingleEmail(from, to, mailmodel.subject, mailmodel.plainTextContent, mailmodel.htmlContent);

            var response = await client.SendEmailAsync(msg);



        }








    }
}








