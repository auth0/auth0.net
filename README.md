![.NET client for Auth0 Authentication and Management APIs](https://cdn.auth0.com/website/sdks/banners/auth0-net-banner.png)

![Release](https://img.shields.io/github/v/release/auth0/auth0.net)
![Downloads](https://img.shields.io/nuget/dt/auth0.core)
[![License](https://img.shields.io/:license-MIT-blue.svg?style=flat)](https://opensource.org/licenses/MIT)
[![Build and Test](https://github.com/auth0/auth0.net/actions/workflows/build.yml/badge.svg)](https://github.com/auth0/auth0.net/actions/workflows/build.yml)
[![Ask DeepWiki](https://deepwiki.com/badge.svg)](https://deepwiki.com/auth0/auth0.net)
[![fern shield](https://img.shields.io/badge/%F0%9F%8C%BF-Built%20with%20Fern-brightgreen)](https://buildwithfern.com?utm_source=github&utm_medium=github&utm_campaign=readme&utm_source=https%3A%2F%2Fgithub.com%2Fauth0%2Fauth0.net)

:books: [Documentation](#documentation) - :rocket: [Getting Started](#getting-started) - :computer: [API Reference](https://auth0.github.io/auth0.net/) - :speech_balloon: [Feedback](#feedback)

## Documentation

- [Docs site](https://www.auth0.com/docs) - explore our docs site and learn more about Auth0.
- [Examples](Examples.md) - code samples for common scenarios.

## Getting started

### Requirements
This library supports .NET Standard 2.0 and .NET Framework 4.6.2 as well as later versions of both.

### Management API

#### Installation

```powershell
Install-Package Auth0.ManagementApi
```

#### Usage

The recommended way to use the Management API is with the `ManagementClient` wrapper, which provides automatic token management and a simpler configuration experience.

##### Using ManagementClient (Recommended)

The `ManagementClient` wrapper abstracts token management through an `ITokenProvider`. Choose the built-in provider that fits your scenario, or implement the interface for full control.

**Client credentials** (recommended for server-to-server — tokens are acquired and refreshed automatically):

```csharp
var client = new ManagementClient(new ManagementClientOptions
{
    Domain = "YOUR_AUTH0_DOMAIN",
    TokenProvider = new ClientCredentialsTokenProvider(
        domain: "YOUR_AUTH0_DOMAIN",
        clientId: "YOUR_CLIENT_ID",
        clientSecret: "YOUR_CLIENT_SECRET"
    )
});

// Tokens are automatically acquired and refreshed
var users = await client.Users.GetAllAsync();
```

> **Note:** The domain is specified twice — once in `ManagementClientOptions` (to build the base API URL `https://{domain}/api/v2`) and once in `ClientCredentialsTokenProvider` (to build the token endpoint URL `https://{domain}/oauth/token`). Both must match your Auth0 tenant domain.

> **Already have a token?** Use `ManagementApiClient` directly:
> ```csharp
> var client = new ManagementApiClient(
>     token: "your-access-token",
>     clientOptions: new ClientOptions { BaseUrl = "https://YOUR_AUTH0_DOMAIN/api/v2" });
> ```

**Async delegate** (retrieve tokens from an external source such as a secret manager):

```csharp
var client = new ManagementClient(new ManagementClientOptions
{
    Domain = "YOUR_AUTH0_DOMAIN",
    TokenProvider = new DelegateTokenProvider(ct => secretManager.GetSecretAsync("auth0-token", ct))
});
```

Additional configuration options:

```csharp
var client = new ManagementClient(new ManagementClientOptions
{
    Domain = "YOUR_AUTH0_DOMAIN",
    TokenProvider = new ClientCredentialsTokenProvider(
        domain: "YOUR_AUTH0_DOMAIN",
        clientId: "YOUR_CLIENT_ID",
        clientSecret: "YOUR_CLIENT_SECRET",
        audience: "https://custom-audience/"  // Optional: defaults to https://{domain}/api/v2/
    ),
    Timeout = TimeSpan.FromSeconds(60),     // Optional: request timeout
    MaxRetries = 3,                         // Optional: retry attempts
    HttpClient = customHttpClient,          // Optional: bring your own HttpClient
    AdditionalHeaders = new Dictionary<string, string>  // Optional: custom headers
    {
        { "X-Custom-Header", "value" }
    }
});
```

##### Using ManagementApiClient (Alternative)

If you prefer to manage tokens yourself, you can use the `ManagementApiClient` directly. Generate a token for the API calls you wish to make (see [Access Tokens for the Management API](https://auth0.com/docs/api/management/v2/tokens)):

```csharp
var client = new ManagementApiClient(
    token: "your-access-token",
    clientOptions: new ClientOptions { BaseUrl = "https://YOUR_AUTH0_DOMAIN/api/v2" }
);
```

##### Making API Calls

The API calls are divided into groups which correlate to the [Management API documentation](https://auth0.com/docs/api/v2). For example all Connection related methods can be found under the `Connections` property. So to get a list of all database (Auth0) connections, you can make the following API call:

```csharp
await client.Connections.GetAllAsync("auth0");
```

See [more examples](Examples.md#management-api).

### Authentication API

#### Installation

```powershell
Install-Package Auth0.AuthenticationApi
```

#### Usage

To use the Authentication API, create a new instance of the `AuthenticationApiClient` class, passing in the URL of your Auth0 instance, e.g.:

```csharp
var client = new AuthenticationApiClient(new Uri("https://YOUR_AUTH0_DOMAIN"));
```

#### Authentication

This library contains [URL Builders](https://auth0.github.io/auth0.net/#using-url-builders) which will assist you with constructing an authentication URL, but does not actually handle the authentication/authorization flow for you. It is suggested that you refer to the [Quickstart tutorials](https://auth0.com/docs/quickstarts) for guidance on how to implement authentication for your specific platform.

**Important note on state validation**: If you choose to use the [AuthorizationUrlBuilder](https://auth0.github.io/auth0.net/api/Auth0.AuthenticationApi.Builders.AuthorizationUrlBuilder.html) to construct the authorization URL and implement a login flow callback yourself, it is important to generate and store a state value (using [WithState](https://auth0.github.io/auth0.net/api/Auth0.AuthenticationApi.Builders.AuthorizationUrlBuilder.html#Auth0_AuthenticationApi_Builders_AuthorizationUrlBuilder_WithState_System_String_)) and validate it in your callback URL before exchanging the authorization code for the tokens.

See [more examples](Examples.md#authentication-api).

## Advanced

### Accessing the Raw Response

Access raw HTTP response data (status code, headers, URL) alongside parsed response data using the `.WithRawResponse()` method.

```csharp
using Auth0.ManagementApi;

// Access raw response data (status code, headers, etc.) alongside the parsed response
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
var user = await client.Users.CreateAsync(
    new CreateUserRequestContent
    {
        Email = "user@example.com",
        Connection = "Username-Password-Authentication"
    }
);
```

### Working with Optional Fields

The SDK uses `Optional<T>` for fields that need to distinguish between "not set" (undefined) and "explicitly set to null". This is important for PATCH/update operations where you want to:

- **Undefined**: Don't send this field (leave it unchanged on the server)
- **Defined with null**: Send null (clear the field on the server)
- **Defined with value**: Send the value (update the field on the server)

```csharp
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

// Update only the name, leave other fields unchanged
var request = new UpdateUserRequestContent
{
    Name = "John Doe"  // Will be sent
    // Email, PhoneNumber, etc. are Optional<string?>.Undefined by default - won't be sent
};

// Explicitly clear a field by setting it to null
var clearNickname = new UpdateUserRequestContent
{
    Nickname = Optional<string?>.Of(null)  // Will send null to clear the nickname
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
else
{
    Console.WriteLine("Email is not being updated");
}
```

### Interfaces

The SDK provides interfaces for all clients, enabling dependency injection and testing scenarios:

```csharp
using Auth0.ManagementApi;

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
```

Sub-clients also have interfaces (e.g., `IUsersClient`, `IConnectionsClient`) for more granular mocking:

```csharp
// Mock specific sub-clients for unit testing
var mockUsersClient = new Mock<IUsersClient>();
mockUsersClient
    .Setup(c => c.GetAsync(It.IsAny<string>(), It.IsAny<GetUserRequestParameters>(), null, default))
    .ReturnsAsync(new GetUserResponseContent { UserId = "user_123" });
```

## Feedback

### Contributing

We appreciate feedback and contribution to this repo! Before you get started, please see the following:

- [Auth0's general contribution guidelines](https://github.com/auth0/open-source-template/blob/master/GENERAL-CONTRIBUTING.md)
- [Auth0's code of conduct guidelines](https://github.com/auth0/open-source-template/blob/master/CODE-OF-CONDUCT.md)
- Ensure your commits are signed to enhance security, authorship, trust and compliance.
[About commit signature verification](https://docs.github.com/en/authentication/managing-commit-signature-verification/about-commit-signature-verification)


### Raise an issue

To provide feedback or report a bug, please [raise an issue on our issue tracker](https://github.com/auth0/auth0.net/issues).

### Vulnerability Reporting

Please do not report security vulnerabilities on the public GitHub issue tracker. The [Responsible Disclosure Program](https://auth0.com/responsible-disclosure-policy) details the procedure for disclosing security issues.

---

<p align="center">
  <picture>
    <source media="(prefers-color-scheme: light)" srcset="https://cdn.auth0.com/website/sdks/logos/auth0_light_mode.png"   width="150">
    <source media="(prefers-color-scheme: dark)" srcset="https://cdn.auth0.com/website/sdks/logos/auth0_dark_mode.png" width="150">
    <img alt="Auth0 Logo" src="https://cdn.auth0.com/website/sdks/logos/auth0_light_mode.png" width="150">
  </picture>
</p>
<p align="center">Auth0 is an easy to implement, adaptable authentication and authorization platform. To learn more checkout <a href="https://auth0.com/why-auth0">Why Auth0?</a></p>
<p align="center">
This project is licensed under the MIT license. See the <a href="./LICENSE"> LICENSE</a> file for more info.</p>

