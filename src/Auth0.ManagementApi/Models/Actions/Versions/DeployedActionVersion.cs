using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Auth0.ManagementApi.Models.Actions
{

    /// <summary>
    /// 
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class DeployedActionVersion : ActionVersionBase
    {

        /// <summary>
        /// Indicates if this specific version is the currently one deployed.
        /// </summary>
        [JsonProperty("deployed")]
        public bool IsDeployed { get; set; }

    }

}
