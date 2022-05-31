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
using System.Xml.Linq;
using FilledCircle;
using BaseFigure;
using FilledHexagon;
using FilledTriangle;
using ShapePlugins;
using System.Runtime.Serialization;
using System.Security;

namespace SerializerPlugins.CustomBinaryXmlSerializer
{
    public class CustomBinaryXmlSerializer<T> : ISerializer<T>
    {
        public CustomBinaryXmlSerializer() { }
        public void Serialize(T obj, string filename)
        {
            Type[] types = new Type[] { typeof(MemoryStream), typeof(Shape), typeof(Line), typeof(Rect), typeof(Square),
                typeof(Triangle), typeof(Ellipse), typeof(Circle), typeof(Rhombus),
            typeof(RightTriangle), typeof(FilledTriangle.FilledTriangle)};

            BinaryFormatter binFormatter = new BinaryFormatter(); 
            byte[] buf;

            using (MemoryStream ms = new MemoryStream())
            {
                try
                {
                    ms.Position = 0;
                    binFormatter.Serialize(ms, obj);
                    buf = ms.ToArray();
                }
                catch (Exception ex)
                {
                    if (ex is ArgumentException)
                    {
                        throw new CustomSerializerException();
                    }
                    if (ex is SerializationException)
                    {
                        throw new CustomSerializerException();
                    }
                    if (ex is SecurityException)
                    {
                        throw new CustomSerializerException();
                    }
                    throw;
                }
            }

            XmlSerializer xmlFormatter = new XmlSerializer(typeof(byte[]), types);
            using (FileStream fs = new FileStream(filename, FileMode.Truncate))
            {
                try
                {
                    fs.Position = 0;
                    xmlFormatter.Serialize(fs, buf);
                }
                catch (Exception ex)
                {
                    if (ex is InvalidOperationException)
                    {
                        throw new CustomSerializerException();
                    }
                }
            }

        }

        public T Deserialize(string filename)
        {
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(byte[]));
            byte[] buf;
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                try
                {
                    buf = (byte[])xmlFormatter.Deserialize(fs);
                }
                catch (Exception ex)
                {
                    if (ex is InvalidOperationException)
                    {
                        throw new CustomSerializerException();
                    }
                    if (ex is SerializationException)
                    {
                        throw new CustomSerializerException();
                    }
                    if (ex is SecurityException)
                    {
                        throw new CustomSerializerException();
                    }
                    throw;
                }
            }

            BinaryFormatter binFormatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(buf))
            {
                try
                {
                    T obj = (T)binFormatter.Deserialize(ms);
                    return obj;
                }
                catch (Exception ex)
                {
                    if (ex is ArgumentException)
                    {
                        throw new CustomSerializerException();
                    }
                    if (ex is SerializationException)
                    {
                        throw new CustomSerializerException();
                    }
                    if (ex is SecurityException)
                    {
                        throw new CustomSerializerException();
                    }
                    throw;
                }
            }
        }

        public string toString()
        {
            return "BinXML";
        }
    }
}
