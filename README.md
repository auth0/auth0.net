# .NET client library for the Auth0

[![Build Status](https://dev.azure.com/Auth0SDK/Auth0.Net/_apis/build/status/Auth0.Net%20Desktop%20-%20master?branchName=master)](https://dev.azure.com/Auth0SDK/Auth0.Net/_build/latest?definitionId=1&branchName=master) ![NuGet version](https://img.shields.io/nuget/v/auth0.core.svg?style=flat)


This is for clients that are either flagged as **OIDC Conformant** (under the **OAuth** tab in the client **Advanced settings**) or if you are triggering the OIDC-conformant pipeline by using the `audience` parameter when starting an authorization flow.

## Management API

### Full Documentation

Full documentation on how to use this library can be found [here](http://auth0.github.io/auth0.net).

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

This library contains [URL Builders](http://auth0.github.io/auth0.net/#using-url-builders) which will assist you with constructing an authentication URL, but does not actually handle the authentication/authorization flow for you. It is suggested that you refer to the [Quickstart tutorials](https://auth0.com/docs/quickstarts) for guidance on how to implement authentication for your specific platform.

**Important note on state validation**: If you choose to use the [AuthorizationUrlBuilder](http://auth0.github.io/auth0.net/api/Auth0.AuthenticationApi.Builders.AuthorizationUrlBuilder.html) to construct the authorization URL and implement a login flow callback yourself, it is important to generate and store a state value (using [WithState](http://auth0.github.io/auth0.net/api/Auth0.AuthenticationApi.Builders.AuthorizationUrlBuilder.html#Auth0_AuthenticationApi_Builders_AuthorizationUrlBuilder_WithState_System_String_)) and validate it in your callback URL before exchanging the authorization code for the tokens.

## Documentation

For more information about [auth0](http://auth0.com) visit our [documentation page](http://docs.auth0.com/).

## Building

This project can be built on Windows, Linux or macOS. Ensure you have the [.NET Core SDK](https://www.microsoft.com/net/download) installed. You can also use the code editor of your choice or a full-blown IDE such as Visual Studio or Jetbrains Rider.

The full set of libraries can be built by running `build.ps1` (on Windows) or `build.sh` on macOS / Linux. This will do a full compilation as well as execute the unit tests. You can run the unit tests individually by using the `dotnet test` command ([see docs](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test)).

### Building for Release

Since this library also targets the full .NET Framework, you can currently only do a build for release on Windows.

1. Ensure that you have updated the `Major`, `Minor` and `Revision` version numbers in `/build/common.props` for the new version.
1. Also update the `PackageReleaseNotes` in the above-mentioned file with the release notes.
1. Run `build.ps1` and ensure that all the tests pass.
1. Run the command `build.ps1 -Target Pack`. This will perform a full Release build and create NuGet packages (`*.nupkg`) in the `/artifacts` folder.
1. Upload the NuGet packages to NuGet using the `nuget push` command.

## Testing

To run the integration tests, create a file `client-secrets.json` in the `tests\Auth0.ManagementApi.IntegrationTests` directory.

Be aware that Auth0 [enforces rate limits](https://auth0.com/docs/policies/rate-limits), if you are running integration tests against a free-tier Auth0 account you may get `Global limit has been reached` errors.

The content should take the following format.

```
{
  "AUTH0_AUTHENTICATION_API_URL": "yourdomain.auth0.com",
  "AUTH0_MANAGEMENT_API_URL": "yourdomain.auth0.com",
  "AUTH0_MANAGEMENT_API_CLIENT_ID": "your client id",
  "AUTH0_MANAGEMENT_API_CLIENT_SECRET": "your client sercet",
  "AUTH0_MANAGEMENT_API_AUDIENCE": "https://yourdomain.auth0.com/api/v2/"
}

```

## Issue Reporting

If you have found a bug or if you have a feature request, please report them at this repository's issues section. Please do not report security vulnerabilities on the public GitHub issue tracker. The [Responsible Disclosure Program](https://auth0.com/whitehat) details the procedure for disclosing security issues.

## Author

[Auth0](auth0.com)

## License

This project is licensed under the MIT license. See the [LICENSE](LICENSE.txt) file for more info.
