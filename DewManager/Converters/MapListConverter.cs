using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DewManager.Converters
{
    public class MapListConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            ObservableCollection<Map> maps = new ObservableCollection<Map>();
            
            var Token = JToken.Load(reader);
            
            Debug.WriteLine(Token.First);

            foreach (JToken jToken in Token)
            {
                maps.Add(JsonConvert.DeserializeObject<Map>(jToken.ToString()));
            }
            

            return maps;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}