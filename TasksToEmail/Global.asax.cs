using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

            //Preencher os campos de Email e Password antes de executar
            SpamEmailService.SendEmailPendente(1);
            SpamEmailService.SendEmailPendente();
        }

        
            
                    

        
    }
}