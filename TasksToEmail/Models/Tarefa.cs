using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TasksToEmail.Models.Interface;

namespace TasksToEmail.Models
{
    public class Tarefa : IObservable<Email>
    {
        public int IdTarefa { get; set; }
        public string Titulo { get; set; }
        public string Type { get; set; }
        public TarefaStatus _Status { get; set; }
        public string Status { get; set; }
        public int Priority { get; set; }
        public int Severity { get; set; }
        public DateTime ChangeDate { get; set; }
        public string ChangeBy { get; set; }
        public List<IObserver<Email>> _emails { get; set; }
       


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
            return "Tarefa: " + this.Titulo
                + "\n Tipo: " + this.Type
                + "\n Status:" + _Status.getStatus()
                + "\n Prioridade: " + this.Priority
                + "\n Gravidade: " + this.Severity
                + "\n Data da ultima modificação: " + ChangeDate
                + "\n Altor: " + ChangeBy; 
        }
       

        public IDisposable Subscribe(IObserver<Email> observer)
        {
            if (!_emails.Contains(observer))
            {
                _emails.Add(observer);
            }
            return new Disposer(_emails, observer);
        }
        public void EnviarEmail()
        {
            
        }


    }
}