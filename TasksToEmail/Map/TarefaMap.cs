using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TasksToEmail.Models;

namespace TasksToEmail.Map
{
    public class TarefaMap : EntityTypeConfiguration<Tarefa>
    {
        public TarefaMap()
        {
            this.ToTable("Tarefa");
            this.HasKey( obj => obj.IdTarefa);
            this.Property(obj => obj.Titulo).HasColumnName("Title");
            this.Property(obj => obj.Type).HasColumnName("Type");
            this.Property(obj => obj.Status).HasColumnName("Status");
            this.Property(obj => obj.Priority).HasColumnName("Priority");
            this.Property(obj => obj.Severity).HasColumnName("Severity");
            this.Property(obj => obj.ChangeDate).HasColumnName("ChangeDate");
            this.Property(obj => obj.ChangeBy).HasColumnName("ChangeBy");



        }

    }
}