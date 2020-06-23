using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TasksToEmail.Models
{
    public class Email : IObserver<Tarefa>
    {
        private string Destinatario;
        private string Assunto;
        private string CorpoDoEmail;
        private IDisposable _disposer;



        public Email(IObservable<Tarefa> tarefa)
        {
            _disposer = tarefa.Subscribe(this);           
        }

        public string GetDestinatario()
        {
            return this.Destinatario;
        }
        public void SetDestinatario(string dest)
        {
            this.Destinatario = dest;
        }
        public string GetAssunto()
        {
            return this.Assunto;
        }
        public void SetAssunto(string assunto)
        {
            this.Assunto = assunto;
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