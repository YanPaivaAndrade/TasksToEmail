using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using TasksToEmail.Services;

namespace TasksToEmail
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que é executado na inicialização do aplicativo
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            testcAsync();
            
        }

        private async System.Threading.Tasks.Task testcAsync()
        {
            Thread.Sleep(500);
            SpamEmailService ses = new SpamEmailService();
            await ses.EnviarEmailAutomatizado(2);           

        }
    }
}