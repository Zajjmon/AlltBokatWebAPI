using System.Web;
using System.Net.Mail;
using System.Net;
using System;

namespace AlltBokatWebAPI.Models
{
    public class MailTestKlass
    {

        //public void sendmail()
        //{
        //    var fromAddress = new MailAddress("zajjmon01@gmail.com", "Simon");
        //    var toAddress = new MailAddress("zajjmon01@gmail.com", "Johan");
        //    const string fromPassword = "!1234Dampkakan12";
        //    const string subject = "The test mail";
        //    const string body = "Hey now!! This is the grand test yet again.";

        //    var smtp = new SmtpClient
        //    {
        //        Host = "smtp.gmail.com",
        //        Port = 587,
        //        EnableSsl = true,
        //        DeliveryMethod = SmtpDeliveryMethod.Network,
        //        Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
        //        Timeout = 20000
        //    };
        //    using (var message = new MailMessage(fromAddress, toAddress)
        //    {
        //        Subject = subject,
        //        Body = body
        //    })
        //    {
        //        smtp.Send(message);
        //    }
        //}

        // tar emot faktiska värden för att lägga i notifikationsmailet.
        public void sendmail(string CustomerMail, string CustomerName, string UserMail, string UserName, string BookingDescription, DateTime StartTime, DateTime EndTime)
        {
            var fromAddress = new MailAddress("zajjmon01@gmail.com", "AlltBokat Notification Team");

            string fromPassword = "!1234Dampkakan12";
            string subject = "New Booking";
            string body = "Hey now! The Customer " + CustomerName + " has booked a time with the Deliverer " + UserName + " between " + StartTime.ToString() + " and " + EndTime.ToString() + " with the description: " + BookingDescription + ".";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };

            var toCustomerMail = new MailAddress(CustomerMail);
            using (var message = new MailMessage(fromAddress, toCustomerMail)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }




            var toDelivererMail = new MailAddress(UserMail);
            using (var message = new MailMessage(fromAddress, toDelivererMail)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }






        // om man bara vill testa med default värden, tar EJ emot DateTime objekt utan gör egna defaultvärden för dem.

        public void sendmail(string CustomerMail = "zajjmon01@gmail.com", string UserUsername = "ZajjmonVillHa", string DelivererMail = "zajjmon01@gmail.com", string DelivererUserName = "JohanLevererar", string BookingDescription = "I just want some quality time for one hour")
        {
            var fromAddress = new MailAddress("zajjmon01@gmail.com", "AlltBokat Notification Team");

            string fromPassword = "!1234Dampkakan12";
            string subject = "New Booking";
            var StartTime = DateTime.Now;
            var EndTime = DateTime.Now.AddHours(1);
            string body = "Hey now!! This is the grand test yet again. \n The Customer " + UserUsername + " has booked a time with the Deliverer " + DelivererUserName + "\n between " + StartTime.ToString() + " and " + EndTime.ToString() + "\n with the description: " + BookingDescription + ".";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };

            var toCustomerMail = new MailAddress(CustomerMail, "AlltBokat Notification Team");
            using (var message = new MailMessage(fromAddress, toCustomerMail)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }




            var toDelivererMail = new MailAddress(DelivererMail, "AlltBokat Notification Team");
            using (var message = new MailMessage(fromAddress, toDelivererMail)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

    }

}