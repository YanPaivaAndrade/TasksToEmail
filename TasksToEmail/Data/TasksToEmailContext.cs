using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TasksToEmail.Map;
using TasksToEmail.Models;

namespace TasksToEmail.Data
{
    public class TasksToEmailContext : DbContext
    {
        public TasksToEmailContext() : base("Server=DESKTOP-IGNV26B\\SQLEXPRESS; Database=BancoDeTarefas;Integrated Security = True;")
        {
        }
        public DbSet<Tarefa> Tarefas { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<TasksToEmailContext>(null);
            modelBuilder.Configurations.Add(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}