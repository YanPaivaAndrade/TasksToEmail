using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace TasksToEmail.Models.Interface
{
    public interface TarefaStatus
    {
        
        void SetTarefaDesenvolvimento(Tarefa t);
        void SetTarefaDimensionamento(Tarefa t);
        void SetTarefaEntregue(Tarefa t);
        void SetTarefaPendente(Tarefa t);
        string getStatus(Tarefa t);
        string getStatus();
    }
}
