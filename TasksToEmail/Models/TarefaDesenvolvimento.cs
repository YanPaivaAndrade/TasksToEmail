using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TasksToEmail.Models.Interface;

namespace TasksToEmail.Models
{
    public class TarefaDesenvolvimento : TarefaStatus
    {
        public string getStatus()
        {
            return "Desenvolvimento.";
        }

        public void SetTarefaDesenvolvimento(Tarefa t)
        {
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
            t.SetStatus(new TarefaPendente());
        }
    }

}