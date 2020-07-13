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
        private static string login = "";
        private static string senha = "";
        private static string destinatario = "";
        private static string remetente = "";

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
                    LogDoEmail(_TarefaService.FindAllPendente(), "Pendente");
                    Send("Pendente", _TarefaService.FindAllPendente());
                    cont++;
                }
            });
        }
        public static void SendEmailPendente(Email e)
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1 * 60000);
                LogDoEmailCustom(e);
                SendCustom(e);
            });
        }
        public static void SendEmailDimensionamento(Email e)
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1 * 60000);
                LogDoEmailCustom(e);
                SendCustom(e);
            });
        }
        public static void SendEmailDesenvolvimento(Email e)
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1 * 60000);
                LogDoEmailCustom(e);
                SendCustom(e);
            });
        }
        public static void SendEmailEntregue(Email e)
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1 * 60000);
                LogDoEmailCustom(e);
                SendCustom(e);
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
            int smtpPort = 587;
            SmtpClient smtp = new SmtpClient(smtpServer, smtpPort);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            NetworkCredential cred = new NetworkCredential(login, senha);
            smtp.Credentials = cred;
            smtp.EnableSsl = true;


            Email e = new Email();
            e.Assunto = "Tarefas " + assunto + " ordenadas por Priority";
            e.Destinatario = destinatario;
            e.Remetente = remetente;
            MailMessage message = new MailMessage();
            message.To.Add(destinatario);
            message.From = new MailAddress(remetente);
            message.Subject = e.Assunto;
            message.IsBodyHtml = true;

            e.CorpoDoEmail = GetHtml();
            foreach (Tarefa t in list)
            {
                e.CorpoDoEmail += t.GetStatus();                
            }
            e.CorpoDoEmail += "</table>";
            message.Body = e.CorpoDoEmail;
            smtp.Send(message);

        }
        private static void LogDoEmailCustom(Email e)
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
        private static void SendCustom(Email e)
        {
            DateTime data = DateTime.Now;
            string smtpServer = "smtp.gmail.com";
            string smtpLogin = login;
            string smtpPassword = senha;
            int smtpPort = 587;
            MailMessage message = new MailMessage(e.Remetente, e.Destinatario);
            message.Subject = e.Assunto;
            message.Body = @"Segue relatório do RAT gerado em "
                            + data.ToString("dd / MM / yyyy HH: mm")
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

        public static string GetHtml()
        {
            return "<table  class=\"table table-striped table-hover\">" +
                                "<tr class=\"badge-secondary bg-primary\">" +
                                    "<th> Tarefa</th>" +
                                    "<th> Status</th>" +
                                    "<th> Data da ultima modificação: </th>" +
                            "<th> Autor</th>" +
                            "</tr>";
        }
    }
}