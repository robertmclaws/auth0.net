using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models.Actions
{
    /// <summary>
    /// Represents an Action based on editable JavaScript code.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class CodeAction : DeployableActionBase<CodeActionVersion, DeployedCodeActionVersion>
    {

        /// <summary>
        /// The source code of the action.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The list of third party npm modules, and their versions, that this action depends on.
        /// </summary>
        public IList<CodeActionDependency> Dependencies { get; set; }

        /// <summary>
        /// The Node runtime. For example: node12, defaults to node12
        /// </summary>
        public ActionRuntimeType Runtime { get; set; }

        /// <summary>
        /// The build status of this action.
        /// </summary>
        public ActionStatusType Status { get; set; }

    }

}