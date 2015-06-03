using AoqibaoStore.Abstract;
using AoqibaoStore.Models;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace AoqibaoStore.Concrete
{
    //public class EmailSettings
    //{
    //    public string MailToAddress;
    //    public string MailFromAddress = @"admin@aoqibao.com";
    //    public bool UseSsl = true;
    //    public string Username = @"juehualu@gmail.com";
    //    public string Password = @"fisherv1";
    //    public string ServerName = @"smtp.gmail.com";
    //    public int ServerPort = 587;
    //}

        public class EmailOrderProcessor : IOrderProcessor
        {
            private EmailSettings emailSettings;

            public EmailOrderProcessor(EmailSettings settings) {
                emailSettings = settings;
            }


            public void ProcessOrder(Cart cart, ShippingDetails shippingInfo) {

                //Save order to Db


                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.EnableSsl = emailSettings.UseSsl;
                    smtpClient.Host = emailSettings.ServerName;
                    smtpClient.Port = emailSettings.ServerPort;
                    smtpClient.UseDefaultCredentials = false;

                    smtpClient.Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password);

                    StringBuilder body = new StringBuilder()
                                    .AppendLine("A new order has been submitted")
                                    .AppendLine("---")
                                    .AppendLine("Items:");

                foreach (var line in cart.Lines)
                {
                    var subtotal = line.Product.unitPrice * line.Quantity;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c}",line.Quantity,line.Product.name,subtotal);
                }

                body.AppendFormat("Total order value: {0:c}", cart.ComputeTotalValue())
                                            .AppendLine("---")
                                            .AppendLine("Ship to:")
                                            .AppendLine(shippingInfo.Name)
                                            .AppendLine(shippingInfo.Line1)
                                            .AppendLine(shippingInfo.Line2 ?? "")
                                            .AppendLine(shippingInfo.Line3 ?? "")
                                            .AppendLine(shippingInfo.City)
                                            .AppendLine(shippingInfo.State ?? "")
                                            .AppendLine(shippingInfo.Country)
                                            .AppendLine(shippingInfo.Postcode)
                                            .AppendLine("---");

                MailMessage mailMessage = new MailMessage(
                                        emailSettings.MailFromAddress,
                                        "fisherv1@hotmail.com",
                                        "New order submitted",
                                        body.ToString());

                smtpClient.Send(mailMessage);
                }
            
            }
        }
    }