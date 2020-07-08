using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TasksToEmail.Models.Enumerados;

namespace TasksToEmail.Models.ViewModel
{
    public class TarefaViewModel
    {
        public Tarefa Tarefa { get; set; }
        public List<string> StatusProp { get; set; }
        public List<string> TypeProp { get; set; }
        public List<int> SeverityProp { get; set; }
        public List<int> PriorityProp { get; set; }
        public TarefaViewModel()
        {
            TypeProp = new List<string>();
            StatusProp = new List<string>();
            SeverityProp = new List<int>();
            PriorityProp = new List<int>();
            StatusProp.Add("Pendente");
            StatusProp.Add("Dimensionamento");
            StatusProp.Add("Desenvolvimento");
            StatusProp.Add("Entregue");
            TypeProp.Add("Bug");
            TypeProp.Add("BackLog");
            SeverityProp.Add(1);
            SeverityProp.Add(2); 
            SeverityProp.Add(3);
            PriorityProp.Add(1);
            PriorityProp.Add(2);
            PriorityProp.Add(3);
        }
    }
}