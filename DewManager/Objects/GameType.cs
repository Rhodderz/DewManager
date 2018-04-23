using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public IList<Command> Commands{ get; set; }
        
        [JsonProperty("SpecificMaps")]
        public IList<Map> SpecificMaps { get; set; }

        public GameType(){}

        public GameType(string displayName, string typeName)
        {
            this.DisplayName = displayName;
            this.TypeName = typeName;
        }

        public class CommandConverter : JsonConverter
        {
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                IList<Command> commands = new List<Command>();

                var Token = JToken.Load(reader);
                Debug.WriteLine(Token.First);
                Debug.WriteLine(Token.Last);

                foreach (string cmd in Token)
                {
                    commands.Add(new Command(cmd));
                }
                
                return commands;
            }

            public override bool CanConvert(Type objectType)
            {
                return true;
            }
        }
    }
}