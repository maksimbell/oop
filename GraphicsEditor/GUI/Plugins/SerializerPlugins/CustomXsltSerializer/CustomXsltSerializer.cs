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
using System.Xml.Linq;
using System.Runtime.Serialization;
using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace SerializerPlugins.CustomXsltSerializer
{
    public class CustomXsltSerializer<T> : ISerializer<T>
    {
        private string xslt =
        @"<?xml version='1.0'?>
        <xsl:stylesheet xmlns:xsl='http://www.w3.org/1999/XSL/Transform' version='1.0'>
          <xsl:template match='/Shape'>
               <StartPoint>
                    <xsl:value-of select='X'/>
                    <xsl:value-of select='Y'/>
               </StartPoint>
          </xsl:template>
        </xsl:stylesheet>";

        public CustomXsltSerializer() { }
        public void Serialize(T obj, string filename)
        {
            /*Type[] types = new Type[] { typeof(Shape), typeof(Line), typeof(Rect), typeof(Square),
                typeof(Triangle), typeof(Ellipse), typeof(Circle), typeof(ShapePlugins.Rhombus),
            typeof(ShapePlugins.RightTriangle)};*/

            /*XDocument xDocument = new XDocument(
                     new XElement("Shape",
                       new XAttribute("StartPoint", new XAttribute("X", )),
                       new XElement("FirstName", "Alex"),
                       new XElement("LastName", "Erohin")));*/

            XDocument oldDocument = XDocument.Load("C:/Users/maksimbell/bsuir/4sem/oop/labs/GraphicsEditor/GUI/bin/Debug/net6.0-windows/assets/simple_rect.xml");
            var newDocument = new XDocument();

            using (var stringReader = new StringReader(xslt))
            {
                using (XmlReader xsltReader = XmlReader.Create(stringReader))
                {
                    var transformer = new XslCompiledTransform();
                    transformer.Load(xsltReader);
                    using (XmlReader oldDocumentReader = oldDocument.CreateReader())
                    {
                        using (XmlWriter newDocumentWriter = newDocument.CreateWriter())
                        {
                            transformer.Transform(oldDocumentReader, newDocumentWriter);
                        }
                    }
                }
            }

            string result = newDocument.ToString();
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
