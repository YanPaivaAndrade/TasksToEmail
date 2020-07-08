using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using TasksToEmail.Data;
using TasksToEmail.Models;
using TasksToEmail.Services.Exceções;

namespace TasksToEmail.Services
{
    public class TarefaService
    {
        private readonly TasksToEmailContext _context = new TasksToEmailContext();
        public TarefaService()
        {
        }

        public Tarefa FindById(int id)
        {
            var tarefa1 = (from obj in _context.Tarefas where obj.IdTarefa.Equals(id) select obj).FirstOrDefault();
            return tarefa1;
        }
        public List<Tarefa> FindAll()
        {
            var tarefas = (from obj in _context.Tarefas select obj).OrderByDescending(tarefa => tarefa.Priority).ToList();
            return tarefas;
        }
        public List<Tarefa> FindAllPendente()
        {
            var tarefas = (from obj in _context.Tarefas where obj.Status.Equals("Pendente") select obj).OrderBy(tarefa => tarefa.Priority).ToList();
            return tarefas;
        }
        public List<Tarefa> FindAllDimensionamento()
        {
            var tarefas = (from obj in _context.Tarefas where obj.Status.Equals("Dimensionamento") select obj).OrderBy(tarefa => tarefa.Priority).ToList();
            return tarefas;
        }
        public List<Tarefa> FindAllDesenvolvimento()
        {
            var tarefas = (from obj in _context.Tarefas where obj.Status.Equals("Desenvolvimento") select obj).OrderBy(tarefa => tarefa.Priority).ToList();
            return tarefas;
        }

        public void Update(Tarefa tarefa)
        {
            bool validadorDeObj = _context.Tarefas.Any(obj => obj.IdTarefa == tarefa.IdTarefa);
            if (validadorDeObj)
            {
                _context.Entry(tarefa).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
            try
            {
                _context.Entry(tarefa).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public List<Tarefa> FindAllEntregue()
        {
            var tarefas = (from obj in _context.Tarefas where obj.Status.Equals("Entregue") select obj).OrderBy(tarefa => tarefa.Priority).ToList();
            return tarefas;
        }

        public void Insert(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            try
            {
                var tarefa = FindById(id);
                _context.Tarefas.Remove(tarefa);
                _context.SaveChanges();
            }
            catch(DbUpdateException)
            {
                throw new IntegrityException("Não foi possível completar a deleção.");
            }
            
        }
    }
}