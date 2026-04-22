using Auth0.ManagementApi;
using Auth0.ManagementApi.Test.Unit.MockServer;
using Auth0.ManagementApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.ManagementApi.Test.Unit.MockServer.Clients;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "name": "name"
            }
            """;

        const string mockResponse = """
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
              "session_transfer": {
                "can_create_session_transfer_token": true,
                "enforce_cascade_revocation": true,
                "allowed_authentication_methods": [
                  "cookie"
                ],
                "enforce_device_binding": "ip",
                "allow_refresh_token": true,
                "enforce_online_refresh_tokens": true,
                "delegation": {
                  "allow_delegated_access": true,
                  "enforce_device_binding": "ip"
                }
              },
              "oidc_logout": {
                "backchannel_logout_urls": [
                  "backchannel_logout_urls"
                ],
                "backchannel_logout_initiators": {
                  "mode": "custom",
                  "selected_initiators": [
                    "rp-logout"
                  ]
                },
                "backchannel_logout_session_metadata": {
                  "include": true
                }
              },
              "grant_types": [
                "grant_types"
              ],
              "jwt_configuration": {
                "lifetime_in_seconds": 1,
                "secret_encoded": true,
                "scopes": {
                  "key": "value"
                },
                "alg": "HS256"
              },
              "signing_keys": [
                {
                  "pkcs7": "pkcs7",
                  "cert": "cert",
                  "subject": "subject"
                }
              ],
              "encryption_key": {
                "pub": "pub",
                "cert": "cert",
                "subject": "subject"
              },
              "sso": true,
              "sso_disabled": true,
              "cross_origin_authentication": true,
              "cross_origin_loc": "cross_origin_loc",
              "custom_login_page_on": true,
              "custom_login_page": "custom_login_page",
              "custom_login_page_preview": "custom_login_page_preview",
              "form_template": "form_template",
              "addons": {
                "aws": {
                  "principal": "principal",
                  "role": "role",
                  "lifetime_in_seconds": 1
                },
                "azure_blob": {
                  "accountName": "accountName",
                  "storageAccessKey": "storageAccessKey",
                  "containerName": "containerName",
                  "blobName": "blobName",
                  "expiration": 1,
                  "signedIdentifier": "signedIdentifier",
                  "blob_read": true,
                  "blob_write": true,
                  "blob_delete": true,
                  "container_read": true,
                  "container_write": true,
                  "container_delete": true,
                  "container_list": true
                },
                "azure_sb": {
                  "namespace": "namespace",
                  "sasKeyName": "sasKeyName",
                  "sasKey": "sasKey",
                  "entityPath": "entityPath",
                  "expiration": 1
                },
                "rms": {
                  "url": "url"
                },
                "mscrm": {
                  "url": "url"
                },
                "slack": {
                  "team": "team"
                },
                "sentry": {
                  "org_slug": "org_slug",
                  "base_url": "base_url"
                },
                "box": {
                  "key": "value"
                },
                "cloudbees": {
                  "key": "value"
                },
                "concur": {
                  "key": "value"
                },
                "dropbox": {
                  "key": "value"
                },
                "echosign": {
                  "domain": "domain"
                },
                "egnyte": {
                  "domain": "domain"
                },
                "firebase": {
                  "secret": "secret",
                  "private_key_id": "private_key_id",
                  "private_key": "private_key",
                  "client_email": "client_email",
                  "lifetime_in_seconds": 1
                },
                "newrelic": {
                  "account": "account"
                },
                "office365": {
                  "domain": "domain",
                  "connection": "connection"
                },
                "salesforce": {
                  "entity_id": "entity_id"
                },
                "salesforce_api": {
                  "clientid": "clientid",
                  "principal": "principal",
                  "communityName": "communityName",
                  "community_url_section": "community_url_section"
                },
                "salesforce_sandbox_api": {
                  "clientid": "clientid",
                  "principal": "principal",
                  "communityName": "communityName",
                  "community_url_section": "community_url_section"
                },
                "samlp": {
                  "mappings": {
                    "key": "value"
                  },
                  "audience": "audience",
                  "recipient": "recipient",
                  "createUpnClaim": true,
                  "mapUnknownClaimsAsIs": true,
                  "passthroughClaimsWithNoMapping": true,
                  "mapIdentities": true,
                  "signatureAlgorithm": "signatureAlgorithm",
                  "digestAlgorithm": "digestAlgorithm",
                  "issuer": "issuer",
                  "destination": "destination",
                  "lifetimeInSeconds": 1,
                  "signResponse": true,
                  "nameIdentifierFormat": "nameIdentifierFormat",
                  "nameIdentifierProbes": [
                    "nameIdentifierProbes"
                  ],
                  "authnContextClassRef": "authnContextClassRef"
                },
                "layer": {
                  "providerId": "providerId",
                  "keyId": "keyId",
                  "privateKey": "privateKey",
                  "principal": "principal",
                  "expiration": 1
                },
                "sap_api": {
                  "clientid": "clientid",
                  "usernameAttribute": "usernameAttribute",
                  "tokenEndpointUrl": "tokenEndpointUrl",
                  "scope": "scope",
                  "servicePassword": "servicePassword",
                  "nameIdentifierFormat": "nameIdentifierFormat"
                },
                "sharepoint": {
                  "url": "url",
                  "external_url": [
                    "external_url"
                  ]
                },
                "springcm": {
                  "acsurl": "acsurl"
                },
                "wams": {
                  "masterkey": "masterkey"
                },
                "wsfed": {
                  "key": "value"
                },
                "zendesk": {
                  "accountName": "accountName"
                },
                "zoom": {
                  "account": "account"
                },
                "sso_integration": {
                  "name": "name",
                  "version": "version"
                }
              },
              "token_endpoint_auth_method": "none",
              "is_token_endpoint_ip_header_trusted": true,
              "client_metadata": {
                "key": "value"
              },
              "mobile": {
                "android": {
                  "app_package_name": "app_package_name",
                  "sha256_cert_fingerprints": [
                    "sha256_cert_fingerprints"
                  ]
                },
                "ios": {
                  "team_id": "team_id",
                  "app_bundle_identifier": "app_bundle_identifier"
                }
              },
              "initiate_login_uri": "initiate_login_uri",
              "refresh_token": {
                "rotation_type": "rotating",
                "expiration_type": "expiring",
                "leeway": 1,
                "token_lifetime": 1,
                "infinite_token_lifetime": true,
                "idle_token_lifetime": 1,
                "infinite_idle_token_lifetime": true,
                "policies": [
                  {
                    "audience": "audience",
                    "scope": [
                      "scope"
                    ]
                  }
                ]
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
              "client_authentication_methods": {
                "private_key_jwt": {
                  "credentials": [
                    {
                      "id": "id"
                    }
                  ]
                },
                "tls_client_auth": {
                  "credentials": [
                    {
                      "id": "id"
                    }
                  ]
                },
                "self_signed_tls_client_auth": {
                  "credentials": [
                    {
                      "id": "id"
                    }
                  ]
                }
              },
              "require_pushed_authorization_requests": true,
              "require_proof_of_possession": true,
              "signed_request_object": {
                "required": true,
                "credentials": [
                  {
                    "id": "id"
                  }
                ]
              },
              "compliance_level": "none",
              "skip_non_verifiable_callback_uri_confirmation_prompt": true,
              "token_exchange": {
                "allow_any_profile_of_type": [
                  "custom_authentication"
                ]
              },
              "par_request_expiry": 1,
              "token_quota": {
                "client_credentials": {
                  "enforce": true,
                  "per_day": 1,
                  "per_hour": 1
                }
              },
              "express_configuration": {
                "initiate_login_uri_template": "initiate_login_uri_template",
                "user_attribute_profile_id": "user_attribute_profile_id",
                "connection_profile_id": "connection_profile_id",
                "enable_client": true,
                "enable_organization": true,
                "linked_clients": [
                  {
                    "client_id": "client_id"
                  }
                ],
                "okta_oin_client_id": "okta_oin_client_id",
                "admin_login_domain": "admin_login_domain",
                "oin_submission_id": "oin_submission_id"
              },
              "my_organization_configuration": {
                "connection_profile_id": "connection_profile_id",
                "user_attribute_profile_id": "user_attribute_profile_id",
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/clients")
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

        var response = await Client.Clients.CreateAsync(
            new CreateClientRequestContent { Name = "name" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
