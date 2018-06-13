using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace ApplicationFramework.Serialization
{
    public class JsonSerializer : ISerializer
    {
        private readonly JsonSerializerSettings settings;

        public JsonSerializer()
        {
            settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
                DateTimeZoneHandling = DateTimeZoneHandling.Local,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            settings.Converters.Add(new StringEnumConverter());
        }

        string ISerializer.Serialize<T>(T value)
        {
            return JsonConvert.SerializeObject(value, settings);
        }

        T ISerializer.Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value, settings);
        }
    }
}
