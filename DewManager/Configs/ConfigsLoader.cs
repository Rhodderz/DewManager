using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Documents;
using DewManager.Parsers;
using Newtonsoft.Json;

namespace DewManager.Configs
{
    public class ConfigLoader
    {
        private ObjectLocations _objectLocations;
        private List<DewritoConfig> _dewritoPrefs;
        private dynamic _serverJSON;
        private List<Voting> _votingConfigs;
        private List<Veto> _vetoConfigs;
        
        public ConfigLoader(ObjectLocations objectLocations)
        {
            this._objectLocations = objectLocations;
            
            LoadDewrito();
            //LoadServerJSON(); //Doesnt appear to be required
            LoadVotingJSON();
        }

        private void LoadDewrito()
        {
            string[] prefsList = Directory.GetFiles(_objectLocations.getRootDir_Path(), "dewrito_prefs*");
            
            _dewritoPrefs = new List<DewritoConfig>();
            
            foreach (string filepath in prefsList)
            {
                _dewritoPrefs.Add(CfgParse.LoadCfg(filepath));
            }
        }

        private void LoadServerJSON()
        {
            string rawJSON = File.ReadAllText(_objectLocations.getServerJson_Path());
            _serverJSON = JsonConvert.DeserializeObject(rawJSON);
        }

        private void LoadVotingJSON()
        {
            _votingConfigs = new List<Voting>();
            foreach (DewritoConfig dewritoConfig in _dewritoPrefs)
            {
                _votingConfigs.Add(JsonConvert.DeserializeObject<Voting>(File.ReadAllText(
                    _objectLocations.getRootDir_Path() + "/" + dewritoConfig.getVotingConfig().Trim('"'))
                ));
            }
        }
        
        private void LoadVetoJSON()
        {
            _vetoConfigs = new List<Veto>();
            foreach (DewritoConfig dewritoConfig in _dewritoPrefs)
            {
                _vetoConfigs.Add(JsonConvert.DeserializeObject<Veto>(
                    File.ReadAllText(_objectLocations.getRootDir_Path() + "/" + dewritoConfig.getVetoConfig().Trim('"')
                    )
                ));
            }
        }

        public DewritoConfig getDefaultDewritoConfig()
        {
            return _dewritoPrefs[0];
        }

        public List<DewritoConfig> getConfigList()
        {
            return _dewritoPrefs;
        }

        public List<Voting> getVotingConfig()
        {
            return _votingConfigs;
        }
        
        public ConfigBundle getConfigBundle(int index)
        {
            return new ConfigBundle(index, _dewritoPrefs[index], _votingConfigs[index]);
        }
    }
}