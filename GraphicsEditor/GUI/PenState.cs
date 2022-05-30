using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Windows;

namespace GUI
{
    [Serializable]
    public class PenState
    {
        [XmlIgnore]
        private Color color;
        private int rgb;
        private float width;

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public int RGB
        {
            get { return rgb; }
            set { rgb = value; }
        }

        public float Width
        {
            get { return width; }
            set { width = value; }
        }

        public PenState() { }
    }
}
