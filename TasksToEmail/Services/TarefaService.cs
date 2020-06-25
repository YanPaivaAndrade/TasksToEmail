using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TasksToEmail.Data;
using TasksToEmail.Models;

namespace TasksToEmail.Services
{
    public class TarefaService
    {
        private readonly TasksToEmailContext _context;
        public TarefaService(TasksToEmailContext context)
        {
            _context = context;
        }
        public List<Tarefa> FindAll()
        {
            var tarefas = (from obj in _context.Tarefas select obj).OrderBy(tarefa => tarefa.Priority).ToList();
            return  tarefas;
        }
        public List<Tarefa> FindAllPendente()
        {
            var tarefas = (from obj in _context.Tarefas where obj.Status.Equals("Pendente") select obj).OrderBy(tarefa => tarefa.Priority).ToList();
            return tarefas;
        }


    }
}