using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using DewManager.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace DewManager
{
    public class GameType
    {
        [JsonProperty("displayName")]
        public string DisplayName{ get; set; }
        
        [JsonProperty("typeName")]
        public string TypeName{ get; set; }
        
        [JsonConverter(typeof(CommandConverter))]
        public ObservableCollection<Command> Commands{ get; set; }
        
        [JsonConverter(typeof(MapListConverter))]
        public ObservableCollection<Map> SpecificMaps { get; set; }

        public GameType(){}

        public GameType(string displayName, string typeName)
        {
            this.DisplayName = displayName;
            this.TypeName = typeName;
        }
    }
}