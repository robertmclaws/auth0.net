using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Auth0.ManagementApi.Models.Actions
{

    /// <summary>
    /// 
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class IntegrationAction : DeployableActionBase<ActionVersionBase, DeployedActionVersion>
    {

        /// <summary>
        /// 
        /// </summary>
        public Guid InstalledIntegrationId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Integration Integration { get; set; }

    }

}
