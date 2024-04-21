using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Actions
{
    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
    public enum ActionStatusType
    {
        /// <summary>
        /// 
        /// </summary>
        Pending,

        /// <summary>
        /// 
        /// </summary>
        Building,

        /// <summary>
        /// 
        /// </summary>
        Packaged,

        /// <summary>
        /// 
        /// </summary>
        Built,

        /// <summary>
        /// 
        /// </summary>
        Retrying,

        /// <summary>
        /// 
        /// </summary>
        Failed
    }
}
