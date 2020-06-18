using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksToEmail.Models.Interface
{
    interface TarefaStatus
    {
        void SetTarefaDesenvolvimento(Tarefa t);
        void SetTarefaDimensionamento(Tarefa t);
        void SetTarefaEntregue(Tarefa t);
        void SetTarefaPendente(Tarefa t);
        string getStatus();
    }
}
