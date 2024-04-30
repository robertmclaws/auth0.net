using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Auth0.ManagementApi.Models.Actions
{

    /// <summary>
    /// Represents a Trigger in Auth0
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Trigger : TriggerBase
    {
        /// <summary>
        /// Runtimes supported by this trigger.
        /// </summary>
        public System.Collections.Generic.List<ActionRuntimeType> Runtimes { get; set; }

        /// <summary>
        /// Runtime that will be used when none is specified when creating an action.
        /// </summary>
        public ActionRuntimeType DefaultRuntime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Collections.Generic.List<TriggerBase> CompatibleTriggers { get; set; }
    }

}