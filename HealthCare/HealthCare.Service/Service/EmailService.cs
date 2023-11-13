using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Gmail.v1;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Windows;
using System.IO;
using System.Threading;
using System.Net.Mail;
using System.Net;
using HealthCare.Service.IService;
namespace HealthCare.Service.Service
{
    public class EmailService : IEmailService
    {
        public string SendEmail(string to, string subject, string body)
        {
            string senderEmail = "hammadejazkhan786@gmail.com"; 
            string senderPassword = "bdtioqvdkozebpvi"; 

            string host = "smtp.gmail.com";
            int port = 587;

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(senderEmail);
            mailMessage.Subject = subject;
            mailMessage.To.Add(new MailAddress(to));
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;

            var client = new SmtpClient(host)
            {
                Port = port,
                Credentials = new NetworkCredential(senderEmail, senderPassword),
                EnableSsl = true
            };
            try
            {
                client.Send(mailMessage);
                return "Email sent successfully!";
            }
            catch (SmtpException ex)
            {
                return $"Failed to send email. SmtpError: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"General error sending email: {ex.Message}";
            }

        }
        public string GenerateVerificationCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
