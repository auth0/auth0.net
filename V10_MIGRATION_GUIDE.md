# Auth0 .NET SDK v9 to v10 Migration Guide

**Please review this guide thoroughly to understand the changes required to migrate `Auth0.ManagementApi` from v9 to v10.**

## Table of Contents

- [Overview](#overview)
- [Breaking Changes](#breaking-changes)
  - [NuGet Package](#nuget-package)
  - [Response Date Fields Now Wrapped in `Optional<T>`](#response-date-fields-now-wrapped-in-optionalt)
- [Migration Steps](#migration-steps)
- [New Features in v10](#new-features-in-v10)
  - [Network ACL Keys](#network-acl-keys)
  - [Cross-App Access on Connection Profiles](#cross-app-access-on-connection-profiles)
  - [Third-Party Client Access on `ClientMyOrganization`](#third-party-client-access-on-clientmyorganization)
  - [Network ACL Rule `match_all`](#network-acl-rule-match_all)
  - [New OAuth Scopes](#new-oauth-scopes)
- [Additional Notes](#additional-notes)
- [Troubleshooting](#troubleshooting)

## Overview

The Auth0 .NET SDK v10 builds on the v9 foundation (OpenAPI-generated via [Fern](https://github.com/fern-api/fern), System.Text.Json, `ManagementClient` with automatic token management, `WithRawResponseTask`/`WithRawResponseTask<T>` on every operation). Client initialization, request/response type naming, the pagination model (`Pager<T>`), and the sub-client organization are **unchanged** in v10.

The v10 breaking-change surface is small and confined to **reading a set of date-valued properties on session and refresh-token response types**, which are now wrapped in `Optional<T>` for consistency with the rest of the generated surface. Everything else in this release is additive.

> **Scope:** This guide covers `Auth0.ManagementApi` only. The `Auth0.Core` and `Auth0.AuthenticationApi` packages are versioned independently and are not affected by these changes. If you are still on v8, migrate to v9 first using the [v8 to v9 Migration Guide](V9_MIGRATION_GUIDE.md).

## Breaking Changes

### NuGet Package

The package name is unchanged; only the version changes.

**v9:**
```xml
<PackageReference Include="Auth0.ManagementApi" Version="9.x.x" />
```

**v10:**
```xml
<PackageReference Include="Auth0.ManagementApi" Version="10.x.x" />
```

### Response Date Fields Now Wrapped in `Optional<T>`

Several date-valued properties on session and refresh-token response types — plus one nested field on flow and session-signal types — changed from a plain nullable type (`T?`) to `Optional<T?>`. This makes the properties consistent with how the SDK represents "field may be absent" everywhere else, and lets you distinguish a field the API **omitted** from a field the API **returned as `null`**.

Because `Optional<T>` does **not** define an implicit conversion *to* its underlying type, any code that reads one of these properties as its old type will no longer compile.

#### Affected types and properties

**Refresh token responses** — returned by `client.RefreshTokens.GetAsync(...)`, `client.RefreshTokens.UpdateAsync(...)`, and (as `Pager<RefreshTokenResponseContent>`) `client.RefreshTokens.ListAsync(...)`:

| Type | Properties | v9 type | v10 type |
|------|-----------|---------|----------|
| `GetRefreshTokenResponseContent` | `CreatedAt`, `IdleExpiresAt`, `ExpiresAt`, `LastExchangedAt` | `RefreshTokenDate?` | `Optional<RefreshTokenDate?>` |
| `RefreshTokenResponseContent` | `CreatedAt`, `IdleExpiresAt`, `ExpiresAt`, `LastExchangedAt` | `RefreshTokenDate?` | `Optional<RefreshTokenDate?>` |
| `UpdateRefreshTokenResponseContent` | `CreatedAt`, `IdleExpiresAt`, `ExpiresAt`, `LastExchangedAt` | `RefreshTokenDate?` | `Optional<RefreshTokenDate?>` |

**Session responses** — returned by `client.Sessions.GetAsync(...)` and `client.Sessions.UpdateAsync(...)`:

| Type | Properties | v9 type | v10 type |
|------|-----------|---------|----------|
| `GetSessionResponseContent` | `CreatedAt`, `UpdatedAt`, `AuthenticatedAt`, `IdleExpiresAt`, `ExpiresAt`, `LastInteractedAt` | `SessionDate?` | `Optional<SessionDate?>` |
| `SessionResponseContent` | `CreatedAt`, `UpdatedAt`, `AuthenticatedAt`, `IdleExpiresAt`, `ExpiresAt`, `LastInteractedAt` | `SessionDate?` | `Optional<SessionDate?>` |
| `UpdateSessionResponseContent` | `CreatedAt`, `UpdatedAt`, `AuthenticatedAt`, `IdleExpiresAt`, `ExpiresAt`, `LastInteractedAt` | `SessionDate?` | `Optional<SessionDate?>` |

**Nested types:**

| Type | Property | v9 type | v10 type |
|------|----------|---------|----------|
| `SessionAuthenticationSignal` | `Timestamp` | `SessionDate?` | `Optional<SessionDate?>` |
| `FlowActionFlowMapValueParams` | `Fallback` | `FlowActionFlowMapValueParamsFallback?` | `Optional<FlowActionFlowMapValueParamsFallback?>` |

#### How to read the new properties

`Optional<T>` distinguishes three states: **undefined** (field absent from the response), **defined with `null`**, and **defined with a value**. The simplest drop-in replacement that preserves the old nullable semantics is `GetValueOrDefault()`, which returns `null` when the field is either undefined or explicitly `null`:

**v9 — refresh token:**
```csharp
var refreshToken = await client.RefreshTokens.GetAsync("rt_id");

// CreatedAt was RefreshTokenDate?
RefreshTokenDate? createdAt = refreshToken.CreatedAt;
if (createdAt is not null && createdAt.IsDateTime())
{
    DateTime created = createdAt.AsDateTime();
}
```

**v10 — refresh token:**
```csharp
var refreshToken = await client.RefreshTokens.GetAsync("rt_id");

// CreatedAt is now Optional<RefreshTokenDate?>
RefreshTokenDate? createdAt = refreshToken.CreatedAt.GetValueOrDefault();
if (createdAt is not null && createdAt.IsDateTime())
{
    DateTime created = createdAt.AsDateTime();
}
```

**v10 — session, including authentication-signal timestamps:**
```csharp
var session = await client.Sessions.GetAsync("session_id");

// ExpiresAt is now Optional<SessionDate?>
SessionDate? expiresAt = session.ExpiresAt.GetValueOrDefault();

// SessionAuthenticationSignal.Timestamp is now Optional<SessionDate?> as well
if (session.Authentication?.Methods is { } methods)
{
    foreach (var signal in methods)
    {
        SessionDate? timestamp = signal.Timestamp.GetValueOrDefault();
    }
}
```

**v10 — flow action fallback:**
```csharp
// params_ is a FlowActionFlowMapValueParams read from a flow response.
// Fallback is now Optional<FlowActionFlowMapValueParamsFallback?>
FlowActionFlowMapValueParamsFallback? fallback = params_.Fallback.GetValueOrDefault();
```

If you need to tell "the API omitted this field" apart from "the API returned `null`", use `IsDefined` or `TryGetValue` instead of collapsing both to `null`:

```csharp
if (refreshToken.ExpiresAt.IsDefined)
{
    // The field was present in the response (its value may still be null).
    RefreshTokenDate? expiresAt = refreshToken.ExpiresAt.Value;
}
else
{
    // The field was omitted from the response.
}

// Or, equivalently:
if (refreshToken.ExpiresAt.TryGetValue(out RefreshTokenDate? expiresAt))
{
    // expiresAt may be null; the field was present.
}
```

> **Note:** Only **reads** are affected. Constructing these types still works unchanged, because `Optional<T>` defines an implicit conversion *from* `T` — for example `new GetRefreshTokenResponseContent { CreatedAt = someRefreshTokenDate }` continues to compile.

## Migration Steps

### Step 1: Update the NuGet Package

```bash
dotnet add package Auth0.ManagementApi --version 10.*
```

Or update your `.csproj`:
```xml
<PackageReference Include="Auth0.ManagementApi" Version="10.*" />
```

### Step 2: Rebuild and Address Compiler Errors

Most v9 code compiles unchanged. The single breaking change surfaces as compiler errors wherever you read one of the affected date properties as its old type:

- **`Cannot implicitly convert type 'Auth0.ManagementApi.Core.Optional<...>' to 'Auth0.ManagementApi.RefreshTokenDate'`** (or the `SessionDate` / `FlowActionFlowMapValueParamsFallback` equivalents) — the property is now `Optional<T?>`. Use `.GetValueOrDefault()` for the old nullable semantics, or `.IsDefined` / `.TryGetValue(out ...)` when you need to distinguish an omitted field from a `null` one. See [Response Date Fields Now Wrapped in `Optional<T>`](#response-date-fields-now-wrapped-in-optionalt).

Search your codebase for reads of these properties on the affected types (`CreatedAt`, `UpdatedAt`, `AuthenticatedAt`, `IdleExpiresAt`, `ExpiresAt`, `LastInteractedAt`, `LastExchangedAt`, `Timestamp`, and `Fallback`) and wrap them accordingly.

## New Features in v10

All of the following are additive and require no code changes to adopt.

### Network ACL Keys

A new `NetworkAcls` sub-client is available under `client.Keys` for managing the keys used to verify HTTP Message Signatures on Network ACL rules.

```csharp
// Create a key
var created = await client.Keys.NetworkAcls.CreateAsync(new CreateKeysNetworkAclsRequestContent());

// List all keys
var all = await client.Keys.NetworkAcls.ListAsync();

// Retrieve a specific key
NetworkAclKey key = await client.Keys.NetworkAcls.GetAsync("key_id");
```

### Cross-App Access on Connection Profiles

`ConnectionProfile` gains an optional `CrossAppAccessResourceApp` property (JSON `cross_app_access_resource_app`), typed as `ConnectionProfileCrossAppAccessResourceApp?`.

### Third-Party Client Access on `ClientMyOrganization`

The `ClientMyOrganizationPostConfiguration`, `ClientMyOrganizationPatchConfiguration`, and `ClientMyOrganizationResponseConfiguration` types gain an optional `ThirdPartyClientAccess` property (JSON `third_party_client_access`), typed as `ClientMyOrganizationThirdPartyClientAccessConfiguration?`.

### Network ACL Rule `match_all`

`NetworkAclRule` gains an optional `MatchAll` property (`bool?`, JSON `match_all`).

### New OAuth Scopes

Two scope constants were added to `OauthScope` for the Network ACL Keys endpoints:

| Constant | Value |
|----------|-------|
| `OauthScope.CreateNetworkAclKeys` | `create:network_acl_keys` |
| `OauthScope.ReadNetworkAclKeys` | `read:network_acl_keys` |

## Additional Notes

1. **No client initialization changes**: `ManagementClient`, `ManagementClientOptions`, `ITokenProvider`, and the token provider implementations are unchanged from v9.
2. **No pagination changes**: List operations continue to return `Pager<T>` with `IAsyncEnumerable<T>` iteration.
3. **No exception changes**: `ManagementApiException` and its enriched members (`ApiError`, `RateLimit`, quota limits) introduced in v9 are unchanged.

## Troubleshooting

### Common Issues

1. **`Cannot implicitly convert type 'Auth0.ManagementApi.Core.Optional<Auth0.ManagementApi.RefreshTokenDate>' to 'Auth0.ManagementApi.RefreshTokenDate'`** (or the `SessionDate` / `FlowActionFlowMapValueParamsFallback` variants): the property is now `Optional<T?>`. Read it with `.GetValueOrDefault()`, or use `.IsDefined` / `.TryGetValue(out ...)` — see [Response Date Fields Now Wrapped in `Optional<T>`](#response-date-fields-now-wrapped-in-optionalt).
2. **`Optional value is undefined` (`InvalidOperationException`)**: you accessed `.Value` on an undefined `Optional<T>`. Guard with `.IsDefined` first, or use `.GetValueOrDefault()` / `.TryGetValue(out ...)`.

### Getting Help

- Check the [API Reference Documentation](https://auth0.github.io/auth0.net/)
- Review the [Examples](Examples.md) in the repository
- [Open an issue on GitHub](https://github.com/auth0/auth0.net/issues) for specific migration problems

---

This migration guide covers the changes needed to upgrade `Auth0.ManagementApi` from v9 to v10. The breaking-change surface is limited to reading date-valued properties on session and refresh-token responses, which are now wrapped in `Optional<T>`; the rest of the release is additive.
