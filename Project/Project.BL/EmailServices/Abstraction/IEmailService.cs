using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.EmailServices.Abstraction;

public interface IEmailService
{
    void SendWelcome(string toUser);
    void SendConfirmEmail(string toUser, string confirmUrl);
    void ReservMessage(string toUser);
    void SendAcceptedEmail(string toUser);
    void SendRejectedEmail(string toUser);
    void AdoptionMessage(string toUser);
    void SendAdoptionAcceptedEmail(string toUser);
    void SendAdoptionRejectedEmail(string toUser);

}
