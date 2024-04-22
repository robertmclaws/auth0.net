using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Actions
{

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(KebabCaseNamingStrategy))]
    public enum TriggerStatusType
    {

        /// <summary>
        /// 
        /// </summary>
        Current,

        /// <summary>
        /// 
        /// </summary>
        Deprecated

    }

}
