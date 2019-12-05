# Migration Guide

## Migrating from v3 to v4

Version 4 of both the Authentication API SDK as well as the Management API SDK include breaking changes. This document will discuss the reason for these changes, as well as instructions on how to migrate to the new version.

### OIDC Conformance

The main reason for the breaking changes is related to improved OIDC compliance which was added to the Authentication API. Because of this, the behaviour of some of the existing Authentication API endpoints have changed, and other endpoints are being deprecated.

For a full background and other details please refer to the official [OIDC-conformant authentication migration guide](https://auth0.com/docs/api-auth/tutorials/adoption).

### Better separation of the Authentication and Management API

Because of the changes to the Authentication pipeline for OIDC conformance, some breaking changes were introduced and we are therefore required to increase the version number of the Authentication API SDK. One problem however was that some classes were shared in between the Authentication API SDK and the Management API SDK, in particular the information returned from the `/userinfo` endpoint. 

In the new OIDC conformant pipeline this is not the case anymore, as the endpoint return claims which conform to the [OIDC standard](http://openid.net/specs/openid-connect-core-1_0.html#StandardClaims).

Because of this single instance of shared data between the Authentication and Management API SDKs, a lot of the _Models_ returned by the various methods has been stored in the [Auth0.Core NuGet package](https://www.nuget.org/packages/Auth0.Core). With version 4 this is not the case anymore. 

All model classes are now stored in the NuGet package which they relate to. So all Authentication API SDK model classes are stored in the [Auth0.AuthenticationAPI NuGet package](https://www.nuget.org/packages/Auth0.AuthenticationApi). Likewise, all Management API SDK model classes are stored in the [Auth0.ManagementAPI NuGet package](https://www.nuget.org/packages/Auth0.ManagementApi).

The [Auth0.Core NuGet package](https://www.nuget.org/packages/Auth0.Core) only contains some shared classes used for communicating with the actual APIs, Exception classes etc.

The separation allows us to evolve these 2 packages in the future more easily in a separate directions.

## Difference between Version 3 and Version 4

Version 3 of the Auth0.NET SDK can still be used for applications which do not use the OIDC-conformant pipeline. For these applications you must install the following NuGet packages:

* [Auth0.AuthenticationAPI](https://www.nuget.org/packages/Auth0.AuthenticationApi) Version 3.x
* [Auth0.ManagementAPI](https://www.nuget.org/packages/Auth0.ManagementApi) Version 3.x
* [Auth0.Core](https://www.nuget.org/packages/Auth0.Core) Version 3.x

Version 4 of the Auth0.NET SDK **must be used** for applications which use the OIDC-conformant pipeline. For these applications you must install the following NuGet packages:

* [Auth0.AuthenticationAPI](https://www.nuget.org/packages/Auth0.AuthenticationApi) Version 4.x
* [Auth0.ManagementAPI](https://www.nuget.org/packages/Auth0.ManagementApi) Version 4.x
* [Auth0.Core](https://www.nuget.org/packages/Auth0.Core) Version 4.x

## List of changes

Here follows the list of changes made from Version 3 to Version 4 of the Auth0.NET SDK, with guidance on how to change your applications.

### Authentication API

* **Removed** all members previously marked as obsolete. This relates mostly to the methods which did not conform to the *Async naming convention for .NET `async` methods.

* **Deprecated** the `AuthenticateAsync()` method as the legacy `oauth/ro` endpoint has been disabled. You should use `GetTokenAsync(ResourceOwnerTokenRequest)` instead. `AuthenticateAsync()` has been changed to simply call the new `GetTokenAsync(ResourceOwnerTokenRequest)` method. Note that confidential clients will need to provide a `ClientSecret` in addition to the `ClientId`. For more information see the [Resource Owner Password grant type](https://auth0.com/docs/api/authentication#resource-owner-password). 

* **Changed** the response of `AuthenticateAsync()` to now return an `AccessTokenResponse` instead of `AuthorizationResponse`. 

* **Renamed** the `Connection` property in `AuthenticationRequest` class to `Realm`. It is also now optional. If the Connection is not provided in the `Realm` property, the Authentication API will use the connection specified as the Default Directory in the [Account Settings](https://manage.auth0.com/#/account). **As noted above however**, you should use `GetTokenAsync(ResourceOwnerTokenRequest)` instead.

* **Deprecated** the `GetDelegationTokenAsync(RefreshTokenDelegationRequest)` method. The token refresh exchange must be done using the `GetTokenAsync(RefreshTokenRequest)` method.

* **Renamed** the `AccessToken` class returned by authentication and token methods to `AccessTokenResponse`. 

* **Changed** the response of the `GetUserInfoAsync()` method to return a `UserInfo` class instead of `User`. This is in order to conform to the [OIDC Specification](https://openid.net/specs/openid-connect-core-1_0.html#UserInfoResponse).

* **Removed** the `GetTokenInfoAsync()` method, based on the deprecated `/tokeninfo` endpoint.

* **Removed** the `GetAccessTokenAsync` method, based on the deprecated `/oauth/access_token` endpoint.

* **Removed** the `WithDevice()` method from `AuthorizationUrlBuilder`, because of obsoleted `device` parameter.

* **Added** support for adding `nonce`, `audience`, `response_mode` and multiple `response_type` parameters to the `/authorize` URL when using the `AuthorizationUrlBuilder` class. This was done by adding the `WithNonce()`, `WithAudience()`, `WithResponseMode()` and `WithResponseType()` methods.

* **Changed** `LogoutUrlBuilder` to now use the `v2/logout` endpoint. 

* **Added** support for adding `federated` and `clientId` parameters to the `v2/logout` endpoint when using the `LogoutUrlBuilder` class. This was done by adding the `Federated()` and `WithClientId()` methods.

* **Removed** the unused `OAuthToken` class. 

* **Moved** all model classes from the `Auth0.Core` NuGet package to the `Auth0.AuthenticationApi` NuGet package. For more information see the list of Core Classes which has been affected below.

### Management API

* **Moved** all model classes from the `Auth0.Core` NuGet package to the `Auth0.ManagementApi` NuGet package. For more information see the list of Core Classes which has been affected below.

### Core Classes

The following types have been moved from the `Auth0.Core` NuGet package. Below you can see the list of classes with their old and new namespaces. Please update your code accordingly.

Class | Old Namespace | New Namespace
---------|----------|---------
Addons | Auth0.Core | Auth0.ManagementApi.Models
BlacklistedTokenBase | Auth0.Core | Auth0.ManagementApi.Models
Client | Auth0.Core | Auth0.ManagementApi.Models
ClientApplicationType | Auth0.Core | Auth0.ManagementApi.Models
ClientBase | Auth0.Core | Auth0.ManagementApi.Models
ClientGrant | Auth0.Core | Auth0.ManagementApi.Models
ClientGrantBase | Auth0.Core | Auth0.ManagementApi.Models
Connection | Auth0.Core | Auth0.ManagementApi.Models 
ConnectionBase | Auth0.Core | Auth0.ManagementApi.Models
DailyStatistics | Auth0.Core | Auth0.ManagementApi.Models
DeviceCredential | Auth0.Core | Auth0.ManagementApi.Models
DeviceCredentialBase | Auth0.Core | Auth0.ManagementApi.Models
EmailProvider | Auth0.Core | Auth0.ManagementApi.Models
EmailProviderBase | Auth0.Core | Auth0.ManagementApi.Models
EmailProviderCredentials | Auth0.Core | Auth0.ManagementApi.Models
EncryptionKey | Auth0.Core | Auth0.ManagementApi.Models
Identity | Auth0.Core | Auth0.ManagementApi.Models
Job | Auth0.Core | Auth0.ManagementApi.Models
JwtConfiguration | Auth0.Core | Auth0.ManagementApi.Models
LogEntry | Auth0.Core | Auth0.ManagementApi.Models
Mobile | Auth0.Core | Auth0.ManagementApi.Models
ResourceServer | Auth0.Core | Auth0.ManagementApi.Models
ResourceServerBase | Auth0.Core | Auth0.ManagementApi.Models
ResourceServerScope | Auth0.Core | Auth0.ManagementApi.Models
Rule | Auth0.Core | Auth0.ManagementApi.Models
RuleBase | Auth0.Core | Auth0.ManagementApi.Models
LoginRequest | Auth0.Core.Rules | Auth0.ManagementApi.Models.Rules
LoginRequestGeography | Auth0.Core.Rules | Auth0.ManagementApi.Models.Rules
LoginRequestQuery | Auth0.Core.Rules | Auth0.ManagementApi.Models.Rules
RulesContext | Auth0.Core.Rules | Auth0.ManagementApi.Models.Rules
RulesContextSsoConfiguration | Auth0.Core.Rules | Auth0.ManagementApi.Models.Rules
RulesContextStats | Auth0.Core.Rules | Auth0.ManagementApi.Models.Rules
RulesRequest | Auth0.Core.Rules | Auth0.ManagementApi.Models.Rules
ScopeEntry | Auth0.Core | Auth0.ManagementApi.Models
Scopes | Auth0.Core | Auth0.ManagementApi.Models
SigningAlgorithm | Auth0.Core | Auth0.ManagementApi.Models
SigningKey | Auth0.Core | Auth0.ManagementApi.Models
TenantErrorPage | Auth0.Core | Auth0.ManagementApi.Models
TenantSettings | Auth0.Core | Auth0.ManagementApi.Models
TenantSettingsBase | Auth0.Core | Auth0.ManagementApi.Models
Ticket | Auth0.Core | Auth0.ManagementApi.Models
TokenEndpointAuthMethod | Auth0.Core | Auth0.ManagementApi.Models
User | Auth0.Core | Auth0.ManagementApi.Models
UserBase | Auth0.Core | Auth0.ManagementApi.Models
UserBlock | Auth0.Core | Auth0.ManagementApi.Models
UserBlocks | Auth0.Core | Auth0.ManagementApi.Models
