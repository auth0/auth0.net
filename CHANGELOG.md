# Change Log

## [7.17.4](https://github.com/auth0/auth0.net/tree/7.17.4) (2022-10-17)
[Full Changelog](https://github.com/auth0/auth0.net/compare/7.17.3...7.17.4)

**Changed**
- Rework IdTokenValidator to be able to use a proxy [\#596](https://github.com/auth0/auth0.net/pull/596) ([frederikprijck](https://github.com/frederikprijck))
- Add support for Ephemeral sessions [\#593](https://github.com/auth0/auth0.net/pull/593) ([frederikprijck](https://github.com/frederikprijck))

## [7.17.3](https://github.com/auth0/auth0.net/tree/7.17.3) (2022-10-03)
[Full Changelog](https://github.com/auth0/auth0.net/compare/7.17.2...7.17.3)

**Changed**
- [SDK-3641] Support stage property in Breached Password Detection configuration [\#591](https://github.com/auth0/auth0.net/pull/591) ([ewanharris](https://github.com/ewanharris))

## [7.17.2](https://github.com/auth0/auth0.net/tree/7.17.2) (2022-09-12)
[Full Changelog](https://github.com/auth0/auth0.net/compare/7.17.1...7.17.2)

**Changed**
- Support EnabledConnections in OrganizationCreateRequest [\#585](https://github.com/auth0/auth0.net/pull/585) ([ssurowiec](https://github.com/ssurowiec))

## [7.17.1](https://github.com/auth0/auth0.net/tree/7.17.1) (2022-09-12)
[Full Changelog](https://github.com/auth0/auth0.net/compare/7.17.0...7.17.1)

**Fixed**
- Moving IDisposable on to IManagementApiClient [\#581](https://github.com/auth0/auth0.net/pull/581) ([kevbite](https://github.com/kevbite))

## [7.17.0](https://github.com/auth0/auth0.net/tree/7.17.0) (2022-07-26)
[Full Changelog](https://github.com/auth0/auth0.net/compare/7.16.1...7.17.0)

**Added**
- Add interfaces for Management Clients [\#569](https://github.com/auth0/auth0.net/pull/569) ([DerKobe](https://github.com/derkobe))

## [7.16.1](https://github.com/auth0/auth0.net/tree/7.16.1) (2022-07-12)
[Full Changelog](https://github.com/auth0/auth0.net/compare/7.16.0...7.16.1)

**Changed**
- Add display_name to ConnectionCreateRequest and ConnectionUpdateRequest [\#573](https://github.com/auth0/auth0.net/pull/573) ([rinkeb](https://github.com/rinkeb))

## [release-7.16.0](https://github.com/auth0/auth0.net/tree/release-7.16.0) (2022-05-03)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.15.0...release-7.16.0)

**Changed**
- Add ProvisioningTicketUrl [\#562](https://github.com/auth0/auth0.net/pull/562) ([zzanol](https://github.com/zzanol))

**Security**
- [Snyk] Security upgrade Newtonsoft.Json from 12.0.3 to 13.0.1 [\#560](https://github.com/auth0/auth0.net/pull/560) ([crew-security](https://github.com/crew-security))
- [Snyk] Security upgrade Microsoft.IdentityModel.Protocols.OpenIdConnect from 5.6.0 to 6.5.0 [\#559](https://github.com/auth0/auth0.net/pull/559) ([snyk-bot](https://github.com/snyk-bot))

## [release-7.15.0](https://github.com/auth0/auth0.net/tree/release-7.15.0) (2022-03-04)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.14.0...release-7.15.0)

**Added**
- Add support for Rules Configs endpoints  [\#552](https://github.com/auth0/auth0.net/pull/552) ([caldwell0414](https://github.com/caldwell0414))

**Changed**
- Add ID Token validation to device-code and passwordless  [\#553](https://github.com/auth0/auth0.net/pull/553) ([frederikprijck](https://github.com/frederikprijck))

**Note** that with this release, ID Token validation has been added when retrieving a token using any of the Device Code or Passwordless flows.
There might be a rare occasion where this could break your application, in the situation where you are using invalid ID Tokens.
However, typically this should not cause any issues as ID Tokens are supposed to be valid. If they aren't, you probably want to get notified about it as soon as possible.

Prior to this change, those methods would return the tokens without checking the validaty of your ID Token.
However, given the fact that this should realy be an edge case, and we believe it's a good idea to inform you about invalid tokens sooner rather than later, we decided to introduce this change in a minor release.

## [release-7.14.0](https://github.com/auth0/auth0.net/tree/release-7.14.0) (2022-02-15)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.13.0...release-7.14.0)

**Added**
- Implement Attack Protection Endpoints [\#547](https://github.com/auth0/auth0.net/pull/547) ([frederikprijck](https://github.com/frederikprijck))

## [release-7.13.0](https://github.com/auth0/auth0.net/tree/release-7.13.0) (2022-02-11)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.12.1...release-7.13.0)

**Added**
- Retrieve and Update the Enabled Phone Factors [\#544](https://github.com/auth0/auth0.net/pull/544) ([frederikprijck](https://github.com/frederikprijck))

## [release-7.12.1](https://github.com/auth0/auth0.net/tree/release-7.12.1) (2022-01-07)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.12.0...release-7.12.1)

**Changed**
- Increase delay between subsequent retries [\#540](https://github.com/auth0/auth0.net/pull/540) ([frederikprijck](https://github.com/frederikprijck))

**Fixed**
- add webauthn-* enrollment auth methods [\#539](https://github.com/auth0/auth0.net/pull/539) ([frederikprijck](https://github.com/frederikprijck))
- Support updating all guardian factors [\#536](https://github.com/auth0/auth0.net/pull/536) ([frederikprijck](https://github.com/frederikprijck))

## [release-7.12.0](https://github.com/auth0/auth0.net/tree/release-7.12.0) (2021-10-27)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.11.0...release-7.12.0)

**Added**
- Support setting access token after instantiation of ManagementApiClient [\#532](https://github.com/auth0/auth0.net/pull/532) ([mfolker](https://github.com/mfolker))
- Add auth0-forwarded-for header to passwordless sms authentication for… [\#530](https://github.com/auth0/auth0.net/pull/530) ([rhyswilliamszip](https://github.com/rhyswilliamszip))

## [release-7.11.0](https://github.com/auth0/auth0.net/tree/release-7.11.0) (2021-10-01)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.10.0...release-7.11.0)

**Added**
- Add Keys Endpoints [\#527](https://github.com/auth0/auth0.net/pull/527) ([colinbobolin](https://github.com/colinbobolin))
- Added Prompt Client to Management API SDK [\#522](https://github.com/auth0/auth0.net/pull/522) ([hakuna-matata-in](https://github.com/hakuna-matata-in))

**Changed**
- [SDK-2548] Support unpaginated requests for some endpoints [\#525](https://github.com/auth0/auth0.net/pull/525) ([frederikprijck](https://github.com/frederikprijck))

## [release-7.10.0](https://github.com/auth0/auth0.net/tree/release-7.10.0) (2021-08-30)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.9.0...release-7.10.0)

**Added**
- Add support for Actions Management APIs [\#517](https://github.com/auth0/auth0.net/pull/517) ([frederikprijck](https://github.com/frederikprijck))

**Fixed**
- Ensure Checkpoint Pagination works when no next is returned [\#520](https://github.com/auth0/auth0.net/pull/520) ([frederikprijck](https://github.com/frederikprijck))

## [release-7.9.0](https://github.com/auth0/auth0.net/tree/release-7.9.0) (2021-08-24)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.8.1...release-7.9.0)

**Added**
- Add cancellation token support [\#513](https://github.com/auth0/auth0.net/pull/513) ([hawxy](https://github.com/hawxy))
- Implement automatic rate-limit handling [\#512](https://github.com/auth0/auth0.net/pull/512) ([frederikprijck](https://github.com/frederikprijck))
- Add connection property to OrganizationConnection [\#511](https://github.com/auth0/auth0.net/pull/511) ([frederikprijck](https://github.com/frederikprijck))
- Update pagination interface to support 'from' and 'take' checkpoint pagination parameters [\#507](https://github.com/auth0/auth0.net/pull/514) ([evansims](https://github.com/evansims))

**Fixed**
- GetAllMemberRolesAsync should return a list of Role instances [\#514](https://github.com/auth0/auth0.net/pull/514) ([frederikprijck](https://github.com/frederikprijck))
- Ensure CustomDomainVerification.Methods can be serialized [\#509](https://github.com/auth0/auth0.net/pull/509) ([frederikprijck](https://github.com/frederikprijck))

**Note**: In the situation where you are providing your own implementation for `IManagementConnection` or `IAuthenticationConnection`, upgrading to `7.9.0` will require changing your implementations to also include the optional `CancellationToken` parameters.

## [release-7.8.1](https://github.com/auth0/auth0.net/tree/release-7.8.1) (2021-07-07)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.8.0...release-7.8.1)

**Fixed**
- Make GuardianFactor serialization a bit more resilient to new factor names [\#504](https://github.com/auth0/auth0.net/pull/504) ([frederikprijck](https://github.com/frederikprijck))
- Set ClientSecret if defined when using PKCE [\#503](https://github.com/auth0/auth0.net/pull/503) ([frederikprijck](https://github.com/frederikprijck))

## [release-7.8.0](https://github.com/auth0/auth0.net/tree/release-7.8.0) (2021-04-02)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.7.0...release-7.8.0)

**Added**
- [SDK-2438] Add support for Organizations in Management API [\#489](https://github.com/auth0/auth0.net/pull/489) ([frederikprijck](https://github.com/frederikprijck))

## [release-7.7.0](https://github.com/auth0/auth0.net/tree/release-7.7.0) (2021-03-23)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.6.1...release-7.7.0)

**Added**
- [SDK-2400] Add support for Organizations [\#486](https://github.com/auth0/auth0.net/pull/486) ([frederikprijck](https://github.com/frederikprijck))

## [release-7.6.1](https://github.com/auth0/auth0.net/tree/release-7.6.1) (2021-03-12)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.6.0...release-7.6.1)

**Changed**
- Add ApiError to RateLimitException to access the response body [\#480](https://github.com/auth0/auth0.net/pull/480) ([fernandozpiccin](https://github.com/fernandozpiccin))

## [release-7.6.0](https://github.com/auth0/auth0.net/tree/release-7.6.0) (2021-02-15)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.5.1...release-7.6.0)

**Added**
- Adds support for /branding endpoints [\#475](https://github.com/auth0/auth0.net/pull/475) ([connorconway](https://github.com/connorconway))
- Adds support for /hooks endpoints [\#471](https://github.com/auth0/auth0.net/pull/471) ([connorconway](https://github.com/connorconway))

**Changed**
- Ensure await is using ConfigureAwait [\#474](https://github.com/auth0/auth0.net/pull/474) ([frederikprijck](https://github.com/frederikprijck))

## [release-7.5.1](https://github.com/auth0/auth0.net/tree/release-7.5.1) (2021-02-02)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.5.0...release-7.5.1)

**Changed**
- Sync Tenant Flags with API v2 [\#467](https://github.com/auth0/auth0.net/pull/467) ([frederikprijck](https://github.com/frederikprijck))
- Add ClientId to PasswordChangeTicketRequest [\#464](https://github.com/auth0/auth0.net/pull/464) ([frederikprijck](https://github.com/frederikprijck))

## [release-7.5.0](https://github.com/auth0/auth0.net/tree/release-7.5.0) (2021-01-21)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.4.0...release-7.5.0)

**Added**
- Add pagination to retrieving Device Credentials [\#460](https://github.com/auth0/auth0.net/pull/460) ([frederikprijck](https://github.com/frederikprijck))

## [release-7.4.0](https://github.com/auth0/auth0.net/tree/release-7.4.0) (2020-12-11)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.3.2...release-7.4.0)

**Added**
- Add Device Authorization flow [\#456](https://github.com/auth0/auth0.net/pull/456) ([acraven](https://github.com/acraven))

## [release-7.3.2](https://github.com/auth0/auth0.net/tree/release-7.3.2) (2020-11-13)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.3.1...release-7.3.2)

**Added**
- Allow creating and updating RefreshToken settings for Clients [\#451](https://github.com/auth0/auth0.net/pull/451) ([SamTheWizard](https://github.com/SamTheWizard))

## [release-7.3.1](https://github.com/auth0/auth0.net/tree/release-7.3.1) (2020-11-12)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.3.0...release-7.3.1)

**Fixed**
- Include WebAuthn Guardian Factory names [\#446](https://github.com/auth0/auth0.net/pull/446) ([frederikprijck](https://github.com/frederikprijck))

## [release-7.3.0](https://github.com/auth0/auth0.net/tree/release-7.3.0) (2020-10-23)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.2.0...release-7.3.0)

**Added**
- Complete passwordless API [\#438](https://github.com/auth0/auth0.net/pull/438) ([frederikprijck](https://github.com/frederikprijck))
- Implement the POST Job Users Export endpoint [\#436](https://github.com/auth0/auth0.net/pull/436) ([frederikprijck](https://github.com/frederikprijck))

## [release-7.2.0](https://github.com/auth0/auth0.net/tree/release-7.2.0)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.1.0...release-7.2.0)

- Support passing the Identity property to the payload sent to JobsClient.SendVerificationEmailAsync 
and TicketClient.CreateEmailVerificationTicketAsync in Auth0.ManagementApi
- Fix ConnectionsClient.GetAllAsync when trying to use multiple strategies in Auth0.ManagementApi
- Add Sources to the User's Permissions when using UserClient.GetPermissionsAsync in Auth0.ManagementApi.
The return type of the UserClient.GetPermissionsAsync method has been changed, 
so there might be use-cases where this is breaking your existing code base.
In case you are inheriting the UserClient and overriding the GetPermissionsAsync method, you will need to update your code
to ensure the return type matches the return type of the updated UserClient.GetPermissionsAsync method.

## [release-7.1.0](https://github.com/auth0/auth0.net/tree/release-7.1.0)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.0.9...release-7.1.0)

- Add support for Log Streams API in Auth0.ManagementApi

## [release-7.0.9](https://github.com/auth0/auth0.net/tree/release-7.0.9)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.0.8...release-7.0.9)

- Fix boolean casing on form post operations such as ImportUsersAsync so that upsert and sendCompletionEmail work.

## [release-7.0.8](https://github.com/auth0/auth0.net/tree/release-7.0.8)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.0.7...release-7.0.8)

- Add missing "connections" property on UserBlock class

## [release-7.0.7](https://github.com/auth0/auth0.net/tree/release-7.0.7)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.0.6...release-7.0.7)

- AuthenticationApiClient now respects path portions of the URI passed to the constructor.

## [release-7.0.6](https://github.com/auth0/auth0.net/tree/release-7.0.6)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.0.5...release-7.0.6)

- Force DateParseHandling of DateTime in JSON.NET serialization to avoid global setting.

## [release-7.0.5](https://github.com/auth0/auth0.net/tree/release-7.0.5)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.0.4...release-7.0.5)

- Use own JSON.NET serialization settings (avoids conflicts with changes to global)
- Fix Jobs ImportUsersAsync function, add new SendVerificationEmail setting.
- Add missing properties to Jobs class.
- Add client_secret support to passwordless authentication.

## [release-7.0.4](https://github.com/auth0/auth0.net/tree/release-7.0.4)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.0.3...release-7.0.4)

- Ensure JWKS keys are cached for the correct period.
- Raise RateLimitApiException on 429/TooManyRequests status code response.

## [release-7.0.3](https://github.com/auth0/auth0.net/tree/release-7.0.3)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.0.2...release-7.0.3)

- Fixed path encoding allowing ResourceServers.GetAsync to work with HTTP URLs #377
- Add support for extra error properties to faciliate mfa_required etc. #376

## [release-7.0.2](https://github.com/auth0/auth0.net/tree/release-7.0.2)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.0.1...release-7.0.2)

- Fixed a concurrency issue - missing ConfigureAwait(false) in HttpClient*Connections.

## [release-7.0.1](https://github.com/auth0/auth0.net/tree/release-7.0.1)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-7.0.0...release-7.0.1)

- Fixes request message disposal issue in HttpClient*Connection.GetAsync on .NET Framework 4.x

## [release-7.0.0](https://github.com/auth0/auth0.net/tree/release-7.0.0)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-6.5.6...release-7.0.0)

There are many breaking changes in this release. Please see our Migration Guide for v7 at
https://auth0.github.io/auth0.net/migrating.html

The summary of changes is:

- Authentication SDK includes new ID Token Validation. If your application uses HS256
signing you should set either SigningAlgorithm to SigningAlgorithm.HS256 on requests
you make to AuthenticationApiClient or switch to RS256 if your application is not confidential.

- Improved testing and mocking support. You can now mock `IAuthenticationConnection` /
`IManagementConnection` classes to provide local unit-testing functionality for
`AuthenticationApiClient` and `ManagementApiClient` respectively.

- Many classes moved namespace and assembly primarily ones in `Core` that were around paging.
Visual Studio should be able to suggest where classes you were using now reside.

- Disposal is now consistent. If `AuthenticationApiClient` or `ManagementApiClient` create a
connection for you they will manage its lifecycle. If you pass in a connection then it will be your
responsibility to manage it. This also applies to how `HttpClientAuthenticationConnection` and
`HttpClientManagementConnection` will only dispose of a `HttpClient` they create and not ones they
are given.

- Rate Limiting information is now only available on the `RateLimitApiException` which is raised when
the rate limit is exceeded.

- `ApiException` is now `ErrorApiException`. If you use the status code or error message on exception
you will need to switch to catching the later. The former is now a base class that does not have
this information but ensures any old catch `ApiException` will continue to catch rate limit
exceptions which also now inherit from this class.

- Microsoft recommends `HttpClient` is reused as much as possible.  Therefore you should use
dependency injection or inversion of control to ensure that either a single instance of
`AuthenticationApiClient` / `ManagementApiClient` or its connections `HttpClientXConnection` are
created to ensure sharing.  These classes are now thread-safe. You can additionally share
`HttpClient` objects between them if you wish by injecting it into the `HttpClientXConnection`
constructor.

- Connections now have DisplayName, Realms and IsDomainConnection properties.

## [release-6.5.6](https://github.com/auth0/auth0.net/tree/release-6.5.6)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-6.5.5...release-6.5.6)

- Fix sharing of ApiConnection objects (would keep expanding default Auth0-Client header)

## [release-6.5.5](https://github.com/auth0/auth0.net/tree/release-6.5.5)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-6.5.4...release-6.5.5)

- Signup API result now handles custom databases returning variations of "id" name
- Fix EnrollmentAuthMethod.Authenticator enum name
- ClientBase now has property for `initiate_login_uri`

## [release-6.5.4](https://github.com/auth0/auth0.net/tree/release-6.5.4)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-6.5.3...release-6.5.4)

SECURITY FIX for CVE-2019-16929. See https://github.com/auth0/auth0.net/blob/master/SECURITY-NOTICE.md#idtokenvalidator-public for more details.

## [release-6.5.3](https://github.com/auth0/auth0.net/tree/release-6.5.3)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-6.5.2...release-6.5.3)

WARNING: If you generate tokens in your project via System.IdentityModel.Tokens.Jwt
please read the important notice at https://github.com/auth0/auth0.net/issues/300

- Upgraded System.IdentityModel.Tokens.Jwt to 5.5 to fix incompatible kid
- Upgraded Microsoft.IdentityModel.Protocols.OpenIdConnect to 5.5
- Add ClientId to VerifyEmailJobRequest
- Updated all test dependencies (xunit, FluentAssertions, .NET Test SDK)
- Removed unused Console Workbench project

## [release-6.5.2](https://github.com/auth0/auth0.net/tree/release-6.5.2)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-6.5.1...release-6.5.2)

- UserClient.GetEnrollments now correctly passes user id.

## [release-6.5.1](https://github.com/auth0/auth0.net/tree/release-6.5.1)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-6.5.0...release-6.5.1)

- User and role permissions endpoints in UsersClient and RolesClient paging fix.

## [release-6.5.0](https://github.com/auth0/auth0.net/tree/release-6.5.0)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-6.4.0...release-6.5.0)

- Assembly is now strong-name-signed so it can be used by other strong-name-signed packages.
- NOTE: This is code signing only using a non-secret key. It is not authenticode or tamper protection.
- User and role permissions endpoints in UsersClient and RolesClient now correctly honoring paging.
- User model optional fields (CreatedAt, UpdatedAt, LastLogin) are now nullable.

## [release-6.4.0](https://github.com/auth0/auth0.net/tree/release-6.4.0)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-6.3.0...release-6.4.0)

- TenantSettings lifetimes are now double not integer.
- Added various Guardian-related endpoints on UserClient.

## [release-6.3.0](https://github.com/auth0/auth0.net/tree/release-6.3.0)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-6.2.0...release-6.3.0)

- Missing Tenant settings now available (device flow, Guardian MFA, Change Password, flags etc.

## [release-6.2.0](https://github.com/auth0/auth0.net/tree/release-6.2.0)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-6.1.0...release-6.2.0)

- Added client_id to GetDeviceCredentials response
- Added various user properties to UserUpdateRequest

## [release-6.1.0](https://github.com/auth0/auth0.net/tree/release-6.1.0)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-6.0.0...release-6.1.0)

- New user permission endpoints added to UsersClient
- New role permission endpoints added to RolesClient
- AuthenticationApiClient now implements IDisposable to dispose ApiConnection and HttpClient
- Added various new and missing properties to Resource Servers (ResourceServerBase)

## [release-6.0.0](https://github.com/auth0/auth0.net/tree/release-6.0.0)
[Full Changelog](https://github.com/auth0/auth0.net/compare/release-6.0.0...release-5.11.0)

- New GuardianClient for managing /guardian endpoints
- New RolesClient for managing /roles endpoints
- PasswordChangeTicket now has IncludeEmailInRedirect and MailEmailAsVerified
- ApiConnection now has Dispose to dispose the HttpClient it creates
- ManagementApiClient now has Dispose to dispose the ApiConnection it creates
- XML documentation tweaks
- Dependencies updated

BREAKING CHANGES
See our migration guide at https://github.com/auth0/auth0.net/blob/master/docs-source/migrating-to-v6.md

- All I*Client interfaces have been removed so adding endpoints is no longer breaking
- IManagementApi interface was removed so adding new clients is no longer breaking
- All non-paging GetAll methods have been removed
- DiagnosticsHeader/DiagnosticsComponent are no longer available

