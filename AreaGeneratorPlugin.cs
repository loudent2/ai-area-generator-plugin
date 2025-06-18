using System;
using System.Windows.Forms;

#if PLUGIN
using NWN2Toolset.Plugins;
using TD.SandBar;
#endif

namespace AIAreaGeneratorPlugin
{
#if PLUGIN
    public class AIAreaGeneratorPlugin : INWN2Plugin
    {
        private MenuButtonItem _menuItem;

        public string Name => "AIAreaGeneratorPlugin";
        public string DisplayName => "AI Area Generator";
        public string MenuName => "AI Area Generator";
        public object Preferences { get => null; set { } }

        public void Load(INWN2PluginHost host) { }

        public void Startup(INWN2PluginHost host)
        {
            _menuItem = host.GetMenuForPlugin(this);
            _menuItem.Activate += HandlePluginLaunch;
        }

        public void Shutdown(INWN2PluginHost host) { }

        public void Unload(INWN2PluginHost host) { }

        public MenuButtonItem PluginMenuItem => _menuItem;

        private Form generatorForm;

        private void HandlePluginLaunch(object sender, EventArgs e)
        {
            if (generatorForm == null || generatorForm.IsDisposed)
            {
                generatorForm = new AreaGenForm();
                NWN2Toolset.NWN2ToolsetMainForm.App.AddOwnedForm(generatorForm);
            }

            generatorForm.Show();
            generatorForm.BringToFront();
        }
    }
#else
    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run(new AreaGenForm());
        }
    }
#endif
}
