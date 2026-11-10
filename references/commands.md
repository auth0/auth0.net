# Commands

Exact commands from CI (`.github/workflows/build.yml`) and `CONTRIBUTING.md`. CI runs on .NET SDK `8.0.x`, Ubuntu.

```bash
# Restore dependencies
dotnet restore

# Build (CI builds without re-restoring)
dotnet build --no-restore

# Format check (fails if code is not formatted)
dotnet format --verify-no-changes

# Format / auto-fix
dotnet format
```

## Tests

The CI splits tests by project. Unit tiers need no credentials; integration tiers need a live tenant (see [testing.md](testing.md)).

```bash
# Core unit tests (xUnit) — no credentials
dotnet test tests/Auth0.Core.UnitTests/Auth0.Core.UnitTests.csproj

# ManagementApi unit/mock tests (NUnit + WireMock.Net) — no credentials
dotnet test tests/Auth0.ManagementApi.Test/Auth0.ManagementApi.Test.csproj

# Run everything (will attempt the live integration tiers too — see Ask First)
dotnet test
```

### With coverage (as CI runs it)

```bash
dotnet test tests/Auth0.Core.UnitTests/Auth0.Core.UnitTests.csproj \
  --collect:"XPlat Code coverage" --results-directory ./TestResults/ \
  /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura
```

Coverage is collected via Coverlet (`XPlat Code Coverage`, cobertura) and uploaded to Codecov. There is no enforced threshold gate in CI (`fail_ci_if_error: false`).

## Release (reference only — do not run as an agent)

Releases are cut by maintainers via the `release.yml` / `nuget-release.yml` workflows. Do not perform releases; only keep the version source files in sync (see Boundaries in `CLAUDE.md`).
