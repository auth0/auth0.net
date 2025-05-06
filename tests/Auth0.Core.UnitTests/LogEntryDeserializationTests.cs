using Auth0.ManagementApi.Models;
using Newtonsoft.Json;
using Xunit;

namespace Auth0.Core.UnitTests;

public class LogEntryDeserializationTests
{
    [Fact]
    public void Should_deserialize_scopes_as_array()
    {
        var content = @"{
                      ""date"": ""2025-04-18T21:33:54.447Z"",
                      ""type"": ""f"",
                      ""user_agent"": ""Edge 135.0.0 / Windows 10.0.0"",
                      ""scope"": [
                        ""openid"",
                        ""profile"",
                        ""offline_access"",
                      ],
                    }";

        var parsed = JsonConvert.DeserializeObject<LogEntry>(content);

        Assert.Equal(new[] { "openid", "profile", "offline_access" }, parsed.Scope);

    }

    [Fact]
    public void Should_deserialize_scopes_as_null_when_null()
    {
        var content = @"{
                      ""date"": ""2025-04-18T21:33:54.447Z"",
                      ""type"": ""f"",
                      ""user_agent"": ""Edge 135.0.0 / Windows 10.0.0"",
                      ""scope"": null,
                    }";

        var parsed = JsonConvert.DeserializeObject<LogEntry>(content);

        Assert.Null(parsed.Scope);

    }


}