using GUI.ShapeHandlers;
using GUI.Drawer;

namespace GUI.Serializer
{
    public class SerializerTypeHandler<T>
    {
        public Dictionary<string, SerializerCreateHandler<T>> serializerCreateHandlers;
        public SerializerTypeHandler(List<Type> serializerPlugins, List<Type> serializerHandlerPlugins)
        {
            serializerCreateHandlers =
            new Dictionary<string, SerializerCreateHandler<T>> {
                {"CustomBinarySerializer", new BinarySerializerHandler<T>() },
            };

            // add plugins here
            for (int i = 0; i < serializerPlugins.Count; i++)
            { 
                Type t = serializerHandlerPlugins[i];
                Type[] typeArgs = { typeof(Shape)};
                Type constructed = t.MakeGenericType(typeArgs);
                object o = Activator.CreateInstance(constructed);

                serializerCreateHandlers[serializerPlugins[i].ToString().Split('.')[1]] = (SerializerCreateHandler<T>)o;
            }
        }

        public SerializerCreateHandler<T> getHandler(string currentSerializer)
        {
            return serializerCreateHandlers[currentSerializer];
        }
    }
}
