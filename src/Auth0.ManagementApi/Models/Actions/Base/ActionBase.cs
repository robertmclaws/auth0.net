using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Auth0.ManagementApi.Models.Actions
{

    /// <summary>
    /// 
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public abstract class ActionBase
    {
        /// <summary>
        /// Indicates if all of an Action's contents have been deployed.
        /// </summary>
        public bool AllChangesDeployed { get; set; }

        /// <summary>
        /// The time when this action was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }


        /// <summary>
        /// The unique ID of the action.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of an action.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The list of secrets that are included in an action or a version of an action.
        /// </summary>
        public IList<ActionSecret> Secrets { get; set; }

        /// <summary>
        /// The list of triggers that this action supports. At this time, an action can only target a single trigger at a time.
        /// </summary>
        public IList<TriggerBase> SupportedTriggers { get; set; }

        /// <summary>
        /// The time when this action was updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

    }

}