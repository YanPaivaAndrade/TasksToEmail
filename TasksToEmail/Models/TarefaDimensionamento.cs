using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TasksToEmail.Models.Interface;

namespace TasksToEmail.Models
{
    public class TarefasDimensionamento : TarefaStatus
    {
        public string getStatus(Tarefa t)
        {
            return "Dimensionamento";
        }

        public void SetTarefaDesenvolvimento(Tarefa t)
        {
            t.SetStatus(new TarefasDesenvolvimento);
        }

        public void SetTarefaDimensionamento(Tarefa t)
        {
        }

        public void SetTarefaEntregue(Tarefa t)
        {
            t.SetStatus(new TarefasEntregue());
        }

        public void SetTarefaPendente(Tarefa t)
        {
            t.SetStatus(new TarefasPendente());
        }
    }
}