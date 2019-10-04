# Security vulnerability details for auth0.net

1. [Unintended exposure of IdentityTokenValidator](#idtokenvalidator-public) >= 5.8.0 and < 6.5.4

## Unintended exposure of IdentityTokenValidator

Versions of [auth0.net](https://github.com/auth0/auth0.net) and associated NuGet Package [Auth0.AuthenticationAPI](https://www.nuget.org/packages/Auth0.AuthenticationApi/) from `5.8.0` to `6.5.3` inclusive include a class named `IdentityTokenValidator` with a public `ValidateAsync` method, that only performs limited validation suitable for auth0 issued tokens.

## Am I affected?

You are affected by this vulnerability if all of the following conditions apply:

- You are using `IdentityTokenValidator` to validate untrusted ID tokens
- You are using a version of Auth0.AuthenticationAPI `6.5.3` or earlier

## How to fix that?

Developers should not use the `IdentityTokenValidator` class to validate untrusted ID tokens. See https://auth0.com/docs/tokens/guides/id-token/validate-id-token for our recommendations for validating ID tokens. https://jwt.io/ is a good resource on open source JWT validation libraries and their capabilities. Note that additional logic may be required based upon your use case.

Developers using the [auth0.net](https://github.com/auth0/auth0.net) and associated NuGet Package [Auth0.AuthenticationAPI](https://www.nuget.org/packages/Auth0.AuthenticationApi/) `6.5.3` or earlier should upgrade to the latest version `6.5.4` to prevent accidental usage of the `IdentityTokenValidator` class.

### Will this update impact my users?

No. This fix patches the client library that your application runs, but will not impact your users, their current state, or any existing sessions.

### Upgrade notes

1. This update marks the `IdentityTokenValidator.ValidateAsync` method deprecated and moves the previous internal logic there to an internal method.
2. If you do not receive a compiler error when using this update you are not affected.
3. If you receive a compiler error telling you to check SECURITY-NOTICE.md please follow the "How to fix that?" steps above.

### References

1. [CVE-2019-16929](https://cve.mitre.org/cgi-bin/cvename.cgi?name=CVE-2019-16929)

### Credits

- Dennis Detering (Spike Reply GmbH)
