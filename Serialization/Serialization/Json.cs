using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;

namespace Serialization
{
    class Json
    {
        public static void Serialize<T>(T obj) where T : class
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            using (FileStream fs = new FileStream(Path.Combine(Program.OutputDir, $"{typeof(T).Name}.json"), FileMode.Create))
            {
                using (var rw = JsonReaderWriterFactory.CreateJsonWriter(fs, Encoding.UTF8))
                {
                    serializer.WriteObject(rw, obj);
                }
            }
        }

        public static void Deserialize<T>(string fullPath, out T obj) where T : class
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            using (FileStream fileStream = new FileStream(fullPath, FileMode.Open))
            {
                using (XmlDictionaryReader r = JsonReaderWriterFactory.CreateJsonReader(fileStream, Encoding.UTF8, XmlDictionaryReaderQuotas.Max, null))
                {
                    obj = (T)serializer.ReadObject(r);
                }
            }
        }
    }
}
