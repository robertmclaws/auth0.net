using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Auth0.ManagementApi.Models.Actions
{

    /// <summary>
    /// 
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class TriggerBase
    {

        #region Properties

        /// <summary>
        /// The actions extensibility point
        /// </summary>
        public TriggerType Id { get; set; }

        /// <summary>
        /// The version of a trigger. v1, v2, etc.
        /// </summary>
        /// <remarks>When submitting data, leave this blank to use the most current version.</remarks>
        public string Version { get; set; }

        /// <summary>
        /// The trigger's status.
        /// </summary>
        public TriggerStatusType Status { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public TriggerBase()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        public TriggerBase(TriggerType id, TriggerStatusType status = TriggerStatusType.Current) : this()
        {
            Id = id;
            Status = status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="version"></param>
        /// <param name="status"></param>
        public TriggerBase(TriggerType id, string version, TriggerStatusType status = TriggerStatusType.Current) : this(id, status)
        {
            Version = version;
        }

        #endregion

    }

}