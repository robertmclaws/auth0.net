using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Actions
{
    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
    public enum IntegrationFeatureType
    {
        /// <summary>
        /// 
        /// </summary>
        Action,

        /// <summary>
        /// 
        /// </summary>
        LogStream,

        /// <summary>
        /// 
        /// </summary>
        SmsProvider,

        /// <summary>
        /// 
        /// </summary>
        SocialConnection,

        /// <summary>
        /// 
        /// </summary>
        SsoIntegration,

        /// <summary>
        /// 
        /// </summary>
        Unspecified
    }
}
