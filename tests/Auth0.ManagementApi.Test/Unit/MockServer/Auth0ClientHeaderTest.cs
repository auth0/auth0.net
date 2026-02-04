using System.Text;
using System.Text.Json;
using NUnit.Framework;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Auth0.ManagementApi.Test.Unit.MockServer;

[TestFixture]
public class Auth0ClientHeaderTest : BaseMockServerTest
{
    [Test]
    public async Task Request_IncludesAuth0ClientHeader()
    {
        // Setup mock to capture requests
        Server
            .Given(
                Request.Create()
                    .WithPath("/connections/test-id/status")
                    .UsingGet()
            )
            .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
            );

        // Make a request
        await Client.Connections.CheckStatusAsync("test-id");

        // Verify Auth0-Client header was sent
        var logEntries = Server.LogEntries;
        Assert.That(logEntries, Has.Count.GreaterThan(0));

        var request = logEntries[0].RequestMessage;
        Assert.That(request.Headers, Does.ContainKey("Auth0-Client"));

        // Decode and verify header structure
        var auth0ClientHeader = request.Headers["Auth0-Client"].First();
        var decodedJson = Base64UrlDecode(auth0ClientHeader);
        var headerData = JsonSerializer.Deserialize<Auth0ClientHeaderData>(decodedJson);

        Assert.That(headerData, Is.Not.Null);
        Assert.That(headerData!.Name, Is.EqualTo("Auth0.Net"));
        Assert.That(headerData.Version, Is.Not.Null.And.Not.Empty);
        Assert.That(headerData.Env, Is.Not.Null);
        Assert.That(headerData.Env!.Target, Is.Not.Null.And.Not.Empty);
    }

    private static string Base64UrlDecode(string input)
    {
        var output = input;
        output = output.Replace('-', '+');
        output = output.Replace('_', '/');
        switch (output.Length % 4)
        {
            case 2: output += "=="; break;
            case 3: output += "="; break;
        }
        return Encoding.UTF8.GetString(Convert.FromBase64String(output));
    }

    private record Auth0ClientHeaderData(
        [property: System.Text.Json.Serialization.JsonPropertyName("name")] string? Name,
        [property: System.Text.Json.Serialization.JsonPropertyName("version")] string? Version,
        [property: System.Text.Json.Serialization.JsonPropertyName("env")] Auth0ClientEnv? Env
    );

    private record Auth0ClientEnv(
        [property: System.Text.Json.Serialization.JsonPropertyName("target")] string? Target
    );
}
