using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AoqibaoStore.Abstract;
using AoqibaoStore.Models;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace AoqibaoStore.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress;
        public string MailFromAddress = @"admin@aoqibao.com";
        public bool UseSsl = true;
        public string Username = @"juehualu@gmail.com";
        public string Password = @"fisherv1";
        public string ServerName = @"smtp.gmail.com";
        public int ServerPort = 587;
    }

    public class EmailContactProcessor : IContactProcessor
    {
        private EmailSettings emailSettings;

        public EmailContactProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }

        public void ProcessContact(Contact contact)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;

                smtpClient.Credentials = new NetworkCredential(emailSettings.Username,emailSettings.Password);

                StringBuilder body = new StringBuilder()
                                     .AppendLine("A new contact has been submitted")
                                     .AppendLine("---")
                                     .AppendLine("Content:");

                body.AppendLine("").AppendFormat("Name is {0} ",contact.name);
                body.AppendLine("").AppendFormat("Email is {0} ", contact.email);
                body.AppendLine("").AppendFormat("Phone is {0} ", contact.phone);
                body.AppendLine("").AppendFormat("Message is {0} ", contact.body);


                MailMessage mailMessage = new MailMessage(
                                          emailSettings.MailFromAddress,
                                           contact.email,
                                          "New Contact submitted",
                                          body.ToString());

                smtpClient.Send(mailMessage);
            }

        }


   

    }
}