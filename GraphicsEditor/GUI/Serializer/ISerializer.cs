using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Serializer
{
    public interface ISerializer<T>
    {
        void Serialize(T obj, string filename);
        T Deserialize(string filename);
    }
}
