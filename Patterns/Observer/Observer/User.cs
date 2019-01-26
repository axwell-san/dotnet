namespace Observer
{
    public class User
    {
        private string _name;
        private int _age;

        public User(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public string Name => _name;
        public int Age => _age;
    }
}
