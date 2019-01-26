using System;
using System.Collections.Generic;

namespace Observer
{
    public class UsersMonitor : IObserver<IList<User>>
    {
        private string _name;
        private int? _usersCount;
        private IDisposable cancellation;

        public UsersMonitor(string name)
        {
            _name = name;
        }

        public virtual void Subscribe(ObjectsHandler<User> provider)
        {
            cancellation = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            cancellation.Dispose();
            Console.WriteLine($"Observer '{_name}' has been unsubscribed");
        }

        public void OnNext(IList<User> value)
        {
            if (_usersCount != null)
            {
                if (value?.Count > _usersCount)
                {
                    Console.WriteLine($"{_name} has been notified: new user was added");
                }

                if (value?.Count < _usersCount)
                {
                    Console.WriteLine($"{_name} has been notified: user was deleted");
                }

                PrintUsers(value);
            }

            _usersCount = value.Count;
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"{_name} has been notified: {error.Message}");
        }

        public void OnCompleted()
        {
        }

        private void PrintUsers(IList<User> value)
        {
            Console.WriteLine("Users:");

            foreach (var user in value)
            {
                Console.Write($"{user.Name} {user.Age}\n");
            }
        }
    }
}

