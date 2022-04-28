using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using GUI.Interfaces;

namespace GUI.PluginHandler
{
    public class PluginLoader
    {
        private List<IPlugin> plugins = new List<IPlugin>();
        private string Path { get; set; }
        public PluginLoader(string path)
        {
            Path = path;
        }

        public void Load()
        {
            plugins.Clear();

            DirectoryInfo pluginDirectory = new DirectoryInfo(Path);
            if (!pluginDirectory.Exists)
                pluginDirectory.Create();

            var pluginFiles = Directory.GetFiles(Path, "PluginShapes.dll");
            foreach (var file in pluginFiles)
            {
                Assembly asm = Assembly.LoadFrom(file);

                var types = asm.GetTypes().
                                Where(t => t.GetInterfaces().
                                Where(i => i.FullName == typeof(IPlugin).FullName).Any());

                foreach (var type in types)
                {
                    var plugin = asm.CreateInstance(type.FullName) as IPlugin;
                    plugins.Add(plugin);
                }

                types = types;
            }
        }
    }
}
