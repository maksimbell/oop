using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    [Serializable]
    public class PenState
    {
        private Color color;
        private int width;

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }
    }
}
