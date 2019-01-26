using System;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectsHandler<User> usersHandler = new ObjectsHandler<User>();
            UsersMonitor usersObserver = new UsersMonitor("Users observer");
            UsersMonitor usersObserver2 = new UsersMonitor("Users observer2");
            var user = new User(name: "John Smith", age: 35);
            var user2 = new User(name: "Alex Davis", age: 41);
            usersObserver.Subscribe(usersHandler);
            usersHandler.AddObject(user);
            usersObserver2.Subscribe(usersHandler);
            usersHandler.AddObject(user2);
            usersHandler.AddObject(user);
            usersHandler.DeleteObject(user2);
            usersHandler.DeleteObject(user2);
            usersObserver.Unsubscribe();
            usersHandler.AddObject(user2);
            usersHandler.DeleteObject(user);
            Console.ReadKey();
        }
    }
}
