# Common Pitfalls

- **Generated vs custom code (biggest one).** `src/Auth0.ManagementApi/` is largely Fern-generated. Editing a generated file "fixes" nothing — the next `fern generate` overwrites it. Before touching a Management file, confirm it's in `.fernignore`; if not, change the API definition or the generator (`CONTRIBUTING.md` → "About Generated Code"), or add the file to `.fernignore` if it's genuinely new custom code.

- **Two independent version sources.** `Auth0.Core` + `Auth0.AuthenticationApi` are versioned by `build/common.props` (`<Version>`) and the root `.version` (currently a 7.x line). `Auth0.ManagementApi` is versioned separately by `src/Auth0.ManagementApi/.version` and `Core/Public/Version.cs` (a 9.x line). Bump the correct pair — don't assume one version applies to all packages.

- **Split JSON stacks.** `Auth0.Core`/`Auth0.AuthenticationApi` use both `Newtonsoft.Json` and `System.Text.Json`; generated `Auth0.ManagementApi` uses `System.Text.Json`. Use the serializer that matches the project you're in; don't add Newtonsoft to Management code.

- **Custom props overrides the csproj's `TargetFrameworks` (biggest TFM gotcha).** `Auth0.ManagementApi.csproj` declares `net462;net8.0;net9.0;netstandard2.0`, but it imports `Auth0.ManagementApi.Custom.props` *last*, and that file unconditionally re-sets `<TargetFrameworks>net462;netstandard2.0</TargetFrameworks>`. Last-wins means the override takes effect: **all three shipped packages build only for `net462` + `netstandard2.0`.** Don't trust the `<TargetFrameworks>` line in the csproj — confirm with `dotnet msbuild <proj> -getProperty:TargetFrameworks`. (net8.0/net9.0/net10.0 only appear in *test* projects.)

- **Multi-target framework conditionals.** Guard newer-runtime APIs with `#if` (e.g. `init` accessors behind `#if NET5_0_OR_GREATER`, `DateTimeOnly` via `Portable.System.DateTimeOnly` on older TFMs). A change that builds on one TFM can still break another. Note: because the shipped packages compile only `net462`/`netstandard2.0`, `#if NET8_0` / `NET5_0_OR_GREATER` branches in the Fern-generated ManagementApi source never make it into the shipped assembly — the `#else`/older-TFM branch is what ships.

- **`WarningsAsErrors=nullable`.** A nullable-reference warning in `Auth0.Core` fails the build, not just the linter (`Nullable` is enabled repo-wide, but only Core promotes those warnings to errors). Annotate nullability correctly rather than suppressing.

- **Mixed test frameworks.** `Auth0.ManagementApi.Test` is **NUnit** (`Assert.That` constraint model); the other test projects are **xUnit** (`Fact`/`Theory` + FluentAssertions). Match the framework of the project you're adding tests to.
