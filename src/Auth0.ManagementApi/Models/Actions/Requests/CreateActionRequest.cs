using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Auth0.ManagementApi.Models.Actions
{
    /// <summary>
    /// Request configuration for creating an action.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]

    public class CreateActionRequest : ActionRequestBase
    {

        /// <summary>
        /// 
        /// </summary>
        public CreateActionRequest() : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        public CreateActionRequest(CodeAction action) : base(action)
        {
        }

    }

}