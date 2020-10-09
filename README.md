# .NET client library for the Auth0

[![Build status](https://dev.azure.com/Auth0SDK/Auth0.Net/_apis/build/status/Auth0.Net)](https://dev.azure.com/Auth0SDK/Auth0.Net/_build/latest?definitionId=6) [![NuGet version](https://img.shields.io/nuget/v/auth0.core.svg?style=flat)](https://www.nuget.org/packages/Auth0.Core/)
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Fauth0%2Fauth0.net.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2Fauth0%2Fauth0.net?ref=badge_shield)

This library supports .NET Standard 2.0 and .NET Framework 4.5.2 as well as later versions of both.

This is for clients that are either flagged as **OIDC Conformant** (under the **OAuth** tab in the client **Advanced settings**) or if you are triggering the OIDC-conformant pipeline by using the `audience` parameter when starting an authorization flow.

## Management API

### Full Documentation

See the [full documentation on how to use this library](https://auth0.github.io/auth0.net).

### Installation

```powershell
Install-Package Auth0.ManagementApi
```

### Usage

Generate a token for the API calls you wish to make (see [Access Tokens for the Management API](https://auth0.com/docs/api/management/v2/tokens)). Create an instance of the `ManagementApiClient` class with the token and the API URL of your Auth0 instance:

```csharp
var client = new ManagementApiClient("your token", new Uri("https://YOUR_AUTH0_DOMAIN/api/v2"));
```

The API calls are divided into groups which correlate to the [Management API documentation](https://auth0.com/docs/api/v2). For example all Connection related methods can be found under the `ManagementApiClient.Connections` property. So to get a list of all database (Auth0) connections, you can make the following API call:

```csharp
await client.Connections.GetAllAsync("auth0");
```

## Authentication API

### Installation

```powershell
Install-Package Auth0.AuthenticationApi
```

### Usage

To use the Authentication API, create a new instance of the `AuthenticationApiClient` class, passing in the URL of your Auth0 instance, e.g.:

```csharp
var client = new AuthenticationApiClient(new Uri("https://YOUR_AUTH0_DOMAIN"));
```

## Authentication

This library contains [URL Builders](https://auth0.github.io/auth0.net/#using-url-builders) which will assist you with constructing an authentication URL, but does not actually handle the authentication/authorization flow for you. It is suggested that you refer to the [Quickstart tutorials](https://auth0.com/docs/quickstarts) for guidance on how to implement authentication for your specific platform.

**Important note on state validation**: If you choose to use the [AuthorizationUrlBuilder](https://auth0.github.io/auth0.net/api/Auth0.AuthenticationApi.Builders.AuthorizationUrlBuilder.html) to construct the authorization URL and implement a login flow callback yourself, it is important to generate and store a state value (using [WithState](https://auth0.github.io/auth0.net/api/Auth0.AuthenticationApi.Builders.AuthorizationUrlBuilder.html#Auth0_AuthenticationApi_Builders_AuthorizationUrlBuilder_WithState_System_String_)) and validate it in your callback URL before exchanging the authorization code for the tokens.

## Building

This project can be built on Windows, Linux or macOS. Ensure you have the [.NET Core SDK](https://www.microsoft.com/net/download) installed. You can also use the code editor of your choice or a full-blown IDE such as Visual Studio or Jetbrains Rider.

The full set of libraries can be built by running `dotnet restore` followed by `dotnet build`. You can run the unit tests individually by using the `dotnet test` command ([see docs](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test)).

### Building for Release

Since this library also targets the full .NET Framework, you can currently only do a build for release on Windows.

1. Ensure that you have updated the `Major`, `Minor` and `Revision` version numbers in `/build/common.props` for the new version.
1. Also update the `PackageReleaseNotes` in the above-mentioned file with the release notes.
1. Push these changes to a prepare-x.y.z branch for approval then merge
1. Wait for CI to complete, download and extract the `Auth0.Net.Packages.zip`
1. Upload the NuGet packages to NuGet using the `nuget push` command.

## Testing

This project features extensive integration tests which unfortunately require specific server-side configuration and paid plan features in order to test the full functionality. As the management API side of things specifically provides functionality that could break the configuration we do not provide keys or testing against our integration tenants.

When reviewing external pull requests we manually run the integration tests against your PR to ensure they pass and the CI server will run them once merged.

## Issue Reporting

If you have found a bug or if you have a feature request, please report them at this repository's issues section. Please do not report security vulnerabilities on the public GitHub issue tracker. The [Responsible Disclosure Program](https://auth0.com/whitehat) details the procedure for disclosing security issues.

## Author

[Auth0](https://auth0.com)

## License

This project is licensed under the MIT license. See the [LICENSE](LICENSE) file for more info.

// Triggering CI from A PR. DO NOT MERGE


[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Fauth0%2Fauth0.net.svg?type=large)](https://app.fossa.com/projects/git%2Bgithub.com%2Fauth0%2Fauth0.net?ref=badge_large)
