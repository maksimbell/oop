using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
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
            using (FileStream fs = new FileStream(filename, FileMode.Truncate))
            {
                try
                {
                    fs.Position = 0;
                    formatter.Serialize(fs, obj);
                }
                catch (Exception ex)
                {
                    if (ex is ArgumentException)
                    {
                        throw new CustomBinarySerializerException();
                    }
                    if (ex is SerializationException)
                    {
                        throw new CustomBinarySerializerException();
                    }
                    if (ex is SecurityException)
                    {
                        throw new CustomBinarySerializerException();
                    }
                    throw;
                }
            }
        }
        public T Deserialize(string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                try
                {
                    T obj = (T)formatter.Deserialize(fs);
                    return obj;
                }
                catch (Exception ex)
                {
                    if(ex is ArgumentException)
                    {
                        throw new CustomBinarySerializerException(); 
                    }
                    if (ex is SerializationException)
                    {
                        throw new CustomBinarySerializerException();
                    }
                    if (ex is SecurityException)
                    {
                        throw new CustomBinarySerializerException(); 
                    }
                    throw;
                }
            }
        }
    }
}
