using Auth0.ManagementApi.Core;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Core;

[TestFixture]
public class CustomDomainInterceptorTest
{
    [Test]
    [TestCase("/tickets/email-verification")]
    [TestCase("/api/v2/tickets/email-verification")]
    public void IsWhitelisted_EmailVerificationTicket_ReturnsTrue(string path) =>
        Assert.That(CustomDomainInterceptor.IsWhitelisted(path), Is.True);

    [Test]
    [TestCase("/tickets/password-change")]
    [TestCase("/api/v2/tickets/password-change")]
    public void IsWhitelisted_PasswordChangeTicket_ReturnsTrue(string path) =>
        Assert.That(CustomDomainInterceptor.IsWhitelisted(path), Is.True);

    [Test]
    [TestCase("/organizations/org_abc123/invitations")]
    [TestCase("/api/v2/organizations/org_abc123/invitations")]
    [TestCase("/organizations/org_abc123/invitations/inv_xyz789")]
    [TestCase("/api/v2/organizations/org_abc123/invitations/inv_xyz789")]
    public void IsWhitelisted_OrganizationInvitations_ReturnsTrue(string path) =>
        Assert.That(CustomDomainInterceptor.IsWhitelisted(path), Is.True);

    [Test]
    [TestCase("/guardian/enrollments/ticket")]
    [TestCase("/api/v2/guardian/enrollments/ticket")]
    public void IsWhitelisted_GuardianEnrollmentTicket_ReturnsTrue(string path) =>
        Assert.That(CustomDomainInterceptor.IsWhitelisted(path), Is.True);

    [Test]
    [TestCase("/jobs/verification-email")]
    [TestCase("/api/v2/jobs/verification-email")]
    public void IsWhitelisted_VerificationEmailJob_ReturnsTrue(string path) =>
        Assert.That(CustomDomainInterceptor.IsWhitelisted(path), Is.True);

    [Test]
    [TestCase("/jobs/users-imports")]
    [TestCase("/api/v2/jobs/users-imports")]
    public void IsWhitelisted_UsersImportsJob_ReturnsTrue(string path) =>
        Assert.That(CustomDomainInterceptor.IsWhitelisted(path), Is.True);

    [Test]
    [TestCase("/users")]
    [TestCase("/api/v2/users")]
    [TestCase("/users/auth0|abc123")]
    [TestCase("/api/v2/users/auth0|abc123")]
    public void IsWhitelisted_Users_ReturnsTrue(string path) =>
        Assert.That(CustomDomainInterceptor.IsWhitelisted(path), Is.True);

    [Test]
    [TestCase("/self-service-profiles/ssp_1/sso-ticket")]
    [TestCase("/api/v2/self-service-profiles/ssp_1/sso-ticket")]
    [TestCase("/self-service-profiles/ssp_1/sso-ticket/t_1/revoke")]
    [TestCase("/api/v2/self-service-profiles/ssp_1/sso-ticket/t_1/revoke")]
    public void IsWhitelisted_SelfServiceProfileSsoTicket_ReturnsTrue(string path) =>
        Assert.That(CustomDomainInterceptor.IsWhitelisted(path), Is.True);

    [Test]
    [TestCase("/clients")]
    [TestCase("/api/v2/clients")]
    [TestCase("/clients/client_123")]
    [TestCase("/connections")]
    [TestCase("/api/v2/connections/conn_abc/status")]
    [TestCase("/roles")]
    [TestCase("/logs")]
    [TestCase("/stats/active-users")]
    [TestCase("/api/v2/organizations/org_abc123/members")]
    [TestCase("/api/v2/organizations/org_abc123/connections")]
    [TestCase("/jobs/users-exports")]
    [TestCase("/api/v2/jobs/abc123")]
    [TestCase("/guardian/enrollments")]
    [TestCase("/api/v2/guardian/factors")]
    [TestCase("/api/v2/users/auth0|abc123/roles")]
    [TestCase("/api/v2/users/auth0|abc123/permissions")]
    [TestCase("/users-by-email")]
    [TestCase("/api/v2/users-by-email")]
    public void IsWhitelisted_NonWhitelistedPath_ReturnsFalse(string path) =>
        Assert.That(CustomDomainInterceptor.IsWhitelisted(path), Is.False);

