using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using TasksToEmail.Models;

namespace TasksToEmail.Services
{
    public class SpamEmailService
    {
        private static readonly TarefaService _TarefaService = new TarefaService();
        private static string login = "gckael@gmail.com";
        private static string senha = "a12457800740012s";
        private static string destinatario = "gckael@gmail.com";
        private static string remetente = "gckael@gmail.com";

        public SpamEmailService() {
        }
        public static void SendEmailPendenteAutomatico(int tempo)
        {

        //Cont para em 32 pois é referente a carga horaria de 8h diarias ((8h*60m)/15m) 
            int cont = 0;
            Task.Factory.StartNew(() =>
            {
                while (_TarefaService.FindAllPendente().Count > 0 && cont < 2)
                {
                    Thread.Sleep(tempo * 60000);
                    MontarEmailAutomatico("Pendente", _TarefaService.FindAllPendente());
                    cont++;
                }
            });
        }
        public static void SendEmailPendente(Email e)
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1 * 60000);
                LogEmail(e);
                SendEmail(e);
            });
        }
        public static void SendEmailDimensionamento(Email e)
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1 * 60000);
                LogEmail(e);
                SendEmail(e);
            });
        }
        public static void SendEmailDesenvolvimento(Email e)
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1 * 60000);
                LogEmail(e);
                SendEmail(e);
            });
        }
        public static void SendEmailEntregue(Email e)
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1 * 60000);
                LogEmail(e);
                SendEmail(e);
            });
        }
        private static void MontarEmailAutomatico(string assunto, List<Tarefa> list)
        {
            Email e = new Email();
            e.Assunto = "Tarefas " + assunto + " ordenadas por Priority";
            e.Destinatario = destinatario;
            e.Remetente = remetente;
            foreach (Tarefa t in list)
            {
                e.CorpoDoEmail += t.GetStatus();                
            }
            SendEmail(e);
            LogEmail(e);
        }
        private static void LogEmail(Email e)
        {
            FileStream file = null;
            StreamWriter sw = null;
            string path = @"C:\Users\yan_1\Documents\Rerum\TasksToEmail\log.txt";
            try
            {
                file = new FileStream(path, FileMode.Append);
                sw = new StreamWriter(file);
                sw.WriteLine(e.Assunto);
                sw.WriteLine(e.CorpoDoEmail);
            }
            catch
            {
                Console.WriteLine("erro");
            }
            finally
            {
                if (file != null)
                    file.Close();
                // if (sw != null)
                //  sw.Close();
            }
        }
        private static void SendEmail(Email e)
        {
            string smtpServer = "smtp.gmail.com";
            string smtpLogin = login;
            string smtpPassword = senha;
            int smtpPort = 587;
            MailMessage message = new MailMessage(e.Remetente, e.Destinatario);
            message.Subject = e.Assunto;
            SmtpClient smtp = new SmtpClient(smtpServer, smtpPort);
            smtp.EnableSsl = smtpPort == 587;
            smtp.UseDefaultCredentials = smtpPort == 25;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            if (smtpPort == 587)
            {
                NetworkCredential cred = new NetworkCredential(smtpLogin, smtpPassword);
                smtp.Credentials = cred;
            }
            message.Body = GetHtml() + e.CorpoDoEmail + "</tr></table></table></tr></table>";
            message.IsBodyHtml = true;
            smtp.Send(message);

        }

        public static string GetHtml()
        {
            return  "<table border = \"0\" cellpadding = \"0\" cellspacing = \"0\" width = \"100%\">"+
                        "<tr>" +
                            "<td><table align=\"left\"border = \"0\"cellpadding = \"0\" cellspacing = \"0\" width = \"600\" >"+         
                                "<tr>"+
                                        "<td><h2> Segue relatório de tarefas gerado em " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "</h2></td>" +
                                "</tr>"+       
                                "<tr>"+
                                        "<td><table align=\"center\" style=\"width: 100%;font-size: 20px;color: rgb(119, 119, 119);background-color:rgba(0, 0, 0, 0.05);\">" +
                                                "<tr style=\"color: rgb(255, 255, 255);background-color: rgb(153, 153, 153);\">" +
                                                    "<th> Tarefa</th>" +
                                                    "<th> Status</th>" +
                                                    "<th> Data da ultima modificação: </th>" +
                                                    "<th> Autor</th>" +
                                                "</tr>";
        }
    }
}