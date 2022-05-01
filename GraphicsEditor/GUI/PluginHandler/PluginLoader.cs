using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using GUI.Interfaces;
using GUI.Drawer;

namespace GUI.PluginHandler
{
    public class PluginLoader
    {
        private List<Type> plugins = new List<Type>();
        private string Path { get; set; }
        public PluginLoader(string path)
        {
            Path = path;
        }

        public List<Type> Load(string plugin)
        {
            plugins.Clear();

            DirectoryInfo pluginDirectory = new DirectoryInfo(Path);
            if (!pluginDirectory.Exists)
                pluginDirectory.Create();

            var pluginFiles = Directory.GetFiles(Path, "ShapePlugins.dll");
            foreach (var file in pluginFiles)
            {
                Assembly asm = Assembly.LoadFrom(file);

                var types = asm.GetTypes();

                foreach (var type in types)
                {
                    if (type.FullName.Contains(plugin)) {
                        plugins.Add(type);
                    }
                }
            }

            return plugins;
        }
    }
}
