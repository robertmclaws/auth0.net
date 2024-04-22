using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Auth0.ManagementApi.Models.Actions
{

    /// <summary>
    /// 
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ActionVersionBase
    {

        /// <summary>
        /// The time when this version was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The unique id of an action version.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The Node runtime. For example: `node12`
        /// </summary>
        public ActionRuntimeType Runtime { get; set; }

        /// <summary>
        /// The build status of this specific version.
        /// </summary>
        public ActionStatusType Status { get; set; }

        /// <summary>
        /// The time when a version was updated. Versions are never updated externally. Only Auth0 will update an action version as it is being built.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

    }

}