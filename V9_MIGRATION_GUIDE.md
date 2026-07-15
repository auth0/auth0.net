# Auth0 .NET SDK v8 to v9 Migration Guide

**Please review this guide thoroughly to understand the changes required to migrate `Auth0.ManagementApi` from v8 to v9.**

## Table of Contents

- [Overview](#overview)
- [Breaking Changes](#breaking-changes)
  - [NuGet Package](#nuget-package)
  - [Void-Returning Methods Now Return `WithRawResponseTask`](#void-returning-methods-now-return-withrawresponsetask)
  - [Connection Attribute Identifier Types](#connection-attribute-identifier-types)
  - [Federated Connections Tokens Removed](#federated-connections-tokens-removed)
  - [`Asn` Device Binding Value Removed](#asn-device-binding-value-removed)
- [Migration Steps](#migration-steps)
- [New Features in v9](#new-features-in-v9)
  - [Enriched Exceptions (`ApiError`, `RateLimit`, Quota Limits)](#enriched-exceptions-apierror-ratelimit-quota-limits)
  - [Organization Roles Members Sub-client](#organization-roles-members-sub-client)
  - [Token Vault Privileged Access Grants](#token-vault-privileged-access-grants)
  - [Connection Lifecycle Events](#connection-lifecycle-events)
  - [Network ACL `auth0_managed` Matches](#network-acl-auth0_managed-matches)
  - [Typed Error Bodies](#typed-error-bodies)
- [Additional Notes](#additional-notes)
- [Troubleshooting](#troubleshooting)

## Overview

The Auth0 .NET SDK v9 builds on the v8 foundation (OpenAPI-generated via [Fern](https://github.com/fern-api/fern), System.Text.Json, `ManagementClient` with automatic token management). The client initialization, request/response type naming, pagination model (`Pager<T>`), and sub-client organization introduced in v8 are **unchanged** in v9.

v9 focuses on:

- **Uniform raw-response access** across every operation, including endpoints that return no body
- **Richer exception information**: structured API errors, rate limit, and quota details parsed from response headers
- **New Management API surface**: Organization Roles members, Token Vault privileged access grants, and Connection lifecycle event streams
- **More precise types**: per-attribute Connection identifier types replacing a single shared type
- **Surface removals**: the Federated Connections Tokens client and related types have been removed, along with the `asn` client session transfer device binding value

> **Scope:** This guide covers `Auth0.ManagementApi` only. If you are still on v7, migrate to v8 first using the [v7 to v8 Migration Guide](V8_MIGRATION_GUIDE.md).

## Breaking Changes

### NuGet Package

The package name is unchanged; only the version changes.

**v8:**
```xml
<PackageReference Include="Auth0.ManagementApi" Version="8.x.x" />
```

**v9:**
```xml
<PackageReference Include="Auth0.ManagementApi" Version="9.x.x" />
```

### Void-Returning Methods Now Return `WithRawResponseTask`

In v8, operations with no response body (deletes, unblocks, and other side-effecting calls) returned a plain `Task`. In v9 these return the new non-generic `WithRawResponseTask`, mirroring how body-returning methods return `WithRawResponseTask<T>`. This gives every operation access to raw HTTP response metadata (status code, URL, headers) via `.WithRawResponse()`.

This change affects approximately 97 methods across the client interfaces (`DeleteAsync`, `UnblockIpAsync`, `CheckIpAsync`, `SetAsync`, `UpdateUniversalLoginAsync`, and similar void operations).

**v8:**
```csharp
Task DeleteAsync(
    string id,
    RequestOptions? options = null,
    CancellationToken cancellationToken = default);
```

**v9:**
```csharp
WithRawResponseTask DeleteAsync(
    string id,
    RequestOptions? options = null,
    CancellationToken cancellationToken = default);
```

**What you need to do — usually nothing.** `WithRawResponseTask` is awaitable and completes with no value (void semantics), and it defines an implicit conversion to `Task`. Existing `await` call sites continue to compile and behave identically:

```csharp
// Works in both v8 and v9
await client.Users.DeleteAsync("user_id");
```

You only need to change code that relied on the return type being exactly `Task`:

```csharp
// v8 — storing the result as Task
Task deletion = client.Users.DeleteAsync("user_id");
await deletion;

// v9 — either await directly, or convert explicitly
await client.Users.DeleteAsync("user_id");

// or, if you must hold a Task reference:
Task deletion = client.Users.DeleteAsync("user_id"); // implicit conversion applies
await deletion;
```

**New capability** — you can now read response metadata from these operations:

```csharp
var raw = await client.Users.DeleteAsync("user_id").WithRawResponse();
Console.WriteLine($"Status: {raw.StatusCode}");
if (raw.Headers.TryGetValue("X-Request-Id", out var requestId))
{
    Console.WriteLine($"Request ID: {requestId}");
}
```

> **Note:** Method groups passed where a `Task`-returning delegate is expected (e.g. `Func<..., Task>`) may need an explicit lambda wrapper, since the method now returns `WithRawResponseTask` rather than `Task`.

### Connection Attribute Identifier Types

The single shared `ConnectionAttributeIdentifier` type has been split into three per-attribute types. The `Identifier` property on each Connection attribute now uses its own type instead of the shared one.

| Attribute type | v8 `Identifier` type | v9 `Identifier` type |
|----------------|----------------------|----------------------|
| `EmailAttribute` | `ConnectionAttributeIdentifier` | `EmailAttributeIdentifier` |
| `PhoneAttribute` | `ConnectionAttributeIdentifier` | `PhoneAttributeIdentifier` |
| `UsernameAttribute` | `ConnectionAttributeIdentifier` | `UsernameAttributeIdentifier` |

Each new type carries an `Active` flag and an attribute-specific `DefaultMethod` enum (for example, `EmailAttributeIdentifier.DefaultMethod` is a `DefaultMethodEmailIdentifierEnum?`).

**v8:**
```csharp
var email = new EmailAttribute
{
    Identifier = new ConnectionAttributeIdentifier { Active = true }
};
```

**v9:**
```csharp
var email = new EmailAttribute
{
    Identifier = new EmailAttributeIdentifier
    {
        Active = true,
        DefaultMethod = DefaultMethodEmailIdentifierEnum.Email
    }
};
```

**What you need to do:** Replace references to `ConnectionAttributeIdentifier` with the type matching the attribute you are configuring. Any code that constructed or read `ConnectionAttributeIdentifier` directly will fail to compile and must be updated.

### Federated Connections Tokens Removed

The Federated Connections Tokens surface has been removed in v9. This affects the `Users.FederatedConnectionsTokensets` sub-client, its associated types, the `federated_connections_access_tokens` connection option, and the related OAuth scopes.

**Removed members:**

| Removed in v9 | Kind |
|----------------|------|
| `client.Users.FederatedConnectionsTokensets` (`ListAsync`, `DeleteAsync`) | Sub-client |
| `FederatedConnectionTokenSet` | Type |
| `ConnectionFederatedConnectionsAccessTokens` | Type |
| `FederatedConnectionsAccessTokens` property on `ConnectionPropertiesOptions`, `UpdateConnectionOptions`, `ConnectionOptionsAzureAd`, `ConnectionOptionsCommonOidc`, `ConnectionOptionsGoogleApps`, `ConnectionOptionsOidc`, `ConnectionOptionsOkta` | Property |
| `OauthScope.ReadFederatedConnectionsTokens` (`read:federated_connections_tokens`) | Scope constant |
| `OauthScope.DeleteFederatedConnectionsTokens` (`delete:federated_connections_tokens`) | Scope constant |

**v8:**
```csharp
// Listing / deleting a user's federated connection token sets
var tokenSets = await client.Users.FederatedConnectionsTokensets.ListAsync("user_id");
await client.Users.FederatedConnectionsTokensets.DeleteAsync("user_id");

// Enabling token collection on a connection option
var options = new ConnectionOptionsOidc
{
    FederatedConnectionsAccessTokens = new ConnectionFederatedConnectionsAccessTokens
    {
        Active = true
    }
};
```

**v9:** No replacement. Remove the sub-client calls, the `FederatedConnectionsAccessTokens` assignments, and any use of the removed scope constants. Any code referencing these members will fail to compile and must be deleted.

**What you need to do:** Delete all usages of the members listed above. If you were relying on federated connection token collection, coordinate the replacement approach with the Auth0 API rather than the SDK.

### `Asn` Device Binding Value Removed

The `Asn` value has been removed from `ClientSessionTransferDelegationDeviceBindingEnum`. Only `Ip` remains.

**v8:**
```csharp
var binding = ClientSessionTransferDelegationDeviceBindingEnum.Asn;
```

**v9:**
```csharp
// Asn is no longer available; only Ip remains
var binding = ClientSessionTransferDelegationDeviceBindingEnum.Ip;
```

**What you need to do:** Replace any use of `ClientSessionTransferDelegationDeviceBindingEnum.Asn` (or the string value `"asn"`). Code referencing the removed value will fail to compile.

## Migration Steps

### Step 1: Update the NuGet Package

```bash
dotnet add package Auth0.ManagementApi --version 9.*
```

Or update your `.csproj`:
```xml
<PackageReference Include="Auth0.ManagementApi" Version="9.*" />
```

### Step 2: Rebuild and Address Compiler Errors

Most v8 code compiles unchanged. The breaking changes surface as compiler errors:

1. **`ConnectionAttributeIdentifier` not found** — replace with `EmailAttributeIdentifier`, `PhoneAttributeIdentifier`, or `UsernameAttributeIdentifier` as appropriate (see [Connection Attribute Identifier Types](#connection-attribute-identifier-types)).
2. **Cannot implicitly convert `WithRawResponseTask` to `Task`** — only appears where a delete/void method result was stored as an explicit `Task` or passed to a `Task`-typed parameter. Await it directly, or rely on the implicit conversion (see [Void-Returning Methods](#void-returning-methods-now-return-withrawresponsetask)).
3. **`FederatedConnectionsTokensets` / `FederatedConnectionTokenSet` / `ConnectionFederatedConnectionsAccessTokens` / `FederatedConnectionsAccessTokens` not found** — the Federated Connections Tokens surface was removed; delete these usages (see [Federated Connections Tokens Removed](#federated-connections-tokens-removed)).
4. **`ClientSessionTransferDelegationDeviceBindingEnum` does not contain a definition for `Asn`** — use `Ip`; `Asn` was removed (see [`Asn` Device Binding Value Removed](#asn-device-binding-value-removed)).

### Step 3 (Optional): Adopt the Enriched Exception Information

If you handle `ManagementApiException` (or its subtypes such as `TooManyRequestsError`), you can now read structured error and rate-limit data. See [Enriched Exceptions](#enriched-exceptions-apierror-ratelimit-quota-limits).

## New Features in v9

### Enriched Exceptions (`ApiError`, `RateLimit`, Quota Limits)

`ManagementApiException` now exposes structured, lazily-parsed error and rate-limit information. All members are additive — existing `StatusCode` and `Body` access is unchanged.

```csharp
using Auth0.ManagementApi;

try
{
    await client.Users.GetAsync("user_id", new GetUserRequestParameters());
}
catch (TooManyRequestsError ex)
{
    // Structured error payload parsed from the response body
    string? code = ex.ErrorCode;      // machine-readable error code
    string? description = ex.Description; // human-readable message
    ApiError? apiError = ex.ApiError;  // full structured error, or null

    // Rate limit details parsed from response headers
    RateLimit? rl = ex.RateLimit;
    long? remaining = rl?.Remaining;             // x-ratelimit-remaining
    DateTimeOffset? reset = rl?.Reset;           // x-ratelimit-reset
    TimeSpan? retryAfter = rl?.RetryAfter;       // retry-after

    // Quota details (when present)
    var clientQuota = rl?.ClientQuotaLimit;      // Auth0-Client-Quota-Limit
    var orgQuota = rl?.OrganizationQuotaLimit;   // Auth0-Organization-Quota-Limit
}
catch (ManagementApiException ex)
{
    int statusCode = ex.StatusCode;
    object body = ex.Body;
    string? errorCode = ex.ErrorCode;
    string message = ex.Message; // now surfaces the API's error description when available
}
```

Key additions on `ManagementApiException`:

| Member | Description |
|--------|-------------|
| `ApiError? ApiError` | Structured error (`Error`, `ErrorCode`, `Message`) parsed from the body, or `null` |
| `string? ErrorCode` | Machine-readable error code shortcut |
| `string? Description` | Human-readable error description shortcut |
| `RateLimit? RateLimit` | Rate limit + quota info parsed from response headers, or `null` |
| `RawResponse? RawResponse` | Raw HTTP response (status, URL, headers) when available |

> **Note:** `Message` now returns the API's error description when one was parsed, falling back to the SDK's default message otherwise. If you log or assert on exact message text, review those sites.

### Organization Roles Members Sub-client

v9 adds a `Members` sub-client under Organization Roles, letting you list the organization members assigned a specific role within an organization.

```csharp
var pager = await client.Organizations.Roles.Members.ListAsync(
    id: "org_id",
    roleId: "rol_id",
    new ListOrganizationRoleMembersRequestParameters());

await foreach (var member in pager)
{
    Console.WriteLine(member);
}
```

The result is a `Pager<RoleMember>`, consistent with the v8 pagination model.

### Token Vault Privileged Access Grants

v9 adds the `TokenVaultPrivilegedAccessGrant` type for granting client credential (M2M) applications privileged access to Token Vault connections and scopes.

```csharp
var grant = new TokenVaultPrivilegedAccessGrant
{
    Connection = "google-oauth2",
    Scopes = new[] { "https://www.googleapis.com/auth/calendar" }
};
```

### Connection Lifecycle Events

The Event Streams surface now includes Connection lifecycle CloudEvents (for example, `EventStreamCloudEventConnectionCreated`), enabling event-driven workflows that react to connection changes. Event stream delivery and redelivery clients were extended accordingly, backed by a new server-sent-events (SSE) reconnect helper for resilient streaming.

### Network ACL `auth0_managed` Matches

`NetworkAclMatch` gains an optional `Auth0Managed` property (`IEnumerable<string>?`, JSON `auth0_managed`), letting you match against Auth0-managed network lists in ACL rules.

```csharp
var match = new NetworkAclMatch
{
    Auth0Managed = new[] { "some-managed-list" }
};
```

### Typed Error Bodies

v9 introduces typed error body records — `NotFoundErrorBody` and `TooManyRequestsErrorBody` (with their nested `*Error` types) — carrying `Message`, `StatusCode`, and a structured `Error`. These complement the enriched exception members above when you need to deserialize an error payload into a strong type.

## Additional Notes

1. **No client initialization changes**: `ManagementClient`, `ManagementClientOptions`, `ITokenProvider`, and the token provider implementations are unchanged from v8.
2. **No pagination changes**: List operations continue to return `Pager<T>` with `IAsyncEnumerable<T>` iteration, `AsPagesAsync()`, and `GetNextPageAsync()`.
3. **`Optional<T>` for PATCH** semantics are unchanged from v8.
4. **Uniform raw-response access**: every operation — including void operations — now supports `.WithRawResponse()` for status code, URL, and header inspection.

## Troubleshooting

### Common Issues

1. **`The type or namespace name 'ConnectionAttributeIdentifier' could not be found`**: Replace with `EmailAttributeIdentifier`, `PhoneAttributeIdentifier`, or `UsernameAttributeIdentifier` matching the attribute.
2. **`Cannot implicitly convert type 'WithRawResponseTask' to 'System.Threading.Tasks.Task'`**: Await the call directly instead of assigning to a `Task` variable, or rely on the implicit conversion. Wrap in a lambda if passing as a `Func<..., Task>` delegate.
3. **Unexpected exception message text**: `ManagementApiException.Message` now surfaces the parsed API error description when available — update log assertions if needed.
4. **`'IUsersClient' does not contain a definition for 'FederatedConnectionsTokensets'`** (or missing `FederatedConnectionTokenSet` / `ConnectionFederatedConnectionsAccessTokens` / `FederatedConnectionsAccessTokens`): the Federated Connections Tokens surface was removed in v9 — delete these usages.
5. **`'ClientSessionTransferDelegationDeviceBindingEnum' does not contain a definition for 'Asn'`**: the `Asn` value was removed — use `Ip`.

### Getting Help

- Check the [API Reference Documentation](https://auth0.github.io/auth0.net/)
- Review the [Examples](Examples.md) in the repository
- [Open an issue on GitHub](https://github.com/auth0/auth0.net/issues) for specific migration problems

---

This migration guide covers the changes needed to upgrade `Auth0.ManagementApi` from v8 to v9. The breaking-change surface is small — most v8 code compiles unchanged — while v9 adds richer exceptions, uniform raw-response access, and new Management API capabilities.
