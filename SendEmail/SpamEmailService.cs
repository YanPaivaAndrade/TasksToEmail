using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using TasksToEmail.Models;
using TasksToEmail.Services;
using TasksToEmail.Data;


namespace SendEmail
{
    public class SpamEmailService
    {
        private readonly TarefaService _TarefaService = new TarefaService(new TasksToEmailContext());
       
        public async Task EnviarEmailAutomatizado()
        {
           
             Action<List<Tarefa>> action = PreencherEmail;
             TimeSpan span = new TimeSpan(0, 0, 0, 15);
             List<Tarefa> list = _TarefaService.FindAllPendente();
             ThreadStart start = delegate { RunAfterTimespan(action, span, list); };
             Thread t4 = new Thread(start);
             t4.Start();
            if(_TarefaService.FindAllPendente().Count>0 || _TarefaService.FindAllPendente() != null)
            {
                await EnviarEmailAutomatizado();
            }

            
        }
        public static void RunAfterTimespan(Action<List<Tarefa>> action, TimeSpan span, List<Tarefa> list)
        {
            Thread.Sleep(span);
            action(list);
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
                if (sw != null)
                    sw.Close();
            }
            
        }
    }
}