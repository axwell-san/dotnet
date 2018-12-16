using System;
using System.IO;
using System.Reflection;

namespace Serialization
{
    class Program
    {
        public static string OutputDir => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        static void Main(string[] args)
        {
            Student student = new Student
            {
                Id = Guid.NewGuid(),
                FirstName = "Billy",
                SecondName = "Jim",
                Age = 21,
                Contact = new Contact
                {
                    Address = "Big str. 1",
                    PhoneNumber = 123456789
                }
            };

            Xml.Serialize(student);
            Xml.Deserialize(Path.Combine(Program.OutputDir, $"{typeof(Student).Name}.xml"), out student);

            Json.Serialize(student);
            Json.Deserialize(Path.Combine(Program.OutputDir, $"{typeof(Student).Name}.json"), out student);

            Binary.Serialize(student);
            Binary.Deserialize(Path.Combine(Program.OutputDir, typeof(Student).Name), out student);
        }
    }
}
