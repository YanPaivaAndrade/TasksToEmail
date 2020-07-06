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
    public static class SpamEmailService
    {
        private static readonly TarefaService _TarefaService = new TarefaService();

        public static void SendEmailPendente(int tempo)
        {
            int cont = 0;
            Task.Factory.StartNew(() =>
            {
                while (_TarefaService.FindAllPendente().Count > 0 && cont < 2)
                {
                    Thread.Sleep(tempo * 60000);
                    LogDoEmail(_TarefaService.FindAllPendente(), "Pendente");
                    Send("Pendente", _TarefaService.FindAllPendente());
                    cont++;
                }
            });
        }
        public static void SendEmailPendente()
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1 * 60000);
                LogDoEmail(_TarefaService.FindAllPendente(), "Pendente");
                Send("Pendente", _TarefaService.FindAllPendente());
            });
        }
        public static void SendEmailDimensionamento()
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1 * 60000);
                LogDoEmail(_TarefaService.FindAllDimensionamento(), "Dimensionamento");   
                Send("Dimensionamento", _TarefaService.FindAllDimensionamento());
            });
        }
        public static void SendEmailDesenvolvimento()
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1 * 60000);
                LogDoEmail(_TarefaService.FindAllDesenvolvimento(), "Desenvolvimento");
                Send("Desenvolvimento", _TarefaService.FindAllDesenvolvimento());
            });
        }
        public static void SendEmailEntregue()
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1 * 60000);
                LogDoEmail(_TarefaService.FindAllEntregue(), "Entregue");
                Send("Entregue", _TarefaService.FindAllEntregue());
            });
        }
        private static void LogDoEmail(List<Tarefa> list, string assunto)
        {
            FileStream file = null;
            StreamWriter sw = null;
            string path = @"C:\Users\yan_1\Documents\Rerum\TasksToEmail\log.txt";
            Email e = new Email();
            e.Assunto = "Tarefas " +assunto+ " ordenadas por Priority ";
            foreach (Tarefa t in list)
            {
                e.CorpoDoEmail += t.GetStatus();
                e.CorpoDoEmail += "\n\n";
            }
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
        private static void Send(string assunto, List<Tarefa> list)
        {
            DateTime data = DateTime.Now;
            string smtpServer = "smtp.gmail.com";
            string smtpLogin = "";
            string smtpPassword = "";
            int smtpPort = 587;

            Email e = new Email();
            e.Assunto = @"Tarefas " + assunto + " ordenadas por Priority";
            
            e.Destinatario = @"";
            e.Remetente = @"";
            MailMessage message = new MailMessage(e.Remetente, e.Destinatario);
            message.Subject = e.Assunto;
            foreach (Tarefa t in list)
            {
                e.CorpoDoEmail += t.GetStatus();
                e.CorpoDoEmail += "\n\n";
            }
            message.Body = @"Segue relatório do RAT gerado em "
                            +data.ToString("dd / MM / yyyy HH: mm") 
                            + ".\n" + e.CorpoDoEmail;

            SmtpClient smtp = new SmtpClient(smtpServer, smtpPort);
            smtp.EnableSsl = smtpPort == 587;
            smtp.UseDefaultCredentials = smtpPort == 25;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            if (smtpPort == 587)
            {
                NetworkCredential cred = new NetworkCredential(smtpLogin, smtpPassword);
                smtp.Credentials = cred;
            }

            smtp.Send(message);

        }
    }
}