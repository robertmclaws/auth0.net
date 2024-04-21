using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Actions
{
    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(KebabCaseNamingStrategy))]
    public enum ActionRuntimeType
    {
        /// <summary>
        /// 
        /// </summary>
        Node12,

        /// <summary>
        /// 
        /// </summary>
        Node16,

        /// <summary>
        /// 
        /// </summary>
        Node18,

        /// <summary>
        /// 
        /// </summary>
        Node18Actions,
    }
}
