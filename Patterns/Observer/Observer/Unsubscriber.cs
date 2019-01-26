using System;
using System.Collections.Generic;

namespace Observer
{
    public class Unsubscriber<T> : IDisposable
    {
        private IList<IObserver<IList<T>>> _observers;
        private IObserver<IList<T>> _observer;

        internal Unsubscriber(IList<IObserver<IList<T>>> observers, IObserver<IList<T>> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}
