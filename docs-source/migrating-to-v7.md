# Migration Guide

## Migrating From v6 to v7

There are a number of important changes in v7 including some that may be breaking depending on your scenarios. They are as follows:

### ID Token

As part of our on-going efforts to be OpenID Compliant, the authentication SDK expects an ID Token to always be present. Therefore, `openid` should always be passed as a `Scope` when calling `GetTokenAsync` for the `Refresh Token` or `Resource Owner Password` grants, as well as when using `AuthenticationApiClient.BuildAuthorizationUrl`. Only the [Client Credentials](https://auth0.com/docs/flows/client-credentials-flow) grant doesn't require the existence of an ID Token, as there is no user involved in the process of getting a token in that case.

### ID Token Validation

The authentication SDK now includes all-new ID Token validation capable of validating both RS256 and HS256 signed tokens.

If your app is configured for:

#### RS256

No changes are required to your application.

JWKS caching has changed. Previously it would cache the document once and it would be indefinitely until the app is restarted.

The JWKS document will now only cache for 10 minutes and will retry more frequently when presented with new signing keys. This provides support for rotation of signing keys in the future.

#### HS256

The situation here depends on whether your application [is confidential or public](https://auth0.com/docs/applications/concepts/app-types-confidential-public).

- If using HS256 and your app is confidential (e.g. a web server) then you must set `SigningAlgorithm` to `SigningAlgorithm.HS256` on all `AuthenticationApiClient` requests.

- If using HS256 and your app is **NOT** confidential (e.g. a desktop or mobile app) you should plan to move to RS256 as soon as possible. Client secrets can not be kept secure in these types of applications.

### Class Reorganization

- A number of classes previously found in the `Auth0.Core` assembly and namespace such as `PagedList`, `IPagedList`, `PagingInfo` and `PagingInformation` can now be found in the `Auth0.ManagementApi` assembly in the `Auth0.ManagementApi.Paging` namespace.

Visual Studio should be able to help locate and update `using` statements as appropriate.

### Connections

Previously there was a single connection type known as `ApiConnection` and its associated `IApiConnection` interface.

These have been replaced by `HttpClientAuthenticationConnection` and `IAuthenticationConnection` for authentication and `HttpClientManagementConnection` and `IManagementConnection` for management APIs.

These provide the following improvements:

#### Mocking

Either of these interfaces can now be easily mocked to provide full coverage of either authentication or management surface areas. There are just two methods per interface - one for GET operations and one for all other operations - that cover the entire Authentication and Management API surfaces.

#### Thread Safety & Pooling

These provide much better thread-safety as well as a clear entry-point for mocking and testing. Each has just two methods that can be mocked - one for GET and one for non-GET HTTP operations - that cover the entire Authentication and Management API surface.

Microsoft recommends `HttpClient` is reused as much as possible and these new classes provide many opportunities for re-use.

You can use dependency injection/inversion of control to ensure that either a single instance of `AuthenticationApiClient` / `ManagementApiClient` is created.

Alternatively you can use the same technique to inject a single instance of `HttpClientAuthenticationConnection` or `HttpClientManagementConnection` is created.

Finally you could take full control and share a single `HttpClient` between both `AuthenticationApiClient` and `ManagementApiClient` as well as potentially sharing the `HttpClient` with your own connections or libraries (if doing this take care to ensure none of the usage changes the default behavior such as the default HTTP headers).

### ApiInfo & Rate Limiting

Previously information about the last call made including rate limiting was exposed on both the `ApiConnection`, `AuthenticationApiClient`, and `ManagementApiClient`.

This anti-pattern discouraged sharing of the clients and connections as they are not thread-safe being the last call made and in doing so prevented re-use of the underlying `HttpClient`.

RateLimit information is now available on `RateLimitApiException`.

### Exception Handling

The introduction of the new `RateLimitApiException` meant we needed to re-organize the exceptions.

If you were catching `ApiException` previously but not using any of the custom properties on it such as `ApiError` or `ErrorCode` then you do not need to make any additional changes.

If however you use `ApiError` and `ErrorCode` then you will need to:

1. Catch the `ErrorApiException` sub-class instead which now contains these properties
2. Decide how to handle `RateLimitApiException` sub-class exceptions that may occur during rate limiting

### AuthenticationClient URL builders

The URL builder helper methods have been moved into extension methods in order to make the IAuthenticationClient interface simpler.

For most users this change will not be breaking and using them will compile as-before.
