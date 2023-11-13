using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Service.IService
{
    public interface IEmailService
    {
        string SendEmail(string to, string subject, string body);
        string GenerateVerificationCode(int length);
    }
}
