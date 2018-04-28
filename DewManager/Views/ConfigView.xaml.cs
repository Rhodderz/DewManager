using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Prism.Commands;

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

        private void DeleteDefaultMapItem_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button) sender;
            Map context = (Map)button.DataContext;
            Debug.WriteLine(context.Name);
            config.VotingConfig.Maps.RemoveAt(config.VotingConfig.Maps.IndexOf(context));
        }
    }
}
