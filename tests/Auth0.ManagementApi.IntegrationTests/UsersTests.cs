using System;
using System.Dynamic;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

using FluentAssertions;
using Xunit;

using Auth0.Tests.Shared;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Connections;
using Auth0.ManagementApi.Users;
using Auth0.ManagementApi.Organizations;

namespace Auth0.ManagementApi.IntegrationTests;

public class UsersTestsFixture : TestBaseFixture
{
    public CreateConnectionResponseContent Connection { get; private set; }
    public CreateUserResponseContent User { get; private set; }
    public const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

    public override async Task InitializeAsync()
    {
        await base.InitializeAsync();

        Connection = await ApiClient.Connections.CreateAsync(new CreateConnectionRequestContent
        {
            Name = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}",
            Strategy = ConnectionIdentityProviderEnum.Auth0,
            EnabledClients = new[] { TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"), TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
        });

        TrackIdentifier(CleanUpType.Connections, Connection.Id);

        User = await ApiClient.Users.CreateAsync(TestBaseUtils.CreateUserRequest(
            connection: Connection.Name,
            email: $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
            emailVerified: true,
            password: Password
        ));

        TrackIdentifier(CleanUpType.Users, User.UserId);
    }

    public override async Task DisposeAsync()
    {
        foreach (KeyValuePair<CleanUpType, IList<string>> entry in identifiers)
        {
            await ManagementTestBaseUtils.CleanupAsync(ApiClient, entry.Key, entry.Value);
        }

        ApiClient?.Dispose();
    }
}

public class UsersTests : IClassFixture<UsersTestsFixture>
{
    private const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

    private UsersTestsFixture fixture;

    public UsersTests(UsersTestsFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async Task Test_users_crud_sequence()
    {
        // Add a new user
        var newUserRequest = TestBaseUtils.CreateUserRequest(
            connection: fixture.Connection.Name,
            email: $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
            emailVerified: true,
            password: Password
        );
        var newUserResponse = await fixture.ApiClient.Users.CreateAsync(newUserRequest);

        fixture.TrackIdentifier(CleanUpType.Users, newUserResponse.UserId);

        newUserResponse.Should().NotBeNull();
        newUserResponse.Email.Should().Be(newUserRequest.Email);

        // Update the user
        var updateUserRequest = TestBaseUtils.CreateUpdateUserRequest();
        updateUserRequest.Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}";
        updateUserRequest.VerifyEmail = false;
        var updateUserResponse = await fixture.ApiClient.Users.UpdateAsync(newUserResponse.UserId, updateUserRequest);
        updateUserResponse.Should().NotBeNull();
        updateUserResponse.Email.Should().Be(updateUserRequest.Email.Value);

        // Ensure firstname, lastname etc are ignored and not sent to Auth0. If not, the following will throw an exception
        var updateUserRequest2 = TestBaseUtils.CreateUpdateUserRequest();
        updateUserRequest2.EmailVerified = true; // We need to pass in at least one property, so we set this as the other properties below will not be serialized
        await fixture.ApiClient.Users.UpdateAsync(newUserResponse.UserId, updateUserRequest2);

        // Get a single user
        var user = await fixture.ApiClient.Users.GetAsync(newUserResponse.UserId, new GetUserRequestParameters());
        user.Should().NotBeNull();
        user.Email.Should().Be(updateUserResponse.Email);

        // Delete the user and ensure we get an exception when trying to fetch them again
        await fixture.ApiClient.Users.DeleteAsync(user.UserId);
        Func<Task> getFunc = async () => await fixture.ApiClient.Users.GetAsync(user.UserId, new GetUserRequestParameters());
        await getFunc.Should().ThrowAsync<NotFoundError>();

        fixture.UnTrackIdentifier(CleanUpType.Users, newUserResponse.UserId);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    public void Attempting_to_delete_users_with_null_or_empty_id_should_throw(string id)
    {
        // The SDK doesn't validate null/empty IDs client-side - it sends the request
        // and the API returns an error (404 NotFound)
        Func<Task> deleteFunc = async () => await fixture.ApiClient.Users.DeleteAsync(id);
        deleteFunc.Should().Throw<ManagementApiException>();
    }

    [Fact]
    public async Task Test_user_by_email()
    {
        var email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}";

        var newUserRequest = TestBaseUtils.CreateUserRequest(
            connection: fixture.Connection.Name,
            email: email,
            emailVerified: true,
            password: Password
        );

        var newUserResponse = await fixture.ApiClient.Users.CreateAsync(newUserRequest);
        fixture.TrackIdentifier(CleanUpType.Users, newUserResponse.UserId);

        // Ensure we can find the user by email address
        var users = await fixture.ApiClient.Users.ListUsersByEmailAsync(new ListUsersByEmailRequestParameters { Email = email });
        Assert.Single(users);

        // Make sure they are one and the same
        Assert.Equal(newUserResponse.UserId, users.First().UserId);

        await fixture.ApiClient.Users.DeleteAsync(newUserResponse.UserId);
        fixture.UnTrackIdentifier(CleanUpType.Users, newUserResponse.UserId);
    }

