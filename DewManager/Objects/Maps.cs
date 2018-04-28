using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace DewManager
{
    public class Maps
    {
        //Seperate class than the rest of the loaders as maybe oneday i can get more info from the maps
        
        private ObjectLocations _objLocations;
        private ObservableCollection<Map> _mapsList;

        public Maps()
        {
            _mapsList = new ObservableCollection<Map>();
        }

        public Maps(ObjectLocations objLocations)
        {
            this._objLocations = objLocations;
            _mapsList = new ObservableCollection<Map>();

            AddDefaultMaps();
            AddCustomMaps();
        }

        private void AddDefaultMaps()
        {
            string[] mapFileList = Directory.GetFiles(_objLocations.getDefMapsFolder_path(), "*.map");
            foreach (var filepath in mapFileList)
            {
                Debug.WriteLine("Loading Map: " + filepath);

                string filename = Path.GetFileName(filepath);
                switch (filename.ToLower())
                {
                    case "bunkerworld.map":
                        _mapsList.Add(new Map("Standoff", filename));
                        break;
                    case "shrine.map":
                        _mapsList.Add(new Map("Sandtrap", filename));
                        break;
                    case "s3d_turf.map":
                        _mapsList.Add(new Map("Icebox", filename));
                        break;
                    case "s3d_reactor.map":
                        _mapsList.Add(new Map("Reactor", filename));
                        break;
                    case "chill.map":
                        _mapsList.Add(new Map("Narrows", filename));
                        break;
                    case "deadlock.map":
                        _mapsList.Add(new Map("High Ground", filename));
                        break;
                    case "zanzibar.map":
                        _mapsList.Add(new Map("Last Resort", filename));
                        break;
                    case "riverworld.map":
                        _mapsList.Add(new Map("Valhalla", filename));
                        break;
                    case "cyberdyne.map":
                        _mapsList.Add(new Map("The Pit", filename));
                        break;
                    case "guardian.map":
                        _mapsList.Add(new Map("Guardian", filename));
                        break;
                    case "s3d_avalanche.map":
                        _mapsList.Add(new Map("Diamondback", filename));
                        break;
                }
            }
        }

        private void AddCustomMaps()
        {
            string[] mapFolderList = Directory.GetDirectories(_objLocations.getMapsFolder_Path());
            foreach (var folderpath in mapFolderList)
            {
                Debug.WriteLine(folderpath);
                string foldername = new DirectoryInfo(folderpath).Name;
                string[] mapFileList = Directory.GetFiles(folderpath, "*.map");
                foreach (var filepath in mapFileList)
                {
                    string filename = Path.GetFileName(filepath);
                    _mapsList.Add(new Map(foldername, filename));
                    Debug.WriteLine("Loading Map: " + foldername);
                }
            }
        }

        public ObservableCollection<Map> GetMaps()
        {
            return _mapsList;
        }
    }
}