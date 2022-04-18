using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Serializer
{
    public class CustomBinarySerializer<T> : ISerializer<T>
    {
        public CustomBinarySerializer() { }
        public void Serialize(T obj, string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
        }
        public T Deserialize(string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                T obj = (T)formatter.Deserialize(fs);
                return obj;
            }
        }
    }
}
