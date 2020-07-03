using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            SendEmail();
            async void SendEmail()
            {
                SpamEmailService ses = new SpamEmailService();
                await ses.EnviarEmailAutomatizado();
            }
        }
    }
}
