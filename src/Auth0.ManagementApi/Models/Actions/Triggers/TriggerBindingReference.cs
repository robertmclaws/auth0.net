using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Auth0.ManagementApi.Models.Actions
{

    /// <summary>
    /// 
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class TriggerBindingReference
    {

        /// <summary>
        ///  How the action is being referred to.
        /// </summary>
        public TriggerReferenceType Type { get; set; }

        /// <summary>
        /// The value to ude to look up the binding, based on the <see cref="Type" />.
        /// </summary>
        public string Value { get; set; }

    }

}