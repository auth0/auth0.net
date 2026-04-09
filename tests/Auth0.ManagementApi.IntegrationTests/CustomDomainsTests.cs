using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Auth0.Core.Exceptions;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.Clients;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using System.Net.Http;

using FluentAssertions;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

public class CustomDomainsTestsFixture : TestBaseFixture
{
    public override async Task DisposeAsync()
    {
        foreach (KeyValuePair<CleanUpType, IList<string>> entry in identifiers)
        {
            await ManagementTestBaseUtils.CleanupAsync(ApiClient, entry.Key, entry.Value);
        }

        ApiClient.Dispose();
    }
}

public class CustomDomainsTests : IClassFixture<CustomDomainsTestsFixture>
{
    private readonly Mock<IManagementConnection> _mockConnection;
    private readonly CustomDomainsClient _client;
    private readonly CustomDomainsTestsFixture fixture;

    public CustomDomainsTests(CustomDomainsTestsFixture fixture)
    {
        this.fixture = fixture;
        _mockConnection = new Mock<IManagementConnection>();
        _client = new CustomDomainsClient(
            _mockConnection.Object,
            new Uri("https://test.auth0.com/api/v2/"),
            new Dictionary<string, string>());
    }
    [Fact]
    public async Task Test_custom_domains()
    {
        // Test getting all custom domains
        var domains = await fixture.ApiClient.CustomDomains.GetAllAsync();
        domains.Should().HaveCountGreaterThan(0); 
        
        var customDomain = await fixture.ApiClient.CustomDomains.CreateAsync(
            new CustomDomainCreateRequest
            {
                Domain = "test.dx-sdks.club", 
                Type = CustomDomainCertificateProvisioning.Auth0ManagedCertificate,
                VerificationMethod = "txt"
            });
        
        var id = customDomain.CustomDomainId;
        fixture.TrackIdentifier(CleanUpType.CustomDomains, id);
        
        // Test getting a single custom domain
        var domain = await fixture.ApiClient.CustomDomains.GetAsync(id);
        domain.Should().NotBeNull();
        domain.CustomDomainId.Should().Be(id);
        
        // Test updating a custom domain
        var updateRequest = new CustomDomainUpdateRequest()
        {
            TlsPolicy = "recommended",
            CustomClientIpHeader = null
        };

        var updatedCustomDomain = await fixture.ApiClient.CustomDomains.UpdateAsync(id, updateRequest);
        updatedCustomDomain.Should().NotBeNull();
        updatedCustomDomain.CustomClientIpHeader.Should().Be(updateRequest.CustomClientIpHeader);
        updatedCustomDomain.TlsPolicy.Should().Be(updateRequest.TlsPolicy);
        
        var nonExistentId = "cd_XXw4P8C04x1Aa9e5";
        await fixture.ApiClient.CustomDomains.DeleteAsync(nonExistentId);

        // Test verifying a non-existing id. This will give 404
        var verifyFunc = async () => await fixture.ApiClient.CustomDomains.VerifyAsync(nonExistentId);
        
        verifyFunc.Should().Throw<ApiException>()
            .WithMessage($"The custom domain {nonExistentId} does not exist");

        await fixture.ApiClient.CustomDomains.DeleteAsync(id);
        
        var afterRunCustomDomains =
            await fixture.ApiClient.CustomDomains.GetAllAsync(
                new CustomDomainsGetAllRequest()
                {
                    Sort = "domain:1"
                }, new CheckpointPaginationInfo());
        
        afterRunCustomDomains.Should().NotContain(x => x.CustomDomainId == id);
        fixture.UnTrackIdentifier(CleanUpType.CustomDomains, id);
    }
    
    /// <summary>
    /// Sets up the mock to capture the URI passed to GetAsync. Returns a holder
    /// whose <c>Value</c> is populated after the call under test completes.
    /// </summary>
    private (Func<Uri> GetUri, Func<JsonConverter[]> GetConverters) SetupCapture(
        ICheckpointPagedList<CustomDomain> response = null)
    {
        Uri capturedUri = null;
        JsonConverter[] capturedConverters = null;

        _mockConnection
            .Setup(c => c.GetAsync<ICheckpointPagedList<CustomDomain>>(
                It.IsAny<Uri>(),
                It.IsAny<IDictionary<string, string>>(),
                It.IsAny<JsonConverter[]>(),
                It.IsAny<CancellationToken>()))
            .Callback<Uri, IDictionary<string, string>, JsonConverter[], CancellationToken>(
                (uri, _, converters, _) =>
                {
                    capturedUri = uri;
                    capturedConverters = converters;
                })
            .ReturnsAsync(response ?? new CheckpointPagedList<CustomDomain>());

        return (() => capturedUri, () => capturedConverters);
    }

