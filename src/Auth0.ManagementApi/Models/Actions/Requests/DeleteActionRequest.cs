using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Auth0.ManagementApi.Models.Actions
{

    /// <summary>
    /// Request configuration for deleting an action.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class DeleteActionRequest
    {

        #region Properties

        /// <summary>
        /// Force action deletion detaching bindings
        /// </summary>
        public bool? Force { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the <see cref="DeleteActionRequest" /> class.
        /// </summary>
        /// <param name="force"></param>
        public DeleteActionRequest(bool? force = null)
        {
            Force = force;
        }

        #endregion

    }

}