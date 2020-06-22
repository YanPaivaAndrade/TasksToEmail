using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TasksToEmail.Models.Interface;

namespace TasksToEmail.Models
{
    public class TarefasDesenvolvimento : TarefaStatus
    {
        public string getStatus(Tarefa t)
        {
            return "Desenvolvimento.";
        }

        public void SetTarefaDesenvolvimento(Tarefa t)
        {
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
            t.SetStatus(new TarefasPendente());
        }
    }

}