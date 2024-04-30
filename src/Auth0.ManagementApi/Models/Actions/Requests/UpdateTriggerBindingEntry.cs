using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models.Actions
{

    /// <summary>
    /// 
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class UpdateTriggerBindingEntry
    {

        /// <summary>
        /// The name of the binding.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// A reference to an action. An action can be referred to by <see cref="TriggerReferenceType.ActionId" />, 
        /// <see cref="TriggerReferenceType.ActionName" />, or <see cref="TriggerReferenceType.BindingId" />.
        /// </summary>
        [JsonProperty("ref")]
        public TriggerBindingReference Reference { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<ActionSecret> Secrets { get; set; }

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public UpdateTriggerBindingEntry()
        {
            Reference = new TriggerBindingReference()
            {
                Type = TriggerReferenceType.ActionId
            };
            Secrets = [];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="displayName"></param>
        /// <param name="referenceType"></param>
        /// <param name="referenceValue"></param>
        public UpdateTriggerBindingEntry(string displayName, TriggerReferenceType referenceType, string referenceValue) : this()
        {
            DisplayName = displayName;
            Reference.Type = referenceType;
            Reference.Value = referenceValue;
        }

        #endregion

    }

}