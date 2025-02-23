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


        message.Subject = "Your reservation has been accepted🎉";
        message.IsBodyHtml = true;

        message.Body = "Thank you for choosing us";
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


        message.Subject = "The reserve is full on the ground.";
        message.IsBodyHtml = true;

        message.Body = "You can visit other places";
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


        message.Subject = "Thank you for your application";
        message.IsBodyHtml = true;

        message.Body = "We will contact you";
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


        message.Subject = "You have come to our petpal";
        message.IsBodyHtml = true;

        message.Body = "You are welcome🎉";
        smtp.Send(message);
    }

    public void AdoptionMessage(string toUser)
    {
        SmtpClient smtp = new SmtpClient(_configuration["Email:Host"], Convert.ToInt32(_configuration["Email:Port"]));
        smtp.EnableSsl = true;
        smtp.Credentials = new NetworkCredential(_configuration["Email:Login"], _configuration["Email:Passcode"]);

        MailAddress from = new MailAddress("nacibar-ab108@code.edu.az");
        MailAddress to = new MailAddress(toUser);

        MailMessage message = new MailMessage(from, to);


        message.Subject = "Thank you for your application";
        message.IsBodyHtml = true;

        message.Body = "We will contact you.";
        smtp.Send(message);
    }

    public void SendAdoptionAcceptedEmail(string toUser)
    {
        SmtpClient smtp = new SmtpClient(_configuration["Email:Host"], Convert.ToInt32(_configuration["Email:Port"]));
        smtp.EnableSsl = true;
        smtp.Credentials = new NetworkCredential(_configuration["Email:Login"], _configuration["Email:Passcode"]);

        MailAddress from = new MailAddress("nacibar-ab108@code.edu.az");
        MailAddress to = new MailAddress(toUser);

        MailMessage message = new MailMessage(from, to);


        message.Subject = "Thank you for your application";
        message.IsBodyHtml = true;

        message.Body = "You own the animal.";
        smtp.Send(message);
    }

    public void SendAdoptionRejectedEmail(string toUser)
    {
        SmtpClient smtp = new SmtpClient(_configuration["Email:Host"], Convert.ToInt32(_configuration["Email:Port"]));
        smtp.EnableSsl = true;
        smtp.Credentials = new NetworkCredential(_configuration["Email:Login"], _configuration["Email:Passcode"]);

        MailAddress from = new MailAddress("nacibar-ab108@code.edu.az");
        MailAddress to = new MailAddress(toUser);

        MailMessage message = new MailMessage(from, to);


        message.Subject = "Thank you for your application";
        message.IsBodyHtml = true;

        message.Body = "Sorry,your registration was being canceled";
        smtp.Send(message);
    }
}
