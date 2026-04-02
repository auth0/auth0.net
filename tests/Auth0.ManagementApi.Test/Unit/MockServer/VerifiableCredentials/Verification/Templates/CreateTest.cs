using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using Auth0.ManagementApi.VerifiableCredentials.Verification;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.VerifiableCredentials.Verification.Templates;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "name": "name",
              "type": "type",
              "dialect": "dialect",
              "presentation": {
                "org.iso.18013.5.1.mDL": {
                  "org.iso.18013.5.1": {}
                }
              },
              "well_known_trusted_issuers": "well_known_trusted_issuers"
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "name": "name",
              "type": "type",
              "dialect": "dialect",
              "presentation": {
                "org.iso.18013.5.1.mDL": {
                  "org.iso.18013.5.1": {}
                }
              },
              "custom_certificate_authority": "custom_certificate_authority",
              "well_known_trusted_issuers": "well_known_trusted_issuers",
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/verifiable-credentials/verification/templates")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.VerifiableCredentials.Verification.Templates.CreateAsync(
            new CreateVerifiableCredentialTemplateRequestContent
            {
                Name = "name",
                Type = "type",
                Dialect = "dialect",
                Presentation = new MdlPresentationRequest
                {
                    OrgIso1801351MDl = new MdlPresentationRequestProperties
                    {
                        OrgIso1801351 = new MdlPresentationProperties(),
                    },
                },
                WellKnownTrustedIssuers = "well_known_trusted_issuers",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