    [Fact]
    public async Task Test_user_blocking()
    {
        // Add a new user, and ensure user is not blocked
        var newUserRequest = TestBaseUtils.CreateUserRequest(
            connection: fixture.Connection.Name,
            email: $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
            emailVerified: true,
            password: Password
        );
        var newUserResponse = await fixture.ApiClient.Users.CreateAsync(newUserRequest);

        fixture.TrackIdentifier(CleanUpType.Users, newUserResponse.UserId);

        Assert.NotEqual(true, newUserResponse.Blocked);

        // Ensure the user is not blocked when we select the user individually
        var user = await fixture.ApiClient.Users.GetAsync(newUserResponse.UserId, new GetUserRequestParameters());
        user.Blocked.Should().NotBeTrue();

        // Block the user, and ensure returned user is blocked
        var updateUserRequest = TestBaseUtils.CreateUpdateUserRequest();
        updateUserRequest.Blocked = true;
        var updateUserResponse = await fixture.ApiClient.Users.UpdateAsync(newUserResponse.UserId, updateUserRequest);
        updateUserResponse.Blocked.Should().BeTrue();

        // Ensure the user is not blocked when we select the user individually
        user = await fixture.ApiClient.Users.GetAsync(newUserResponse.UserId, new GetUserRequestParameters());
        user.Blocked.Should().BeTrue();

        // Delete the user
        await fixture.ApiClient.Users.DeleteAsync(user.UserId);
        fixture.UnTrackIdentifier(CleanUpType.Users, newUserResponse.UserId);
    }

    [Fact]
    public async Task Test_deleting_user_from_connection()
    {
        // Add a new user, and ensure user is not blocked
        var userEmail = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}";
        var newUserRequest = TestBaseUtils.CreateUserRequest(
            connection: fixture.Connection.Name,
            email: userEmail,
            emailVerified: true,
            password: Password
        );
        var newUserResponse = await fixture.ApiClient.Users.CreateAsync(newUserRequest);
        fixture.TrackIdentifier(CleanUpType.Users, newUserResponse.UserId);

        Assert.NotEqual(true, newUserResponse.Blocked);

        // Delete the user from the connection
        await fixture.ApiClient.Connections.Users.DeleteByEmailAsync(fixture.Connection.Id, new DeleteConnectionUsersByEmailQueryParameters
        {
            Email = userEmail
        });

