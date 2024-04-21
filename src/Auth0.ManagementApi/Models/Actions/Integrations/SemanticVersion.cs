using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Auth0.ManagementApi.Models.Actions
{

    /// <summary>
    /// 
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class SemanticVersion
    {

        /// <summary>
        /// 
        /// </summary>
        public int Major { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Minor { get; set; }

    }

}
