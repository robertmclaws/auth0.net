using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Actions
{
    /// <summary>
    /// Request configuration for updating an action.
    /// </summary>
    public class UpdateActionRequest: CodeAction
    {

        [JsonIgnore]
        public new bool AllChangesDeployed { get; set; }





    }
}