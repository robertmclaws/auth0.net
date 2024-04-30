using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models.Actions;
using Auth0.ManagementApi.Paging;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;


namespace Auth0.ManagementApi.IntegrationTests
{

    public class ActionsTestsFixture : TestBaseFixture
    {
        public override async Task DisposeAsync()
        {
            foreach (KeyValuePair<CleanUpType, IList<string>> entry in identifiers)
            {
                await ManagementTestBaseUtils.CleanupAsync(ApiClient, entry.Key, entry.Value);
            }

            ApiClient.Dispose();
        }
    }

    public class ActionsTests : IClassFixture<ActionsTestsFixture>
    {
        ActionsTestsFixture fixture;

        public ActionsTests(ActionsTestsFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task Test_actions_crud_sequence()
        {
            var actionsBeforeCreate = await fixture.ApiClient.Actions.GetAllAsync(new GetActionsRequest(), new PaginationInfo());

            var createdAction = await fixture.ApiClient.Actions.CreateAsync(new CreateActionRequest
            {
                Name = $"{TestingConstants.ActionPrefix}-{Guid.NewGuid()}",
                Code = "module.exports = () => {}",
                Runtime = ActionRuntimeType.Node12,
                Secrets = new List<ActionSecret> { new ActionSecret("My_Secret", "Test123") },
                SupportedTriggers = new List<TriggerBase> { new TriggerBase(TriggerType.PostLogin, "v2") }
            });

            fixture.TrackIdentifier(CleanUpType.Actions, createdAction.Id);

            var actionsAfterCreate = await fixture.ApiClient.Actions.GetAllAsync(new GetActionsRequest(), new PaginationInfo());

            actionsAfterCreate.Count.Should().Be(actionsBeforeCreate.Count + 1);
            createdAction.Should().BeEquivalentTo(actionsAfterCreate.Last() as CodeAction, options => options.Excluding(o => o.Status));

            var updatedAction = await fixture.ApiClient.Actions.UpdateAsync(createdAction.Id.ToString(), new UpdateActionRequest
            {
                Code = "module.exports = () => { console.log(true); }"
            });

            updatedAction.Should().BeEquivalentTo(createdAction, options => options.Excluding(o => o.Code).Excluding(o => o.UpdatedAt));
            updatedAction.Code.Should().Be("module.exports = () => { console.log(true); }");

            var actionAfterUpdate = await fixture.ApiClient.Actions.GetAsync(updatedAction.Id.ToString()) as CodeAction;

            updatedAction.Should().BeEquivalentTo(actionAfterUpdate, options => options.Excluding(o => o.Status));
            actionAfterUpdate.Code.Should().Be("module.exports = () => { console.log(true); }");

            await fixture.ApiClient.Actions.DeleteAsync(actionAfterUpdate.Id.ToString());

            var actionsAfterDelete = await fixture.ApiClient.Actions.GetAllAsync(new GetActionsRequest(), new PaginationInfo());
            actionsAfterDelete.Count.Should().Be(actionsBeforeCreate.Count);

            fixture.UnTrackIdentifier(CleanUpType.Actions, createdAction.Id);
        }

        [Fact]
        public async Task Test_get_triggers()
        {
            var triggers = await fixture.ApiClient.Actions.GetAllTriggersAsync();

            triggers.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Test_get_and_update_trigger_bindings()
        {
            var triggerBindingsBeforeCreate = await fixture.ApiClient.Actions.GetAllTriggerBindingsAsync("post-login", new PaginationInfo());

            var createdAction = await fixture.ApiClient.Actions.CreateAsync(new CreateActionRequest
            {
                Name = $"{TestingConstants.ActionPrefix}-{Guid.NewGuid()}",
                Code = "module.exports = () => {}",
                Runtime = ActionRuntimeType.Node12,
                Secrets = new List<ActionSecret> { new ActionSecret("My_Secret", "Test123") },
                SupportedTriggers = new List<TriggerBase> { new TriggerBase(TriggerType.PostLogin, "v2") }
            });

            fixture.TrackIdentifier(CleanUpType.Actions, createdAction.Id);

            await RetryUtils.Retry(() => fixture.ApiClient.Actions.GetAsync(createdAction.Id.ToString()), response => (response as CodeAction)?.Status is not ActionStatusType.Built);

            await fixture.ApiClient.Actions.DeployAsync(createdAction.Id.ToString());

            // 
            await RetryUtils.Retry(() => fixture.ApiClient.Actions.GetAsync(createdAction.Id.ToString()), response => !response.AllChangesDeployed);

            await fixture.ApiClient.Actions.UpdateTriggerBindingsAsync("post-login", new UpdateTriggerBindingsRequest
            {
                Bindings = new List<UpdateTriggerBindingEntry>
                {
                    new("My Binding", TriggerReferenceType.ActionId, createdAction.Id.ToString())
                }
            });

            var triggerBindingsAfterCreate = await fixture.ApiClient.Actions.GetAllTriggerBindingsAsync("post-login", new PaginationInfo());

            triggerBindingsAfterCreate.Count.Should().Be(triggerBindingsBeforeCreate.Count + 1);

            await fixture.ApiClient.Actions.UpdateTriggerBindingsAsync("post-login", new UpdateTriggerBindingsRequest());

            await fixture.ApiClient.Actions.DeleteAsync(createdAction.Id.ToString());

            fixture.UnTrackIdentifier(CleanUpType.Actions, createdAction.Id);
        }

        [Fact]
        public async Task Test_action_version_crud_sequence()
        {
            // 1. Create a new CodeAction
            var createdAction = await fixture.ApiClient.Actions.CreateAsync(new CreateActionRequest
            {
                Name = $"{TestingConstants.ActionPrefix}-{Guid.NewGuid()}",
                Code = "module.exports = () => {}",
                Runtime = ActionRuntimeType.Node12,
                Secrets = new List<ActionSecret> { new ActionSecret("My_Secret", "Test123") },
                SupportedTriggers = new List<TriggerBase> { new TriggerBase(TriggerType.PostLogin, "v2") }
            });

            fixture.TrackIdentifier(CleanUpType.Actions, createdAction.Id);

            // 2. Get all the versions after the action was created
            var versionsAfterCreate = await fixture.ApiClient.Actions.GetAllVersionsAsync(createdAction.Id.ToString(), new PaginationInfo());

            versionsAfterCreate.Count.Should().Be(0);

            // 3.a Before deploying, ensure it's in built status (this is async and sometimes causes CI to fail)
            await RetryUtils.Retry(() => fixture.ApiClient.Actions.GetAsync(createdAction.Id.ToString()), (action) => (action as CodeAction)?.Status is not ActionStatusType.Built);

            // 3.b Deploy the current version
            await fixture.ApiClient.Actions.DeployAsync(createdAction.Id.ToString());

            // 4. Get all the versions after the action was deployed
            var versionsAfterDeploy = await fixture.ApiClient.Actions.GetAllVersionsAsync(createdAction.Id.ToString(), new PaginationInfo());

            versionsAfterDeploy.Count.Should().Be(1);

            // 5. Update the action
            await fixture.ApiClient.Actions.UpdateAsync(createdAction.Id.ToString(), new UpdateActionRequest
            {
                Code = "module.exports = () => { console.log(true); }"
            });

            // 6.a Before deploying, ensure it's in built status (this is async and sometimes causes CI to fail)
            await RetryUtils.Retry(() => fixture.ApiClient.Actions.GetAsync(createdAction.Id.ToString()), (action) => (action as CodeAction)?.Status is not ActionStatusType.Built);

            // 6.b. Deploy the latest version
            var deployedVersion = await fixture.ApiClient.Actions.DeployAsync(createdAction.Id.ToString());

            // Wait 2 seconds because it can take a while for the CodeAction to be deployed
            await Task.Delay(2000);

            // 7. Get all the versions after the action was updated
            var versionsAfterSecondDeploy = await fixture.ApiClient.Actions.GetAllVersionsAsync(createdAction.Id.ToString(), new PaginationInfo());

            versionsAfterSecondDeploy.Count.Should().Be(2);
            versionsAfterSecondDeploy.Single(v => v.Id == deployedVersion.Id).As<DeployedCodeActionVersion>().IsDeployed.Should().BeTrue();
            versionsAfterSecondDeploy.Single(v => v.Id != deployedVersion.Id).As<DeployedCodeActionVersion>().IsDeployed.Should().BeFalse();

            var action = await fixture.ApiClient.Actions.GetAsync(createdAction.Id.ToString()) as CodeAction;
            action.DeployedVersion.Id.Should().Be(deployedVersion.Id);

            // 9. Rollback
            var rollbackedVersion = await fixture.ApiClient.Actions.RollbackToVersionAsync(createdAction.Id.ToString(), versionsAfterDeploy.Single().Id.ToString());

            // 10. Get all the versions after the action was rollbacked
            // Retry until the rollback was processed as this is async
            var versionAfterRollback = await RetryUtils.Retry(() => fixture.ApiClient.Actions.GetVersionAsync(createdAction.Id.ToString(), rollbackedVersion.Id.ToString()), (response) => response.As<DeployedCodeActionVersion>().IsDeployed is false);

            var versionsAfterRollback = await fixture.ApiClient.Actions.GetAllVersionsAsync(createdAction.Id.ToString(), new PaginationInfo());

            versionsAfterRollback.Count.Should().Be(3);
            versionsAfterRollback.Single(v => v.Id == versionAfterRollback.Id).Should().BeEquivalentTo(versionAfterRollback);
            versionsAfterRollback.Single(v => v.Id == versionAfterRollback.Id).As<DeployedCodeActionVersion>().IsDeployed.Should().BeTrue();
            versionsAfterRollback.Where(v => v.Id != versionAfterRollback.Id).ToList().ForEach(v => v.As<DeployedCodeActionVersion>().IsDeployed.Should().BeFalse());

            // 10. Delete CodeAction
            await fixture.ApiClient.Actions.DeleteAsync(createdAction.Id.ToString());

            fixture.UnTrackIdentifier(CleanUpType.Actions, createdAction.Id);
        }
    }
}
