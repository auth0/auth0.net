# Code Style

Enforced by `dotnet format` + `.editorconfig` (mostly ReSharper `hint`/`suggestion` severities; `dotnet_diagnostic.CS1591` is a suggestion). `Nullable` is enabled repo-wide, and `Auth0.Core` sets `WarningsAsErrors=nullable` — a nullability warning fails its build.

## Naming

- **PascalCase** — public types, methods, properties.
- **`_camelCase`** — private instance fields.
- **`camelCase`** — locals and parameters.
- One API resource per directory under `src/Auth0.ManagementApi/` (`Users/`, `Connections/`, …); custom public types live under `Core/Public/`.

## Optional<T> (ManagementApi PATCH semantics)

Generated request models use `Optional<T>` to distinguish "not set" from "explicitly null":

**✅ Good — only send what you mean:**

```csharp
var request = new UpdateUserRequestContent
{
    Name = "John Doe"                     // sent
    // Email left as Optional<string?>.Undefined — not sent
};
var clear = new UpdateUserRequestContent
{
    Nickname = Optional<string?>.Of(null) // sent as null → clears the field
};
```

**❌ Bad — defeats the tri-state and clobbers server data:**

```csharp
var request = new UpdateUserRequestContent
{
    Name = "John Doe",
    Email = null,      // ambiguous intent; don't assign raw null to an Optional<T> field
    Nickname = ""       // empty string is not "clear"
};
```

## Custom vs generated code

- Custom code that must survive Fern regeneration lives in files listed in `.fernignore` and typically uses the `.Custom.cs` suffix (e.g. `ClientOptions.Custom.cs`) or a partial class extending a generated type.
- Multi-target conditionals use `#if NET462 / NETSTANDARD2_0 / NET8_0 …` (see `ClientOptions.Custom.cs`), and `init` vs `set` accessors are guarded by `#if NET5_0_OR_GREATER`. Note the shipped packages compile only `net462`/`netstandard2.0` (see [pitfalls.md](pitfalls.md)), so the newer-TFM branches (`NET8_0`, `NET5_0_OR_GREATER`) don't reach the shipped assembly — the `net462`/`netstandard2.0` branch is what ships.

## Patterns

- **Builder** — Authentication API URL builders (`AuthorizationUrlBuilder`, `LogoutUrlBuilder`, fluent `WithState(...)`).
- **Provider/Strategy** — `ITokenProvider` with `ClientCredentialsTokenProvider` / `DelegateTokenProvider` implementations behind `ManagementClient`.
- **Interface-per-client** — every client and sub-client has an interface for DI and mocking.
- **Typed exceptions** — `ApiException` base with `ErrorApiException`/`RateLimitApiException` (Core) and per-status errors (ManagementApi).
