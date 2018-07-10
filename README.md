# .Net client library for the Auth0 platform.

Version **4.x** is meant to be used for clients that are either flagged as **OIDC Conformant** (under the **OAuth** tab in the client **Advanced settings**) or if you are triggering the OIDC-conformant pipeline by using the `audience` parameter when starting an authorization flow. 

If not, please continue using **v3.x**. Both version will be fully supported and mantained.

## Changes

* V4 contains some breaking changes (mostly to accomodate OIDC-conformant clients, 
but also fix some inconsistencies) and some new functionality. Changes are listed [here](v4-changes.md).

## Management API

### Full Documentation

Full documentation on how to use this library can be found at [http://auth0.github.io/auth0.net](http://auth0.github.io/auth0.net)

### Installation

```
Install-Package Auth0.ManagementApi
```

### Usage

Generate a token for the API calls you wish to make (see [https://auth0.com/docs/api/v2/tokens](https://auth0.com/docs/api/v2/tokens)). Create an instance of the `ManagementApiClient` class with the token and the API URL of your Auth0 instance:

~~~csharp
 var client = new ManagementApiClient("your token", new Uri("https://YOUR_AUTH0_DOMAIN/api/v2"));
~~~

The API calls are divided into groups which correlate to the [Management API documentation](https://auth0.com/docs/api/v2). For example all Connection related methods can be found under the `ManagementApiClient.Connections` property. So to get a list of all database (Auth0) connections, you can make the following API call:

```
await client.Connections.GetAllAsync("auth0");
```

## Authentication API

### Installation

```
Install-Package Auth0.AuthenticationApi
```

### Usage

To use the Authentication API, create a new instance of the `AuthenticationApiClient` class, passing in the URL of your Auth0 instance, e.g.:

```
var client = new AuthenticationApiClient(new Uri("https://YOUR_AUTH0_DOMAIN"));
```

## Authentication

This library is contains [URL Builders](http://auth0.github.io/auth0.net/#using-url-builders) which will assist you with constructing an authentication URL, but does not actually handle the authentication/authorization flow for you. It is suggested that you refer to the [Quickstart tutorials](https://auth0.com/docs/quickstarts) for guidance on how to implement authentication for your specific platform.

**Important note on state validation**: If you choose to use the [AuthorizationUrlBuilder](http://auth0.github.io/auth0.net/api/Auth0.AuthenticationApi.Builders.AuthorizationUrlBuilder.html) to construct the authorization URL and implement a login flow callback yourself, it is important to generate and store a state value (using [WithState](http://auth0.github.io/auth0.net/api/Auth0.AuthenticationApi.Builders.AuthorizationUrlBuilder.html#Auth0_AuthenticationApi_Builders_AuthorizationUrlBuilder_WithState_System_String_)) and validate it in your callback URL before calling exchanging the authorization code for the tokens.

## Documentation

For more information about [auth0](http://auth0.com) visit our [documentation page](http://docs.auth0.com/).

## Issue Reporting

If you have found a bug or if you have a feature request, please report them at this repository issues section. Please do not report security vulnerabilities on the public GitHub issue tracker. The [Responsible Disclosure Program](https://auth0.com/whitehat) details the procedure for disclosing security issues.

## Author

[Auth0](auth0.com)

## License

This project is licensed under the MIT license. See the [LICENSE](LICENSE.txt) file for more info.
