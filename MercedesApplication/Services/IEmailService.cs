using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public interface IEmailService
    {
        void EmailSender(string email, string text);
    }
}
