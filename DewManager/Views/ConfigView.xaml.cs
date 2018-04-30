using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using MahApps.Metro.Controls;

namespace DewManager.Views
{
    /// <summary>
    /// Interaction logic for ConfigView.xaml
    /// </summary>
    public partial class ConfigView : StackPanel
    {
        private ConfigBundle config;

        private ListBox dragSource = null;

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

        private void DeleteMapItem_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button) sender;
            Map context = (Map) button.DataContext;
            ListBox lb = button.Parent.TryFindParent<ListBox>();
            ObservableCollection<Map> contextCollection = (ObservableCollection<Map>) lb.ItemsSource;
            contextCollection.RemoveAt(contextCollection.IndexOf(context));
        }

        private void AvailableMaps_dragPreview(object sender, MouseButtonEventArgs e)
        {
            ListBox parent = (ListBox) sender;
            dragSource = parent;
            object data = GetDataFromLB(dragSource, e.GetPosition(parent));

            if (data != null)
            {
                DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);
            }
        }

        private object GetDataFromLB(ListBox source, Point point)
        {
            UIElement element = source.InputHitTest(point) as UIElement;
            if (element != null)
            {
                object data = DependencyProperty.UnsetValue;
                while (data == DependencyProperty.UnsetValue)
                {
                    data = source.ItemContainerGenerator.ItemFromContainer(element);

                    if (data == DependencyProperty.UnsetValue)
                    {
                        element = VisualTreeHelper.GetParent(element) as UIElement;
                    }

                    if (Equals(element, source))
                    {
                        return null;
                    }

                    if (data != DependencyProperty.UnsetValue)
                    {
                        return data;
                    }
                }
            }
            
            return null;
        }

        private void defaultMaps_drop(object sender, DragEventArgs e)
        {
            ListBox parent = (ListBox) sender;
            Map data = (Map)e.Data.GetData(typeof(Map));
            ObservableCollection<Map> parentOC = (ObservableCollection<Map>) parent.ItemsSource;
            if (parentOC == null)
            {
                parentOC = new ObservableCollection<Map>();
            }
            if (parentOC.Any(map => map.Name == data.Name))
            {
                Debug.WriteLine(data.Name + " ::: Already Exists");
            }
            else
            {
                Debug.WriteLine(data.Name + " ::: Adding");
                parentOC.Add(data);
            }
        }

        private void specificMaps_drop(object sender, DragEventArgs e)
        {
            ListBox parent = (ListBox) sender;
            Map data = (Map)e.Data.GetData(typeof(Map));
            ObservableCollection<Map> parentOC = (ObservableCollection<Map>) parent.ItemsSource;
            if (parentOC == null)
            {
                parentOC = new ObservableCollection<Map>();
            }
            if (parentOC.Any(map => map.Name == data.Name))
            {
                Debug.WriteLine(data.Name + " ::: Already Exists");
            }
            else
            {
                Debug.WriteLine(data.Name + " ::: Adding");
                parentOC.Add(data);
            }
        }

        private void GameTypesButton_drop(object sender, DragEventArgs e)
        {
            Button parent = (Button) sender;
            
            if (e.Data.GetData(typeof(Map)) != null)
            {
                Map data = (Map)e.Data.GetData(typeof(Map));
                StackPanel sp = (StackPanel) parent.Parent;
                ListView specificMapsLV = (ListView)sp.GetChildObjects().OfType<ListView>().First(lv => lv.Name == "specificMaps_lb");
                ObservableCollection<Map> specificMaps = (ObservableCollection<Map>) specificMapsLV.ItemsSource;
                
                if (specificMaps == null)
                {
                    specificMaps = new ObservableCollection<Map>();
                }

                Debug.WriteLine(specificMaps.Count);
                specificMapsLV.ItemsSource = specificMaps;
                
                if (specificMaps.Any(map => map.Name == data.Name))
                {
                    Debug.WriteLine("Apparently " + data.Name + " already exists");
                }
                else
                {
                    Debug.WriteLine("Apparently " + data.Name + " is now added");
                    specificMaps.Add(data);
                }
            }
        }
    }
}