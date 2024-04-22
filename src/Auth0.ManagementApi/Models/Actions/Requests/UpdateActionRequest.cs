using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Auth0.ManagementApi.Models.Actions
{

    /// <summary>
    /// Request configuration for updating an action.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class UpdateActionRequest : ActionRequestBase
    {

        /// <summary>
        /// 
        /// </summary>
        public UpdateActionRequest() : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        public UpdateActionRequest(CodeAction action) : base(action)
        {
        }

    }

}