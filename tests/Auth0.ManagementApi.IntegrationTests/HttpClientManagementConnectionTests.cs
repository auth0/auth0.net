using Auth0.Tests.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

public class HttpClientManagementConnectionTests : TestBase
{
    [Fact(Skip = "HttpClientManagementConnection no longer exists in new Fern-generated API")]
    public async Task Disposes_HttpClient_it_creates_on_dispose()
    {
        // HttpClientManagementConnection no longer exists in new API
        // The new ManagementClient handles HTTP client lifecycle internally
    }

    [Fact(Skip = "HttpClientManagementConnection no longer exists in new Fern-generated API")]
    public async Task Does_not_dispose_HttpClient_it_was_given_on_dispose()
    {
        // HttpClientManagementConnection no longer exists in new API
        // The new ManagementClient handles HTTP client lifecycle internally
    }
}
