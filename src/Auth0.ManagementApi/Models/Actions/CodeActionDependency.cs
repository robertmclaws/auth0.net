using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Auth0.ManagementApi.Models.Actions
{

    /// <summary>
    /// Represent an npm dependency for an action or an action's version.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class CodeActionDependency
    {

        /// <summary>
        /// The name of the npm module, e.g. 'lodash'
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The version of the npm module, e.g. '4.17.1'
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// An optional value used primarily for private npm registries.
        /// </summary>
        [JsonProperty("registry_url")]
        public string PrivateRegistryUrl { get; set; }

    }

}