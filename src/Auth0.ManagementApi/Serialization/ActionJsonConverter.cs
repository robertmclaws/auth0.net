using Auth0.ManagementApi.Models.Actions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Auth0.ManagementApi.Serialization
{

    /// <summary>
    /// 
    /// </summary>
    public class ActionJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ActionBase);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            if (jo["installed_integration_id"] is not null)
            {
                return jo.ToObject<IntegrationAction>(serializer);
            }
            return jo.ToObject<CodeAction>(serializer);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //base.WriteJson(writer, value, serializer);
        }
    }
}
