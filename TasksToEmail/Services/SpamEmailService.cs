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
    public class SpamEmailService
    {
        private readonly TarefaService _TarefaService = new TarefaService(new Data.TasksToEmailContext());
       
        public bool Test()
        {
            if (_TarefaService.FindAllPendente().Count > 0 || _TarefaService.FindAllPendente() != null)
                return true;
            return false;
        }
        public async Task EnviarEmailAutomatizado(int? cont)
        {
            Thread.Sleep(500);
            List<Tarefa> list = _TarefaService.FindAllPendente();
            PreencherEmail(list);
           /* if (cont > 0)
                EnviarEmailAutomatizado(cont--);
            else
                return;
           */
        }
       
        private void PreencherEmail(List<Tarefa> list)
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