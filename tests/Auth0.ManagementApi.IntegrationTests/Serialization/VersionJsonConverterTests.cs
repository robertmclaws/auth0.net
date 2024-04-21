using Auth0.ManagementApi.Models.Actions;
using Auth0.ManagementApi.Serialization;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests.Serialization
{

    public class VersionJsonConverterTests
    {

        #region VersionArray

        private string versions = @"
            [
              {
                ""code"": ""module.exports = () => {}"",
                ""dependencies"": [
                  {
                    ""name"": ""linqts"",
                    ""version"": ""latest""
                  }
                ],
                ""id"": ""5D9B9B6D-763F-4DD5-8850-09B9402BCBFF"",
                ""deployed"": true,
                ""number"": 3,
                ""built_at"": ""2024-04-16T16:59:36.357999750Z"",
                ""secrets"": [
                  {
                    ""name"": ""test1"",
                    ""updated_at"": ""2024-04-14T07:00:51.570790606Z""
                  },
                  {
                    ""name"": ""test2"",
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
              {
                ""id"": ""1F2DDF2D-1A40-48B7-BB39-BD00686DE1B0"",
                ""code"": ""module.exports = () => {}"",
                ""runtime"": ""node18-actions"",
                ""status"": ""BUILT"",
                ""number"": 3,
                ""build_time"": ""2024-04-16T16:59:36.357999750Z"",
                ""created_at"": ""2024-04-16T16:59:36.193111909Z"",
                ""updated_at"": ""2024-04-16T16:59:36.359302885Z""
              },
              {
                ""id"": ""0F94FE00-D2A4-4A01-B666-46C4E7342CA2"",
                ""runtime"": ""node18"",
                ""status"": ""BUILT"",
                ""created_at"": ""2024-04-10T16:26:07.874808431Z"",
                ""updated_at"": ""2024-04-10T16:26:09.696451712Z""
              },
              {
                ""code"": """",
                ""dependencies"": [],
                ""id"": ""70C900F1-A2D5-4814-9A04-20E6DAF3AD6F"",
                ""deployed"": true,
                ""secrets"": [],
                ""status"": ""built"",
                ""created_at"": ""2024-04-10T16:26:07.874808431Z"",
                ""updated_at"": ""2024-04-10T16:26:09.696451712Z"",
                ""runtime"": ""node18""
              }
            ]";

        #endregion

        [Fact]
        public void Should_DeserializeProperly()
        {
            var versionList = JsonConvert.DeserializeObject<List<ActionVersionBase>>(versions, new VersionJsonConverter());

            versionList.Should().NotBeNullOrEmpty().And.HaveCount(4);
            versionList.OfType<DeployedCodeActionVersion>().Should().HaveCount(1);
            versionList.OfType<CodeActionVersion>().Should().HaveCount(1);
            versionList.Where(c => c.GetType() == typeof(DeployedActionVersion)).Should().HaveCount(1);
            versionList.Where(c => c.GetType() == typeof(ActionVersionBase)).Should().HaveCount(1);

            var dcav = versionList[0] as DeployedCodeActionVersion;
            dcav.Should().NotBeNull();
            dcav.Id.Should().Be("5D9B9B6D-763F-4DD5-8850-09B9402BCBFF");
            dcav.Code.Should().Be("module.exports = () => {}");
            dcav.Dependencies.Should().NotBeNullOrEmpty().And.HaveCount(1);
            dcav.Dependencies[0].Name.Should().Be("linqts");
            dcav.Dependencies[0].Version.Should().Be("latest");
            dcav.IsDeployed.Should().BeTrue();
            dcav.Number.Should().Be(3);
            dcav.BuiltAt.Should().BeCloseTo(new System.DateTime(2024, 4, 16, 16, 59, 36, 357, System.DateTimeKind.Utc));
            dcav.Secrets.Should().NotBeNullOrEmpty().And.HaveCount(2);
            dcav.Secrets[0].Name.Should().Be("test1");
            //dcav.Secrets[0].UpdatedAt.Should().BeCloseTo(new System.DateTime(2024, 4, 14, 7, 0, 51, 570, System.DateTimeKind.Utc));
            dcav.Secrets[1].Name.Should().Be("test2");
            //dcav.Secrets[1].UpdatedAt.Should().BeCloseTo(new System.DateTime(2024, 4, 14, 7, 0, 51, 570, System.DateTimeKind.Utc));
            dcav.Status.Should().Be(ActionStatusType.Built);
            dcav.CreatedAt.Should().BeCloseTo(new System.DateTime(2024, 4, 16, 16, 59, 36, 193, System.DateTimeKind.Utc));
            dcav.UpdatedAt.Should().BeCloseTo(new System.DateTime(2024, 4, 16, 16, 59, 36, 359, System.DateTimeKind.Utc));
            dcav.Runtime.Should().Be(ActionRuntimeType.Node18Actions);
            dcav.SupportedTriggers.Should().NotBeNullOrEmpty().And.HaveCount(1);
            dcav.SupportedTriggers[0].Id.Should().Be(TriggerType.PostLogin);

            var cav = versionList[1] as CodeActionVersion;
            cav.Should().NotBeNull();
            cav.Id.Should().Be("1F2DDF2D-1A40-48B7-BB39-BD00686DE1B0");
            cav.Code.Should().Be("module.exports = () => {}");
            cav.Runtime.Should().Be(ActionRuntimeType.Node18Actions);
            cav.Status.Should().Be(ActionStatusType.Built);
            cav.Number.Should().Be(3);
            cav.BuiltAt.Should().BeCloseTo(new System.DateTime(2024, 4, 16, 16, 59, 36, 357, System.DateTimeKind.Utc));
            cav.CreatedAt.Should().BeCloseTo(new System.DateTime(2024, 4, 16, 16, 59, 36, 193, System.DateTimeKind.Utc));
            cav.UpdatedAt.Should().BeCloseTo(new System.DateTime(2024, 4, 16, 16, 59, 36, 359, System.DateTimeKind.Utc));

            var av = versionList[2];
            av.Should().NotBeNull();
            av.Id.Should().Be("0F94FE00-D2A4-4A01-B666-46C4E7342CA2");
            av.Runtime.Should().Be(ActionRuntimeType.Node18);
            av.Status.Should().Be(ActionStatusType.Built);
            av.CreatedAt.Should().BeCloseTo(new System.DateTime(2024, 4, 10, 16, 26, 7, 874, System.DateTimeKind.Utc));
            av.UpdatedAt.Should().BeCloseTo(new System.DateTime(2024, 4, 10, 16, 26, 9, 696, System.DateTimeKind.Utc));

            var dav = versionList[3] as DeployedActionVersion;
            dav.Should().NotBeNull();
            dav.Id.Should().Be("70C900F1-A2D5-4814-9A04-20E6DAF3AD6F");
            dav.IsDeployed.Should().BeTrue();
            dav.Status.Should().Be(ActionStatusType.Built);
            dav.CreatedAt.Should().BeCloseTo(new System.DateTime(2024, 4, 10, 16, 26, 7, 874, System.DateTimeKind.Utc));
            dav.UpdatedAt.Should().BeCloseTo(new System.DateTime(2024, 4, 10, 16, 26, 9, 696, System.DateTimeKind.Utc));
            dav.Runtime.Should().Be(ActionRuntimeType.Node18);
        }
    }

}