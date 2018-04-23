using Newtonsoft.Json;

namespace DewManager
{
    public class Map
    {
        [JsonProperty("displayName")]
        public string Name { get; set; }

        [JsonProperty("mapName")]
        public string FileName{ get; set; }
        
        public Map()
        {
        }

        public Map(string name, string fileName)
        {
            this.Name = name;
            this.FileName = fileName;
        }
    }
}