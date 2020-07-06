using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public static void SendEmail(int tempo)
        {
            int cont = 0;
            Task.Factory.StartNew(() =>
            {
                while (_TarefaService.FindAllPendente().Count > 0 && cont < 2)
                {
                    Thread.Sleep(tempo * 60000);
                    PreencherEmail(_TarefaService.FindAllPendente());
                    cont++;
                }
            });
        }
        private static void PreencherEmail(List<Tarefa> list)
        {
            FileStream file = null;
            StreamWriter sw = null;
            string path = @"C:\Users\yan_1\Documents\Rerum\TasksToEmail\email.txt";
            Email e = new Email();
            e.Assunto = "Tarefas  pendentes ordenadas por Priority ";
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

    }
}