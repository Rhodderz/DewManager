using Newtonsoft.Json;

namespace DewManager
{
    public class Playlist
    {
        [JsonProperty("map")]
        public Map map { get; set; }
        
        [JsonProperty("gametype")]
        public GameType GameType { get; set; }
    }
}