using System;
using System.Collections.Generic;

namespace Observer
{
    public class ObjectsHandler<T> : IObservable<IList<T>>
    {
        private IList<IObserver<IList<T>>> _observers;
        private IList<T> _objects;

        public ObjectsHandler()
        {
            _observers = new List<IObserver<IList<T>>>();
            _objects = new List<T>();
        }

        public IDisposable Subscribe(IObserver<IList<T>> observer)
        {
            _observers.Add(observer);
            observer.OnNext(_objects);

            return new Unsubscriber<T>(_observers, observer);
        }

        public void AddObject(T obj)
        {
            Exception e = null;

            if (_objects.Contains(obj))
            {
                e = new Exception("object to add already exists");
            }
            else
            {
                _objects.Add(obj);
            }

            NotifyObservers(e);
        }

        public void DeleteObject(T obj)
        {
            Exception e = null;

            if (!_objects.Contains(obj))
            {
                e = new Exception("object to delete not found");
            }
            else
            {
                _objects.Remove(obj);
            }

            NotifyObservers(e);
        }

        private void NotifyObservers(Exception exception = null)
        {
            if (exception != null)
            {
                foreach (var observer in _observers)
                {
                    observer.OnError(exception);
                }
            }
            else
            {
                foreach (var observer in _observers)
                {
                    observer.OnNext(_objects);
                }
            }
        }
    }
}