        await fixture.ApiClient.Users.DeleteAsync(newUserResponse.UserId);
        fixture.UnTrackIdentifier(CleanUpType.Users, newUserResponse.UserId);
    }

    [Fact]
    public async Task Test_when_paging_not_specified_does_not_include_totals()
    {
        // Act
        var usersPager = await fixture.ApiClient.Users.ListAsync(new ListUsersRequestParameters());

        // Assert
        usersPager.CurrentPage.Items.Should().NotBeNull();
    }

    [Fact]
    public async Task Test_paging_with_totals()
    {
        // Act
        var usersPager = await fixture.ApiClient.Users.ListAsync(new ListUsersRequestParameters
        {
            Page = 0,
            PerPage = 50,
            IncludeTotals = true
        });

        // Assert
        usersPager.CurrentPage.Items.Should().NotBeNull();
    }

    [Fact]
    public async Task Test_paging_includes_totals()
    {
        // Act
        var usersPager = await fixture.ApiClient.Users.ListAsync(new ListUsersRequestParameters
        {
            Page = 0,
            PerPage = 50,
            IncludeTotals = true
        });

        // Assert
        usersPager.CurrentPage.Items.Should().NotBeNull();
    }

    [Fact]
    public async Task Test_without_paging()
    {
        // Act
        var usersPager = await fixture.ApiClient.Users.ListAsync(new ListUsersRequestParameters());

        // Assert
        var users = usersPager.CurrentPage.Items.ToList();
        users.Count.Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task Test_roles_assign_unassign_permission_to_user()
    {
        var userCreateRequest = TestBaseUtils.CreateUserRequest(
            connection: fixture.Connection.Name,
            email: $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
            emailVerified: true,
            password: Password
        );

        var user = await fixture.ApiClient.Users.CreateAsync(userCreateRequest);
        fixture.TrackIdentifier(CleanUpType.Users, user.UserId);

        // Get a resource server
        var resourceServer = await fixture.ApiClient.ResourceServers.GetAsync("dotnet-testing", new GetResourceServerRequestParameters());
        var originalScopes = resourceServer.Scopes != null ? resourceServer.Scopes.ToList() : new List<ResourceServerScope>();

        // Create a permission/scope
        var newScope = new ResourceServerScope { Value = $"{Guid.NewGuid():N}scope", Description = "Integration test" };

        // Update resource server with new scope
        var updatedResourceServer = await fixture.ApiClient.ResourceServers.UpdateAsync(resourceServer.Id, new UpdateResourceServerRequestContent
        {
            Scopes = originalScopes.Concat(new[] { newScope }).ToList(),
        });

        // Associate a permission with the user
        await fixture.ApiClient.Users.Permissions.CreateAsync(user.UserId, new CreateUserPermissionsRequestContent
        {
            Permissions = new[] { new PermissionRequestPayload { ResourceServerIdentifier = updatedResourceServer.Identifier, PermissionName = newScope.Value } }
        });

        // Ensure the permission is associated with the user
        var associatedPermissionsPager = await fixture.ApiClient.Users.Permissions.ListAsync(user.UserId, new ListUserPermissionsRequestParameters());
        var associatedPermissions = associatedPermissionsPager.CurrentPage.Items.ToList();
        associatedPermissions.Should().NotBeNull();
        associatedPermissions.Should().HaveCount(1);
        associatedPermissions.First().ResourceServerIdentifier.Should().Be(updatedResourceServer.Identifier);
        associatedPermissions.First().PermissionName.Should().Be(newScope.Value);

        // Unassociate a permission with the user
        await fixture.ApiClient.Users.Permissions.DeleteAsync(user.UserId, new DeleteUserPermissionsRequestContent
        {
            Permissions = new[] { new PermissionRequestPayload { ResourceServerIdentifier = updatedResourceServer.Identifier, PermissionName = newScope.Value } }
        });

        // Ensure the permission is unassociated with the user
        associatedPermissionsPager = await fixture.ApiClient.Users.Permissions.ListAsync(user.UserId, new ListUserPermissionsRequestParameters());
        associatedPermissions = associatedPermissionsPager.CurrentPage.Items.ToList();
        associatedPermissions.Should().NotBeNull();
        associatedPermissions.Should().HaveCount(0);

        // Clean Up - Remove the permission from the resource server
        await fixture.ApiClient.ResourceServers.UpdateAsync(resourceServer.Id, new UpdateResourceServerRequestContent
        {
            Scopes = originalScopes
        });

        // Clean Up - Remove the user
        await fixture.ApiClient.Users.DeleteAsync(user.UserId);
        fixture.UnTrackIdentifier(CleanUpType.Users, user.UserId);
    }

    [Fact]
    public async void Test_user_organizations()
    {
        var existingOrganizationId = "org_x2j4mAL75v96wKkt";
        var userCreateRequest = TestBaseUtils.CreateUserRequest(
            connection: fixture.Connection.Name,
            email: $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
            emailVerified: true,
            password: Password
        );

        var user = await fixture.ApiClient.Users.CreateAsync(userCreateRequest);
        fixture.TrackIdentifier(CleanUpType.Users, user.UserId);

        await fixture.ApiClient.Organizations.Members.CreateAsync(existingOrganizationId, new CreateOrganizationMemberRequestContent
        {
            Members = new List<string> { user.UserId }
        });

        var organizationsPager = await fixture.ApiClient.Users.Organizations.ListAsync(user.UserId, new ListUserOrganizationsRequestParameters());
        var organizations = organizationsPager.CurrentPage.Items.ToList();

        organizations.Should().NotBeNull();
        organizations.Count.Should().Be(1);

        await fixture.ApiClient.Organizations.Members.DeleteAsync(existingOrganizationId, new DeleteOrganizationMembersRequestContent
        {
            Members = new List<string> { user.UserId }
        });

        organizationsPager = await fixture.ApiClient.Users.Organizations.ListAsync(user.UserId, new ListUserOrganizationsRequestParameters());
        organizations = organizationsPager.CurrentPage.Items.ToList();

        organizations.Should().NotBeNull();
        organizations.Count.Should().Be(0);

        // Clean Up - Remove the user
        await fixture.ApiClient.Users.DeleteAsync(user.UserId);
        fixture.UnTrackIdentifier(CleanUpType.Users, user.UserId);
    }

    [Fact]
    public async Task Can_create_user_with_custom_id()
    {
        string userId = Guid.NewGuid().ToString("N");

        var userCreateRequest = TestBaseUtils.CreateUserRequest(
            connection: fixture.Connection.Name,
            email: $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
            emailVerified: true,
            password: Password,
            userId: userId
        );
        var user = await fixture.ApiClient.Users.CreateAsync(userCreateRequest);
        fixture.TrackIdentifier(CleanUpType.Users, user.UserId);

        // Retrieve the new user
        var retrievedUser = await fixture.ApiClient.Users.GetAsync(user.UserId, new GetUserRequestParameters());

        // Verify
        retrievedUser.Should().NotBeNull();
        retrievedUser.Identities.First().UserId.Should().Be(userId);

        await fixture.ApiClient.Users.DeleteAsync(user.UserId);
        fixture.UnTrackIdentifier(CleanUpType.Users, user.UserId);
    }

    [Fact]
    public async Task Can_read_profileData()
    {
        // 'profileData' is available on linked identities,
        // so first let's create a linked user

        var mainIdentityCreateRequest = TestBaseUtils.CreateUserRequest(
            connection: fixture.Connection.Name,
            email: $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
            emailVerified: true,
            password: Password
        );

        var mainUser = await fixture.ApiClient.Users.CreateAsync(mainIdentityCreateRequest);
        fixture.TrackIdentifier(CleanUpType.Users, mainUser.UserId);

        var secondaryIdentityUserCreateRequest = TestBaseUtils.CreateUserRequest(
            connection: fixture.Connection.Name,
            email: $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
            emailVerified: true,
            password: Password
        );

        var secondaryUser = await fixture.ApiClient.Users.CreateAsync(secondaryIdentityUserCreateRequest);
        fixture.TrackIdentifier(CleanUpType.Users, secondaryUser.UserId);

        await fixture.ApiClient.Users.Identities.LinkAsync(mainUser.UserId,
            TestBaseUtils.CreateLinkUserIdentityRequest(
                provider: UserIdentityProviderEnum.Auth0,
                connectionId: fixture.Connection.Id,
                userId: secondaryUser.UserId.Split('|')[1]
            ));

        var linkedUser = await fixture.ApiClient.Users.GetAsync(mainUser.UserId, new GetUserRequestParameters());
        linkedUser.Should().NotBeNull();
        linkedUser.Identities.Should().HaveCount(2);

        await fixture.ApiClient.Users.DeleteAsync(mainUser.UserId);
        fixture.UnTrackIdentifier(CleanUpType.Users, mainUser.UserId);

        await fixture.ApiClient.Users.DeleteAsync(secondaryUser.UserId);
        fixture.UnTrackIdentifier(CleanUpType.Users, secondaryUser.UserId);
    }
}
