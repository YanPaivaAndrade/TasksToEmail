using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TasksToEmail.Models.Interface;

namespace TasksToEmail.Models
{
    public class TarefasEntregue : TarefaStatus
    {
        public string getStatus()
        {
            return "Entregue";
        }

        public void SetTarefaDesenvolvimento(Tarefa t)
        {
        }

        public void SetTarefaDimensionamento(Tarefa t)
        {
        }

        public void SetTarefaEntregue(Tarefa t)
        {
        }

        public void SetTarefaPendente(Tarefa t)
        {
        }
    }
}