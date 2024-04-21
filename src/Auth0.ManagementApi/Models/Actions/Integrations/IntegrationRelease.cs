using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Auth0.ManagementApi.Models.Actions
{

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class IntegrationRelease
    {

        /// <summary>
        /// The unique ID of the action.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Trigger Trigger { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("semver")]
        public SemanticVersion Version { get; set; }

    }

}
