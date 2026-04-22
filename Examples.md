# Examples using auth0.net

- [Authentication API](#authentication-api)
- [Management API](#management-api)

# Authentication API

- [1. Client Initialization](#1-client-initialization)
- [2. Login With Client Credentials](#2-login-with-client-credentials)
- [3. Authenticate using Resource Owner Password Grant Flow with MFA](#3-authenticate-using-resource-owner-password-grant-flow-with-mfa)
  - [3.1. Authenticate the User](#31-authenticate-the-user)
  - [3.2. Enroll / Challenge the user with a code](#32-enroll-challenge-the-user-with-a-code)
  - [3.3. Use the code to verify and get the access token.](#33-use-the-code-to-verify-and-get-the-access-token)
  - [3.4. Challenge an already enrolled user](#34-challenge-an-already-enrolled-user)
  - [3.5. Get the list of Authenticators for a user](#35-get-the-list-of-authenticators-for-a-user)
  - [3.6. Delete an enrolled authenticator](#36-delete-an-enrolled-authenticator)

## 1. Client Initialization

```csharp
public async Task Initialize(string returnUrl = "/")
{
    var authClient = new AuthenticationApiClient("my.custom.domain");
}
```

Or you could pass your own implementation of the `IAuthenticationConnection` to override the default behaviour of interacting with the Auth0 server as below.

```csharp
public class ExampleApp
{
    public class YourCustomImplementation : IAuthenticationConnection
    {
        public Task<T> GetAsync<T>(
            Uri uri,
            IDictionary<string, string> headers = null,
            CancellationToken cancellationToken = default)
        {
            // Custom Implementation
            return (Task<T>)Task.CompletedTask;
        }

        public Task<T> SendAsync<T>(
            HttpMethod method,
            Uri uri,
            object body,
            IDictionary<string, string> headers = null,
            CancellationToken cancellationToken = default)
        {
            // Custom Implementation
            return (Task<T>)Task.CompletedTask;
        }
    }

    public async Task Initialize(string returnUrl = "/")
    {
        var authConnection = new YourCustomImplementation();
        var authClient = new AuthenticationApiClient("my.custom.domain", authConnection);
    }
}
```

[Go to Top](#)

## 2. Login With Client Credentials

Use the client's credentials to fetch the access token for further use.
To learn more about `Client Credentials Flow` head to the [Docs](https://auth0.com/docs/get-started/authentication-and-authorization-flow/client-credentials-flow).

```csharp
public async Task LoginWithClientCredentials()
{
    var authClient = new AuthenticationApiClient("my.custom.domain");

    // Fetch the access token using the Client Credentials.
    var accessTokenResponse = await authClient.GetTokenAsync(new ClientCredentialsTokenRequest()
    {
        Audience = "audience",
        ClientId = "clientId",
        ClientSecret = "clientSecret",
    });

    Console.WriteLine($"Access Token : {accessTokenResponse.AccessToken}");
    Console.WriteLine($"Refresh Token : {accessTokenResponse.RefreshToken}");
    Console.WriteLine($"Id Token : {accessTokenResponse.IdToken}");
    Console.WriteLine($"Token Type : {accessTokenResponse.TokenType}");
    Console.WriteLine($"Expires In : {accessTokenResponse.ExpiresIn}");
}
```

[Go to Top](#)

## 3. Authenticate using Resource Owner Password Grant Flow with MFA

Head [here](https://auth0.com/docs/secure/multi-factor-authentication/authenticate-using-ropg-flow-with-mfa) to undertstand more about this flow and to get a glimpse of the pre-requisites required for this flow.

### 3.1. Authenticate the User

- When the user tries to login for the first time since enabling MFA, we would encounter an `ErrorApiException` exception indicating that MFA is required.
- We then extract the `mfa_token` from the exception and use that to enroll / challenge the user.

```csharp
public async Task LoginWithRopgWithMfa()
{
    var authClient = new AuthenticationApiClient("my.custom.domain");
    string mfaToken = "";
    try
    {
        var accessTokenResponse = await authClient.GetTokenAsync(new ResourceOwnerTokenRequest()
        {
            ClientId = "_clientId",
            ClientSecret = "_clientSecret",
            Username = "userName",
            Password = "password",
            Scope = "openid profile email", // Depends on the scopes you want to request.
            Realm = "realm"
        });
    } catch (ErrorApiException ex)
    {
        // Indicates that MFA is required.
        mfaToken = ex.ApiError.ExtraData["mfa_token"];
    }
}
```

### 3.2. Enroll / Challenge the user with a code

- Using the `mfa_token` we trigger a flow that will send out a code to the user.

```csharp
// Example of Enrolling the user
var resp = await authClient.AssociateMfaAuthenticatorAsync(
    new AssociateMfaAuthenticatorRequest
    {
        ClientId = "_clientId",
        ClientSecret = "_clientSecret",
        OobChannels = new List<string> { "sms" },
        AuthenticatorTypes = new[] { "oob" },
        Token = mfaToken,
        PhoneNumber = "+911234567890" // Users phone-number which will receive the code.
    });
```

### 3.3. Use the code to verify and get the access token.

```csharp
var token = await authClient.GetTokenAsync(new MfaOobTokenRequest()
    {
        ClientId = _clientId,
        ClientSecret = _clientSecret,
        MfaToken = mfaToken,
        OobCode = resp.OobCode,
        BindingCode = "sms" // the Code received by the user from the previous call.
    }
);
```

### 3.4. Challenge an already enrolled user

```csharp
var response = await authClient.MfaChallenge(
    new MfaChallengeRequest()
    {
        ClientId = _clientId,
        ClientSecret = _clientSecret,
        MfaToken = mfaToken,
        ChallengeType = "oob",
        AuthenticatorId = "authenticatorId"
    });
```

### 3.5. Get the list of Authenticators for a user

```csharp
var response = await authClient.ListMfaAuthenticatorsAsync("mfaToken");
```

### 3.6. Delete an enrolled authenticator

```csharp
await authClient.DeleteMfaAuthenticatorAsync(
    new DeleteMfaAuthenticatorRequest()
    {
        AccessToken = "AccessToken",
        AuthenticatorId = "id-random"
    });
```

[Go to Top](#)

# Management API

- [1. Management Client Initialization](#1-management-client-initialization)
- [2. Update M2M Token Quota at different levels](#2-update-m2m-token-quota-at-different-levels)
  - [2.1. Update Default Token Quota at Tenant level](#21-update-default-token-quota-at-tenant-level)
  - [2.2 Update Token Quota at Client level](#22-update-token-quota-at-client-level)
  - [2.2 Update Token Quota at Organisation level](#23-update-token-quota-at-organisation-level)
- [3. Get Job Error Details](#3-get-job-error-details)
- [4. Manage Network Access Control Lists (ACLs)](#4-manage-network-access-control-lists-acls)
  - [4.1 Create a Network ACL](#41-create-a-network-acl)
  - [4.2 Get all Network ACLs configured](#42-get-all-network-acls-configured)
  - [4.3 Get a specific Network ACL configuration](#43-get-a-specific-network-acl-configuration)
  - [4.4 Update Network ACL with a PATCH request](#44-update-network-acl-with-a-patch-request)
  - [4.5 Update Network ACL with a PUT request](#45-update-network-acl-with-a-put-request)
- [5. Multiple Custom Domain (MCD) Header](#5-multiple-custom-domain-mcd-header)
  - [5.1 Global configuration via ManagementClient (recommended)](#51-global-configuration-via-managementclient-recommended)
  - [5.2 Per-request override](#52-per-request-override)
  - [5.3 Global configuration via ManagementApiClient](#53-global-configuration-via-managementapiclient)

## 1. Management Client Initialization

The recommended way to initialize the Management API client is using the `ManagementClient` wrapper, which abstracts token management via an `ITokenProvider`.

**Client credentials** (recommended — tokens are acquired and refreshed automatically):

```csharp
using Auth0.ManagementApi;

public async Task Initialize()
{
    var client = new ManagementClient(new ManagementClientOptions
    {
        Domain = "my.custom.domain",
        TokenProvider = new ClientCredentialsTokenProvider(
            domain: "my.custom.domain",
            clientId: "clientId",
            clientSecret: "clientSecret"
        )
    });

    // Tokens are acquired and refreshed automatically
    var users = await client.Users.ListAsync(new ListUsersRequestParameters());
}
```

**Async delegate** (retrieve tokens from an external source such as a vault):

```csharp
var client = new ManagementClient(new ManagementClientOptions
{
    Domain = "my.custom.domain",
    TokenProvider = new DelegateTokenProvider(ct => GetTokenFromVaultAsync(ct))
});
```

If you prefer to manage tokens yourself, you can use the `ManagementApiClient` directly:

```csharp
using Auth0.ManagementApi;

public async Task InitializeWithManualToken()
{
    var authClient = new AuthenticationApiClient("my.custom.domain");

    // Fetch the access token using the Client Credentials.
    var accessTokenResponse = await authClient.GetTokenAsync(new ClientCredentialsTokenRequest()
    {
        Audience = "https://my.custom.domain/api/v2/",
        ClientId = "clientId",
        ClientSecret = "clientSecret",
    });

    var apiClient = new ManagementApiClient(
        token: accessTokenResponse.AccessToken,
        clientOptions: new ClientOptions { BaseUrl = "https://my.custom.domain/api/v2" });
}
```

[Go to Top](#)

## 2. Update M2M Token Quota at different levels

### 2.1 Update Default Token Quota at Tenant level

Assuming you have a `ManagementClient` or `ManagementApiClient` initialized as shown above.

```csharp
using Auth0.ManagementApi;

var tenantUpdateSettings = new UpdateTenantSettingsRequestContent
{
    DefaultTokenQuota = new DefaultTokenQuota
    {
        Clients = new TokenQuotaConfiguration
        {
            ClientCredentials = new TokenQuotaClientCredentials
            {
                Enforce = true,
                PerDay = 200,
                PerHour = 100
            }
        },
        Organizations = new TokenQuotaConfiguration
        {
            ClientCredentials = new TokenQuotaClientCredentials
            {
                Enforce = true,
                PerDay = 200,
                PerHour = 100
            }
        }
    }
};

var updatedSettings = await client.Tenants.Settings.UpdateAsync(tenantUpdateSettings);
```

[Go to Top](#)

### 2.2 Update Token Quota at Client level

Assuming you have a `ManagementClient` or `ManagementApiClient` initialized as shown above.

```csharp
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

var clientUpdateRequest = new UpdateClientRequestContent
{
    TokenQuota = Optional<UpdateTokenQuota?>.Of(new UpdateTokenQuota
    {
        ClientCredentials = new TokenQuotaClientCredentials
        {
            Enforce = true,
            PerDay = 200,
            PerHour = 100
        }
    })
};

var clientUpdateResponse = await client.Clients.UpdateAsync("client_id", clientUpdateRequest);
```

[Go to Top](#)

### 2.3 Update Token Quota at Organisation level

Assuming you have a `ManagementClient` or `ManagementApiClient` initialized as shown above.

```csharp
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

var orgUpdateRequest = new UpdateOrganizationRequestContent
{
    TokenQuota = Optional<UpdateTokenQuota?>.Of(new UpdateTokenQuota
    {
        ClientCredentials = new TokenQuotaClientCredentials
        {
            Enforce = true,
            PerDay = 200,
            PerHour = 100
        }
    })
};

var orgUpdateResponse = await client.Organizations.UpdateAsync("org_id", orgUpdateRequest);
```

[Go to Top](#)

## 3. Get Job Error Details

When a job fails, you can get the error details using the `Jobs.Errors.GetAsync` method.
The response is an undiscriminated union type that will contain either `IEnumerable<GetJobErrorResponseContent>` (for import job errors) or `GetJobGenericErrorResponseContent` (for other job errors).

Assuming you have a `ManagementClient` or `ManagementApiClient` initialized as shown above.

```csharp
using Auth0.ManagementApi;

public async Task GetJobErrorDetails(string jobId)
{
    var jobError = await client.Jobs.Errors.GetAsync(jobId);

    // Handle the response based on its type using Visit() for side effects
    jobError.Visit(
        importErrors =>
        {
            // Handle import job errors (IEnumerable<GetJobErrorResponseContent>)
            foreach (var error in importErrors)
            {
                Console.WriteLine($"User object: {error.User}");
                if (error.Errors != null)
                {
                    foreach (var err in error.Errors)
                    {
                        Console.WriteLine($"Error Code: {err.Code}");
                        Console.WriteLine($"Error Message: {err.Message}");
                        Console.WriteLine($"Error Path: {err.Path}");
                    }
                }
            }
        },
        genericError =>
        {
            // Handle generic job errors (GetJobGenericErrorResponseContent)
            Console.WriteLine($"Job Type: {genericError.Type}");
            Console.WriteLine($"Job Status: {genericError.Status}");
            Console.WriteLine($"Job Id: {genericError.Id}");
            Console.WriteLine($"Job Connection Id: {genericError.ConnectionId}");
            Console.WriteLine($"Job Created At: {genericError.CreatedAt}");
            Console.WriteLine($"Job Status Details: {genericError.StatusDetails}");
        }
    );

    // Alternative: Use Match() to return a value
    var summary = jobError.Match(
        importErrors => $"Import job with {importErrors.Count()} errors",
        genericError => $"Job {genericError.Id} failed with status: {genericError.Status}"
    );
    Console.WriteLine(summary);

    // Alternative: Use TryGet methods for conditional access
    if (jobError.TryGetListOfGetJobErrorResponseContent(out var errors))
    {
        Console.WriteLine($"Found {errors!.Count()} import errors");
    }
    else if (jobError.TryGetGetJobGenericErrorResponseContent(out var generic))
    {
        Console.WriteLine($"Generic error: {generic!.StatusDetails}");
    }
}
```

[Go to Top](#)

## 4. Manage Network Access Control Lists (ACLs)
You can read more about ACLs on the [Docs](https://auth0.com/docs/secure/tenant-access-control-list)

### 4.1 Create a Network ACL

Assuming a scenario where you want to create a Network ACL that blocks traffic from a specific country,
you can use the following code snippet. This example uses the `NetworkAcls` client to create a new Network ACL
with a rule that blocks traffic from an Imaginary country (IMG).

```csharp
using Auth0.ManagementApi;

public async Task CreateNetworkAcl()
{
    var networkAcl = new CreateNetworkAclRequestContent
    {
        Active = true,
        Priority = 1,
        Description = "Reject all traffic from imaginary Country",
        Rule = new NetworkAclRule
        {
            Action = new NetworkAclAction { Block = true },
            Match = new NetworkAclMatch
            {
                GeoCountryCodes = new List<string> { "IMG" }
            },
            Scope = NetworkAclRuleScopeEnum.Management
        }
    };

    await client.NetworkAcls.CreateAsync(networkAcl);
}
```

[Go to Top](#)

### 4.2 Get all Network ACLs configured

```csharp
using Auth0.ManagementApi;

public async Task GetAllNetworkAcls()
{
    var pager = await client.NetworkAcls.ListAsync(new ListNetworkAclsRequestParameters());

    await foreach (var acl in pager)
    {
        Console.WriteLine($"Network ACL ID: {acl.Id}");
        Console.WriteLine($"Description: {acl.Description}");
        Console.WriteLine($"Priority: {acl.Priority}");
        Console.WriteLine($"Active: {acl.Active}");
        Console.WriteLine($"Created At: {acl.CreatedAt}");
        Console.WriteLine($"Updated At: {acl.UpdatedAt}");
    }
}
```

[Go to Top](#)

### 4.3 Get a specific Network ACL configuration

```csharp
using Auth0.ManagementApi;

public async Task GetNetworkAcl(string aclId)
{
    var networkAcl = await client.NetworkAcls.GetAsync(aclId);

    Console.WriteLine($"Network ACL ID: {networkAcl.Id}");
    Console.WriteLine($"Description: {networkAcl.Description}");
    Console.WriteLine($"Priority: {networkAcl.Priority}");
    Console.WriteLine($"Active: {networkAcl.Active}");
    Console.WriteLine($"Created At: {networkAcl.CreatedAt}");
    Console.WriteLine($"Updated At: {networkAcl.UpdatedAt}");
}
```

[Go to Top](#)

### 4.4 Update Network ACL with a PATCH request
Assuming you have the id of the ACL to update, you can use the following code snippet.
```csharp
using Auth0.ManagementApi;

public async Task UpdateNetworkAcl(string aclId)
{
    var updateRequest = new UpdateNetworkAclRequestContent
    {
        Active = false,
        Priority = 2,
        Description = "Updated description for examples",
        Rule = new NetworkAclRule
        {
            Action = new NetworkAclAction { Block = true },
            Match = new NetworkAclMatch
            {
                GeoCountryCodes = new List<string> { "US" }
            },
            NotMatch = new NetworkAclMatch
            {
                GeoCountryCodes = new List<string> { "CA" }
            },
            Scope = NetworkAclRuleScopeEnum.Management
        }
    };
    await client.NetworkAcls.UpdateAsync(aclId, updateRequest);
}
```

[Go to Top](#)

### 4.5 Update Network ACL with a PUT request
Assuming you have the id of the ACL to update, you can use the following code snippet.
```csharp
using Auth0.ManagementApi;

public async Task SetNetworkAcl(string aclId)
{
    var setRequest = new SetNetworkAclRequestContent
    {
        Active = false,
        Priority = 2,
        Description = "Updated description for examples",
        Rule = new NetworkAclRule
        {
            Action = new NetworkAclAction { Block = true },
            Match = new NetworkAclMatch
            {
                GeoCountryCodes = new List<string> { "US" }
            },
            NotMatch = new NetworkAclMatch
            {
                GeoCountryCodes = new List<string> { "CA" }
            },
            Scope = NetworkAclRuleScopeEnum.Management
        }
    };
    await client.NetworkAcls.SetAsync(aclId, setRequest);
}
```

[Go to Top](#)

## 5. Multiple Custom Domain (MCD) Header

Auth0 tenants with Multiple Custom Domains enabled must supply the `Auth0-Custom-Domain` header
on the Management API endpoints that generate user-facing links. The affected endpoints are:

- `POST /api/v2/tickets/email-verification`
- `POST /api/v2/tickets/password-change`
- `POST /api/v2/organizations/{id}/invitations`
- `POST /api/v2/guardian/enrollments/ticket`
- `POST /api/v2/jobs/verification-email`
- `POST /api/v2/jobs/users-imports` (when `verify_email: true`)
- `POST /api/v2/users` (Create)
- `PATCH /api/v2/users/{id}` (Update, when `verify_email: true`)

### 5.1 Global configuration via ManagementClient (recommended)

When `CustomDomain` is set on `ManagementClientOptions` and no custom `HttpClient` is provided,
the SDK automatically configures a `CustomDomainInterceptor` that strips the header from any
endpoint not on the whitelist above.

```csharp
using Auth0.ManagementApi;

public async Task UseCustomDomainGlobal()
{
    var client = new ManagementClient(new ManagementClientOptions
    {
        Domain = "my.auth0.domain",
        TokenProvider = new ClientCredentialsTokenProvider(
            domain: "my.auth0.domain",
            clientId: "clientId",
            clientSecret: "clientSecret"
        ),
        CustomDomain = "login.mycompany.com"
    });

    // Auth0-Custom-Domain header is sent automatically on whitelisted endpoints
    // and stripped from all others.
    var ticket = await client.Tickets.VerifyEmailAsync(
        new VerifyEmailTicketRequestContent { UserId = "auth0|abc123" });

    Console.WriteLine($"Ticket URL: {ticket.Ticket}");
}
```

[Go to Top](#)

### 5.2 Per-request override

Use `CustomDomainHeader.For()` to supply the header for a single call without configuring it
globally. This is useful when only a subset of calls require the header, or when you need to
use a different domain for a specific request.

```csharp
using Auth0.ManagementApi;

public async Task UseCustomDomainPerRequest()
{
    // Client without a global custom domain
    var client = new ManagementClient(new ManagementClientOptions
    {
        Domain = "my.auth0.domain",
        TokenProvider = new ClientCredentialsTokenProvider(
            domain: "my.auth0.domain",
            clientId: "clientId",
            clientSecret: "clientSecret"
        )
    });

    // Supply the header only for this call
    var ticket = await client.Tickets.VerifyEmailAsync(
        new VerifyEmailTicketRequestContent { UserId = "auth0|abc123" },
        CustomDomainHeader.For("login.mycompany.com"));

    Console.WriteLine($"Ticket URL: {ticket.Ticket}");

    // Works with any whitelisted endpoint
    var invitation = await client.Organizations.Invitations.CreateAsync(
        "org_123",
        new CreateOrganizationInvitationRequestContent
        {
            Inviter = new OrganizationInvitationInviter { Name = "Admin" },
            Invitee = new OrganizationInvitationInvitee { Email = "user@example.com" },
            ClientId = "clientId"
        },
        CustomDomainHeader.For("login.mycompany.com"));
}
```

> **Combining with other per-request options:** `CustomDomainHeader.For()` is a convenience
> helper that returns a `RequestOptions` pre-populated with only the `Auth0-Custom-Domain`
> header. When you also need to set other options on the same call (additional headers, timeout,
> retries), construct `RequestOptions` directly instead:
>
> ```csharp
> await client.Tickets.VerifyEmailAsync(
>     new VerifyEmailTicketRequestContent { UserId = "auth0|abc123" },
>     new RequestOptions
>     {
>         AdditionalHeaders = new[]
>         {
>             new KeyValuePair<string, string?>("Auth0-Custom-Domain", "login.mycompany.com"),
>             new KeyValuePair<string, string?>("X-Correlation-Id", "abc-123"),
>         },
>         MaxRetries = 1,
>     });
> ```

[Go to Top](#)

### 5.3 Global configuration via ManagementApiClient

If you manage tokens yourself using `ManagementApiClient` directly, pass a `CustomDomainInterceptor`
as the `HttpClient` handler to enable automatic header stripping.

```csharp
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

public async Task UseCustomDomainWithManagementApiClient()
{
    // CustomDomainInterceptor strips the header from non-whitelisted endpoints.
    var client = new ManagementApiClient(
        token: "your-access-token",
        clientOptions: new ClientOptions
        {
            BaseUrl = "https://my.auth0.domain/api/v2",
            CustomDomain = "login.mycompany.com",
            HttpClient = new HttpClient(new CustomDomainInterceptor())
        });

    var ticket = await client.Tickets.VerifyEmailAsync(
        new VerifyEmailTicketRequestContent { UserId = "auth0|abc123" });

    Console.WriteLine($"Ticket URL: {ticket.Ticket}");
}
```

> **Note:** If you supply your own `HttpClient` alongside `CustomDomain`, the
> `CustomDomainInterceptor` is **not** injected automatically — you must add it yourself
> as shown above. Without it the header is still sent, but it will be present on every
> request rather than only whitelisted ones.

[Go to Top](#)
