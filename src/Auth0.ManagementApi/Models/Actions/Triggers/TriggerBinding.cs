using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Auth0.ManagementApi.Models.Actions
{

    /// <summary>
    /// Represents a Trigger Binding in Auth0
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class TriggerBinding
    {

        #region Properties

        /// <summary>
        /// The connected action.
        /// </summary>
        public CodeAction Action { get; set; }

        /// <summary>
        /// The time when the binding was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The name of the binding.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The unique ID of this binding.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The actions extensibility point.
        /// </summary>
        public TriggerType TriggerId { get; set; }

        /// <summary>
        /// The time when the binding was updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public UpdateTriggerBindingEntry ToUpdateTriggerBindingEntry()
        {
            return new UpdateTriggerBindingEntry(DisplayName, TriggerReferenceType.BindingId, Id.ToString());
        }

        #endregion

    }

}