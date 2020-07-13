using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TasksToEmail.Models.Interface;

namespace TasksToEmail.Models
{
    public class Tarefa     {
        public int IdTarefa { get; set; }
        public string Titulo { get; set; }
        public string Type { get; set; }
        public TarefaStatus _Status { get; set; }
        public string Status { get; set; }
        public int Priority { get; set; }
        public int Severity { get; set; }
        public DateTime ChangeDate { get; set; }
        public string ChangeBy { get; set; }
       


        public Tarefa()
        {
            
        }

       
        public void SetStatus(TarefaStatus status)
        {
            this._Status = status;
        }
        public void SetTarefaDesenvolvimento()
        {
            _Status.SetTarefaDesenvolvimento(this);
            Status = _Status.getStatus();
        }
        public void SetTarefaDimensionamento() 
        {
            _Status.SetTarefaDimensionamento(this);
            Status = _Status.getStatus();
        }

        public void SetTarefaEntregue() 
        {
            _Status.SetTarefaEntregue(this);
            Status = _Status.getStatus();
        }
        public void SetTarefaPendente()
        {
            _Status.SetTarefaPendente(this);
            Status = _Status.getStatus();
        }
        public string GetStatus()
        {
            return          "<tr>"+
                                "<td onclick=\"location.href = 'http://www.google.com'; \"style=\"cursor:  pointer; \">" + Titulo + "</td>" +
                                "<td>" + Status + "</td>"+
                                "<td>" + ChangeDate + "</td>"+
                                "<td>" + ChangeBy + "</td>"+
                            "</tr>";
        }
       
    }
}