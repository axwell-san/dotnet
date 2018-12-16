using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization
{
    class Binary
    {
        public static void Serialize<T>(T obj) where T : class
        {
            BinaryFormatter serializer = new BinaryFormatter();
            using (Stream stream = File.Open(Path.Combine(Program.OutputDir, typeof(T).Name), FileMode.Create))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, obj);
            }
        }

        public static void Deserialize<T>(string fullPath, out T obj) where T : class
        {
            BinaryFormatter serializer = new BinaryFormatter();
            using (Stream stream = File.Open(Path.Combine(Program.OutputDir, typeof(T).Name), FileMode.Open))
            {
                obj = (T)serializer.Deserialize(stream);
            }
        }
    }
}
