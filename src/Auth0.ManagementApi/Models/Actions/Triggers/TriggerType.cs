using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Auth0.ManagementApi.Models.Actions
{

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter), typeof(KebabCaseNamingStrategy))]
    public enum TriggerType
    {

        /// <summary>
        /// 
        /// </summary>
        CredentialsExchange,
        
        /// <summary>
        /// 
        /// </summary>
        IgaApproval,
        
        /// <summary>
        /// 
        /// </summary>
        IgaCertification,
        
        /// <summary>
        /// 
        /// </summary>
        IgaFulfillmentAssignment,
        
        /// <summary>
        /// 
        /// </summary>
        IgaFulfillmentExecution,
        
        /// <summary>
        /// 
        /// </summary>
        NotificationsCustomProviderPhone,
        
        /// <summary>
        /// 
        /// </summary>
        PasswordResetPostChallenge,
        
        /// <summary>
        /// 
        /// </summary>
        PostChangePassword,
        
        /// <summary>
        /// 
        /// </summary>
        PostLogin,
        
        /// <summary>
        /// 
        /// </summary>
        PostUserRegistration,
        
        /// <summary>
        /// 
        /// </summary>
        PreUserRegistration,
        
        /// <summary>
        /// 
        /// </summary>
        SendPhoneMessage,

    }

}
