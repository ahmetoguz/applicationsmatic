using System;
using System.Collections.Generic;
using System.Text;

namespace Smatic.Core.Services
{
    interface IEmailService
    {
        void SendInviteEmail(string from, string to, string subject, string body);
    }
}
