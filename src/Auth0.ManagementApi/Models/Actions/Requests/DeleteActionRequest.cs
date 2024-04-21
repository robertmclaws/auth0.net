using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Auth0.ManagementApi.Models.Actions
{
    /// <summary>
    /// Request configuration for deleting an action.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class DeleteActionRequest
    {
        /// <summary>
        /// Force action deletion detaching bindings
        /// </summary>
        public bool? Force { get; set; }
    }
}