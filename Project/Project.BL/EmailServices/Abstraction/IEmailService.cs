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
}
