using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Actions
{

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
    public enum TriggerReferenceType
    {

        /// <summary>
        /// 
        /// </summary>
        ActionId,

        /// <summary>
        /// 
        /// </summary>
        ActionName,

        /// <summary>
        /// 
        /// </summary>
        BindingId

    }

}
