namespace Auth0.ManagementApi.Models.Actions
{

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TCurrent"></typeparam>
    /// <typeparam name="TDeployed"></typeparam>
    /// <remarks>This class exists because we don't want generics over-complicating the base return types.</remarks>
    public class DeployableActionBase<TCurrent, TDeployed> : ActionBase
        where TCurrent : ActionVersionBase
        where TDeployed : DeployedActionVersion
    {

        /// <summary>
        /// 
        /// </summary>
        public TCurrent CurrentVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TDeployed DeployedVersion { get; set; }

        /// <summary>
        /// Indicates if this Action is the currently Deployed one.
        /// </summary>
        public bool IsCurrentVersionDeployed => DeployedVersion?.Id == CurrentVersion?.Id;

    }

}