    [Test]
    public void IsWhitelisted_NullPath_ReturnsFalse() =>
        Assert.That(CustomDomainInterceptor.IsWhitelisted(null), Is.False);

    [Test]
    public void IsWhitelisted_EmptyPath_ReturnsFalse() =>
        Assert.That(CustomDomainInterceptor.IsWhitelisted(string.Empty), Is.False);

    [Test]
    public async Task SendAsync_NonWhitelistedPath_StripsHeader()
    {
        var testHandler = new TestHandler();
        var interceptor = new CustomDomainInterceptor(testHandler);
        var httpClient = new HttpClient(interceptor);

        var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/clients");
        request.Headers.Add(CustomDomainInterceptor.HeaderName, "login.mycompany.com");

        await httpClient.SendAsync(request);

        Assert.That(testHandler.LastRequest!.Headers.Contains(CustomDomainInterceptor.HeaderName), Is.False);
    }

    [Test]
    public async Task SendAsync_WhitelistedPath_PreservesHeader()
    {
        var testHandler = new TestHandler();
        var interceptor = new CustomDomainInterceptor(testHandler);
        var httpClient = new HttpClient(interceptor);

        var request = new HttpRequestMessage(HttpMethod.Post,
            "http://localhost/tickets/email-verification");
        request.Headers.Add(CustomDomainInterceptor.HeaderName, "login.mycompany.com");

        await httpClient.SendAsync(request);

        Assert.That(testHandler.LastRequest!.Headers.Contains(CustomDomainInterceptor.HeaderName), Is.True);
        Assert.That(
            testHandler.LastRequest.Headers.GetValues(CustomDomainInterceptor.HeaderName).First(),
            Is.EqualTo("login.mycompany.com"));
    }

    [Test]
    public async Task SendAsync_NoHeader_DoesNotAddHeader()
    {
        var testHandler = new TestHandler();
        var interceptor = new CustomDomainInterceptor(testHandler);
        var httpClient = new HttpClient(interceptor);

        var request = new HttpRequestMessage(HttpMethod.Post,
            "http://localhost/tickets/email-verification");

        await httpClient.SendAsync(request);

        Assert.That(testHandler.LastRequest!.Headers.Contains(CustomDomainInterceptor.HeaderName), Is.False);
    }

    [Test]
    public async Task SendAsync_NonWhitelistedPath_OnlyStripsCustomDomainHeader_LeavesOtherHeadersIntact()
    {
        // Verifies the interceptor is surgical: it removes only Auth0-Custom-Domain and does
        // not disturb any other headers present on the same request.
        var testHandler = new TestHandler();
        var interceptor = new CustomDomainInterceptor(testHandler);
        var httpClient = new HttpClient(interceptor);

        var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/clients");
        request.Headers.Add(CustomDomainInterceptor.HeaderName, "login.mycompany.com");
        request.Headers.Add("X-Correlation-Id", "abc-123");
        request.Headers.Add("X-Custom-Header", "custom-value");

        await httpClient.SendAsync(request);

        Assert.That(testHandler.LastRequest!.Headers.Contains(CustomDomainInterceptor.HeaderName),
            Is.False, "Auth0-Custom-Domain should be stripped");
        Assert.That(testHandler.LastRequest.Headers.Contains("X-Correlation-Id"),
            Is.True, "X-Correlation-Id should be preserved");
        Assert.That(testHandler.LastRequest.Headers.GetValues("X-Correlation-Id").First(),
            Is.EqualTo("abc-123"));
        Assert.That(testHandler.LastRequest.Headers.Contains("X-Custom-Header"),
            Is.True, "X-Custom-Header should be preserved");
        Assert.That(testHandler.LastRequest.Headers.GetValues("X-Custom-Header").First(),
            Is.EqualTo("custom-value"));
    }

    /// <summary>
    /// Helper handler to capture the outgoing request after passing through the interceptor for assertion.
    /// </summary>
    private sealed class TestHandler : HttpMessageHandler
    {
        public HttpRequestMessage? LastRequest { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            LastRequest = request;
            return Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK));
        }
    }
}
