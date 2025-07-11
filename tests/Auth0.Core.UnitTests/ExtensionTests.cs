using System.Collections.Generic;

using FluentAssertions;
using Xunit;

namespace Auth0.Core.UnitTests;

public class ExtensionTests 
{
    [Theory]
    [InlineData("b=per_hour;q=2;r=1;t=3452", "per_hour", 2, 1, 3452)]
    [InlineData("b=per_day;q=100;r=99;t=3524", "per_day", 100, 99, 3524)]
    public async void ParseQuotaLimit_Parses_Successfully_For_Valid_Values(
        string input, string bucket, int q, int r, int t)
    {
        var quotaLimit = Extensions.ParseQuotaLimit(input, out string actualBucket);

        quotaLimit.Should().NotBeNull();
        quotaLimit.Quota.Should().Be(q);
        quotaLimit.Remaining.Should().Be(r);
        quotaLimit.ResetAfter.Should().Be(t);
        actualBucket.Should().Be(bucket);
    }
        
    [Fact]
    public async void ParseQuotaLimit_Should_Return_NULL_For_NULL_Inupt()
    {
        var quotaLimit = Extensions.ParseQuotaLimit(null, out string actualBucket);
        quotaLimit.Should().BeNull();
    }
        
    [Theory]
    [InlineData("b=per_hour;q=2;r=1;t=924", "per_hour", 2, 1, 924)]
    [InlineData("b=per_day;q=2;r=1;t=924", "per_day", 2, 1, 924)]
    public async void ParseClientQuotaLimit_Parses_Successfully_When_Either_Value_Is_Missing(
        string input, string bucket, int q, int r, int t)
    {
        var clientLimit = Extensions.ParseClientLimit(input);

        if (bucket == "per_hour")
        {
            clientLimit.Should().NotBeNull();
            clientLimit.PerHour.Quota.Should().Be(q);
            clientLimit.PerHour.Remaining.Should().Be(r);
            clientLimit.PerHour.ResetAfter.Should().Be(t);

            clientLimit.PerDay.Should().BeNull();    
        }
        else if(bucket == "per_day")
        {
            clientLimit.Should().NotBeNull();
            clientLimit.PerDay.Quota.Should().Be(q);
            clientLimit.PerDay.Remaining.Should().Be(r);
            clientLimit.PerDay.ResetAfter.Should().Be(t);

            clientLimit.PerHour.Should().BeNull();  
        }
    }
        
    [Fact]
    public async void ParseClientQuotaLimit_Parses_Successfully_When_Both_Values_Are_Present_And_Valid()
    {
        var headerValue = "b=per_hour;q=10;r=9;t=924,b=per_day;q=100;r=99;t=924";
        var clientQuota = Extensions.ParseClientLimit(headerValue);

        clientQuota.PerDay.Quota.Should().Be(100);
        clientQuota.PerDay.Remaining.Should().Be(99);
        clientQuota.PerDay.ResetAfter.Should().Be(924);
            
        clientQuota.PerHour.Quota.Should().Be(10);
        clientQuota.PerHour.Remaining.Should().Be(9);
        clientQuota.PerHour.ResetAfter.Should().Be(924);
    }
        
    [Theory]
    [InlineData("b=per_hour;q=2;r=1;t=924", "per_hour", 2, 1, 924)]
    [InlineData("b=per_day;q=2;r=1;t=924", "per_day", 2, 1, 924)]
    public async void ParseOrganisationQuotaLimit_Parses_Successfully_When_Either_Value_Is_Missing(
        string input, string bucket, int q, int r, int t)
    {
        var organizationLimit = Extensions.ParseOrganizationLimit(input);

        if (bucket == "per_hour")
        {
            organizationLimit.Should().NotBeNull();
            organizationLimit.PerHour.Quota.Should().Be(q);
            organizationLimit.PerHour.Remaining.Should().Be(r);
            organizationLimit.PerHour.ResetAfter.Should().Be(t);

            organizationLimit.PerDay.Should().BeNull();    
        }
        else if(bucket == "per_day")
        {
            organizationLimit.Should().NotBeNull();
            organizationLimit.PerDay.Quota.Should().Be(q);
            organizationLimit.PerDay.Remaining.Should().Be(r);
            organizationLimit.PerDay.ResetAfter.Should().Be(t);

            organizationLimit.PerHour.Should().BeNull();  
        }
    }
        
    [Fact]
    public async void ParseOrganisationQuotaLimit_Parses_Successfully_When_Both_Values_Are_Present_And_Valid()
    {
        var headerValue = "b=per_hour;q=10;r=9;t=924,b=per_day;q=100;r=99;t=924";
        var organisationQuota = Extensions.ParseOrganizationLimit(headerValue);

        organisationQuota.PerDay.Quota.Should().Be(100);
        organisationQuota.PerDay.Remaining.Should().Be(99);
        organisationQuota.PerDay.ResetAfter.Should().Be(924);
            
        organisationQuota.PerHour.Quota.Should().Be(10);
        organisationQuota.PerHour.Remaining.Should().Be(9);
        organisationQuota.PerHour.ResetAfter.Should().Be(924);
    }
        
