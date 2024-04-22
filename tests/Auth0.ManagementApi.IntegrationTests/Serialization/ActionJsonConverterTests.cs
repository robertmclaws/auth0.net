using Auth0.ManagementApi.Models.Actions;
using Auth0.ManagementApi.Paging;
using Auth0.ManagementApi.Serialization;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests.Serialization
{

    public class ActionJsonConverterTests
    {

        #region ActionsArray 

        private string actions = @"
        [
            {
              ""id"": ""6348B355-DBFA-4A57-A90D-DF229EAD0A8A"",
              ""name"": ""Country-based Access v2"",
              ""supported_triggers"": [
                {
                  ""id"": ""post-login"",
                  ""version"": ""v2"",
                  ""status"": ""CURRENT""
                }
              ],
              ""created_at"": ""2022-05-18T22:38:09.857843240Z"",
              ""updated_at"": ""2022-05-18T22:38:09.857843240Z"",
              ""current_version"": {
                ""id"": ""D688741B-F02C-41A7-BC7B-917528BCAE46"",
                ""runtime"": ""node12"",
                ""status"": ""BUILT"",
                ""created_at"": ""2022-05-18T22:38:09.857868448Z"",
                ""updated_at"": ""2022-05-18T22:38:10.052231614Z""
              },
              ""deployed_version"": {
                ""code"": """",
                ""dependencies"": [],
                ""id"": ""D688741B-F02C-41A7-BC7B-917528BCAE46"",
                ""deployed"": true,
                ""secrets"": [],
                ""status"": ""built"",
                ""created_at"": ""2022-05-18T22:38:09.857868448Z"",
                ""updated_at"": ""2022-05-18T22:38:10.052231614Z"",
                ""runtime"": ""node12""
              },
              ""installed_integration_id"": ""D9A3FC6B-7B92-418E-A82F-548581EB7E89"",
              ""integration"": {
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
                  ""semver"": {}
                }
              },
              ""all_changes_deployed"": false
            },
            {
              ""id"": ""EBD43D98-C109-4FD6-8E83-12C9E531DF46"",
              ""name"": ""Alice KYC v3"",
              ""supported_triggers"": [
                {
                  ""id"": ""post-login"",
                  ""version"": ""v3"",
                  ""status"": ""CURRENT""
                }
              ],
              ""created_at"": ""2024-04-10T16:26:07.874800361Z"",
              ""updated_at"": ""2024-04-10T16:26:07.874800361Z"",
              ""current_version"": {
                ""id"": ""A7AB8469-F0CF-4766-BE80-C2BEB7306CDB"",
                ""runtime"": ""node18"",
                ""status"": ""BUILT"",
                ""created_at"": ""2024-04-10T16:26:07.874808431Z"",
                ""updated_at"": ""2024-04-10T16:26:09.696451712Z""
              },
              ""deployed_version"": {
                ""code"": """",
                ""dependencies"": [],
                ""id"": ""A7AB8469-F0CF-4766-BE80-C2BEB7306CDB"",
                ""deployed"": true,
                ""secrets"": [],
                ""status"": ""built"",
                ""created_at"": ""2024-04-10T16:26:07.874808431Z"",
                ""updated_at"": ""2024-04-10T16:26:09.696451712Z"",
                ""runtime"": ""node18""
              },
              ""installed_integration_id"": ""D03D912D-43FE-4718-BCDD-BD06E4ACA60E"",
              ""integration"": {
                ""id"": ""93022438-d318-4aa7-a219-a9a005cfdd59"",
                ""catalog_id"": ""alice-kyc"",
                ""url_slug"": ""alice-kyc"",
                ""partner_id"": ""c1aa5db6-de0c-4a76-bc0c-2e61bbaff198"",
                ""name"": ""Alice KYC"",
                ""description"": ""Alice Biometrics' mission is to protect digital assets in a world where identity impersonation is becoming easier and identity fraud is an increasing risk. With world-leading AI technologies for facial recognition, passive liveness detection, and anti-fraud security, Alice ensures that interactions in digital processes are carried out by a real person who is who they claim to be. But not only that, it does so seamlessly and without friction for the user, resulting in immediate decisions and a completely straightforward process. Through our AI technology, it is now much simpler and safer to prevent bot account openings, account impersonation and takeover, implement password recovery with biometric security, facial 2FA, or verify the identity of your users to comply with KYC."",
                ""short_description"": ""Verify users identity as part of your registration process"",
                ""logo"": ""https://cdn.auth0.com/marketplace/catalog/content/assets/creators/alice-biometrics/alice-biometrics-avatar.png"",
                ""terms_of_use_url"": ""https://alicebiometrics.com/en/terms-and-conditions/"",
                ""updated_at"": ""2024-04-10T16:26:07.864398609Z"",
                ""created_at"": ""2023-11-30T22:04:48.754432541Z"",
                ""feature_type"": ""action"",
                ""current_release"": {
                  ""id"": """",
                  ""semver"": {}
                }
              },
              ""all_changes_deployed"": false
            },
            {
              ""id"": ""8E1D4A54-1740-4881-8516-F7EB491B5C13"",
              ""name"": ""Script: Post-Login"",
              ""supported_triggers"": [
                {
                  ""id"": ""post-login"",
                  ""version"": ""v3""
                }
              ],
              ""created_at"": ""2024-04-14T06:58:02.014006271Z"",
              ""updated_at"": ""2024-04-16T17:09:28.166631965Z"",
              ""code"": ""module.exports = () => {}"",
              ""dependencies"": [
                {
                  ""name"": ""linqts"",
                  ""version"": ""0.2.1""
                }
              ],
              ""runtime"": ""node18-actions"",
              ""status"": ""built"",
              ""secrets"": [
                {
                  ""name"": ""claimsNamespace"",
                  ""updated_at"": ""2024-04-14T07:00:51.570790606Z""
                },
                {
                  ""name"": ""apiEndpoint"",
                  ""updated_at"": ""2024-04-14T07:00:51.570790606Z""
                }
              ],
              ""current_version"": {
                ""id"": ""52EE7FDD-02AE-4C07-8C0A-3D5E580ED8E0"",
                ""code"": ""module.exports = () => {}"",
                ""runtime"": ""node18-actions"",
                ""status"": ""BUILT"",
                ""number"": 3,
                ""build_time"": ""2024-04-16T16:59:36.357999750Z"",
                ""created_at"": ""2024-04-16T16:59:36.193111909Z"",
                ""updated_at"": ""2024-04-16T16:59:36.359302885Z""
              },
              ""deployed_version"": {
                ""code"": ""module.exports = () => {}"",
                ""dependencies"": [
                  {
                    ""name"": ""linqts"",
                    ""version"": ""0.2.1""
                  }
                ],
                ""id"": ""52EE7FDD-02AE-4C07-8C0A-3D5E580ED8E0"",
                ""deployed"": true,
                ""number"": 3,
                ""built_at"": ""2024-04-16T16:59:36.357999750Z"",
                ""secrets"": [
                  {
                    ""name"": ""claimsNamespace"",
                    ""updated_at"": ""2024-04-14T07:00:51.570790606Z""
                  },
                  {
                    ""name"": ""apiEndpoint"",
                    ""updated_at"": ""2024-04-14T07:00:51.570790606Z""
                  }
                ],
                ""status"": ""built"",
                ""created_at"": ""2024-04-16T16:59:36.193111909Z"",
                ""updated_at"": ""2024-04-16T16:59:36.359302885Z"",
                ""runtime"": ""node18-actions"",
                ""supported_triggers"": [
                  {
                    ""id"": ""post-login"",
                    ""version"": ""v3""
                  }
                ]
              },
              ""all_changes_deployed"": false
            }
          ]";

        #endregion

        [Fact]
        public void Should_DeserializeProperly()
        {
            var actionList = JsonConvert.DeserializeObject<List<ActionBase>>(actions, new ActionJsonConverter());

            actionList.Should().NotBeNullOrEmpty().And.HaveCount(3);
            actionList.OfType<IntegrationAction>().Should().HaveCount(2);
            actionList.OfType<CodeAction>().Should().HaveCount(1);

            var action1 = actionList[0] as IntegrationAction;
            action1.Should().NotBeNull();
            action1.Id.Should().Be(new Guid("6348B355-DBFA-4A57-A90D-DF229EAD0A8A"));
            action1.Name.Should().Be("Country-based Access v2");
            action1.CreatedAt.Should().BeCloseTo(new DateTime(2022, 5, 18, 22, 38, 9, 857, DateTimeKind.Utc));
            action1.UpdatedAt.Should().BeCloseTo(new DateTime(2022, 5, 18, 22, 38, 9, 857, DateTimeKind.Utc));
            action1.CurrentVersion.Should().NotBeNull();
            action1.CurrentVersion.Id.Should().Be(new Guid("D688741B-F02C-41A7-BC7B-917528BCAE46"));
            action1.CurrentVersion.Runtime.Should().Be(ActionRuntimeType.Node12);
            action1.CurrentVersion.Status.Should().Be(ActionStatusType.Built);
            action1.CurrentVersion.CreatedAt.Should().BeCloseTo(new DateTime(2022, 5, 18, 22, 38, 9, 857, DateTimeKind.Utc));
            action1.CurrentVersion.UpdatedAt.Should().BeCloseTo(new DateTime(2022, 5, 18, 22, 38, 10, 052, DateTimeKind.Utc));
            action1.DeployedVersion.Should().NotBeNull();
            action1.DeployedVersion.Id.Should().Be(new Guid("D688741B-F02C-41A7-BC7B-917528BCAE46"));
            action1.DeployedVersion.Runtime.Should().Be(ActionRuntimeType.Node12);
            action1.DeployedVersion.Status.Should().Be(ActionStatusType.Built);
            action1.DeployedVersion.CreatedAt.Should().BeCloseTo(new DateTime(2022, 5, 18, 22, 38, 9, 857, DateTimeKind.Utc));
            action1.DeployedVersion.UpdatedAt.Should().BeCloseTo(new DateTime(2022, 5, 18, 22, 38, 10, 052, DateTimeKind.Utc));
            action1.IsCurrentVersionDeployed.Should().BeTrue();
            action1.InstalledIntegrationId.Should().Be(new Guid("D9A3FC6B-7B92-418E-A82F-548581EB7E89"));
            action1.Integration.Should().NotBeNull();
            action1.Integration.Id.Should().Be(new Guid("750ce7ba-eac5-44a2-97ac-a67b2183bdea"));
            action1.Integration.CatalogId.Should().Be("auth0-country-based-access");
            action1.Integration.UrlSlug.Should().Be("country-based-access");
            action1.Integration.PartnerId.Should().Be(new Guid("d929f92d-efd5-465f-9801-cdd40bfe2c39"));
            action1.Integration.Name.Should().Be("Country-based Access");
            action1.Integration.Description.Should().Be("This integration allows you to restrict access to your applications by country. You may choose to implement Country-based Access controls for various reasons, including to allow your applications to comply with unique restrictions based on where you do business. \n\nWith the Country-based Access integration, you can define any and all countries to restrict persons and entities from those countries logging into your applications. ");
            action1.Integration.ShortDescription.Should().Be("Restrict access to users by country");
            action1.Integration.LogoUrl.Should().Be("https://cdn.auth0.com/marketplace/catalog/content/assets/creators/auth0/auth0-avatar.png");
            action1.Integration.TermsOfUseUrl.Should().Be("https://cdn.auth0.com/website/legal/files/mktplace/auth0-integration.pdf");
            action1.Integration.PublicSupportUrl.Should().Be("https://support.auth0.com/");
            action1.Integration.CreatedAt.Should().BeCloseTo(new DateTime(2022, 5, 12, 19, 54, 2, 958, DateTimeKind.Utc));
            action1.Integration.UpdatedAt.Should().BeCloseTo(new DateTime(2022, 5, 18, 22, 38, 9, 809, DateTimeKind.Utc));
            action1.Integration.FeatureType.Should().Be(IntegrationFeatureType.Action);
            action1.Integration.CurrentRelease.Should().NotBeNull();
            action1.Integration.CurrentRelease.Version.Should().NotBeNull();
            action1.Integration.CurrentRelease.Version.Major.Should().Be(0);
            action1.Integration.CurrentRelease.Version.Minor.Should().Be(0);
            action1.SupportedTriggers.Should().NotBeNullOrEmpty().And.HaveCount(1);
            action1.SupportedTriggers[0].Id.Should().Be(TriggerType.PostLogin);
            action1.SupportedTriggers[0].Version.Should().Be("v2");
            action1.SupportedTriggers[0].Status.Should().Be(TriggerStatusType.Current);
            action1.AllChangesDeployed.Should().BeFalse();

            var action2 = actionList[1] as IntegrationAction;
            action2.Should().NotBeNull();
            action2.Id.Should().Be(new Guid("EBD43D98-C109-4FD6-8E83-12C9E531DF46"));
            action2.Name.Should().Be("Alice KYC v3");
            action2.CreatedAt.Should().BeCloseTo(new DateTime(2024, 4, 10, 16, 26, 7, 874, DateTimeKind.Utc));
            action2.UpdatedAt.Should().BeCloseTo(new DateTime(2024, 4, 10, 16, 26, 7, 874, DateTimeKind.Utc));
            action2.CurrentVersion.Should().NotBeNull();
            action2.CurrentVersion.Id.Should().Be(new Guid("A7AB8469-F0CF-4766-BE80-C2BEB7306CDB"));
            action2.CurrentVersion.Runtime.Should().Be(ActionRuntimeType.Node18);
            action2.CurrentVersion.Status.Should().Be(ActionStatusType.Built);
            action2.CurrentVersion.CreatedAt.Should().BeCloseTo(new DateTime(2024, 4, 10, 16, 26, 7, 874, DateTimeKind.Utc));
            action2.CurrentVersion.UpdatedAt.Should().BeCloseTo(new DateTime(2024, 4, 10, 16, 26, 9, 696, DateTimeKind.Utc));
            action2.DeployedVersion.Should().NotBeNull();
            action2.DeployedVersion.Id.Should().Be(new Guid("A7AB8469-F0CF-4766-BE80-C2BEB7306CDB"));
            action2.DeployedVersion.Runtime.Should().Be(ActionRuntimeType.Node18);
            action2.DeployedVersion.Status.Should().Be(ActionStatusType.Built);
            action2.DeployedVersion.CreatedAt.Should().BeCloseTo(new DateTime(2024, 4, 10, 16, 26, 7, 874, DateTimeKind.Utc));
            action2.DeployedVersion.UpdatedAt.Should().BeCloseTo(new DateTime(2024, 4, 10, 16, 26, 9, 696, DateTimeKind.Utc));
            action2.IsCurrentVersionDeployed.Should().BeTrue();
            action2.InstalledIntegrationId.Should().Be(new Guid("D03D912D-43FE-4718-BCDD-BD06E4ACA60E"));
            action2.Integration.Should().NotBeNull();
            action2.Integration.Id.Should().Be(new Guid("93022438-d318-4aa7-a219-a9a005cfdd59"));
            action2.Integration.CatalogId.Should().Be("alice-kyc");
            action2.Integration.UrlSlug.Should().Be("alice-kyc");
            action2.Integration.PartnerId.Should().Be(new Guid("c1aa5db6-de0c-4a76-bc0c-2e61bbaff198"));
            action2.Integration.Name.Should().Be("Alice KYC");
            action2.Integration.Description.Should().Be("Alice Biometrics' mission is to protect digital assets in a world where identity impersonation is becoming easier and identity fraud is an increasing risk. With world-leading AI technologies for facial recognition, passive liveness detection, and anti-fraud security, Alice ensures that interactions in digital processes are carried out by a real person who is who they claim to be. But not only that, it does so seamlessly and without friction for the user, resulting in immediate decisions and a completely straightforward process. Through our AI technology, it is now much simpler and safer to prevent bot account openings, account impersonation and takeover, implement password recovery with biometric security, facial 2FA, or verify the identity of your users to comply with KYC.");
            action2.Integration.ShortDescription.Should().Be("Verify users identity as part of your registration process");
            action2.Integration.LogoUrl.Should().Be("https://cdn.auth0.com/marketplace/catalog/content/assets/creators/alice-biometrics/alice-biometrics-avatar.png");
            action2.Integration.TermsOfUseUrl.Should().Be("https://alicebiometrics.com/en/terms-and-conditions/");
            action2.Integration.PublicSupportUrl.Should().Be(null);
            action2.Integration.CreatedAt.Should().BeCloseTo(new DateTime(2023, 11, 30, 22, 4, 48, 754, DateTimeKind.Utc));
            action2.Integration.UpdatedAt.Should().BeCloseTo(new DateTime(2024, 4, 10, 16, 26, 7, 864, DateTimeKind.Utc));
            action2.Integration.FeatureType.Should().Be(IntegrationFeatureType.Action);
            action2.Integration.CurrentRelease.Should().NotBeNull();
            action2.Integration.CurrentRelease.Version.Should().NotBeNull();
            action2.Integration.CurrentRelease.Version.Major.Should().Be(0);
            action2.Integration.CurrentRelease.Version.Minor.Should().Be(0);
            action2.SupportedTriggers.Should().NotBeNullOrEmpty().And.HaveCount(1);
            action2.SupportedTriggers[0].Id.Should().Be(TriggerType.PostLogin);
            action2.SupportedTriggers[0].Version.Should().Be("v3");
            action2.SupportedTriggers[0].Status.Should().Be(TriggerStatusType.Current);
            action2.AllChangesDeployed.Should().BeFalse();

            var action3 = actionList[2] as CodeAction;
            action3.Should().NotBeNull();
            action3.Id.Should().Be(new Guid("8E1D4A54-1740-4881-8516-F7EB491B5C13"));
            action3.Name.Should().Be("Script: Post-Login");
            action3.CreatedAt.Should().BeCloseTo(new DateTime(2024, 4, 14, 6, 58, 2, 14, DateTimeKind.Utc));
            action3.UpdatedAt.Should().BeCloseTo(new DateTime(2024, 4, 16, 17, 9, 28, 166, DateTimeKind.Utc));
            action3.Code.Should().Be("module.exports = () => {}");
            action3.Dependencies.Should().NotBeNullOrEmpty().And.HaveCount(1);
            action3.Dependencies[0].Name.Should().Be("linqts");
            action3.Dependencies[0].Version.Should().Be("0.2.1");
            action3.Runtime.Should().Be(ActionRuntimeType.Node18Actions);
            action3.Status.Should().Be(ActionStatusType.Built);
            action3.Secrets.Should().NotBeNullOrEmpty().And.HaveCount(2);
            action3.Secrets[0].Name.Should().Be("claimsNamespace");
            //action3.Secrets[0].UpdatedAt.Should().BeCloseTo(new DateTime(2024, 4, 14, 7, 0, 51, 570, DateTimeKind.Utc));
            action3.Secrets[1].Name.Should().Be("apiEndpoint");
            //action3.Secrets[1].UpdatedAt.Should().BeCloseTo(new DateTime(2024, 4, 14, 7, 0, 51, 570, DateTimeKind.Utc));
            action3.CurrentVersion.Should().NotBeNull();
            action3.CurrentVersion.Id.Should().Be(new Guid("52EE7FDD-02AE-4C07-8C0A-3D5E580ED8E0"));
            action3.CurrentVersion.Code.Should().Be("module.exports = () => {}");
            action3.CurrentVersion.Runtime.Should().Be(ActionRuntimeType.Node18Actions);
            action3.CurrentVersion.Status.Should().Be(ActionStatusType.Built);
            action3.CurrentVersion.Number.Should().Be(3);
            action3.CurrentVersion.BuiltAt.Should().BeCloseTo(new DateTime(2024, 4, 16, 16, 59, 36, 357, DateTimeKind.Utc));
            action3.CurrentVersion.CreatedAt.Should().BeCloseTo(new DateTime(2024, 4, 16, 16, 59, 36, 193, DateTimeKind.Utc));
            action3.CurrentVersion.UpdatedAt.Should().BeCloseTo(new DateTime(2024, 4, 16, 16, 59, 36, 359, DateTimeKind.Utc));
            action3.DeployedVersion.Should().NotBeNull();
            action3.DeployedVersion.Code.Should().Be("module.exports = () => {}");
            action3.DeployedVersion.Dependencies.Should().NotBeNullOrEmpty().And.HaveCount(1);
            action3.DeployedVersion.Dependencies[0].Name.Should().Be("linqts");
            action3.DeployedVersion.Dependencies[0].Version.Should().Be("0.2.1");
            action3.DeployedVersion.Id.Should().Be(new Guid("52EE7FDD-02AE-4C07-8C0A-3D5E580ED8E0"));
            action3.DeployedVersion.IsDeployed.Should().BeTrue();
            action3.DeployedVersion.Number.Should().Be(3);
            action3.DeployedVersion.BuiltAt.Should().BeCloseTo(new DateTime(2024, 4, 16, 16, 59, 36, 357, DateTimeKind.Utc));
            action3.DeployedVersion.Secrets.Should().NotBeNullOrEmpty().And.HaveCount(2);
            action3.DeployedVersion.Secrets[0].Name.Should().Be("claimsNamespace");
            //action3.DeployedVersion.Secrets[0].UpdatedAt.Should().BeCloseTo(new DateTime(2024, 4, 14, 7, 0, 51, 570, DateTimeKind.Utc));
            action3.DeployedVersion.Secrets[1].Name.Should().Be("apiEndpoint");
            //action3.DeployedVersion.Secrets[1].UpdatedAt.Should().BeCloseTo(new DateTime(2024, 4, 14, 7, 0, 51, 570, DateTimeKind.Utc));
            action3.DeployedVersion.Status.Should().Be(ActionStatusType.Built);
            action3.DeployedVersion.CreatedAt.Should().BeCloseTo(new DateTime(2024, 4, 16, 16, 59, 36, 193, DateTimeKind.Utc));
            action3.DeployedVersion.UpdatedAt.Should().BeCloseTo(new DateTime(2024, 4, 16, 16, 59, 36, 359, DateTimeKind.Utc));
            action3.DeployedVersion.Runtime.Should().Be(ActionRuntimeType.Node18Actions);
            action3.DeployedVersion.SupportedTriggers.Should().NotBeNullOrEmpty().And.HaveCount(1);
            action3.DeployedVersion.SupportedTriggers[0].Id.Should().Be(TriggerType.PostLogin);
            action3.DeployedVersion.SupportedTriggers[0].Version.Should().Be("v3");
            action3.IsCurrentVersionDeployed.Should().BeTrue();
            action3.AllChangesDeployed.Should().BeFalse();
        }

        [Fact]
        public void PagedList_Should_DeserializeProperly()
        {
            var source = $"{{\"actions\":{actions},\"total\":3,\"limit\":50,\"start\":0}}";
            var list = JsonConvert.DeserializeObject<PagedList<ActionBase>>(source, new PagedListConverter<ActionBase>("actions"), new ActionJsonConverter());
            list.Should().NotBeNull();
            list.Count.Should().Be(3);

        }

    }

}