using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Auth0.ManagementApi.Models.Actions
{

    /// <summary>
    /// 
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ActionSecret
    {

        #region Public Properties

        /// <summary>
        /// The name of the particular secret, e.g. API_KEY.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The time when the secret was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; private set; }

        /// <summary>
        /// The value of the particular secret, e.g. secret123. A secret's value can only be set upon creation. A secret's value will never be returned by the API.
        /// </summary>
        public string Value { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public ActionSecret()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public ActionSecret(string name, string value)
        {
            Name = name;
            Value = value;
        }

        #endregion

    }
}