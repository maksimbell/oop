using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI.Drawer;

namespace GUI.Serializer
{
    public abstract class SerializerCreateHandler<T>
    {
        public abstract ISerializer<T> CreateSerializer();
    }
}
