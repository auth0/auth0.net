# Change Log

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

