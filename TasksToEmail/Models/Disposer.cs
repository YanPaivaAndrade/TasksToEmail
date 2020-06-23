using System;
using System.Collections.Generic;

namespace TasksToEmail.Models
{
    public class Disposer : IDisposable
    {
        private List<IObserver<Email>> _emails;
        private IObserver<Email> observer;

        public Disposer(List<IObserver<Email>> emails, IObserver<Email> observer)
        {
            _emails = emails;
            this.observer = observer;
        }
        public void Dispose()
        {
            if (_emails.Contains(observer))
                _emails.Remove(observer);
        }
    }
}