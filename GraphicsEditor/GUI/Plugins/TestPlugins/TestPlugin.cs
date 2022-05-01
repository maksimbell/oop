using GUI.Interfaces;
using GUI.Drawer;

namespace TestPlugins
{
    public class TestPlugin : IPlugin
    {
        public string Activate(string text)
        {
            return text.ToLower();
        }
    }
}