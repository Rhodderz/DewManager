using Newtonsoft.Json;

namespace DewManager
{
    public class GameType
    {
        [JsonProperty("displayName")]
        public string DisplayName{ get; set; }
        
        [JsonProperty("typeName")]
        public string typeName{ get; set; }
        
        [JsonProperty("commands")]
        public string[] commands{ get; set; }
    }
}