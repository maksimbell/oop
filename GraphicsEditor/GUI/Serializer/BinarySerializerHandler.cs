using GUI.Drawer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Serializer
{
    public class BinarySerializerHandler<T> : SerializerCreateHandler<T>
    {
        public override ISerializer<T> CreateSerializer()
        {
            return new CustomBinarySerializer<T>();
        }
    }
}
