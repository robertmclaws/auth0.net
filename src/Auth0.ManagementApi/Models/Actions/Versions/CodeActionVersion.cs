using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Auth0.ManagementApi.Models.Actions
{
    /// <summary>
    /// Represents a version for an action in Auth0
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class CodeActionVersion : ActionVersionBase
    {

        /// <summary>
        /// The source code of this specific version of the action.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The index of this version in list of versions for the action.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// The time when a version was compiled. Only Auth0 will update an action version as it is being built.
        /// </summary>
        [JsonProperty("build_time")]
        public DateTime BuiltAt { get; set; }


    }
}