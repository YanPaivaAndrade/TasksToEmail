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
            testcAsync();
            
        }

        private void testcAsync()
        {
            int cont = 0;
            TarefaService _ts = new TarefaService();
            Task.Factory.StartNew(() =>
            {
                while(_ts.FindAllPendente().Count> 0 && cont < 2)
                {
                    Thread.Sleep(900000);
                    SpamEmailService ses = new SpamEmailService();
                    ses.EnviarEmailAutomatizado(2);
                    cont++;
                }                
            });
            
                    

        }
    }
}