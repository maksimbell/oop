using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using GUI.Serializer;
using System.Xml.Serialization;
using GUI.Drawer;
using GUI;
using System.Drawing;
using System.Xml.Xsl;
using System.Xml;

namespace SerializerPlugins.CustomXmlSerializer
{
    public class CustomXmlSerializer<T> : ISerializer<T>
    {
        public CustomXmlSerializer() { }
        public void Serialize(T obj, string filename)
        {
            Type[] types = new Type[] { typeof(Shape), typeof(Line), typeof(Rect), typeof(Square),
                typeof(Triangle), typeof(Ellipse), typeof(Circle), typeof(ShapePlugins.Rhombus),
            typeof(ShapePlugins.RightTriangle)};

            XmlSerializer formatter = new XmlSerializer(typeof(T), types);
            using (FileStream fs = new FileStream(filename, FileMode.Truncate))
            {
                fs.Position = 0;
                formatter.Serialize(fs, (T)obj);
            }
        }
        public T Deserialize(string filename)
        {
            Type type = typeof(T);
            XmlSerializer formatter = new XmlSerializer(type);
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                T obj = (T)formatter.Deserialize(fs);
                return obj;
            }
        }

        public string toString()
        {
            return "XML";
        }
    }
}
