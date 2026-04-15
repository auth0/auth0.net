# Auth0 .NET SDK v7 to v8 Migration Guide

**Please review this guide thoroughly to understand the changes required to migrate from Auth0.ManagementApi v7 to v8.**

## Table of Contents

- [Overview](#overview)
- [Authentication API](#authentication-api)
- [Breaking Changes](#breaking-changes)
  - [NuGet Package](#nuget-package)
  - [Client Initialization](#client-initialization)
  - [Serialization Library](#serialization-library)
  - [Request and Response Types](#request-and-response-types)
  - [Method Signatures](#method-signatures)
  - [Sub-client Organization](#sub-client-organization)
  - [Type Changes](#type-changes)
  - [Exception Handling](#exception-handling)
  - [Pagination](#pagination)
- [Migration Steps](#migration-steps)
- [Examples](#examples)
  - [User Management](#user-management)
  - [Client/Application Management](#clientapplication-management)
  - [Connection Management](#connection-management)
- [New Features in v8](#new-features-in-v8)
  - [Raw Response Access](#raw-response-access)
  - [Optional Fields for PATCH Operations](#optional-fields-for-patch-operations)
  - [Interfaces for Dependency Injection](#interfaces-for-dependency-injection)
- [Additional Notes](#additional-notes)
- [Troubleshooting](#troubleshooting)

## Overview

The Auth0 .NET SDK v8 represents a significant update to the Management API SDK with the following major improvements:

- **Generated from OpenAPI**: v8 is generated from Auth0's OpenAPI specifications using [Fern](https://github.com/fern-api/fern), ensuring consistency and accuracy
- **Improved Type Safety**: Strongly typed request/response structures with proper validation
- **Better Organization**: Management APIs are organized into dedicated sub-clients
- **Automatic Token Management**: New `ManagementClient` wrapper handles token acquisition and refresh automatically
- **Enhanced Developer Experience**: Better IntelliSense support and clear method signatures

## Authentication API

The `Auth0.AuthenticationApi` package remains unchanged between v7 and v8. Any code that worked in v7 should work in v8:

```csharp
// Works in both v7 and v8
using Auth0.AuthenticationApi;

var client = new AuthenticationApiClient(new Uri("https://YOUR_DOMAIN"));

var tokenRequest = new ResourceOwnerTokenRequest
{
    ClientId = "YOUR_CLIENT_ID",
    ClientSecret = "YOUR_CLIENT_SECRET",
    Username = "user@example.com",
    Password = "password",
    Scope = "openid profile"
};

var token = await client.GetTokenAsync(tokenRequest);
```

## Breaking Changes

### NuGet Package

The NuGet package name remains unchanged, but the version has been updated.

**v7:**
```xml
<PackageReference Include="Auth0.ManagementApi" Version="7.x.x" />
```

**v8:**
```xml
<PackageReference Include="Auth0.ManagementApi" Version="8.x.x" />
```

### Client Initialization

The way you initialize the Management API client has changed significantly. V8 introduces a new `ManagementClient` wrapper that handles token management automatically.

**v7:**
```csharp
using Auth0.ManagementApi;

// Required manual token management
var token = await GetAccessTokenAsync(); // Your token acquisition logic
var client = new ManagementApiClient(token, new Uri("https://YOUR_DOMAIN/api/v2"));
```

**v8 (Recommended - with automatic token management):**
```csharp
using Auth0.ManagementApi;

// Automatic token acquisition and refresh via client credentials
var client = new ManagementClient(new ManagementClientOptions
{
    Domain = "YOUR_DOMAIN",
    TokenProvider = new ClientCredentialsTokenProvider(
        domain: "YOUR_DOMAIN",
        clientId: "YOUR_CLIENT_ID",
        clientSecret: "YOUR_CLIENT_SECRET"
    )
});
```

**v8 (Alternative - pre-obtained token, use `ManagementApiClient` directly):**
```csharp
using Auth0.ManagementApi;

// Use a pre-obtained access token directly — no wrapper needed
var client = new ManagementApiClient(
    token: "YOUR_ACCESS_TOKEN",
    clientOptions: new ClientOptions { BaseUrl = "https://YOUR_DOMAIN/api/v2" });

// Or retrieve tokens asynchronously (e.g., from a secret manager) via ManagementClient
var client = new ManagementClient(new ManagementClientOptions
{
    Domain = "YOUR_DOMAIN",
    TokenProvider = new DelegateTokenProvider(ct => secretManager.GetSecretAsync("auth0-token", ct))
});

// Or implement ITokenProvider for any other strategy
var client = new ManagementClient(new ManagementClientOptions
{
    Domain = "YOUR_DOMAIN",
    TokenProvider = new MyCustomTokenProvider()
});
```

#### Configuration Options Comparison

| Option | v7 | v8 |
|--------|----|----|
| Domain/URL | Constructor parameter (`Uri`) | `ManagementClientOptions.Domain` |
| Token | Constructor parameter (string) | `new ManagementApiClient(token: "…", clientOptions: …)` |
| Dynamic token | Not supported | `new DelegateTokenProvider(factory)` |
| Client Credentials | Not supported (manual token) | `new ClientCredentialsTokenProvider(...)` |
| Custom token strategy | Not supported | Implement `ITokenProvider` |
| Audience | N/A | `ClientCredentialsTokenProvider` constructor parameter |
| Timeout | Via `HttpClientManagementConnection` | `ManagementClientOptions.Timeout` |
| Max Retries | Via `HttpClientManagementConnection` | `ManagementClientOptions.MaxRetries` |
| Custom HttpClient | Via `HttpClientManagementConnection` | `ManagementClientOptions.HttpClient` |
| Custom Headers | Via `HttpClientManagementConnection` | `ManagementClientOptions.AdditionalHeaders` |

### Serialization Library

V8 uses **System.Text.Json** for serialization instead of **Newtonsoft.Json** (used in v7). This is a significant change that may affect your code if you:

- Use `[JsonProperty]` attributes from Newtonsoft.Json on custom types passed to the SDK
- Rely on Newtonsoft-specific serialization behaviors (e.g., default handling of `null`, camelCase conventions, or custom `JsonConverter` implementations)
- Deserialize SDK response types with Newtonsoft.Json in your own code

**v7:**
```csharp
using Newtonsoft.Json;

// v7 models used Newtonsoft.Json attributes
public class CustomMetadata
{
    [JsonProperty("custom_field")]
    public string CustomField { get; set; }
}
```

**v8:**
```csharp
using System.Text.Json.Serialization;

// v8 models use System.Text.Json attributes
public class CustomMetadata
{
    [JsonPropertyName("custom_field")]
    public string CustomField { get; set; }
}
```

> **Note:** The `Auth0.AuthenticationApi` package continues to use Newtonsoft.Json via `Auth0.Core`. Only `Auth0.ManagementApi` has moved to System.Text.Json.

### Request and Response Types

V8 introduces specific request and response types for each operation, with different naming conventions from v7.

**v7:**
```csharp
// Request type named *CreateRequest, response is the domain type
var request = new UserCreateRequest
{
    Email = "user@example.com",
    Connection = "Username-Password-Authentication",
    Password = "SecurePassword123!"
};

User createdUser = await client.Users.CreateAsync(request);
// createdUser is of type User
```

**v8:**
```csharp
// Request type named *RequestContent, response is *ResponseContent
var request = new CreateUserRequestContent
{
    Email = "user@example.com",
    Connection = "Username-Password-Authentication",
    Password = "SecurePassword123!"
};

CreateUserResponseContent createdUser = await client.Users.CreateAsync(request);
// createdUser is of type CreateUserResponseContent
```

### Method Signatures

Method signatures have been updated with more specific types and clearer parameter structures.

**v7:**
```csharp
// Create user
Task<User> CreateAsync(UserCreateRequest request, CancellationToken cancellationToken = default);

// Get user
Task<User> GetAsync(string id, string fields = null, bool includeFields = true,
    CancellationToken cancellationToken = default);

// List users (with separate pagination parameter)
Task<IPagedList<User>> GetAllAsync(GetUsersRequest request, PaginationInfo pagination = null,
    CancellationToken cancellationToken = default);
```

**v8:**
```csharp
// Create user (WithRawResponseTask<T> awaits to T directly; call .WithRawResponse() for metadata)
WithRawResponseTask<CreateUserResponseContent> CreateAsync(
    CreateUserRequestContent request,
    RequestOptions? options = null,
    CancellationToken cancellationToken = default);

// Get user
WithRawResponseTask<GetUserResponseContent> GetAsync(
    string id,
    GetUserRequestParameters request,
    RequestOptions? options = null,
    CancellationToken cancellationToken = default);

// List users (returns async pager for automatic pagination)
Task<Pager<UserResponseSchema>> ListAsync(
    ListUsersRequestParameters request,
    RequestOptions? options = null,
    CancellationToken cancellationToken = default);
```

### Sub-client Organization

V8 introduces a hierarchical sub-client structure for related resources, improving organization and discoverability.

**v7:**
```csharp
// All user operations on a flat client
var permissions = await client.Users.GetPermissionsAsync("user_id");
var roles = await client.Users.GetRolesAsync("user_id");
var logs = await client.Users.GetLogsAsync("user_id");
var organizations = await client.Users.GetAllOrganizationsAsync("user_id");
```

**v8:**
```csharp
// Operations organized into sub-clients
var permissions = await client.Users.Permissions.ListAsync("user_id", new ListUserPermissionsRequestParameters());
var roles = await client.Users.Roles.ListAsync("user_id", new ListUserRolesRequestParameters());
var logs = await client.Users.Logs.ListAsync("user_id", new ListUserLogsRequestParameters());
var organizations = await client.Users.Organizations.ListAsync("user_id", new ListUserOrganizationsRequestParameters());
```

#### Common Sub-client Mappings

| v7 Method | v8 Sub-client |
|-----------|---------------|
| `client.Users.GetPermissionsAsync()` | `client.Users.Permissions.ListAsync()` |
| `client.Users.GetRolesAsync()` | `client.Users.Roles.ListAsync()` |
| `client.Users.AssignRolesAsync()` | `client.Users.Roles.AssignAsync()` |
| `client.Users.RemoveRolesAsync()` | `client.Users.Roles.DeleteAsync()` |
| `client.Users.GetLogsAsync()` | `client.Users.Logs.ListAsync()` |
| `client.Users.GetAllOrganizationsAsync()` | `client.Users.Organizations.ListAsync()` |
| `client.Users.LinkAccountAsync()` | `client.Users.Identities.LinkAsync()` |
| `client.Users.UnlinkAccountAsync()` | `client.Users.Identities.DeleteAsync()` |
| `client.Organizations.GetAllMembersAsync()` | `client.Organizations.Members.ListAsync()` |
| `client.Organizations.GetAllInvitationsAsync()` | `client.Organizations.Invitations.ListAsync()` |
| `client.Organizations.GetAllConnectionsAsync()` | `client.Organizations.EnabledConnections.ListAsync()` |
| `client.Actions.GetAllVersionsAsync()` | `client.Actions.Versions.ListAsync()` |
| `client.Branding.GetUniversalLoginTemplateAsync()` | `client.Branding.Templates.GetUniversalLoginAsync()` |

### Type Changes

V8 uses generated type classes with different naming conventions.

**v7:**
```csharp
using Auth0.ManagementApi.Models;

User user = ...;
Role role = ...;
Organization organization = ...;
Connection connection = ...;
```

**v8:**
```csharp
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

// Request types
CreateUserRequestContent createRequest = ...;
UpdateUserRequestContent updateRequest = ...;
ListUsersRequestParameters listParams = ...;

// Response types
CreateUserResponseContent createResponse = ...;
GetUserResponseContent getResponse = ...;
Pager<UserResponseSchema> userPager = ...;  // List operations return Pager<T>
```

Type naming conventions in v8:
- Request body types: `*RequestContent` (e.g., `CreateUserRequestContent`)
- Response types: `*ResponseContent` (e.g., `GetUserResponseContent`, `CreateUserResponseContent`)
- Response schema types: `*ResponseSchema` or `*Schema` (e.g., `UserResponseSchema`)
- Query parameters: `*RequestParameters` (e.g., `ListUsersRequestParameters`)
- List operations: Return `Pager<T>` for automatic pagination

### Exception Handling

V8 uses a unified exception hierarchy based on `ManagementApiException`.

**v7:**
```csharp
using Auth0.Core.Exceptions;
using System.Net;

try
{
    var user = await client.Users.GetAsync("user_id");
}
catch (ErrorApiException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
{
    // Handle 404
    string errorCode = ex.ApiError?.ErrorCode;
    string message = ex.ApiError?.Message;
}
catch (RateLimitApiException ex)
{
    // Handle rate limiting
    long? retryAfter = ex.RateLimit?.RetryAfter;
    DateTimeOffset? resetTime = ex.RateLimit?.Reset;
}
catch (ApiException ex)
{
    // Handle other API errors
}
```

**v8:**
```csharp
using Auth0.ManagementApi;

try
{
    var user = await client.Users.GetAsync("user_id", new GetUserRequestParameters());
}
catch (NotFoundError ex)
{
    // Handle 404
    int statusCode = ex.StatusCode; // 404
    object body = ex.Body;
}
catch (TooManyRequestsError ex)
{
    // Handle rate limiting (429)
    int statusCode = ex.StatusCode;
    object body = ex.Body;
}
catch (ManagementApiException ex)
{
    // Handle other API errors
    int statusCode = ex.StatusCode;
    object body = ex.Body;
    string message = ex.Message;
}
```

#### Exception Type Mappings

| HTTP Status | v8 Exception Type |
|-------------|-------------------|
| 400 | `BadRequestError` |
| 401 | `UnauthorizedError` |
| 403 | `ForbiddenError` |
| 404 | `NotFoundError` |
| 409 | `ConflictError` |
| 429 | `TooManyRequestsError` |
| 500 | `InternalServerError` |
| 503 | `ServiceUnavailableError` |
| Other | `ManagementApiException` |

### Pagination

V8 replaces `IPagedList<T>` with a `Pager<T>` abstraction that supports automatic pagination via `IAsyncEnumerable<T>`.

**v7:**
```csharp
// Manual pagination with IPagedList<T>
var request = new GetUsersRequest { Query = "email:*@example.com" };
var pagination = new PaginationInfo(pageNo: 0, perPage: 50, includeTotals: true);

IPagedList<User> users = await client.Users.GetAllAsync(request, pagination);
int totalUsers = users.Paging.Total;  // Total count available directly

foreach (var user in users)
{
    Console.WriteLine(user.Email);
}

// Manual next-page fetch
var nextPage = new PaginationInfo(pageNo: 1, perPage: 50, includeTotals: true);
IPagedList<User> page2 = await client.Users.GetAllAsync(request, nextPage);
```

**v8:**
```csharp
var request = new ListUsersRequestParameters
{
    Q = "email:*@example.com",
    PerPage = 50,
    IncludeTotals = true
};

var pager = await client.Users.ListAsync(request);

// Access total count from the paginated response metadata (IncludeTotals must be true).
// Note: `Total` is the server-side total across all pages, not just the current page's item count.
var firstPageResponse = (ListUsersOffsetPaginatedResponseContent?)pager.CurrentPage.Response;
var totalUsers = firstPageResponse?.Total;
Console.WriteLine($"Total users: {totalUsers}");

// Option 1: Iterate through all items across all pages automatically
// The pager fetches subsequent pages as needed
await foreach (var user in pager)
{
    Console.WriteLine(user.Email);
}

// Option 2: Iterate page by page
await foreach (var page in pager.AsPagesAsync())
{
    Console.WriteLine($"Page has {page.Items.Count} items");
    foreach (var user in page.Items)
    {
        Console.WriteLine(user.Email);
    }
}

// Option 3: Access just the current (first) page
foreach (var user in pager.CurrentPage.Items)
{
    Console.WriteLine(user.Email);
}

// Manual page navigation
if (pager.HasNextPage)
{
    var nextPage = await pager.GetNextPageAsync();
}
```

> **Note:** Pagination parameters such as `Page`, `PerPage`, and `IncludeTotals` are now part of the `*RequestParameters` types (e.g., `ListUsersRequestParameters`) instead of being passed as a separate `PaginationInfo` object.

## Migration Steps

### Step 1: Update NuGet Package

```bash
dotnet add package Auth0.ManagementApi --version 8.*
```

Or update your `.csproj`:
```xml
<PackageReference Include="Auth0.ManagementApi" Version="8.*" />
```

### Step 2: Update Client Initialization

Replace your client initialization with the new `ManagementClient` wrapper:

```csharp
// Old (v7)
var token = await GetAccessTokenAsync();
var client = new ManagementApiClient(token, new Uri("https://YOUR_DOMAIN/api/v2"));

// New (v8) - Recommended with automatic token management
var client = new ManagementClient(new ManagementClientOptions
{
    Domain = "YOUR_DOMAIN",
    TokenProvider = new ClientCredentialsTokenProvider(
        domain: "YOUR_DOMAIN",
        clientId: "YOUR_CLIENT_ID",
        clientSecret: "YOUR_CLIENT_SECRET"
    )
});
```

### Step 3: Update API Calls

Update your API calls to use the new request/response types:

```csharp
// Old (v7)
var request = new UserCreateRequest
{
    Email = "test@example.com",
    Connection = "Username-Password-Authentication"
};
User created = await client.Users.CreateAsync(request);

// New (v8)
var request = new CreateUserRequestContent
{
    Email = "test@example.com",
    Connection = "Username-Password-Authentication"
};
CreateUserResponseContent created = await client.Users.CreateAsync(request);
```

### Step 4: Update Exception Handling

Update your exception handling to use the new exception types:

```csharp
// Old (v7)
catch (ErrorApiException ex) when (ex.StatusCode == HttpStatusCode.NotFound)

// New (v8)
catch (NotFoundError ex)
```

## Examples

### User Management

**Creating a User:**

**v7:**
```csharp
var userRequest = new UserCreateRequest
{
    Email = "newuser@example.com",
    Connection = "Username-Password-Authentication",
    Password = "SecureP@ssw0rd!",
    EmailVerified = true
};

var user = await client.Users.CreateAsync(userRequest);
Console.WriteLine($"Created user: {user.UserId}");
```

**v8:**
```csharp
var request = new CreateUserRequestContent
{
    Email = "newuser@example.com",
    Connection = "Username-Password-Authentication",
    Password = "SecureP@ssw0rd!",
    EmailVerified = true
};

var user = await client.Users.CreateAsync(request);
Console.WriteLine($"Created user: {user.UserId}");
```

**Listing Users:**

**v7:**
```csharp
var request = new GetUsersRequest
{
    SearchEngine = "v3",
    Query = "email:*@example.com"
};

var pagination = new PaginationInfo(pageNo: 0, perPage: 50, includeTotals: true);

IPagedList<User> users = await client.Users.GetAllAsync(request, pagination);
foreach (var user in users)
{
    Console.WriteLine(user.Email);
}
```

**v8:**
```csharp
var request = new ListUsersRequestParameters
{
    SearchEngine = SearchEngineVersionsEnum.V3,
    Q = "email:*@example.com",
    PerPage = 50,
    IncludeTotals = true
};

var pager = await client.Users.ListAsync(request);

// Access total count from the paginated response metadata (IncludeTotals must be true).
// Note: `Total` is the server-side total across all pages, not just the current page's item count.
var firstPageResponse = (ListUsersOffsetPaginatedResponseContent?)pager.CurrentPage.Response;
var totalUsers = firstPageResponse?.Total;
Console.WriteLine($"Total users: {totalUsers}");

// Iterate through all pages automatically
await foreach (var user in pager)
{
    Console.WriteLine(user.Email);
}

// Or iterate page by page
await foreach (var page in pager.AsPagesAsync())
{
    foreach (var user in page.Items)
    {
        Console.WriteLine(user.Email);
    }
}

// Or access just the current (first) page
foreach (var user in pager.CurrentPage.Items)
{
    Console.WriteLine(user.Email);
}
```

### Client/Application Management

**Creating a Client:**

**v7:**
```csharp
var request = new ClientCreateRequest
{
    Name = "My Application",
    ApplicationType = ClientApplicationType.Spa,
    Callbacks = new List<string> { "https://myapp.com/callback" }
};

Client app = await client.Clients.CreateAsync(request);
```

**v8:**
```csharp
var request = new CreateClientRequestContent
{
    Name = "My Application",
    AppType = ClientAppTypeEnum.Spa,
    Callbacks = new[] { "https://myapp.com/callback" }
};

CreateClientResponseContent app = await client.Clients.CreateAsync(request);
```

### Connection Management

**Creating a Connection:**

**v7:**
```csharp
var request = new ConnectionCreateRequest
{
    Name = "my-database",
    Strategy = "auth0"
};

Connection connection = await client.Connections.CreateAsync(request);
```

**v8:**
```csharp
var request = new CreateConnectionRequestContent
{
    Name = "my-database",
    Strategy = ConnectionIdentityProviderEnum.Auth0
};

CreateConnectionResponseContent connection = await client.Connections.CreateAsync(request);
```

## New Features in v8

### Raw Response Access

V8 introduces the ability to access raw HTTP response metadata (status code, headers, URL) alongside parsed responses using the `.WithRawResponse()` method:

```csharp
using Auth0.ManagementApi;

// Access raw response data alongside the parsed response
var result = await client.Users.CreateAsync(
    new CreateUserRequestContent
    {
        Email = "user@example.com",
        Connection = "Username-Password-Authentication"
    }
).WithRawResponse();

// Access the parsed data
var user = result.Data;

// Access raw response metadata
var statusCode = result.RawResponse.StatusCode;
var headers = result.RawResponse.Headers;
var url = result.RawResponse.Url;

// Access specific headers (case-insensitive)
if (headers.TryGetValue("X-Request-Id", out var requestId))
{
    Console.WriteLine($"Request ID: {requestId}");
}

// For the default behavior, simply await without .WithRawResponse()
var user = await client.Users.CreateAsync(request);
```

### Optional Fields for PATCH Operations

V8 uses `Optional<T>` for update/patch request fields to properly distinguish between:
- **Undefined**: Don't send this field (leave it unchanged on the server)
- **Defined with null**: Send null (clear the field on the server)
- **Defined with value**: Send the value (update the field on the server)

**v7:**
```csharp
// In v7, null meant "don't send" - no way to explicitly clear a field
var request = new UserUpdateRequest
{
    Name = "John Doe",  // Will be sent
    Nickname = null     // Won't be sent (but you couldn't explicitly clear it)
};
```

**v8:**
```csharp
using Auth0.ManagementApi.Core;

// Update only specific fields
var request = new UpdateUserRequestContent
{
    Name = "John Doe"  // Will be sent
    // Other Optional fields are Undefined by default - won't be sent
};

// Explicitly clear a field
var clearNickname = new UpdateUserRequestContent
{
    Nickname = Optional<string?>.Of(null)  // Will send null to clear the field
};

// Check if a value is defined
if (request.Name.IsDefined)
{
    Console.WriteLine($"Name will be updated to: {request.Name.Value}");
}

// Use TryGetValue for safe access
if (request.Email.TryGetValue(out var email))
{
    Console.WriteLine($"Email: {email}");
}
```

### Interfaces for Dependency Injection

V8 provides interfaces for all clients, making dependency injection and unit testing easier:

**v7:**
```csharp
// Limited interface support - typically used concrete types
public class UserService
{
    private readonly ManagementApiClient _client;

    public UserService(ManagementApiClient client)
    {
        _client = client;
    }
}
```

**v8:**
```csharp
using Auth0.ManagementApi;

// Use IManagementApiClient interface
public class UserService
{
    private readonly IManagementApiClient _client;

    public UserService(IManagementApiClient client)
    {
        _client = client;
    }

    public async Task<GetUserResponseContent> GetUserAsync(string userId)
    {
        return await _client.Users.GetAsync(userId, new GetUserRequestParameters());
    }
}

// Register with dependency injection
services.AddSingleton<IManagementApiClient>(provider =>
{
    return new ManagementClient(new ManagementClientOptions
    {
        Domain = "YOUR_AUTH0_DOMAIN",
        TokenProvider = new ClientCredentialsTokenProvider(
            domain: "YOUR_AUTH0_DOMAIN",
            clientId: "YOUR_CLIENT_ID",
            clientSecret: "YOUR_CLIENT_SECRET"
        )
    });
});

// Sub-clients also have interfaces for granular mocking
var mockUsersClient = new Mock<IUsersClient>();
mockUsersClient
    .Setup(c => c.GetAsync(It.IsAny<string>(), It.IsAny<GetUserRequestParameters>(), null, default))
    .Returns(new WithRawResponseTask<GetUserResponseContent>(
        Task.FromResult(new WithRawResponse<GetUserResponseContent>
        {
            Data = new GetUserResponseContent { UserId = "user_123" },
            RawResponse = default!
        })
    ));
```

## Additional Notes

1. **Async Methods**: All v8 methods are async and support `CancellationToken`
2. **Request Options**: Per-request configuration is available via `RequestOptions`:
   ```csharp
   var options = new RequestOptions
   {
       Timeout = TimeSpan.FromSeconds(30),
       MaxRetries = 3,
       AdditionalHeaders = new[] { new KeyValuePair<string, string?>("X-Custom-Header", "value") }
   };

   var user = await client.Users.GetAsync("user_id", new GetUserRequestParameters(), options);
   ```
3. **Automatic Token Management**: The `ManagementClient` wrapper automatically handles token expiration and refresh when using client credentials
4. **Thread Safety**: The `ManagementClient` wrapper is thread-safe and can be used as a singleton

## Troubleshooting

### Common Issues

1. **Import Errors**: Update namespace imports from `Auth0.ManagementApi.Models` to `Auth0.ManagementApi`
2. **Type Mismatches**: Use the new `*RequestContent` and `*ResponseContent` types instead of domain objects
3. **Method Not Found**: Check the sub-client structure - methods may have moved (e.g., `GetRolesAsync` is now `Roles.ListAsync`)
4. **Missing CancellationToken**: Add `CancellationToken` parameter if needed for async operations

### Getting Help

- Check the [API Reference Documentation](https://auth0.github.io/auth0.net/)
- Review the [Examples](Examples.md) in the repository
- [Open an issue on GitHub](https://github.com/auth0/auth0.net/issues) for specific migration problems

---

This migration guide covers the major changes needed to upgrade from Auth0.ManagementApi v7 to v8. While the changes are significant, the improved type safety, automatic token management, and better organization make the SDK more robust and easier to use.
