using Auth0.ManagementApi.Tenants;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Tenants.Settings;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "change_password": {
                "enabled": true,
                "html": "html"
              },
              "guardian_mfa_page": {
                "enabled": true,
                "html": "html"
              },
              "default_audience": "default_audience",
              "default_directory": "default_directory",
              "error_page": {
                "html": "html",
                "show_log_link": true,
                "url": "url"
              },
              "device_flow": {
                "charset": "base20",
                "mask": "mask"
              },
              "default_token_quota": {
                "clients": {
                  "client_credentials": {}
                },
                "organizations": {
                  "client_credentials": {}
                }
              },
              "flags": {
                "change_pwd_flow_v1": true,
                "enable_apis_section": true,
                "disable_impersonation": true,
                "enable_client_connections": true,
                "enable_pipeline2": true,
                "allow_legacy_delegation_grant_types": true,
                "allow_legacy_ro_grant_types": true,
                "allow_legacy_tokeninfo_endpoint": true,
                "enable_legacy_profile": true,
                "enable_idtoken_api2": true,
                "enable_public_signup_user_exists_error": true,
                "enable_sso": true,
                "allow_changing_enable_sso": true,
                "disable_clickjack_protection_headers": true,
                "no_disclose_enterprise_connections": true,
                "enforce_client_authentication_on_passwordless_start": true,
                "enable_adfs_waad_email_verification": true,
                "revoke_refresh_token_grant": true,
                "dashboard_log_streams_next": true,
                "dashboard_insights_view": true,
                "disable_fields_map_fix": true,
                "mfa_show_factor_list_on_enrollment": true,
                "remove_alg_from_jwks": true,
                "improved_signup_bot_detection_in_classic": true,
                "genai_trial": true,
                "enable_dynamic_client_registration": true,
                "disable_management_api_sms_obfuscation": true,
                "trust_azure_adfs_email_verified_connection_property": true,
                "custom_domains_provisioning": true
              },
              "friendly_name": "friendly_name",
              "picture_url": "picture_url",
              "support_email": "support_email",
              "support_url": "support_url",
              "allowed_logout_urls": [
                "allowed_logout_urls"
              ],
              "session_lifetime": 1.1,
              "idle_session_lifetime": 1.1,
              "ephemeral_session_lifetime": 1.1,
              "idle_ephemeral_session_lifetime": 1.1,
              "sandbox_version": "sandbox_version",
              "legacy_sandbox_version": "legacy_sandbox_version",
              "sandbox_versions_available": [
                "sandbox_versions_available"
              ],
              "default_redirection_uri": "default_redirection_uri",
              "enabled_locales": [
                "am"
              ],
              "session_cookie": {
                "mode": "persistent"
              },
              "sessions": {
                "oidc_logout_prompt_enabled": true
              },
              "oidc_logout": {
                "rp_logout_end_session_endpoint_discovery": true
              },
              "allow_organization_name_in_authentication_api": true,
              "customize_mfa_in_postlogin_action": true,
              "acr_values_supported": [
                "acr_values_supported"
              ],
              "mtls": {
                "enable_endpoint_aliases": true
              },
              "pushed_authorization_requests_supported": true,
              "authorization_response_iss_parameter_supported": true,
              "skip_non_verifiable_callback_uri_confirmation_prompt": true,
              "resource_parameter_profile": "audience",
              "phone_consolidated_experience": true,
              "enable_ai_guide": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/tenants/settings")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Tenants.Settings.UpdateAsync(
            new UpdateTenantSettingsRequestContent()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
