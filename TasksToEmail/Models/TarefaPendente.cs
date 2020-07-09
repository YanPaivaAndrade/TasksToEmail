using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TasksToEmail.Models.Interface;

namespace TasksToEmail.Models
{
    public class TarefaPendente : TarefaStatus
    {
        public string getStatus()
        {
            return "Pendente.";
        }

        public void SetTarefaDesenvolvimento(Tarefa t)
        {
            t.SetStatus(new TarefaDesenvolvimento());
        }

        public void SetTarefaDimensionamento(Tarefa t)
        {
            t.SetStatus(new TarefaDimensionamento());
        }

        public void SetTarefaEntregue(Tarefa t)
        {
            t.SetStatus(new TarefaEntregue());
        }

        public void SetTarefaPendente(Tarefa t)
        {
        }
    }
}