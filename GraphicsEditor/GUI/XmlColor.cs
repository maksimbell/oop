using System.Xml.Serialization;

public class XmlColor
{
    private Color color_ = Color.Black;

    public XmlColor() { }
    public XmlColor(Color c) { color_ = c; }


    public Color ToColor()
    {
        return color_;
    }

    public void FromColor(Color c)
    {
        color_ = c;
    }

    public static implicit operator Color(XmlColor x)
    {
        return x.ToColor();
    }

    public static implicit operator XmlColor(Color c)
    {
        return new XmlColor(c);
    }
}