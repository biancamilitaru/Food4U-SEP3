using System;

namespace Food4U_SEP3.Service
{
    public interface IEmailService
    {
        void SendEmail(string subject, string body, string receiver);
    }
}