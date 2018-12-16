using System.IO;
using System.Xml.Serialization;

namespace Serialization
{
    class Xml
    {
        public static void Serialize<T>(T obj) where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextWriter writer = new StreamWriter(Path.Combine(Program.OutputDir, $"{typeof(T).Name}.xml")))
            {
                serializer.Serialize(writer, obj);
            }
        }

        public static void Deserialize<T>(string fullPath, out T obj) where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StreamReader(fullPath))
            {
                obj = (T)serializer.Deserialize(reader);
            }
        }
    }
}
