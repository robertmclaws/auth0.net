﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Auth0.ManagementApi.Models.Actions
{
    /// <summary>
    /// 
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ActionError
    {
        public string Id { get; set; }

        [JsonProperty("msg")]
        public string Message { get; set; }

        public string Url { get; set; }
    }
}