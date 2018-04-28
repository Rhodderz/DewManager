using System.Collections;
using System.Collections.ObjectModel;
using System.IO;
using DewManager.Configs;

namespace DewManager
{
    public class ConfigBundle
    {
        public int Index { get; set; }
        public DewritoConfig DewritoConfig{ get; set; }
        public Voting VotingConfig { get; set; }
        public ObjectLocations ObjectLocations { get; set; }
        public ObservableCollection<Map> AvailableMaps { get; set; }
        public ObservableCollection<GameType> AvailableGameTypes { get; set; }

        public ConfigBundle(int index, DewritoConfig dewritoConfig, Voting votingConfig, ObjectLocations objectLocations)
        {
            this.DewritoConfig = dewritoConfig;
            this.VotingConfig = votingConfig;
            this.Index = index;
            this.ObjectLocations = objectLocations;
            GetAvailableMaps();
            GetAvailableGameTypes();
        }

        public void GetAvailableMaps()
        {
            AvailableMaps = (new Maps(ObjectLocations).GetMaps());
        }

        public void GetAvailableGameTypes()
        {
            AvailableGameTypes = new ObservableCollection<GameType>();
            
            string[] variantFolderList = Directory.GetDirectories(ObjectLocations.getVariantsFolder_Path());
            foreach (var folderpath in variantFolderList)
            {
                string foldername = new DirectoryInfo(folderpath).Name;
                /*For now this will be set like this.
                In the future maybe a file with description and name or might be able to pull from variant file
                once i have created the serializer in c++
                */
                AvailableGameTypes.Add(new GameType(foldername, foldername));
            }
        }
    }
}