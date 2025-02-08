using Microsoft.Extensions.Configuration;
using Project.BL.EmailServices.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.EmailServices.Implementation;

public class EmailService(IConfiguration _configuration) : IEmailService
{
    public void SendAcceptedEmail(string toUser)
    {
        SmtpClient smtp = new SmtpClient(_configuration["Email:Host"], Convert.ToInt32(_configuration["Email:Port"]));
        smtp.EnableSsl = true;
        smtp.Credentials = new NetworkCredential(_configuration["Email:Login"], _configuration["Email:Passcode"]);

        MailAddress from = new MailAddress("nacibar-ab108@code.edu.az");
        MailAddress to = new MailAddress(toUser);

        MailMessage message = new MailMessage(from, to);


        message.Subject = "Reserviniz qebul olundu 🎉";
        message.IsBodyHtml = true;

        message.Body = "Bizi sechdiyiniz uchun tesekkurler";
        smtp.Send(message);
    }
    public void SendRejectedEmail(string toUser)
    {
        SmtpClient smtp = new SmtpClient(_configuration["Email:Host"], Convert.ToInt32(_configuration["Email:Port"]));
        smtp.EnableSsl = true;
        smtp.Credentials = new NetworkCredential(_configuration["Email:Login"], _configuration["Email:Passcode"]);

        MailAddress from = new MailAddress("nacibar-ab108@code.edu.az");
        MailAddress to = new MailAddress(toUser);

        MailMessage message = new MailMessage(from, to);


        message.Subject = "Reserv etdiyiniz yer doludur";
        message.IsBodyHtml = true;

        message.Body = "Diger yerlere bash dura bilersiniz";
        smtp.Send(message);
    }
    public void ReservMessage(string toUser)
    {
        SmtpClient smtp = new SmtpClient(_configuration["Email:Host"], Convert.ToInt32(_configuration["Email:Port"]));
        smtp.EnableSsl = true;
        smtp.Credentials = new NetworkCredential(_configuration["Email:Login"], _configuration["Email:Passcode"]);

        MailAddress from = new MailAddress("nacibar-ab108@code.edu.az");
        MailAddress to = new MailAddress(toUser);

        MailMessage message = new MailMessage(from, to);


        message.Subject = "Başvurunuz için Teşekkürler";
        message.IsBodyHtml = true;

        message.Body = "Sizinle elaqeye kecheceyik";
        smtp.Send(message);
    }
    public void SendConfirmEmail(string toUser, string confirmUrl)
    {

        throw new NotImplementedException();
    }

    public void SendWelcome(string toUser)
    {
        SmtpClient smtp = new SmtpClient(_configuration["Email:Host"], Convert.ToInt32(_configuration["Email:Port"]));
        smtp.EnableSsl = true;
        smtp.Credentials = new NetworkCredential(_configuration["Email:Login"], _configuration["Email:Passcode"]);

        MailAddress from = new MailAddress("nacibar-ab108@code.edu.az");
        MailAddress to = new MailAddress(toUser);

        MailMessage message = new MailMessage(from, to);


        message.Subject = "You have come to our restaurant";
        message.IsBodyHtml = true;

        message.Body = "Xoş gəlmişsiniz🎉";
        smtp.Send(message);
    }
}
