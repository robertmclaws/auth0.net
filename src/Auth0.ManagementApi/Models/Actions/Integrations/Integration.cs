using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Auth0.ManagementApi.Models.Actions
{
    /// <summary>
    /// 
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Integration
    {

        /// <summary>
        /// 
        /// </summary>
        public IntegrationFeatureType FeatureType { get; set; }

        /// <summary>
        /// Refers to the ID in the marketplace catalog
        /// </summary>
        public string CatalogId { get; set; }

        /// <summary>
        /// The time when this action was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Details about the current release of the integration
        /// </summary>
        public IntegrationRelease CurrentRelease { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The unique ID of the Integration.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("logo")]
        public string LogoUrl { get; set; }

        /// <summary>
        ///  The integration name, which will be used for display purposes in the marketplace
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The foreign key reference to the partner account this integration belongs to
        /// </summary>
        public Guid PartnerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("public_support_link")]
        public string PublicSupportUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TermsOfUseUrl { get; set; }

        /// <summary>
        /// The time when this action was updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

                /// <summary>
        /// Refers to the url_slug in the marketplace catalog
        /// </summary>
        public string UrlSlug { get; set; }

    }

}
