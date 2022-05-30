using GUI.Drawer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI.Serializer;

namespace SerializerPlugins.CustomXmlSerializer
{
    public class XMLSerializerHandler<T> : SerializerCreateHandler<T>
    {
        public override ISerializer<T> CreateSerializer()
        {
            return new CustomXmlSerializer<T>();
        }
    }
}
