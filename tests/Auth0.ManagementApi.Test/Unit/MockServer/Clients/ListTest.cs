using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Clients;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "start": 1.1,
              "limit": 1.1,
              "total": 1.1,
              "clients": [
                {
                  "client_id": "client_id",
                  "tenant": "tenant",
                  "name": "name",
                  "description": "description",
                  "global": true,
                  "client_secret": "client_secret",
                  "app_type": "native",
                  "logo_uri": "logo_uri",
                  "is_first_party": true,
                  "oidc_conformant": true,
                  "callbacks": [
                    "callbacks"
                  ],
                  "allowed_origins": [
                    "allowed_origins"
                  ],
                  "web_origins": [
                    "web_origins"
                  ],
                  "client_aliases": [
                    "client_aliases"
                  ],
                  "allowed_clients": [
                    "allowed_clients"
                  ],
                  "allowed_logout_urls": [
                    "allowed_logout_urls"
                  ],
                  "grant_types": [
                    "grant_types"
                  ],
                  "signing_keys": [
                    {}
                  ],
                  "sso": true,
                  "sso_disabled": true,
                  "cross_origin_authentication": true,
                  "cross_origin_loc": "cross_origin_loc",
                  "custom_login_page_on": true,
                  "custom_login_page": "custom_login_page",
                  "custom_login_page_preview": "custom_login_page_preview",
                  "form_template": "form_template",
                  "token_endpoint_auth_method": "none",
                  "is_token_endpoint_ip_header_trusted": true,
                  "client_metadata": {
                    "key": "value"
                  },
                  "initiate_login_uri": "initiate_login_uri",
                  "refresh_token": {
                    "rotation_type": "rotating",
                    "expiration_type": "expiring"
                  },
                  "default_organization": {
                    "organization_id": "organization_id",
                    "flows": [
                      "client_credentials"
                    ]
                  },
                  "organization_usage": "deny",
                  "organization_require_behavior": "no_prompt",
                  "organization_discovery_methods": [
                    "email"
                  ],
                  "require_pushed_authorization_requests": true,
                  "require_proof_of_possession": true,
                  "compliance_level": "none",
                  "skip_non_verifiable_callback_uri_confirmation_prompt": true,
                  "par_request_expiry": 1,
                  "token_quota": {
                    "client_credentials": {}
                  },
                  "express_configuration": {
                    "initiate_login_uri_template": "initiate_login_uri_template",
                    "user_attribute_profile_id": "user_attribute_profile_id",
                    "connection_profile_id": "connection_profile_id",
                    "enable_client": true,
                    "enable_organization": true,
                    "okta_oin_client_id": "okta_oin_client_id",
                    "admin_login_domain": "admin_login_domain"
                  },
                  "my_organization_configuration": {
                    "allowed_strategies": [
                      "pingfederate"
                    ],
                    "connection_deletion_behavior": "allow"
                  },
                  "third_party_security_mode": "strict",
                  "redirection_policy": "allow_always",
                  "resource_server_identifier": "resource_server_identifier",
                  "async_approval_notification_channels": [
                    "guardian-push"
                  ],
                  "external_metadata_type": "cimd",
                  "external_metadata_created_by": "admin",
                  "external_client_id": "external_client_id",
                  "jwks_uri": "jwks_uri"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/clients")
                    .WithParam("fields", "fields")
                    .WithParam("page", "1")
                    .WithParam("per_page", "1")
                    .WithParam("app_type", "app_type")
                    .WithParam("external_client_id", "external_client_id")
                    .WithParam("q", "q")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Clients.ListAsync(
            new ListClientsRequestParameters
            {
                Fields = "fields",
                IncludeFields = true,
                Page = 1,
                PerPage = 1,
                IncludeTotals = true,
                IsGlobal = true,
                IsFirstParty = true,
                AppType = "app_type",
                ExternalClientId = "external_client_id",
                Q = "q",
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
