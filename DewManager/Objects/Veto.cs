using Newtonsoft.Json;

namespace DewManager
{
    public class Veto
    {
        [JsonProperty("playlist")] 
        public Playlist Playlist { get; set; }
    }
}