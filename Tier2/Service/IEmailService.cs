using System;

namespace Food4U_SEP3.Service
{
    public interface IEmailService
    {
        void SendEmail(String subject, String body, String receiver);
    }
}