# Testing

Test framework varies by project — check the project before writing tests.

| Project | Framework | Needs creds? | What it covers |
|---------|-----------|--------------|----------------|
| `tests/Auth0.Core.UnitTests` | xUnit 2.4 + FluentAssertions + Moq | No | Core HTTP, exceptions, JSON extensions, rate-limit parsing |
| `tests/Auth0.ManagementApi.Test` | NUnit 4 + WireMock.Net | No | ManagementApi unit + mock-server behavior (headers, interceptors, converters) |
| `tests/Auth0.AuthenticationApi.IntegrationTests` | xUnit + FluentAssertions + Moq | **Yes — live tenant** | Authentication API against a real Auth0 tenant |
| `tests/Auth0.ManagementApi.IntegrationTests` | xUnit + FluentAssertions + Moq | **Yes — live tenant** | Management API against a real Auth0 tenant |
| `tests/Auth0.IntegrationTests.Shared` | — | — | Shared fixtures + resource cleanup for integration tiers |

## Safe (no-credentials) commands

```bash
dotnet test tests/Auth0.Core.UnitTests/Auth0.Core.UnitTests.csproj
dotnet test tests/Auth0.ManagementApi.Test/Auth0.ManagementApi.Test.csproj
```

The two projects above are the default unit tier — no credentials required.

## Integration / Acceptance Tests

> ⚠️ These hit a **live Auth0 tenant**, are slow, and can mutate real resources (they create/delete users, connections, etc. and rely on cleanup fixtures). **Ask before running them** (see Boundaries in `CLAUDE.md`). Auth0 does not publish keys for its integration tenants; maintainers run these manually for external PRs.

```bash
dotnet test tests/Auth0.AuthenticationApi.IntegrationTests/Auth0.AuthenticationApi.IntegrationTests.csproj
dotnet test tests/Auth0.ManagementApi.IntegrationTests/Auth0.ManagementApi.IntegrationTests.csproj
```

Requires environment variables for a real tenant, e.g. `AUTH0_MANAGEMENT_API_URL`, `AUTH0_MANAGEMENT_API_CLIENT_ID`, `AUTH0_MANAGEMENT_API_CLIENT_SECRET`, `AUTH0_CLIENT_ID`, `AUTH0_CLIENT_SECRET`, plus HS256/passwordless/Brucke variants — see the `env:` block in `.github/workflows/build.yml`.

## Run a single test

```bash
# xUnit / NUnit both support the VSTest filter
dotnet test tests/Auth0.ManagementApi.Test/Auth0.ManagementApi.Test.csproj \
  --filter "FullyQualifiedName~Auth0ClientHeaderTests"
```

## Conventions

- **NUnit (`Auth0.ManagementApi.Test`):** `[TestFixture]`, `[Test]`, `Assert.That(actual, Is.EqualTo(...))` constraint model; `[Parallelizable(ParallelScope.All)]` on mock-server fixtures. WireMock.Net spins up an in-process HTTP server (`WireMockServer.Start`) to assert on outgoing requests (e.g. header presence).
- **xUnit (`Auth0.Core.UnitTests`, integration tiers):** `[Fact]`/`[Theory]`, `FluentAssertions` (`result.Should().Be(...)`), `Moq` for mocking interfaces (`Mock<IUsersClient>`).
- Prefer the sub-client interfaces (`IUsersClient`, `IConnectionsClient`, `IManagementApiClient`) for mocking rather than concrete clients.
