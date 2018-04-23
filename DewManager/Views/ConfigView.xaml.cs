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
            
            //Server info
            serverName_tb.Text = config.DewritoConfig.getServerName();
            serverMSG_tb.Text = config.DewritoConfig.getServerMSG();
            rconPWD_tb.Text = config.DewritoConfig.getRCONPassword();
            playerName_tb.Text = config.DewritoConfig.getPlayerName();
            announce_chk.IsChecked = config.DewritoConfig.getServerAnnounce();
            
            //Setup Maps list
            availableMaps_lb.ItemsSource = config.AvailableMaps;
            defaultMaps_lb.ItemsSource = config.VotingConfig.Maps;
            
            //Setup Gametypes
            availableGameTypes_lv.ItemsSource = config.VotingConfig.Types;
        }
    }
}
