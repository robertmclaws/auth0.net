using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Auth0.ManagementApi.Models.Actions
{

    /// <summary>
    /// 
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class TriggerBase
    {

        /// <summary>
        /// The actions extensibility point
        /// </summary>
        public TriggerType Id { get; set; }

        /// <summary>
        /// The version of a trigger. v1, v2, etc.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// The trigger's status.
        /// </summary>
        public TriggerStatusType Status { get; set; }

    }

}