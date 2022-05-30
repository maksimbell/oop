using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI;
using GUI.Drawer;
using GUI.ShapeHandlers;

namespace GUI.Serializer
{
    public class SerializerCreator<T>
    {
        private SerializerTypeHandler<T> serializerTypeHandler;
        public SerializerCreator(List<Type> serializerPlugins, List<Type> serializerHandlerPlugins)
        {
            serializerTypeHandler = new SerializerTypeHandler<T>(serializerPlugins, serializerHandlerPlugins);
        }

        public ISerializer<T> GetSerializer(string currentSerializer)
        {
            return serializerTypeHandler.getHandler(currentSerializer).CreateSerializer();
        }

    }
}
