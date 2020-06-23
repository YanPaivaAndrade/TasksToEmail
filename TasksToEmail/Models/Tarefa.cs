using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TasksToEmail.Models.Interface;

namespace TasksToEmail.Models
{
    public class Tarefa : IObservable<Email>
    {
        private string Titulo;
        private string Type;
        private TarefaStatus _Status;
        private int Priority;
        private int Severity;
        private DateTime ChangeDate;
        private string ChangeBy;
        private List<IObserver<Email>> _emails;
        private Email _email;


        public Tarefa()
        {
            _Status = new TarefasPendente();
            _emails = new List<IObserver<Email>>();
        }

        public string GetTitulo()
        {
            return this.Titulo;
        }
        public void SetTitulo(string titulo)
        {
            this.Titulo = titulo;
        }
        public string GetType()
        {
            return this.Type;
        }
        public void SetType(string type)
        {
            this.Type = type;
        }
        public void SetStatus(TarefaStatus status)
        {
            this._Status = status;
        }
        public string GetStatus()
        {
            return "Tarefa: " + this.GetTitulo()
                + "\n Tipo: " + this.GetType()
                + "\n Status:" + _Status.getStatus()
                + "\n Prioridade: " + this.GetPriority()
                + "\n Gravidade: " + this.GetSeverity()
                + "\n Data da ultima modificação: " + this.GetChangeDate()
                + "\n Altor: " + this.GetTChangeBy(); ;
        }
        public int GetPriority()
        {
            return this.Priority;
        }
        public void SetPriority(int nivel)
        {
            this.Priority = nivel;
        }
        public int GetSeverity()
        {
            return this.Severity;
        }
        public void SetSeverity(int nivel)
        {
            this.Severity = nivel;
        }
        public DateTime GetChangeDate()
        {
            return ChangeDate;
        }
        public void SetChangeDate(DateTime data)
        {
            this.ChangeDate = data;
        }
        public string GetTChangeBy()
        {
            return this.ChangeBy;
        }
        public void SetTChangeBy(string autor)
        {
            this.ChangeBy = autor;
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

            foreach (IObserver<Email> email in _emails)
            {
                email.OnNext(_email);
            }
        }


    }
}