    [Fact]
    public async void ParseOrganisationQuotaLimit_Parses_Successfully_When_Header_Is_NULL()
    {
        var organisationQuota = Extensions.ParseOrganizationLimit(null);
        organisationQuota.Should().BeNull();
    }
        
    [Fact]
    public async void ParseClientQuotaLimit_Parses_Successfully_When_Header_Is_NULL()
    {
        var clientQuota = Extensions.ParseClientLimit(null);
        clientQuota.Should().BeNull();
    }
        
    [Fact]
    public async void GetRawHeaders_Returns_Valid_Headers()
    {
        var headers = new Dictionary<string, IEnumerable<string>>
        {
            { "Content-Type", ["application/json"] },
            { "Authorization", ["Bearer dummy_access_token"] },
            { "X-RateLimit-Limit", ["1000"] },
            { "X-RateLimit-Remaining", ["500"] },
            { "X-RateLimit-Reset", ["1633036800"] },
            { "Auth0-Client-Quota-Limit", ["b=per_hour;q=2;r=1;t=924"] },
            { "Auth0-Organization-Quota-Limit", ["b=per_hour;q=2;r=1;t=924"] }
        };
        var rawHeaders = Extensions.GetRawHeaders(headers, "Auth0-Client-Quota-Limit");
        rawHeaders.Should().Be("b=per_hour;q=2;r=1;t=924");
    }
        
    [Fact]
    public async void GetRawHeaders_Returns_NULL_When_Headers_Is_NULL()
    {
        var rawHeaders = Extensions.GetRawHeaders(null, "Auth0-Client-Quota-Limit");
        rawHeaders.Should().BeNull();
    }
        
    [Fact]
    public async void GetClientQuotaLimit_Returns_Valid_Quota()
    {
        var headers = new Dictionary<string, IEnumerable<string>>
        {
            { "Content-Type", ["application/json"] },
            { "Authorization", ["Bearer dummy_access_token"] },
            { "X-RateLimit-Limit", ["1000"] },
            { "X-RateLimit-Remaining", ["500"] },
            { "X-RateLimit-Reset", ["1633036800"] },
            { "Auth0-Client-Quota-Limit", ["b=per_hour;q=2;r=1;t=924,b=per_day;q=20;r=10;t=924"] },
            { "Auth0-Organization-Quota-Limit", ["b=per_hour;q=2;r=1;t=924,b=per_day;q=20;r=10;t=924"] }
        };
        var clientQuotaLimit = headers.GetClientQuotaLimit();
            
        clientQuotaLimit.Should().NotBeNull();
        clientQuotaLimit.PerDay.Should().NotBeNull();
        clientQuotaLimit.PerHour.Should().NotBeNull();
            
        clientQuotaLimit.PerDay.Quota.Should().Be(20);
        clientQuotaLimit.PerDay.Remaining.Should().Be(10);
        clientQuotaLimit.PerDay.ResetAfter.Should().Be(924);
            
        clientQuotaLimit.PerHour.Quota.Should().Be(2);
        clientQuotaLimit.PerHour.Remaining.Should().Be(1);
        clientQuotaLimit.PerHour.ResetAfter.Should().Be(924);
    }
        
    [Fact]
    public async void GetOrganizationQuotaLimit_Returns_Valid_Quota()
    {
        var headers = new Dictionary<string, IEnumerable<string>>
        {
            { "Content-Type", ["application/json"] },
            { "Authorization", ["Bearer dummy_access_token"] },
            { "X-RateLimit-Limit", ["1000"] },
            { "X-RateLimit-Remaining", ["500"] },
            { "X-RateLimit-Reset", ["1633036800"] },
            { "Auth0-Client-Quota-Limit", ["b=per_hour;q=2;r=1;t=924,b=per_day;q=20;r=10;t=924"] },
            { "Auth0-Organization-Quota-Limit", ["b=per_hour;q=2;r=1;t=924,b=per_day;q=20;r=10;t=924"] }
        };
        var organizationQuotaLimit = headers.GetOrganizationQuotaLimit();
            
        organizationQuotaLimit.Should().NotBeNull();
        organizationQuotaLimit.PerDay.Should().NotBeNull();
        organizationQuotaLimit.PerHour.Should().NotBeNull();
            
        organizationQuotaLimit.PerDay.Quota.Should().Be(20);
        organizationQuotaLimit.PerDay.Remaining.Should().Be(10);
        organizationQuotaLimit.PerDay.ResetAfter.Should().Be(924);
            
        organizationQuotaLimit.PerHour.Quota.Should().Be(2);
        organizationQuotaLimit.PerHour.Remaining.Should().Be(1);
        organizationQuotaLimit.PerHour.ResetAfter.Should().Be(924);
    }
}