using Auth0.ManagementApi.Models.Actions;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

public class IntegrationSerializationTests
{

    private string integration = @"
        {
          ""id"": ""750ce7ba-eac5-44a2-97ac-a67b2183bdea"",
          ""catalog_id"": ""auth0-country-based-access"",
          ""url_slug"": ""country-based-access"",
          ""partner_id"": ""d929f92d-efd5-465f-9801-cdd40bfe2c39"",
          ""name"": ""Country-based Access"",
          ""description"": ""This integration allows you to restrict access to your applications by country. You may choose to implement Country-based Access controls for various reasons, including to allow your applications to comply with unique restrictions based on where you do business. \n\nWith the Country-based Access integration, you can define any and all countries to restrict persons and entities from those countries logging into your applications. "",
          ""short_description"": ""Restrict access to users by country"",
          ""logo"": ""https://cdn.auth0.com/marketplace/catalog/content/assets/creators/auth0/auth0-avatar.png"",
          ""terms_of_use_url"": ""https://cdn.auth0.com/website/legal/files/mktplace/auth0-integration.pdf"",
          ""public_support_link"": ""https://support.auth0.com/"",
          ""updated_at"": ""2022-05-18T22:38:09.809749669Z"",
          ""created_at"": ""2022-05-12T19:54:02.958669136Z"",
          ""feature_type"": ""action"",
          ""current_release"": {
            ""id"": """",
            ""semver"": {
                ""major"": 1,
                ""minor"": 19,
            }
          }
        }
        ";


    [Fact]
    public void Should_DeserializeProperly()
    {
        var parsed = JsonConvert.DeserializeObject<Integration>(integration);

        parsed.Should().NotBeNull();
        parsed.Id.Should().Be(new Guid("750ce7ba-eac5-44a2-97ac-a67b2183bdea"));
        parsed.CatalogId.Should().Be("auth0-country-based-access");
        parsed.UrlSlug.Should().Be("country-based-access");
        parsed.PartnerId.Should().Be(new Guid("d929f92d-efd5-465f-9801-cdd40bfe2c39"));
        parsed.Name.Should().Be("Country-based Access");
        parsed.Description.Should().Be("This integration allows you to restrict access to your applications by country. You may choose to implement Country-based Access controls for various reasons, including to allow your applications to comply with unique restrictions based on where you do business. \n\nWith the Country-based Access integration, you can define any and all countries to restrict persons and entities from those countries logging into your applications. ");
        parsed.ShortDescription.Should().Be("Restrict access to users by country");
        parsed.LogoUrl.Should().Be("https://cdn.auth0.com/marketplace/catalog/content/assets/creators/auth0/auth0-avatar.png");
        parsed.TermsOfUseUrl.Should().Be("https://cdn.auth0.com/website/legal/files/mktplace/auth0-integration.pdf");
        parsed.PublicSupportUrl.Should().Be("https://support.auth0.com/");
        parsed.CreatedAt.Should().BeCloseTo(new DateTime(2022, 5, 12, 19, 54, 2, 958, DateTimeKind.Utc));
        parsed.UpdatedAt.Should().BeCloseTo(new DateTime(2022, 5, 18, 22, 38, 9, 809, DateTimeKind.Utc));
        parsed.FeatureType.Should().Be(IntegrationFeatureType.Action);
        parsed.CurrentRelease.Should().NotBeNull();
        parsed.CurrentRelease.Version.Should().NotBeNull();
        parsed.CurrentRelease.Version.Major.Should().Be(1);
        parsed.CurrentRelease.Version.Minor.Should().Be(19);
    }
}
