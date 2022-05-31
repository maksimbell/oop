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
        private static PluginLoader _instance;

        private const string AssemblyPath = "/bin/Debug/net6.0";
        private const string DllExt = ".dll";
        private List<Type> plugins = new List<Type>();
        private string Path { get; set; }

        public static PluginLoader GetInstance()
        {
            if (_instance == null) 
                _instance = new PluginLoader(); 

            return _instance;
        }

        private PluginLoader() { }

        public List<Type> Load(string plugin)
        {
            plugins.Clear();
            string pluginName = plugin.Split("\\")[^1];

            DirectoryInfo pluginDirectory = new DirectoryInfo(plugin + AssemblyPath);
            if (!pluginDirectory.Exists)
                pluginDirectory.Create();

            var pluginFiles = Directory.GetFiles(plugin + AssemblyPath, pluginName + DllExt);
            foreach (var file in pluginFiles)
            {
                Assembly asm = Assembly.LoadFrom(file);

                var types = asm.GetTypes();

                foreach (var type in types)
                {
                    if (type.FullName.Contains(pluginName))
                    {
                        plugins.Add(type);
                    }
                }
            }

            return plugins;
        }

        public List<Type> LoadStrangePlugins()
        {
            plugins.Clear();

            DirectoryInfo pluginDirectory = new DirectoryInfo(Path + "StrangePlugins" + AssemblyPath);
            if (!pluginDirectory.Exists)
                pluginDirectory.Create();

            var pluginFiles = Directory.GetFiles(Path + "StrangePlugins" + AssemblyPath, "*" + DllExt);
            foreach (var file in pluginFiles)
            {
                Assembly asm = Assembly.LoadFrom(file);

                var types = asm.GetTypes();

                foreach (var type in types)
                {
                    plugins.Add(type);
                }
            }

            return plugins;
        }
    }
}
