using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TasksToEmail.Models.Interface;

namespace TasksToEmail.Models
{
    public class TarefasPendente : TarefaStatus
    {
        public string getStatus(Tarefa t)
        {
            return "Pendente.";
        }

        public void SetTarefaDesenvolvimento(Tarefa t)
        {
            t.SetStatus(new TarefasDesenvolvimento());
        }

        public void SetTarefaDimensionamento(Tarefa t)
        {
            t.SetStatus(new TarefasDimensionamento());
        }

        public void SetTarefaEntregue(Tarefa t)
        {
            t.SetStatus(new TarefasEntregue());
        }

        public void SetTarefaPendente(Tarefa t)
        {
        }
    }
}