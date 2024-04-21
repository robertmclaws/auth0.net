using Auth0.ManagementApi.Models.Actions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Auth0.ManagementApi.Serialization
{

    /// <summary>
    /// 
    /// </summary>
    public class VersionJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ActionVersionBase);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);

            return true switch
            {
                true when jo["built_at"] is not null => jo.ToObject<DeployedCodeActionVersion>(serializer),
                true when jo["build_time"] is not null => jo.ToObject<CodeActionVersion>(serializer),
                true when jo["deployed"] is not null => jo.ToObject<DeployedActionVersion>(serializer),
                _ => GetDefault(serializer, jo),
            };
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //base.WriteJson(writer, value, serializer);
        }

        private ActionVersionBase GetDefault(JsonSerializer serializer, JObject jo)
        {
            var item = new ActionVersionBase();
            serializer.Populate(jo.CreateReader(), item);
            return item;
        }

    }

}
