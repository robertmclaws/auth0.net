using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models.Actions
{

    /// <summary>
    /// 
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class DeployedCodeActionVersion : DeployedActionVersion
    {

        /// <summary>
        /// A summary of the resulting Action deployed for this Version.
        /// </summary>
        public ActionBase Action { get; set; }

        /// <summary>
        /// The time when a version was compiled. Only Auth0 will update an action version as it is being built.
        /// </summary>
        public DateTime BuiltAt { get; set; }

        /// <summary>
        /// The source code of this specific version of the action.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The list of third party npm modules, and their versions, that this specific version depends on.
        /// </summary>
        public IList<CodeActionDependency> Dependencies { get; set; }

        /// <summary>
        /// Any errors that occurred while the version was being built.
        /// </summary>
        public IList<ActionError> Errors { get; set; }

        /// <summary>
        /// The index of this version in list of versions for the action.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// The list of secrets that are included in the version.
        /// </summary>
        public IList<CodeActionDependency> Secrets { get; set; }

        /// <summary>
        /// The list of triggers that this action supports. At this time, an action can only target a single trigger at a time.
        /// </summary>
        public IList<TriggerBase> SupportedTriggers { get; set; }

    }

}