    [Fact]
    public async Task GetAllAsync_Throws_When_Request_Is_Null()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() =>
            _client.GetAllAsync(null!, null));
    }

    [Fact]
    public async Task GetAllAsync_Returns_Result_From_Connection()
    {
        var expected = new CheckpointPagedList<CustomDomain>
        {
            new CustomDomain { IsDefault = true },
            new CustomDomain { IsDefault = false }
        };
        SetupCapture(expected);

        var result = await _client.GetAllAsync(new CustomDomainsGetAllRequest(), null);

        result.Should().HaveCount(2);
    }

    [Fact]
    public async Task GetAllAsync_Calls_Correct_Endpoint()
    {
        var (getUri, _) = SetupCapture();

        await _client.GetAllAsync(new CustomDomainsGetAllRequest(), null);

        getUri().AbsolutePath.Should().EndWith("custom-domains");
    }

    [Fact]
    public async Task GetAllAsync_Includes_Query_In_QueryString_When_Provided()
    {
        var (getUri, _) = SetupCapture();

        await _client.GetAllAsync(new CustomDomainsGetAllRequest { Query = "domain:example.com" }, null);

        getUri().Query.Should().Contain("q=domain%3Aexample.com");
    }

    [Fact]
    public async Task GetAllAsync_Includes_Fields_In_QueryString_When_Provided()
    {
        var (getUri, _) = SetupCapture();

        await _client.GetAllAsync(new CustomDomainsGetAllRequest { Fields = "domain,status" }, null);

        getUri().Query.Should().Contain("fields=domain%2Cstatus");
    }

    [Theory]
    [InlineData(true, "include_fields=true")]
    [InlineData(false, "include_fields=false")]
    public async Task GetAllAsync_Includes_IncludeFields_In_QueryString_When_Provided(bool includeFields, string expectedParam)
    {
        var (getUri, _) = SetupCapture();

        await _client.GetAllAsync(new CustomDomainsGetAllRequest { IncludeFields = includeFields }, null);

        getUri().Query.Should().Contain(expectedParam);
    }

    [Fact]
    public async Task GetAllAsync_Includes_Sort_In_QueryString_When_Provided()
    {
        var (getUri, _) = SetupCapture();

        await _client.GetAllAsync(new CustomDomainsGetAllRequest { Sort = "domain:1" }, null);

        getUri().Query.Should().Contain("sort=domain%3A1");
    }

    [Fact]
    public async Task GetAllAsync_Includes_Take_And_From_When_CheckpointPaginationInfo_Provided()
    {
        var (getUri, _) = SetupCapture();

        await _client.GetAllAsync(
            new CustomDomainsGetAllRequest(),
            new CheckpointPaginationInfo(take: 25, from: "cd_abc123"));

        getUri().Query.Should().Contain("take=25");
        getUri().Query.Should().Contain("from=cd_abc123");
    }

    [Fact]
    public async Task GetAllAsync_Omits_From_Param_When_CheckpointPaginationInfo_From_Is_Null()
    {
        var (getUri, _) = SetupCapture();

        await _client.GetAllAsync(
            new CustomDomainsGetAllRequest(),
            new CheckpointPaginationInfo(take: 50));

        getUri().Query.Should().Contain("take=50");
        getUri().Query.Should().NotContain("from=");
    }

    [Fact]
    public async Task GetAllAsync_Passes_CheckpointConverters_To_Connection()
    {
        var (_, getConverters) = SetupCapture();

        await _client.GetAllAsync(new CustomDomainsGetAllRequest(), null);

        getConverters().Should().NotBeNull();
        getConverters().Should().HaveCount(1);
        getConverters()[0].Should().BeAssignableTo<JsonConverter>();
        getConverters()[0].CanConvert(typeof(ICheckpointPagedList<CustomDomain>)).Should().BeTrue();
    }

    /// <summary>
    /// Sets up the mock to capture the HTTP method, URI, and body passed to SendAsync.
    /// Returns holders whose values are populated after the call under test completes.
    /// </summary>
    private (Func<Uri> GetUri, Func<HttpMethod> GetMethod, Func<object> GetBody) SetupSendCapture(
        CustomDomain response = null)
    {
        Uri capturedUri = null;
        HttpMethod capturedMethod = null;
        object capturedBody = null;

        _mockConnection
            .Setup(c => c.SendAsync<CustomDomain>(
                It.IsAny<HttpMethod>(),
                It.IsAny<Uri>(),
                It.IsAny<object>(),
                It.IsAny<IDictionary<string, string>>(),
                It.IsAny<IList<FileUploadParameter>>(),
                It.IsAny<JsonConverter[]>(),
                It.IsAny<CancellationToken>()))
            .Callback<HttpMethod, Uri, object, IDictionary<string, string>, IList<FileUploadParameter>, JsonConverter[], CancellationToken>(
                (method, uri, body, _, _, _, _) =>
                {
                    capturedMethod = method;
                    capturedUri = uri;
                    capturedBody = body;
                })
            .ReturnsAsync(response ?? new CustomDomain());

        return (() => capturedUri, () => capturedMethod, () => capturedBody);
    }

    [Fact]
    public async Task GetDefaultAsync_Calls_Correct_Endpoint()
    {
        Uri capturedUri = null;
        _mockConnection
            .Setup(c => c.GetAsync<CustomDomain>(
                It.IsAny<Uri>(),
                It.IsAny<IDictionary<string, string>>(),
                It.IsAny<JsonConverter[]>(),
                It.IsAny<CancellationToken>()))
            .Callback<Uri, IDictionary<string, string>, JsonConverter[], CancellationToken>(
                (uri, _, _, _) => capturedUri = uri)
            .ReturnsAsync(new CustomDomain());

        await _client.GetDefaultAsync();

        capturedUri.AbsolutePath.Should().EndWith("custom-domains/default");
    }

    [Fact]
    public async Task SetDefaultAsync_Calls_Correct_Endpoint_With_PATCH()
    {
        var (getUri, getMethod, _) = SetupSendCapture();

        await _client.SetDefaultAsync(new CustomDomainSetDefaultRequest { Domain = "login.example.com" });

        getUri().AbsolutePath.Should().EndWith("custom-domains/default");
        getMethod().Method.Should().Be("PATCH");
    }

    [Fact]
    public async Task SetDefaultAsync_Sends_Domain_In_Body()
    {
        var (_, _, getBody) = SetupSendCapture();

        await _client.SetDefaultAsync(new CustomDomainSetDefaultRequest { Domain = "login.example.com" });

        var body = getBody().Should().BeOfType<CustomDomainSetDefaultRequest>().Subject;
        body.Domain.Should().Be("login.example.com");
    }


}