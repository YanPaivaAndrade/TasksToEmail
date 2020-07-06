using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TasksToEmail.Models
{
    public class Email : IObserver<Tarefa>
    {
        public string Remetente { get; set; }
        public string Destinatario { get; set; }
        public string Assunto { get; set; }
        public string CorpoDoEmail { get; set;}
        private IDisposable _disposer;
        public Email() { 
        }
        public Email(IObservable<Tarefa> tarefa)
        {
            _disposer = tarefa.Subscribe(this);           
        }
        public void OnNext(Tarefa value)
        {
            if(CorpoDoEmail == null)
            {
                CorpoDoEmail = value.GetStatus();
            }
            else
            {
                CorpoDoEmail += "\n \n" + value.GetStatus();
            }
        }
        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            _disposer.Dispose();
        }
        
    }
}