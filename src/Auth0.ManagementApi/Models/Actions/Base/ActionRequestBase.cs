using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models.Actions
{

    /// <summary>
    /// 
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public abstract class ActionRequestBase
    {

        #region Properties

        /// <summary>
        /// The source code of the action.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The list of third party npm modules, and their versions, that this action depends on.
        /// </summary>
        public IList<CodeActionDependency> Dependencies { get; set; }

        /// <summary>
        /// The name of an action.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Node runtime. For example: node12, defaults to node12
        /// </summary>
        public ActionRuntimeType Runtime { get; set; }

        /// <summary>
        /// The list of secrets that are included in an action or a version of an action.
        /// </summary>
        public IList<ActionSecret> Secrets { get; set; }

        /// <summary>
        /// The list of triggers that this action supports. At this time, an action can only target a single trigger at a time.
        /// </summary>
        public IList<TriggerBase> SupportedTriggers { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public ActionRequestBase()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        public ActionRequestBase(CodeAction action) : this()
        {
            Code = action.Code;
            Dependencies = action.Dependencies;
            Name = action.Name;
            Runtime = action.Runtime;
            Secrets = action.Secrets;
            SupportedTriggers = action.SupportedTriggers;
        }

        #endregion

    }
}
