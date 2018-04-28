using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DewManager.Converters
{
    public class CommandConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            ObservableCollection<Command> commands = new ObservableCollection<Command>();

            var Token = JToken.Load(reader);

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