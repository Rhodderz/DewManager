using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization.Formatters;

namespace DewManager.Configs
{
    public class DewritoConfig
    {
        public string ConfigName { get; set; }
        public List<DewritoConfigLine> ConfigLines;

        public DewritoConfig()
        {
            ConfigLines = new List<DewritoConfigLine>();
        }

        public string getServerName()
        {
            DewritoConfigLine dewritoConfigLine =  ConfigLines.FirstOrDefault(dewConfigLine => dewConfigLine.Key == "Server.Name");
            return string.Join(" ", dewritoConfigLine.Values).Trim('"');
        }

        public string getVotingConfig()
        {
            DewritoConfigLine dewritoConfigLine =
                ConfigLines.FirstOrDefault(dewConfigLine => dewConfigLine.Key == "Server.VotingJsonPath");
            return string.Join(" ", dewritoConfigLine.Values);
        }
        
        public string getVetoConfig()
        {
            DewritoConfigLine dewritoConfigLine =
                ConfigLines.FirstOrDefault(dewConfigLine => dewConfigLine.Key == "Server.VetoJsonPath");
            return string.Join(" ", dewritoConfigLine.Values);
        }
        
        public string getServerMSG()
        {
            DewritoConfigLine dewritoConfigLine =
                ConfigLines.FirstOrDefault(dewConfigLine => dewConfigLine.Key == "Server.Message");
            return string.Join(" ", dewritoConfigLine.Values).Trim('"');
        }
        
        public string getServerPassword()
        {
            DewritoConfigLine dewritoConfigLine =
                ConfigLines.FirstOrDefault(dewConfigLine => dewConfigLine.Key == "Server.Password");
            return string.Join(" ", dewritoConfigLine.Values).Trim('"');
        }
        
        public string getRCONPassword()
        {
            DewritoConfigLine dewritoConfigLine =
                ConfigLines.FirstOrDefault(dewConfigLine => dewConfigLine.Key == "Server.RconPassword");
            return string.Join(" ", dewritoConfigLine.Values).Trim('"');
        }
        
        public string getPlayerName()
        {
            DewritoConfigLine dewritoConfigLine =
                ConfigLines.FirstOrDefault(dewConfigLine => dewConfigLine.Key == "Player.Name");
            return string.Join(" ", dewritoConfigLine.Values).Trim('"');
        }

        public int getRCONPort()
        {
            DewritoConfigLine dewritoConfigLine =
                ConfigLines.FirstOrDefault(dewConfigLine => dewConfigLine.Key == "Game.RconPort");

            return int.Parse(dewritoConfigLine.Values[0].Trim('"'));
        }
        
        public int getServerPort()
        {
            DewritoConfigLine dewritoConfigLine =
                ConfigLines.FirstOrDefault(dewConfigLine => dewConfigLine.Key == "Server.Port");

            return int.Parse(dewritoConfigLine.Values[0].Trim('"'));
        }
        
        public int getGamePort()
        {
            DewritoConfigLine dewritoConfigLine =
                ConfigLines.FirstOrDefault(dewConfigLine => dewConfigLine.Key == "Server.GamePort");

            return int.Parse(dewritoConfigLine.Values[0].Trim('"'));
        }
        
        public int getSignalServerPort()
        {
            DewritoConfigLine dewritoConfigLine =
                ConfigLines.FirstOrDefault(dewConfigLine => dewConfigLine.Key == "Server.SignalServerPort");

            return int.Parse(dewritoConfigLine.Values[0].Trim('"'));
        }

        public bool getServerAnnounce()
        {
            DewritoConfigLine dewritoConfigLine =
                ConfigLines.FirstOrDefault(dewConfigLine => dewConfigLine.Key == "Server.ShouldAnnounce");

            return int.Parse(dewritoConfigLine.Values[0].Trim('"')) != 0;
        }
    }
}