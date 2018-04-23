using System.Diagnostics;
using System.Windows.Controls;
using DewManager.Configs;
using MahApps.Metro.Controls;

namespace DewManager.Views
{
    /// <summary>
    /// Interaction logic for ConfigView.xaml
    /// </summary>
    public partial class ConfigView : StackPanel
    {
        private ConfigBundle config;
        
        public ConfigView(ConfigBundle config)
        {
            InitializeComponent();

            this.config = config;
            
            InitializeLoadedComponents();
        }

        private void InitializeLoadedComponents()
        {
            Debug.WriteLine("Tab Loaded for: " + config.DewritoConfig.getServerName());
            ConfigIndex.Text = "Config Name: " + config.DewritoConfig.ConfigName;
            
            //Port Spinners
            rconPort_tb.Value = config.DewritoConfig.getRCONPort();
            serverPort_tb.Value = config.DewritoConfig.getServerPort();
            gamePort_tb.Value = config.DewritoConfig.getGamePort();
            signalPort_tb.Value = config.DewritoConfig.getSignalServerPort();
            
            //Server Name info
            serverName_tb.Text = config.DewritoConfig.getServerName();
        }
    }
}
