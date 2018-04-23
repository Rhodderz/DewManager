using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DewManager
{
    public class ObjectLocations
    {
        private string _rootPath;
        private string _dewPref = "/dewrito_prefs.cfg";
        private string _defaultMapsFolder = "/maps";
        private string _mapsFolder = "/mods/maps";
        private string _variantsFolder = "/mods/variants";
        private string _serverJson = "/mods/server/server.json";
        private string _votingJson = "/mods/server/voting.json";
        private string _vetoJson = "/mods/server/veto.json";
        private string _banList = "/mods/server/banlist.txt";

        public ObjectLocations(string rootPath)
        {
            this._rootPath = rootPath;
        }

        public string getRootDir_Path()
        {
            return _rootPath;
        }

        public string getdewPref_path()
        {
            return _rootPath + _dewPref;
        }
        
        public string getDefMapsFolder_path()
        {
            return _rootPath + _defaultMapsFolder;
        }

        public string getMapsFolder_Path()
        {
            return _rootPath + _mapsFolder;
        }

        public string getVariantsFolder_Path()
        {
            return _rootPath + _variantsFolder;
        }

        public string getServerJson_Path()
        {
            return _rootPath + _serverJson;
        }

        public string getVotingJson_Path()
        {
            return _rootPath + _votingJson;
        }
        
        public string getVetoJson_Path()
        {
            return _rootPath + _vetoJson;
        }
        
        public string getBanList_Path()
        {
            return _rootPath + _banList;
        }
    }
}
