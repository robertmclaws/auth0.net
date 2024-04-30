using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models.Actions
{

    /// <summary>
    /// Request configuration to update the actions that are bound (i.e. attached) to a trigger.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]

    public class UpdateTriggerBindingsRequest
    {

        #region Public Properties

        /// <summary>
        /// The actions that will be bound to this trigger. The order in which they are included will be the order in which they are executed.
        /// </summary>
        public IList<UpdateTriggerBindingEntry> Bindings { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public UpdateTriggerBindingsRequest()
        {
            Bindings = [];
        }

        #endregion

    }

}