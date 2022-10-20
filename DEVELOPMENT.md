# Auth0.NET Development

## Building

This project can be built on Windows, Linux or macOS. Ensure you have the [.NET Core SDK](https://www.microsoft.com/net/download) installed. You can also use the code editor of your choice or a full-blown IDE such as Visual Studio or Jetbrains Rider.

The full set of libraries can be built by running `dotnet restore` followed by `dotnet build`. You can run the unit tests individually by using the `dotnet test` command ([see docs](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test)).

### Building for Release

Since this library also targets the full .NET Framework, you can currently only do a build for release on Windows.

1. Run `npm run release [version]` (e.g. `npm run release 7.3.0`)
1. Push these changes to a prepare-x.y.z branch for approval then merge
1. Wait for CI to complete, download and extract the `Auth0.Net.Packages.zip`
1. Upload the NuGet packages to NuGet using the `nuget push` command.

## Testing

This project features extensive integration tests which unfortunately require specific server-side configuration and paid plan features in order to test the full functionality. As the management API side of things specifically provides functionality that could break the configuration we do not provide keys or testing against our integration tenants.

When reviewing external pull requests we manually run the integration tests against your PR to ensure they pass and the CI server will run them once merged.
