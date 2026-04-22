# Reference
## Actions
<details><summary><code>client.Actions.<a href="/src/Auth0.ManagementApi/Actions/ActionsClient.cs">ListAsync</a>(ListActionsRequestParameters { ... }) -> Pager&lt;Action&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all actions.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.ListAsync(
    new ListActionsRequestParameters
    {
        TriggerId = ActionTriggerTypeEnum.PostLogin,
        ActionName = "actionName",
        Deployed = true,
        Page = 1,
        PerPage = 1,
        Installed = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListActionsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Actions.<a href="/src/Auth0.ManagementApi/Actions/ActionsClient.cs">CreateAsync</a>(CreateActionRequestContent { ... }) -> WithRawResponseTask&lt;CreateActionResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create an action. Once an action is created, it must be deployed, and then bound to a trigger before it will be executed as part of a flow.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.CreateAsync(
    new CreateActionRequestContent
    {
        Name = "name",
        SupportedTriggers = new List<ActionTrigger>()
        {
            new ActionTrigger { Id = ActionTriggerTypeEnum.PostLogin },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateActionRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Actions.<a href="/src/Auth0.ManagementApi/Actions/ActionsClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;GetActionResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve an action by its ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The ID of the action to retrieve.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Actions.<a href="/src/Auth0.ManagementApi/Actions/ActionsClient.cs">DeleteAsync</a>(id, DeleteActionRequestParameters { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes an action and all of its associated versions. An action must be unbound from all triggers before it can be deleted.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.DeleteAsync("id", new DeleteActionRequestParameters { Force = true });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The ID of the action to delete.
    
</dd>
</dl>

<dl>
<dd>

**request:** `DeleteActionRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Actions.<a href="/src/Auth0.ManagementApi/Actions/ActionsClient.cs">UpdateAsync</a>(id, UpdateActionRequestContent { ... }) -> WithRawResponseTask&lt;UpdateActionResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update an existing action. If this action is currently bound to a trigger, updating it will <strong>not</strong> affect any user flows until the action is deployed.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.UpdateAsync("id", new UpdateActionRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the action to update.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateActionRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Actions.<a href="/src/Auth0.ManagementApi/Actions/ActionsClient.cs">DeployAsync</a>(id) -> WithRawResponseTask&lt;DeployActionResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deploy an action. Deploying an action will create a new immutable version of the action. If the action is currently bound to a trigger, then the system will begin executing the newly deployed version of the action immediately. Otherwise, the action will only be executed as a part of a flow once it is bound to that flow.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.DeployAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The ID of an action.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Actions.<a href="/src/Auth0.ManagementApi/Actions/ActionsClient.cs">TestAsync</a>(id, TestActionRequestContent { ... }) -> WithRawResponseTask&lt;TestActionResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Test an action. After updating an action, it can be tested prior to being deployed to ensure it behaves as expected.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.TestAsync(
    "id",
    new TestActionRequestContent
    {
        Payload = new Dictionary<string, object?>() { { "key", "value" } },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the action to test.
    
</dd>
</dl>

<dl>
<dd>

**request:** `TestActionRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Branding
<details><summary><code>client.Branding.<a href="/src/Auth0.ManagementApi/Branding/BrandingClient.cs">GetAsync</a>() -> WithRawResponseTask&lt;GetBrandingResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve branding settings.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Branding.GetAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Branding.<a href="/src/Auth0.ManagementApi/Branding/BrandingClient.cs">UpdateAsync</a>(UpdateBrandingRequestContent { ... }) -> WithRawResponseTask&lt;UpdateBrandingResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update branding settings.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Branding.UpdateAsync(new UpdateBrandingRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateBrandingRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## ClientGrants
<details><summary><code>client.ClientGrants.<a href="/src/Auth0.ManagementApi/ClientGrants/ClientGrantsClient.cs">ListAsync</a>(ListClientGrantsRequestParameters { ... }) -> Pager&lt;ClientGrantResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of <a href="https://auth0.com/docs/get-started/applications/application-access-to-apis-client-grants">client grants</a>, including the scopes associated with the application/API pair.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ClientGrants.ListAsync(
    new ListClientGrantsRequestParameters
    {
        From = "from",
        Take = 1,
        Audience = "audience",
        ClientId = "client_id",
        AllowAnyOrganization = true,
        SubjectType = ClientGrantSubjectTypeEnum.Client,
        DefaultFor = ClientGrantDefaultForEnum.ThirdPartyClients,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListClientGrantsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.ClientGrants.<a href="/src/Auth0.ManagementApi/ClientGrants/ClientGrantsClient.cs">CreateAsync</a>(CreateClientGrantRequestContent { ... }) -> WithRawResponseTask&lt;CreateClientGrantResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a client grant for a machine-to-machine login flow. To learn more, read <a href="https://www.auth0.com/docs/get-started/authentication-and-authorization-flow/client-credentials-flow">Client Credential Flow</a>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ClientGrants.CreateAsync(
    new CreateClientGrantRequestContent { Audience = "audience" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateClientGrantRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.ClientGrants.<a href="/src/Auth0.ManagementApi/ClientGrants/ClientGrantsClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;GetClientGrantResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a single <a href="https://auth0.com/docs/get-started/applications/application-access-to-apis-client-grants">client grant</a>, including the
scopes associated with the application/API pair.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ClientGrants.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The ID of the client grant to retrieve.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.ClientGrants.<a href="/src/Auth0.ManagementApi/ClientGrants/ClientGrantsClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete the <a href="https://www.auth0.com/docs/get-started/authentication-and-authorization-flow/client-credentials-flow">Client Credential Flow</a> from your machine-to-machine application.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ClientGrants.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the client grant to delete.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.ClientGrants.<a href="/src/Auth0.ManagementApi/ClientGrants/ClientGrantsClient.cs">UpdateAsync</a>(id, UpdateClientGrantRequestContent { ... }) -> WithRawResponseTask&lt;UpdateClientGrantResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update a client grant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ClientGrants.UpdateAsync("id", new UpdateClientGrantRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the client grant to update.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateClientGrantRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Clients
<details><summary><code>client.Clients.<a href="/src/Auth0.ManagementApi/Clients/ClientsClient.cs">ListAsync</a>(ListClientsRequestParameters { ... }) -> Pager&lt;Client&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve clients (applications and SSO integrations) matching provided filters. A list of fields to include or exclude may also be specified.
For more information, read <a href="https://www.auth0.com/docs/get-started/applications"> Applications in Auth0</a> and <a href="https://www.auth0.com/docs/authenticate/single-sign-on"> Single Sign-On</a>.

<ul>
  <li>
    The following can be retrieved with any scope:
    <code>client_id</code>, <code>app_type</code>, <code>name</code>, and <code>description</code>.
  </li>
  <li>
    The following properties can only be retrieved with the <code>read:clients</code> or
    <code>read:client_keys</code> scope:
    <code>callbacks</code>, <code>oidc_logout</code>, <code>allowed_origins</code>,
    <code>web_origins</code>, <code>tenant</code>, <code>global</code>, <code>config_route</code>,
    <code>callback_url_template</code>, <code>jwt_configuration</code>,
    <code>jwt_configuration.lifetime_in_seconds</code>, <code>jwt_configuration.secret_encoded</code>,
    <code>jwt_configuration.scopes</code>, <code>jwt_configuration.alg</code>, <code>api_type</code>,
    <code>logo_uri</code>, <code>allowed_clients</code>, <code>owners</code>, <code>custom_login_page</code>,
    <code>custom_login_page_off</code>, <code>sso</code>, <code>addons</code>, <code>form_template</code>,
    <code>custom_login_page_codeview</code>, <code>resource_servers</code>, <code>client_metadata</code>,
    <code>mobile</code>, <code>mobile.android</code>, <code>mobile.ios</code>, <code>allowed_logout_urls</code>,
    <code>token_endpoint_auth_method</code>, <code>is_first_party</code>, <code>oidc_conformant</code>,
    <code>is_token_endpoint_ip_header_trusted</code>, <code>initiate_login_uri</code>, <code>grant_types</code>,
    <code>refresh_token</code>, <code>refresh_token.rotation_type</code>, <code>refresh_token.expiration_type</code>,
    <code>refresh_token.leeway</code>, <code>refresh_token.token_lifetime</code>, <code>refresh_token.policies</code>, <code>organization_usage</code>,
    <code>organization_require_behavior</code>.
  </li>
  <li>
    The following properties can only be retrieved with the
    <code>read:client_keys</code> or <code>read:client_credentials</code> scope:
    <code>encryption_key</code>, <code>encryption_key.pub</code>, <code>encryption_key.cert</code>,
    <code>client_secret</code>, <code>client_authentication_methods</code> and <code>signing_key</code>.
  </li>
</ul>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Clients.ListAsync(
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
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListClientsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Clients.<a href="/src/Auth0.ManagementApi/Clients/ClientsClient.cs">CreateAsync</a>(CreateClientRequestContent { ... }) -> WithRawResponseTask&lt;CreateClientResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a new client (application or SSO integration). For more information, read <a href="https://www.auth0.com/docs/get-started/auth0-overview/create-applications">Create Applications</a>
<a href="https://www.auth0.com/docs/authenticate/single-sign-on/api-endpoints-for-single-sign-on>">API Endpoints for Single Sign-On</a>. 

Notes: 
- We recommend leaving the `client_secret` parameter unspecified to allow the generation of a safe secret.
- The <code>client_authentication_methods</code> and <code>token_endpoint_auth_method</code> properties are mutually exclusive. Use 
<code>client_authentication_methods</code> to configure the client with Private Key JWT authentication method. Otherwise, use <code>token_endpoint_auth_method</code>
to configure the client with client secret (basic or post) or with no authentication method (none).
- When using <code>client_authentication_methods</code> to configure the client with Private Key JWT authentication method, specify fully defined credentials. 
These credentials will be automatically enabled for Private Key JWT authentication on the client. 
- To configure <code>client_authentication_methods</code>, the <code>create:client_credentials</code> scope is required.
- To configure <code>client_authentication_methods</code>, the property <code>jwt_configuration.alg</code> must be set to RS256.

<div class="alert alert-warning">SSO Integrations created via this endpoint will accept login requests and share user profile information.</div>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Clients.CreateAsync(new CreateClientRequestContent { Name = "name" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateClientRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Clients.<a href="/src/Auth0.ManagementApi/Clients/ClientsClient.cs">PreviewCimdMetadataAsync</a>(PreviewCimdMetadataRequestContent { ... }) -> WithRawResponseTask&lt;PreviewCimdMetadataResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>


      Fetches and validates a Client ID Metadata Document without creating a client.
      Returns the raw metadata and how it would be mapped to Auth0 client fields.
      This endpoint is useful for testing metadata URIs before creating CIMD clients.
    
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Clients.PreviewCimdMetadataAsync(
    new PreviewCimdMetadataRequestContent { ExternalClientId = "external_client_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PreviewCimdMetadataRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Clients.<a href="/src/Auth0.ManagementApi/Clients/ClientsClient.cs">RegisterCimdClientAsync</a>(RegisterCimdClientRequestContent { ... }) -> WithRawResponseTask&lt;RegisterCimdClientResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>


      Idempotent registration for Client ID Metadata Document (CIMD) clients.
      Uses external_client_id as the unique identifier for upsert operations.
      **Create:** Returns 201 when a new client is created (requires \
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Clients.RegisterCimdClientAsync(
    new RegisterCimdClientRequestContent { ExternalClientId = "external_client_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `RegisterCimdClientRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Clients.<a href="/src/Auth0.ManagementApi/Clients/ClientsClient.cs">GetAsync</a>(id, GetClientRequestParameters { ... }) -> WithRawResponseTask&lt;GetClientResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve client details by ID. Clients are SSO connections or Applications linked with your Auth0 tenant. A list of fields to include or exclude may also be specified. 
For more information, read <a href="https://www.auth0.com/docs/get-started/applications"> Applications in Auth0</a> and <a href="https://www.auth0.com/docs/authenticate/single-sign-on"> Single Sign-On</a>.
<ul>
  <li>
    The following properties can be retrieved with any of the scopes:
    <code>client_id</code>, <code>app_type</code>, <code>name</code>, and <code>description</code>.
  </li>
  <li>
    The following properties can only be retrieved with the <code>read:clients</code> or
    <code>read:client_keys</code> scopes:
    <code>callbacks</code>, <code>oidc_logout</code>, <code>allowed_origins</code>,
    <code>web_origins</code>, <code>tenant</code>, <code>global</code>, <code>config_route</code>,
    <code>callback_url_template</code>, <code>jwt_configuration</code>,
    <code>jwt_configuration.lifetime_in_seconds</code>, <code>jwt_configuration.secret_encoded</code>,
    <code>jwt_configuration.scopes</code>, <code>jwt_configuration.alg</code>, <code>api_type</code>,
    <code>logo_uri</code>, <code>allowed_clients</code>, <code>owners</code>, <code>custom_login_page</code>,
    <code>custom_login_page_off</code>, <code>sso</code>, <code>addons</code>, <code>form_template</code>,
    <code>custom_login_page_codeview</code>, <code>resource_servers</code>, <code>client_metadata</code>,
    <code>mobile</code>, <code>mobile.android</code>, <code>mobile.ios</code>, <code>allowed_logout_urls</code>,
    <code>token_endpoint_auth_method</code>, <code>is_first_party</code>, <code>oidc_conformant</code>,
    <code>is_token_endpoint_ip_header_trusted</code>, <code>initiate_login_uri</code>, <code>grant_types</code>,
    <code>refresh_token</code>, <code>refresh_token.rotation_type</code>, <code>refresh_token.expiration_type</code>,
    <code>refresh_token.leeway</code>, <code>refresh_token.token_lifetime</code>, <code>refresh_token.policies</code>, <code>organization_usage</code>,
    <code>organization_require_behavior</code>.
  </li>
  <li>
    The following properties can only be retrieved with the <code>read:client_keys</code> or <code>read:client_credentials</code> scopes:
    <code>encryption_key</code>, <code>encryption_key.pub</code>, <code>encryption_key.cert</code>,
    <code>client_secret</code>, <code>client_authentication_methods</code> and <code>signing_key</code>.
  </li>
</ul>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Clients.GetAsync(
    "id",
    new GetClientRequestParameters { Fields = "fields", IncludeFields = true }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the client to retrieve.
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetClientRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Clients.<a href="/src/Auth0.ManagementApi/Clients/ClientsClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a client and related configuration (rules, connections, etc).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Clients.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the client to delete.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Clients.<a href="/src/Auth0.ManagementApi/Clients/ClientsClient.cs">UpdateAsync</a>(id, UpdateClientRequestContent { ... }) -> WithRawResponseTask&lt;UpdateClientResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a client's settings. For more information, read <a href="https://www.auth0.com/docs/get-started/applications"> Applications in Auth0</a> and <a href="https://www.auth0.com/docs/authenticate/single-sign-on"> Single Sign-On</a>.

Notes:
- The `client_secret` and `signing_key` attributes can only be updated with the `update:client_keys` scope.
- The <code>client_authentication_methods</code> and <code>token_endpoint_auth_method</code> properties are mutually exclusive. Use <code>client_authentication_methods</code> to configure the client with Private Key JWT authentication method. Otherwise, use <code>token_endpoint_auth_method</code> to configure the client with client secret (basic or post) or with no authentication method (none).
- When using <code>client_authentication_methods</code> to configure the client with Private Key JWT authentication method, only specify the credential IDs that were generated when creating the credentials on the client.
- To configure <code>client_authentication_methods</code>, the <code>update:client_credentials</code> scope is required.
- To configure <code>client_authentication_methods</code>, the property <code>jwt_configuration.alg</code> must be set to RS256.
- To change a client's <code>is_first_party</code> property to <code>false</code>, the <code>organization_usage</code> and <code>organization_require_behavior</code> properties must be unset.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Clients.UpdateAsync("id", new UpdateClientRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the client to update.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateClientRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Clients.<a href="/src/Auth0.ManagementApi/Clients/ClientsClient.cs">RotateSecretAsync</a>(id) -> WithRawResponseTask&lt;RotateClientSecretResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Rotate a client secret.

This endpoint cannot be used with clients configured with Private Key JWT authentication method (client_authentication_methods configured with private_key_jwt). The generated secret is NOT base64 encoded.

For more information, read <a href="https://www.auth0.com/docs/get-started/applications/rotate-client-secret">Rotate Client Secrets</a>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Clients.RotateSecretAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the client that will rotate secrets.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## ConnectionProfiles
<details><summary><code>client.ConnectionProfiles.<a href="/src/Auth0.ManagementApi/ConnectionProfiles/ConnectionProfilesClient.cs">ListAsync</a>(ListConnectionProfileRequestParameters { ... }) -> Pager&lt;ConnectionProfile&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of Connection Profiles. This endpoint supports Checkpoint pagination.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ConnectionProfiles.ListAsync(
    new ListConnectionProfileRequestParameters { From = "from", Take = 1 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListConnectionProfileRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.ConnectionProfiles.<a href="/src/Auth0.ManagementApi/ConnectionProfiles/ConnectionProfilesClient.cs">CreateAsync</a>(CreateConnectionProfileRequestContent { ... }) -> WithRawResponseTask&lt;CreateConnectionProfileResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a Connection Profile.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ConnectionProfiles.CreateAsync(
    new CreateConnectionProfileRequestContent { Name = "name" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateConnectionProfileRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.ConnectionProfiles.<a href="/src/Auth0.ManagementApi/ConnectionProfiles/ConnectionProfilesClient.cs">ListTemplatesAsync</a>() -> WithRawResponseTask&lt;ListConnectionProfileTemplateResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of Connection Profile Templates.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ConnectionProfiles.ListTemplatesAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.ConnectionProfiles.<a href="/src/Auth0.ManagementApi/ConnectionProfiles/ConnectionProfilesClient.cs">GetTemplateAsync</a>(id) -> WithRawResponseTask&lt;GetConnectionProfileTemplateResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a Connection Profile Template.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ConnectionProfiles.GetTemplateAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the connection-profile-template to retrieve.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.ConnectionProfiles.<a href="/src/Auth0.ManagementApi/ConnectionProfiles/ConnectionProfilesClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;GetConnectionProfileResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details about a single Connection Profile specified by ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ConnectionProfiles.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the connection-profile to retrieve.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.ConnectionProfiles.<a href="/src/Auth0.ManagementApi/ConnectionProfiles/ConnectionProfilesClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a single Connection Profile specified by ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ConnectionProfiles.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the connection-profile to delete.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.ConnectionProfiles.<a href="/src/Auth0.ManagementApi/ConnectionProfiles/ConnectionProfilesClient.cs">UpdateAsync</a>(id, UpdateConnectionProfileRequestContent { ... }) -> WithRawResponseTask&lt;UpdateConnectionProfileResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update the details of a specific Connection Profile.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ConnectionProfiles.UpdateAsync("id", new UpdateConnectionProfileRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the connection profile to update.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateConnectionProfileRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Connections
<details><summary><code>client.Connections.<a href="/src/Auth0.ManagementApi/Connections/ConnectionsClient.cs">ListAsync</a>(ListConnectionsQueryParameters { ... }) -> Pager&lt;ConnectionForList&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves detailed list of all <a href="https://auth0.com/docs/authenticate/identity-providers">connections</a> that match the specified strategy. If no strategy is provided, all connections within your tenant are retrieved. This action can accept a list of fields to include or exclude from the resulting list of connections. 

This endpoint supports two types of pagination:
<ul>
<li>Offset pagination</li>
<li>Checkpoint pagination</li>
</ul>

Checkpoint pagination must be used if you need to retrieve more than 1000 connections.

<h2>Checkpoint Pagination</h2>

To search by checkpoint, use the following parameters:
<ul>
<li><code>from</code>: Optional id from which to start selection.</li>
<li><code>take</code>: The total amount of entries to retrieve when using the from parameter. Defaults to 50.</li>
</ul>

<b>Note</b>: The first time you call this endpoint using checkpoint pagination, omit the <code>from</code> parameter. If there are more results, a <code>next</code> value is included in the response. You can use this for subsequent API calls. When <code>next</code> is no longer included in the response, no pages are remaining.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.ListAsync(
    new ListConnectionsQueryParameters
    {
        From = "from",
        Take = 1,
        Name = "name",
        Fields = "fields",
        IncludeFields = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListConnectionsQueryParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Connections.<a href="/src/Auth0.ManagementApi/Connections/ConnectionsClient.cs">CreateAsync</a>(CreateConnectionRequestContent { ... }) -> WithRawResponseTask&lt;CreateConnectionResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a new connection according to the JSON object received in <code>body</code>.

<b>Note:</b> If a connection with the same name was recently deleted and had a large number of associated users, the deletion may still be processing. Creating a new connection with that name before the deletion completes may fail or produce unexpected results. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.CreateAsync(
    new CreateConnectionRequestContent
    {
        Name = "name",
        Strategy = ConnectionIdentityProviderEnum.Ad,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateConnectionRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Connections.<a href="/src/Auth0.ManagementApi/Connections/ConnectionsClient.cs">GetAsync</a>(id, GetConnectionRequestParameters { ... }) -> WithRawResponseTask&lt;GetConnectionResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details for a specified <a href="https://auth0.com/docs/authenticate/identity-providers">connection</a> along with options that can be used for identity provider configuration.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.GetAsync(
    "id",
    new GetConnectionRequestParameters { Fields = "fields", IncludeFields = true }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the connection to retrieve
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetConnectionRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Connections.<a href="/src/Auth0.ManagementApi/Connections/ConnectionsClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Removes a specific <a href="https://auth0.com/docs/authenticate/identity-providers">connection</a> from your tenant. This action cannot be undone. Once removed, users can no longer use this connection to authenticate.

<b>Note:</b> If your connection has a large amount of users associated with it, please be aware that this operation can be long running after the response is returned and may impact concurrent <a href="https://auth0.com/docs/api/management/v2/connections/post-connections">create connection</a> requests, if they use an identical connection name. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the connection to delete
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Connections.<a href="/src/Auth0.ManagementApi/Connections/ConnectionsClient.cs">UpdateAsync</a>(id, UpdateConnectionRequestContent { ... }) -> WithRawResponseTask&lt;UpdateConnectionResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update details for a specific <a href="https://auth0.com/docs/authenticate/identity-providers">connection</a>, including option properties for identity provider configuration.

<b>Note</b>: If you use the <code>options</code> parameter, the entire <code>options</code> object is overriden. To avoid partial data or other issues, ensure all parameters are present when using this option.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.UpdateAsync("id", new UpdateConnectionRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the connection to update
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateConnectionRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Connections.<a href="/src/Auth0.ManagementApi/Connections/ConnectionsClient.cs">CheckStatusAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves the status of an ad/ldap connection referenced by its <code>ID</code>. <code>200 OK</code> http status code response is returned  when the connection is online, otherwise a <code>404</code> status code is returned along with an error message
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.CheckStatusAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the connection to check
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## CustomDomains
<details><summary><code>client.CustomDomains.<a href="/src/Auth0.ManagementApi/CustomDomains/CustomDomainsClient.cs">ListAsync</a>(ListCustomDomainsRequestParameters { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;CustomDomain&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details on <a href="https://auth0.com/docs/custom-domains">custom domains</a>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CustomDomains.ListAsync(
    new ListCustomDomainsRequestParameters
    {
        Q = "q",
        Fields = "fields",
        IncludeFields = true,
        Sort = "sort",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListCustomDomainsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.CustomDomains.<a href="/src/Auth0.ManagementApi/CustomDomains/CustomDomainsClient.cs">CreateAsync</a>(CreateCustomDomainRequestContent { ... }) -> WithRawResponseTask&lt;CreateCustomDomainResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a new custom domain.

Note: The custom domain will need to be verified before it will accept
requests.

Optional attributes that can be updated:

- custom_client_ip_header
- tls_policy


TLS Policies:

- recommended - for modern usage this includes TLS 1.2 only
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CustomDomains.CreateAsync(
    new CreateCustomDomainRequestContent
    {
        Domain = "domain",
        Type = CustomDomainProvisioningTypeEnum.Auth0ManagedCerts,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateCustomDomainRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.CustomDomains.<a href="/src/Auth0.ManagementApi/CustomDomains/CustomDomainsClient.cs">GetDefaultAsync</a>() -> WithRawResponseTask&lt;GetDefaultDomainResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve the tenant's default domain.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CustomDomains.GetDefaultAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.CustomDomains.<a href="/src/Auth0.ManagementApi/CustomDomains/CustomDomainsClient.cs">SetDefaultAsync</a>(SetDefaultCustomDomainRequestContent { ... }) -> WithRawResponseTask&lt;UpdateDefaultDomainResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Set the default custom domain for the tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CustomDomains.SetDefaultAsync(
    new SetDefaultCustomDomainRequestContent { Domain = "domain" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SetDefaultCustomDomainRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.CustomDomains.<a href="/src/Auth0.ManagementApi/CustomDomains/CustomDomainsClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;GetCustomDomainResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a custom domain configuration and status.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CustomDomains.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the custom domain to retrieve.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.CustomDomains.<a href="/src/Auth0.ManagementApi/CustomDomains/CustomDomainsClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a custom domain and stop serving requests for it.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CustomDomains.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the custom domain to delete.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.CustomDomains.<a href="/src/Auth0.ManagementApi/CustomDomains/CustomDomainsClient.cs">UpdateAsync</a>(id, UpdateCustomDomainRequestContent { ... }) -> WithRawResponseTask&lt;UpdateCustomDomainResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update a custom domain.

These are the attributes that can be updated:

- custom_client_ip_header
- tls_policy

<h5>Updating CUSTOM_CLIENT_IP_HEADER for a custom domain</h5>To update the <code>custom_client_ip_header</code> for a domain, the body to
send should be:
<pre><code>{ "custom_client_ip_header": "cf-connecting-ip" }</code></pre>

<h5>Updating TLS_POLICY for a custom domain</h5>To update the <code>tls_policy</code> for a domain, the body to send should be:
<pre><code>{ "tls_policy": "recommended" }</code></pre>


TLS Policies:

- recommended - for modern usage this includes TLS 1.2 only


Some considerations:

- The TLS ciphers and protocols available in each TLS policy follow industry recommendations, and may be updated occasionally.
- The <code>compatible</code> TLS policy is no longer supported.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CustomDomains.UpdateAsync("id", new UpdateCustomDomainRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the custom domain to update
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateCustomDomainRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.CustomDomains.<a href="/src/Auth0.ManagementApi/CustomDomains/CustomDomainsClient.cs">TestAsync</a>(id) -> WithRawResponseTask&lt;TestCustomDomainResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Run the test process on a custom domain.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CustomDomains.TestAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the custom domain to test.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.CustomDomains.<a href="/src/Auth0.ManagementApi/CustomDomains/CustomDomainsClient.cs">VerifyAsync</a>(id) -> WithRawResponseTask&lt;VerifyCustomDomainResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Run the verification process on a custom domain.

Note: Check the <code>status</code> field to see its verification status. Once verification is complete, it may take up to 10 minutes before the custom domain can start accepting requests.

For <code>self_managed_certs</code>, when the custom domain is verified for the first time, the response will also include the <code>cname_api_key</code> which you will need to configure your proxy. This key must be kept secret, and is used to validate the proxy requests.

<a href="https://auth0.com/docs/custom-domains#step-2-verify-ownership">Learn more</a> about verifying custom domains that use Auth0 Managed certificates.
<a href="https://auth0.com/docs/custom-domains/self-managed-certificates#step-2-verify-ownership">Learn more</a> about verifying custom domains that use Self Managed certificates.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.CustomDomains.VerifyAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the custom domain to verify.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## DeviceCredentials
<details><summary><code>client.DeviceCredentials.<a href="/src/Auth0.ManagementApi/DeviceCredentials/DeviceCredentialsClient.cs">ListAsync</a>(ListDeviceCredentialsRequestParameters { ... }) -> Pager&lt;DeviceCredential&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve device credential information (<code>public_key</code>, <code>refresh_token</code>, or <code>rotating_refresh_token</code>) associated with a specific user.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.DeviceCredentials.ListAsync(
    new ListDeviceCredentialsRequestParameters
    {
        Page = 1,
        PerPage = 1,
        IncludeTotals = true,
        Fields = "fields",
        IncludeFields = true,
        UserId = "user_id",
        ClientId = "client_id",
        Type = DeviceCredentialTypeEnum.PublicKey,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListDeviceCredentialsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.DeviceCredentials.<a href="/src/Auth0.ManagementApi/DeviceCredentials/DeviceCredentialsClient.cs">CreatePublicKeyAsync</a>(CreatePublicKeyDeviceCredentialRequestContent { ... }) -> WithRawResponseTask&lt;CreatePublicKeyDeviceCredentialResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a device credential public key to manage refresh token rotation for a given <code>user_id</code>. Device Credentials APIs are designed for ad-hoc administrative use only and paging is by default enabled for GET requests.

When refresh token rotation is enabled, the endpoint becomes consistent. For more information, read <a href="https://auth0.com/docs/get-started/tenant-settings/signing-keys"> Signing Keys</a>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.DeviceCredentials.CreatePublicKeyAsync(
    new CreatePublicKeyDeviceCredentialRequestContent
    {
        DeviceName = "device_name",
        Type = DeviceCredentialPublicKeyTypeEnum.PublicKey,
        Value = "value",
        DeviceId = "device_id",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreatePublicKeyDeviceCredentialRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.DeviceCredentials.<a href="/src/Auth0.ManagementApi/DeviceCredentials/DeviceCredentialsClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Permanently delete a device credential (such as a refresh token or public key) with the given ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.DeviceCredentials.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the credential to delete.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## EmailTemplates
<details><summary><code>client.EmailTemplates.<a href="/src/Auth0.ManagementApi/EmailTemplates/EmailTemplatesClient.cs">CreateAsync</a>(CreateEmailTemplateRequestContent { ... }) -> WithRawResponseTask&lt;CreateEmailTemplateResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create an email template.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmailTemplates.CreateAsync(
    new CreateEmailTemplateRequestContent { Template = EmailTemplateNameEnum.VerifyEmail }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateEmailTemplateRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmailTemplates.<a href="/src/Auth0.ManagementApi/EmailTemplates/EmailTemplatesClient.cs">GetAsync</a>(templateName) -> WithRawResponseTask&lt;GetEmailTemplateResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve an email template by pre-defined name. These names are `verify_email`, `verify_email_by_code`, `reset_email`, `reset_email_by_code`, `welcome_email`, `blocked_account`, `stolen_credentials`, `enrollment_email`, `mfa_oob_code`, `user_invitation`, and `async_approval`. The names `change_password`, and `password_reset` are also supported for legacy scenarios.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmailTemplates.GetAsync(EmailTemplateNameEnum.VerifyEmail);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**templateName:** `EmailTemplateNameEnum` — Template name. Can be `verify_email`, `verify_email_by_code`, `reset_email`, `reset_email_by_code`, `welcome_email`, `blocked_account`, `stolen_credentials`, `enrollment_email`, `mfa_oob_code`, `user_invitation`, `async_approval`, `change_password` (legacy), or `password_reset` (legacy).
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmailTemplates.<a href="/src/Auth0.ManagementApi/EmailTemplates/EmailTemplatesClient.cs">SetAsync</a>(templateName, SetEmailTemplateRequestContent { ... }) -> WithRawResponseTask&lt;SetEmailTemplateResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update an email template.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmailTemplates.SetAsync(
    EmailTemplateNameEnum.VerifyEmail,
    new SetEmailTemplateRequestContent { Template = EmailTemplateNameEnum.VerifyEmail }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**templateName:** `EmailTemplateNameEnum` — Template name. Can be `verify_email`, `verify_email_by_code`, `reset_email`, `reset_email_by_code`, `welcome_email`, `blocked_account`, `stolen_credentials`, `enrollment_email`, `mfa_oob_code`, `user_invitation`, `async_approval`, `change_password` (legacy), or `password_reset` (legacy).
    
</dd>
</dl>

<dl>
<dd>

**request:** `SetEmailTemplateRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EmailTemplates.<a href="/src/Auth0.ManagementApi/EmailTemplates/EmailTemplatesClient.cs">UpdateAsync</a>(templateName, UpdateEmailTemplateRequestContent { ... }) -> WithRawResponseTask&lt;UpdateEmailTemplateResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Modify an email template.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EmailTemplates.UpdateAsync(
    EmailTemplateNameEnum.VerifyEmail,
    new UpdateEmailTemplateRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**templateName:** `EmailTemplateNameEnum` — Template name. Can be `verify_email`, `verify_email_by_code`, `reset_email`, `reset_email_by_code`, `welcome_email`, `blocked_account`, `stolen_credentials`, `enrollment_email`, `mfa_oob_code`, `user_invitation`, `async_approval`, `change_password` (legacy), or `password_reset` (legacy).
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateEmailTemplateRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## EventStreams
<details><summary><code>client.EventStreams.<a href="/src/Auth0.ManagementApi/EventStreams/EventStreamsClient.cs">ListAsync</a>(ListEventStreamsRequestParameters { ... }) -> Pager&lt;EventStreamResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EventStreams.ListAsync(
    new ListEventStreamsRequestParameters { From = "from", Take = 1 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListEventStreamsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EventStreams.<a href="/src/Auth0.ManagementApi/EventStreams/EventStreamsClient.cs">CreateAsync</a>(EventStreamsCreateRequest { ... }) -> WithRawResponseTask&lt;CreateEventStreamResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EventStreams.CreateAsync(
    new CreateEventStreamWebHookRequestContent
    {
        Destination = new EventStreamWebhookDestination
        {
            Type = EventStreamWebhookDestinationTypeEnum.Webhook,
            Configuration = new EventStreamWebhookConfiguration
            {
                WebhookEndpoint = "webhook_endpoint",
                WebhookAuthorization = new EventStreamWebhookBasicAuth
                {
                    Method = EventStreamWebhookBasicAuthMethodEnum.Basic,
                    Username = "username",
                },
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `EventStreamsCreateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EventStreams.<a href="/src/Auth0.ManagementApi/EventStreams/EventStreamsClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;GetEventStreamResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EventStreams.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Unique identifier for the event stream.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EventStreams.<a href="/src/Auth0.ManagementApi/EventStreams/EventStreamsClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EventStreams.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Unique identifier for the event stream.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EventStreams.<a href="/src/Auth0.ManagementApi/EventStreams/EventStreamsClient.cs">UpdateAsync</a>(id, UpdateEventStreamRequestContent { ... }) -> WithRawResponseTask&lt;UpdateEventStreamResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EventStreams.UpdateAsync("id", new UpdateEventStreamRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Unique identifier for the event stream.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateEventStreamRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EventStreams.<a href="/src/Auth0.ManagementApi/EventStreams/EventStreamsClient.cs">TestAsync</a>(id, CreateEventStreamTestEventRequestContent { ... }) -> WithRawResponseTask&lt;CreateEventStreamTestEventResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EventStreams.TestAsync(
    "id",
    new CreateEventStreamTestEventRequestContent
    {
        EventType = EventStreamTestEventTypeEnum.GroupCreated,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Unique identifier for the event stream.
    
</dd>
</dl>

<dl>
<dd>

**request:** `CreateEventStreamTestEventRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Flows
<details><summary><code>client.Flows.<a href="/src/Auth0.ManagementApi/Flows/FlowsClient.cs">ListAsync</a>(ListFlowsRequestParameters { ... }) -> Pager&lt;FlowSummary&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Flows.ListAsync(
    new ListFlowsRequestParameters
    {
        Page = 1,
        PerPage = 1,
        IncludeTotals = true,
        Synchronous = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListFlowsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Flows.<a href="/src/Auth0.ManagementApi/Flows/FlowsClient.cs">CreateAsync</a>(CreateFlowRequestContent { ... }) -> WithRawResponseTask&lt;CreateFlowResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Flows.CreateAsync(new CreateFlowRequestContent { Name = "name" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateFlowRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Flows.<a href="/src/Auth0.ManagementApi/Flows/FlowsClient.cs">GetAsync</a>(id, GetFlowRequestParameters { ... }) -> WithRawResponseTask&lt;GetFlowResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Flows.GetAsync("id", new GetFlowRequestParameters());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Flow identifier
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetFlowRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Flows.<a href="/src/Auth0.ManagementApi/Flows/FlowsClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Flows.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Flow id
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Flows.<a href="/src/Auth0.ManagementApi/Flows/FlowsClient.cs">UpdateAsync</a>(id, UpdateFlowRequestContent { ... }) -> WithRawResponseTask&lt;UpdateFlowResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Flows.UpdateAsync("id", new UpdateFlowRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Flow identifier
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateFlowRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Forms
<details><summary><code>client.Forms.<a href="/src/Auth0.ManagementApi/Forms/FormsClient.cs">ListAsync</a>(ListFormsRequestParameters { ... }) -> Pager&lt;FormSummary&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Forms.ListAsync(
    new ListFormsRequestParameters
    {
        Page = 1,
        PerPage = 1,
        IncludeTotals = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListFormsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Forms.<a href="/src/Auth0.ManagementApi/Forms/FormsClient.cs">CreateAsync</a>(CreateFormRequestContent { ... }) -> WithRawResponseTask&lt;CreateFormResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Forms.CreateAsync(new CreateFormRequestContent { Name = "name" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateFormRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Forms.<a href="/src/Auth0.ManagementApi/Forms/FormsClient.cs">GetAsync</a>(id, GetFormRequestParameters { ... }) -> WithRawResponseTask&lt;GetFormResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Forms.GetAsync("id", new GetFormRequestParameters());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The ID of the form to retrieve.
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetFormRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Forms.<a href="/src/Auth0.ManagementApi/Forms/FormsClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Forms.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The ID of the form to delete.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Forms.<a href="/src/Auth0.ManagementApi/Forms/FormsClient.cs">UpdateAsync</a>(id, UpdateFormRequestContent { ... }) -> WithRawResponseTask&lt;UpdateFormResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Forms.UpdateAsync("id", new UpdateFormRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The ID of the form to update.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateFormRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## UserGrants
<details><summary><code>client.UserGrants.<a href="/src/Auth0.ManagementApi/UserGrants/UserGrantsClient.cs">ListAsync</a>(ListUserGrantsRequestParameters { ... }) -> Pager&lt;UserGrant&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve the <a href="https://auth0.com/docs/api-auth/which-oauth-flow-to-use">grants</a> associated with your account. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.UserGrants.ListAsync(
    new ListUserGrantsRequestParameters
    {
        PerPage = 1,
        Page = 1,
        IncludeTotals = true,
        UserId = "user_id",
        ClientId = "client_id",
        Audience = "audience",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListUserGrantsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.UserGrants.<a href="/src/Auth0.ManagementApi/UserGrants/UserGrantsClient.cs">DeleteByUserIdAsync</a>(DeleteUserGrantByUserIdRequestParameters { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a grant associated with your account. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.UserGrants.DeleteByUserIdAsync(
    new DeleteUserGrantByUserIdRequestParameters { UserId = "user_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeleteUserGrantByUserIdRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.UserGrants.<a href="/src/Auth0.ManagementApi/UserGrants/UserGrantsClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a grant associated with your account. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.UserGrants.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the grant to delete.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Groups
<details><summary><code>client.Groups.<a href="/src/Auth0.ManagementApi/Groups/GroupsClient.cs">ListAsync</a>(ListGroupsRequestParameters { ... }) -> Pager&lt;Group&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List all groups in your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Groups.ListAsync(
    new ListGroupsRequestParameters
    {
        ConnectionId = "connection_id",
        Name = "name",
        ExternalId = "external_id",
        Fields = "fields",
        IncludeFields = true,
        From = "from",
        Take = 1,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListGroupsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Groups.<a href="/src/Auth0.ManagementApi/Groups/GroupsClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;GetGroupResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a group by its ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Groups.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Unique identifier for the group (service-generated).
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Groups.<a href="/src/Auth0.ManagementApi/Groups/GroupsClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a group by its ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Groups.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Unique identifier for the group (service-generated).
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Hooks
<details><summary><code>client.Hooks.<a href="/src/Auth0.ManagementApi/Hooks/HooksClient.cs">ListAsync</a>(ListHooksRequestParameters { ... }) -> Pager&lt;Hook&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all <a href="https://auth0.com/docs/hooks">hooks</a>. Accepts a list of fields to include or exclude in the result.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Hooks.ListAsync(
    new ListHooksRequestParameters
    {
        Page = 1,
        PerPage = 1,
        IncludeTotals = true,
        Enabled = true,
        Fields = "fields",
        TriggerId = HookTriggerIdEnum.CredentialsExchange,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListHooksRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Hooks.<a href="/src/Auth0.ManagementApi/Hooks/HooksClient.cs">CreateAsync</a>(CreateHookRequestContent { ... }) -> WithRawResponseTask&lt;CreateHookResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a new hook.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Hooks.CreateAsync(
    new CreateHookRequestContent
    {
        Name = "name",
        Script = "script",
        TriggerId = HookTriggerIdEnum.CredentialsExchange,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateHookRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Hooks.<a href="/src/Auth0.ManagementApi/Hooks/HooksClient.cs">GetAsync</a>(id, GetHookRequestParameters { ... }) -> WithRawResponseTask&lt;GetHookResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve <a href="https://auth0.com/docs/hooks">a hook</a> by its ID. Accepts a list of fields to include in the result.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Hooks.GetAsync("id", new GetHookRequestParameters { Fields = "fields" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the hook to retrieve.
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetHookRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Hooks.<a href="/src/Auth0.ManagementApi/Hooks/HooksClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a hook.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Hooks.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the hook to delete.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Hooks.<a href="/src/Auth0.ManagementApi/Hooks/HooksClient.cs">UpdateAsync</a>(id, UpdateHookRequestContent { ... }) -> WithRawResponseTask&lt;UpdateHookResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update an existing hook.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Hooks.UpdateAsync("id", new UpdateHookRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the hook to update.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateHookRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Jobs
<details><summary><code>client.Jobs.<a href="/src/Auth0.ManagementApi/Jobs/JobsClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;GetJobResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a job. Useful to check its status.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Jobs.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the job.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## LogStreams
<details><summary><code>client.LogStreams.<a href="/src/Auth0.ManagementApi/LogStreams/LogStreamsClient.cs">ListAsync</a>() -> WithRawResponseTask&lt;IEnumerable&lt;LogStreamResponseSchema&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details on [log streams](https://auth0.com/docs/logs/streams).

**Sample Response**

```json
[{
  "id": "string",
  "name": "string",
  "type": "eventbridge",
  "status": "active|paused|suspended",
  "sink": {
    "awsAccountId": "string",
    "awsRegion": "string",
    "awsPartnerEventSource": "string"
  }
}, {
  "id": "string",
  "name": "string",
  "type": "http",
  "status": "active|paused|suspended",
  "sink": {
    "httpContentFormat": "JSONLINES|JSONARRAY",
    "httpContentType": "string",
    "httpEndpoint": "string",
    "httpAuthorization": "string"
  }
},
{
  "id": "string",
  "name": "string",
  "type": "eventgrid",
  "status": "active|paused|suspended",
  "sink": {
    "azureSubscriptionId": "string",
    "azureResourceGroup": "string",
    "azureRegion": "string",
    "azurePartnerTopic": "string"
  }
},
{
  "id": "string",
  "name": "string",
  "type": "splunk",
  "status": "active|paused|suspended",
  "sink": {
    "splunkDomain": "string",
    "splunkToken": "string",
    "splunkPort": "string",
    "splunkSecure": "boolean"
  }
},
{
  "id": "string",
  "name": "string",
  "type": "sumo",
  "status": "active|paused|suspended",
  "sink": {
    "sumoSourceAddress": "string"
  }
},
{
  "id": "string",
  "name": "string",
  "type": "datadog",
  "status": "active|paused|suspended",
  "sink": {
    "datadogRegion": "string",
    "datadogApiKey": "string"
  }
}]
```
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.LogStreams.ListAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.LogStreams.<a href="/src/Auth0.ManagementApi/LogStreams/LogStreamsClient.cs">CreateAsync</a>(CreateLogStreamRequestContent { ... }) -> WithRawResponseTask&lt;CreateLogStreamResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a log stream.

**Log Stream Types**

The `type` of log stream being created determines the properties required in the `sink` payload.

**HTTP Stream**

For an `http` Stream, the `sink` properties are listed in the payload below.

**Request:**
```json
{
  "name": "string",
  "type": "http",
  "sink": {
    "httpEndpoint": "string",
    "httpContentType": "string",
    "httpContentFormat": "JSONLINES|JSONARRAY",
    "httpAuthorization": "string"
  }
}
```

**Response:**
```json
{
  "id": "string",
  "name": "string",
  "type": "http",
  "status": "active",
  "sink": {
    "httpEndpoint": "string",
    "httpContentType": "string",
    "httpContentFormat": "JSONLINES|JSONARRAY",
    "httpAuthorization": "string"
  }
}
```

**Amazon EventBridge Stream**

For an `eventbridge` Stream, the `sink` properties are listed in the payload below.

**Request:**
```json
{
  "name": "string",
  "type": "eventbridge",
  "sink": {
    "awsRegion": "string",
    "awsAccountId": "string"
  }
}
```

The response will include an additional field `awsPartnerEventSource` in the `sink`:

**Response:**
```json
{
  "id": "string",
  "name": "string",
  "type": "eventbridge",
  "status": "active",
  "sink": {
    "awsAccountId": "string",
    "awsRegion": "string",
    "awsPartnerEventSource": "string"
  }
}
```

**Azure Event Grid Stream**

For an `Azure Event Grid` Stream, the `sink` properties are listed in the payload below.

**Request:**
```json
{
  "name": "string",
  "type": "eventgrid",
  "sink": {
    "azureSubscriptionId": "string",
    "azureResourceGroup": "string",
    "azureRegion": "string"
  }
}
```

**Response:**
```json
{
  "id": "string",
  "name": "string",
  "type": "http",
  "status": "active",
  "sink": {
    "azureSubscriptionId": "string",
    "azureResourceGroup": "string",
    "azureRegion": "string",
    "azurePartnerTopic": "string"
  }
}
```

**Datadog Stream**

For a `Datadog` Stream, the `sink` properties are listed in the payload below.

**Request:**
```json
{
  "name": "string",
  "type": "datadog",
  "sink": {
    "datadogRegion": "string",
    "datadogApiKey": "string"
  }
}
```

**Response:**
```json
{
  "id": "string",
  "name": "string",
  "type": "datadog",
  "status": "active",
  "sink": {
    "datadogRegion": "string",
    "datadogApiKey": "string"
  }
}
```

**Splunk Stream**

For a `Splunk` Stream, the `sink` properties are listed in the payload below.

**Request:**
```json
{
  "name": "string",
  "type": "splunk",
  "sink": {
    "splunkDomain": "string",
    "splunkToken": "string",
    "splunkPort": "string",
    "splunkSecure": "boolean"
  }
}
```

**Response:**
```json
{
  "id": "string",
  "name": "string",
  "type": "splunk",
  "status": "active",
  "sink": {
    "splunkDomain": "string",
    "splunkToken": "string",
    "splunkPort": "string",
    "splunkSecure": "boolean"
  }
}
```

**Sumo Logic Stream**

For a `Sumo Logic` Stream, the `sink` properties are listed in the payload below.

**Request:**
```json
{
  "name": "string",
  "type": "sumo",
  "sink": {
    "sumoSourceAddress": "string"
  }
}
```

**Response:**
```json
{
  "id": "string",
  "name": "string",
  "type": "sumo",
  "status": "active",
  "sink": {
    "sumoSourceAddress": "string"
  }
}
```
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.LogStreams.CreateAsync(
    new CreateLogStreamHttpRequestBody
    {
        Type = LogStreamHttpEnum.Http,
        Sink = new LogStreamHttpSink { HttpEndpoint = "httpEndpoint" },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateLogStreamRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.LogStreams.<a href="/src/Auth0.ManagementApi/LogStreams/LogStreamsClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;GetLogStreamResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a log stream configuration and status.

**Sample responses**

**Amazon EventBridge Log Stream**

```json
{
  "id": "string",
  "name": "string",
  "type": "eventbridge",
  "status": "active|paused|suspended",
  "sink": {
    "awsAccountId": "string",
    "awsRegion": "string",
    "awsPartnerEventSource": "string"
  }
}
```

**HTTP Log Stream**

```json
{
  "id": "string",
  "name": "string",
  "type": "http",
  "status": "active|paused|suspended",
  "sink": {
    "httpContentFormat": "JSONLINES|JSONARRAY",
    "httpContentType": "string",
    "httpEndpoint": "string",
    "httpAuthorization": "string"
  }
}
```

**Datadog Log Stream**

```json
{
  "id": "string",
  "name": "string",
  "type": "datadog",
  "status": "active|paused|suspended",
  "sink": {
    "datadogRegion": "string",
    "datadogApiKey": "string"
  }
}
```

**Mixpanel**

**Request:**

```json
{
  "name": "string",
  "type": "mixpanel",
  "sink": {
    "mixpanelRegion": "string",
    "mixpanelProjectId": "string",
    "mixpanelServiceAccountUsername": "string",
    "mixpanelServiceAccountPassword": "string"
  }
}
```

**Response:**

```json
{
  "id": "string",
  "name": "string",
  "type": "mixpanel",
  "status": "active",
  "sink": {
    "mixpanelRegion": "string",
    "mixpanelProjectId": "string",
    "mixpanelServiceAccountUsername": "string",
    "mixpanelServiceAccountPassword": "string"
  }
}
```

**Segment**

**Request:**

```json
{
  "name": "string",
  "type": "segment",
  "sink": {
    "segmentWriteKey": "string"
  }
}
```

**Response:**

```json
{
  "id": "string",
  "name": "string",
  "type": "segment",
  "status": "active",
  "sink": {
    "segmentWriteKey": "string"
  }
}
```

**Splunk Log Stream**

```json
{
  "id": "string",
  "name": "string",
  "type": "splunk",
  "status": "active|paused|suspended",
  "sink": {
    "splunkDomain": "string",
    "splunkToken": "string",
    "splunkPort": "string",
    "splunkSecure": "boolean"
  }
}
```

**Sumo Logic Log Stream**

```json
{
  "id": "string",
  "name": "string",
  "type": "sumo",
  "status": "active|paused|suspended",
  "sink": {
    "sumoSourceAddress": "string"
  }
}
```

**Status**

The `status` of a log stream maybe any of the following:

1. `active` - Stream is currently enabled.
2. `paused` - Stream is currently user disabled and will not attempt log delivery.
3. `suspended` - Stream is currently disabled because of errors and will not attempt log delivery.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.LogStreams.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the log stream to get
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.LogStreams.<a href="/src/Auth0.ManagementApi/LogStreams/LogStreamsClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a log stream.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.LogStreams.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the log stream to delete
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.LogStreams.<a href="/src/Auth0.ManagementApi/LogStreams/LogStreamsClient.cs">UpdateAsync</a>(id, UpdateLogStreamRequestContent { ... }) -> WithRawResponseTask&lt;UpdateLogStreamResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update a log stream.

**Examples of how to use the PATCH endpoint.**

The following fields may be updated in a PATCH operation:

- name
- status
- sink

Note: For log streams of type `eventbridge` and `eventgrid`, updating the `sink` is not permitted.

**Update the status of a log stream**

```json
{
  "status": "active|paused"
}
```

**Update the name of a log stream**

```json
{
  "name": "string"
}
```

**Update the sink properties of a stream of type `http`**

```json
{
  "sink": {
    "httpEndpoint": "string",
    "httpContentType": "string",
    "httpContentFormat": "JSONARRAY|JSONLINES",
    "httpAuthorization": "string"
  }
}
```

**Update the sink properties of a stream of type `datadog`**

```json
{
  "sink": {
    "datadogRegion": "string",
    "datadogApiKey": "string"
  }
}
```

**Update the sink properties of a stream of type `splunk`**

```json
{
  "sink": {
    "splunkDomain": "string",
    "splunkToken": "string",
    "splunkPort": "string",
    "splunkSecure": "boolean"
  }
}
```

**Update the sink properties of a stream of type `sumo`**

```json
{
  "sink": {
    "sumoSourceAddress": "string"
  }
}
```
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.LogStreams.UpdateAsync("id", new UpdateLogStreamRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the log stream to get
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateLogStreamRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Logs
<details><summary><code>client.Logs.<a href="/src/Auth0.ManagementApi/Logs/LogsClient.cs">ListAsync</a>(ListLogsRequestParameters { ... }) -> Pager&lt;Log&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve log entries that match the specified search criteria (or all log entries if no criteria specified).

Set custom search criteria using the <code>q</code> parameter, or search from a specific log ID (<i>"search from checkpoint"</i>).

For more information on all possible event types, their respective acronyms, and descriptions, see <a href="https://auth0.com/docs/logs/log-event-type-codes">Log Event Type Codes</a>.

<h5>To set custom search criteria, use the following parameters:</h5>

<ul>
    <li><b>q:</b> Search Criteria using <a href="https://auth0.com/docs/logs/log-search-query-syntax">Query String Syntax</a></li>
    <li><b>page:</b> Page index of the results to return. First page is 0.</li>
    <li><b>per_page:</b> Number of results per page.</li>
    <li><b>sort:</b> Field to use for sorting appended with `:1` for ascending and `:-1` for descending. e.g. `date:-1`</li>
    <li><b>fields:</b> Comma-separated list of fields to include or exclude (depending on include_fields) from the result, empty to retrieve all fields.</li>
    <li><b>include_fields:</b> Whether specified fields are to be included (true) or excluded (false).</li>
    <li><b>include_totals:</b> Return results inside an object that contains the total result count (true) or as a direct array of results (false, default). <b>Deprecated:</b> this field is deprecated and should be removed from use. See <a href="https://auth0.com/docs/product-lifecycle/deprecations-and-migrations/migrate-to-tenant-log-search-v3#pagination">Search Engine V3 Breaking Changes</a></li>
</ul>

For more information on the list of fields that can be used in <code>fields</code> and <code>sort</code>, see <a href="https://auth0.com/docs/logs/log-search-query-syntax#searchable-fields">Searchable Fields</a>.

Auth0 <a href="https://auth0.com/docs/logs/retrieve-log-events-using-mgmt-api#limitations">limits the number of logs</a> you can return by search criteria to 100 logs per request. Furthermore, you may paginate only through 1,000 search results. If you exceed this threshold, please redefine your search or use the <a href="https://auth0.com/docs/logs/retrieve-log-events-using-mgmt-api#retrieve-logs-by-checkpoint">get logs by checkpoint method</a>.

<h5>To search from a checkpoint log ID, use the following parameters:</h5>
<ul>
    <li><b>from:</b> Log Event ID from which to start retrieving logs. You can limit the number of logs returned using the <code>take</code> parameter. If you use <code>from</code> at the same time as <code>q</code>, <code>from</code> takes precedence and <code>q</code> is ignored.</li>
    <li><b>take:</b> Number of entries to retrieve when using the <code>from</code> parameter.</li>
</ul>

<strong>Important:</strong> When fetching logs from a checkpoint log ID, any parameter other than <code>from</code> and <code>take</code> will be ignored, and date ordering is not guaranteed.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Logs.ListAsync(
    new ListLogsRequestParameters
    {
        Page = 1,
        PerPage = 1,
        Sort = "sort",
        Fields = "fields",
        IncludeFields = true,
        IncludeTotals = true,
        Search = "search",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListLogsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Logs.<a href="/src/Auth0.ManagementApi/Logs/LogsClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;GetLogResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve an individual log event.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Logs.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — log_id of the log to retrieve.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## NetworkAcls
<details><summary><code>client.NetworkAcls.<a href="/src/Auth0.ManagementApi/NetworkAcls/NetworkAclsClient.cs">ListAsync</a>(ListNetworkAclsRequestParameters { ... }) -> Pager&lt;NetworkAclsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get all access control list entries for your client.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.NetworkAcls.ListAsync(
    new ListNetworkAclsRequestParameters
    {
        Page = 1,
        PerPage = 1,
        IncludeTotals = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListNetworkAclsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.NetworkAcls.<a href="/src/Auth0.ManagementApi/NetworkAcls/NetworkAclsClient.cs">CreateAsync</a>(CreateNetworkAclRequestContent { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a new access control list for your client.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.NetworkAcls.CreateAsync(
    new CreateNetworkAclRequestContent
    {
        Description = "description",
        Active = true,
        Rule = new NetworkAclRule
        {
            Action = new NetworkAclAction(),
            Scope = NetworkAclRuleScopeEnum.Management,
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateNetworkAclRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.NetworkAcls.<a href="/src/Auth0.ManagementApi/NetworkAcls/NetworkAclsClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;GetNetworkAclsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get a specific access control list entry for your client.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.NetworkAcls.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the access control list to retrieve.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.NetworkAcls.<a href="/src/Auth0.ManagementApi/NetworkAcls/NetworkAclsClient.cs">SetAsync</a>(id, SetNetworkAclRequestContent { ... }) -> WithRawResponseTask&lt;SetNetworkAclsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update existing access control list for your client.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.NetworkAcls.SetAsync(
    "id",
    new SetNetworkAclRequestContent
    {
        Description = "description",
        Active = true,
        Rule = new NetworkAclRule
        {
            Action = new NetworkAclAction(),
            Scope = NetworkAclRuleScopeEnum.Management,
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the ACL to update.
    
</dd>
</dl>

<dl>
<dd>

**request:** `SetNetworkAclRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.NetworkAcls.<a href="/src/Auth0.ManagementApi/NetworkAcls/NetworkAclsClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete existing access control list for your client.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.NetworkAcls.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the ACL to delete
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.NetworkAcls.<a href="/src/Auth0.ManagementApi/NetworkAcls/NetworkAclsClient.cs">UpdateAsync</a>(id, UpdateNetworkAclRequestContent { ... }) -> WithRawResponseTask&lt;UpdateNetworkAclResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update existing access control list for your client.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.NetworkAcls.UpdateAsync("id", new UpdateNetworkAclRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the ACL to update.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateNetworkAclRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Organizations
<details><summary><code>client.Organizations.<a href="/src/Auth0.ManagementApi/Organizations/OrganizationsClient.cs">ListAsync</a>(ListOrganizationsRequestParameters { ... }) -> Pager&lt;Organization&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve detailed list of all Organizations available in your tenant. For more information, see Auth0 Organizations.

This endpoint supports two types of pagination:
<ul>
<li>Offset pagination</li>
<li>Checkpoint pagination</li>
</ul>

Checkpoint pagination must be used if you need to retrieve more than 1000 organizations.

<h2>Checkpoint Pagination</h2>

To search by checkpoint, use the following parameters:
<ul>
<li><code>from</code>: Optional id from which to start selection.</li>
<li><code>take</code>: The total number of entries to retrieve when using the <code>from</code> parameter. Defaults to 50.</li>
</ul>

<b>Note</b>: The first time you call this endpoint using checkpoint pagination, omit the <code>from</code> parameter. If there are more results, a <code>next</code> value is included in the response. You can use this for subsequent API calls. When <code>next</code> is no longer included in the response, no pages are remaining.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.ListAsync(
    new ListOrganizationsRequestParameters
    {
        From = "from",
        Take = 1,
        Sort = "sort",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListOrganizationsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.<a href="/src/Auth0.ManagementApi/Organizations/OrganizationsClient.cs">CreateAsync</a>(CreateOrganizationRequestContent { ... }) -> WithRawResponseTask&lt;CreateOrganizationResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a new Organization within your tenant.  To learn more about Organization settings, behavior, and configuration options, review <a href="https://auth0.com/docs/manage-users/organizations/create-first-organization">Create Your First Organization</a>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.CreateAsync(new CreateOrganizationRequestContent { Name = "name" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateOrganizationRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.<a href="/src/Auth0.ManagementApi/Organizations/OrganizationsClient.cs">GetByNameAsync</a>(name) -> WithRawResponseTask&lt;GetOrganizationByNameResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details about a single Organization specified by name.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.GetByNameAsync("name");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**name:** `string` — name of the organization to retrieve.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.<a href="/src/Auth0.ManagementApi/Organizations/OrganizationsClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;GetOrganizationResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details about a single Organization specified by ID. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the organization to retrieve.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.<a href="/src/Auth0.ManagementApi/Organizations/OrganizationsClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Remove an Organization from your tenant.  This action cannot be undone. 

<b>Note</b>: Members are automatically disassociated from an Organization when it is deleted. However, this action does <b>not</b> delete these users from your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Organization identifier.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.<a href="/src/Auth0.ManagementApi/Organizations/OrganizationsClient.cs">UpdateAsync</a>(id, UpdateOrganizationRequestContent { ... }) -> WithRawResponseTask&lt;UpdateOrganizationResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update the details of a specific <a href="https://auth0.com/docs/manage-users/organizations/configure-organizations/create-organizations">Organization</a>, such as name and display name, branding options, and metadata.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.UpdateAsync("id", new UpdateOrganizationRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the organization to update.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateOrganizationRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Prompts
<details><summary><code>client.Prompts.<a href="/src/Auth0.ManagementApi/Prompts/PromptsClient.cs">GetSettingsAsync</a>() -> WithRawResponseTask&lt;GetSettingsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details of the Universal Login configuration of your tenant. This includes the <a href="https://auth0.com/docs/authenticate/login/auth0-universal-login/identifier-first">Identifier First Authentication</a> and <a href="https://auth0.com/docs/secure/multi-factor-authentication/fido-authentication-with-webauthn/configure-webauthn-device-biometrics-for-mfa">WebAuthn with Device Biometrics for MFA</a> features.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Prompts.GetSettingsAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Prompts.<a href="/src/Auth0.ManagementApi/Prompts/PromptsClient.cs">UpdateSettingsAsync</a>(UpdateSettingsRequestContent { ... }) -> WithRawResponseTask&lt;UpdateSettingsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update the Universal Login configuration of your tenant. This includes the <a href="https://auth0.com/docs/authenticate/login/auth0-universal-login/identifier-first">Identifier First Authentication</a> and <a href="https://auth0.com/docs/secure/multi-factor-authentication/fido-authentication-with-webauthn/configure-webauthn-device-biometrics-for-mfa">WebAuthn with Device Biometrics for MFA</a> features.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Prompts.UpdateSettingsAsync(new UpdateSettingsRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateSettingsRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## RefreshTokens
<details><summary><code>client.RefreshTokens.<a href="/src/Auth0.ManagementApi/RefreshTokens/RefreshTokensClient.cs">ListAsync</a>(GetRefreshTokensRequestParameters { ... }) -> Pager&lt;RefreshTokenResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a paginated list of refresh tokens for a specific user, with optional filtering by client ID. Results are sorted by credential_id ascending.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.RefreshTokens.ListAsync(
    new GetRefreshTokensRequestParameters
    {
        UserId = "user_id",
        ClientId = "client_id",
        From = "from",
        Take = 1,
        Fields = "fields",
        IncludeFields = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetRefreshTokensRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.RefreshTokens.<a href="/src/Auth0.ManagementApi/RefreshTokens/RefreshTokensClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;GetRefreshTokenResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve refresh token information.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.RefreshTokens.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID refresh token to retrieve
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.RefreshTokens.<a href="/src/Auth0.ManagementApi/RefreshTokens/RefreshTokensClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a refresh token by its ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.RefreshTokens.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the refresh token to delete.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.RefreshTokens.<a href="/src/Auth0.ManagementApi/RefreshTokens/RefreshTokensClient.cs">UpdateAsync</a>(id, UpdateRefreshTokenRequestContent { ... }) -> WithRawResponseTask&lt;UpdateRefreshTokenResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update a refresh token by its ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.RefreshTokens.UpdateAsync("id", new UpdateRefreshTokenRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the refresh token to update.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateRefreshTokenRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## ResourceServers
<details><summary><code>client.ResourceServers.<a href="/src/Auth0.ManagementApi/ResourceServers/ResourceServersClient.cs">ListAsync</a>(ListResourceServerRequestParameters { ... }) -> Pager&lt;ResourceServer&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details of all APIs associated with your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ResourceServers.ListAsync(
    new ListResourceServerRequestParameters
    {
        Page = 1,
        PerPage = 1,
        IncludeTotals = true,
        IncludeFields = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListResourceServerRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.ResourceServers.<a href="/src/Auth0.ManagementApi/ResourceServers/ResourceServersClient.cs">CreateAsync</a>(CreateResourceServerRequestContent { ... }) -> WithRawResponseTask&lt;CreateResourceServerResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a new API associated with your tenant. Note that all new APIs must be registered with Auth0. For more information, read <a href="https://www.auth0.com/docs/get-started/apis"> APIs</a>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ResourceServers.CreateAsync(
    new CreateResourceServerRequestContent { Identifier = "identifier" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateResourceServerRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.ResourceServers.<a href="/src/Auth0.ManagementApi/ResourceServers/ResourceServersClient.cs">GetAsync</a>(id, GetResourceServerRequestParameters { ... }) -> WithRawResponseTask&lt;GetResourceServerResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve <a href="https://auth0.com/docs/apis">API</a> details with the given ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ResourceServers.GetAsync(
    "id",
    new GetResourceServerRequestParameters { IncludeFields = true }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID or audience of the resource server to retrieve.
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetResourceServerRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.ResourceServers.<a href="/src/Auth0.ManagementApi/ResourceServers/ResourceServersClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete an existing API by ID. For more information, read <a href="https://www.auth0.com/docs/get-started/apis/api-settings">API Settings</a>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ResourceServers.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID or the audience of the resource server to delete.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.ResourceServers.<a href="/src/Auth0.ManagementApi/ResourceServers/ResourceServersClient.cs">UpdateAsync</a>(id, UpdateResourceServerRequestContent { ... }) -> WithRawResponseTask&lt;UpdateResourceServerResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Change an existing API setting by resource server ID. For more information, read <a href="https://www.auth0.com/docs/get-started/apis/api-settings">API Settings</a>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ResourceServers.UpdateAsync("id", new UpdateResourceServerRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID or audience of the resource server to update.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateResourceServerRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Roles
<details><summary><code>client.Roles.<a href="/src/Auth0.ManagementApi/Roles/RolesClient.cs">ListAsync</a>(ListRolesRequestParameters { ... }) -> Pager&lt;Role&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve detailed list of user roles created in your tenant.

<b>Note</b>: The returned list does not include standard roles available for tenant members, such as Admin or Support Access.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Roles.ListAsync(
    new ListRolesRequestParameters
    {
        PerPage = 1,
        Page = 1,
        IncludeTotals = true,
        NameFilter = "name_filter",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListRolesRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Roles.<a href="/src/Auth0.ManagementApi/Roles/RolesClient.cs">CreateAsync</a>(CreateRoleRequestContent { ... }) -> WithRawResponseTask&lt;CreateRoleResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a user role for <a href="https://auth0.com/docs/manage-users/access-control/rbac">Role-Based Access Control</a>.

<b>Note</b>: New roles are not associated with any permissions by default. To assign existing permissions to your role, review Associate Permissions with a Role. To create new permissions, review Add API Permissions.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Roles.CreateAsync(new CreateRoleRequestContent { Name = "name" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateRoleRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Roles.<a href="/src/Auth0.ManagementApi/Roles/RolesClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;GetRoleResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details about a specific <a href="https://auth0.com/docs/manage-users/access-control/rbac">user role</a> specified by ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Roles.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the role to retrieve.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Roles.<a href="/src/Auth0.ManagementApi/Roles/RolesClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a specific <a href="https://auth0.com/docs/manage-users/access-control/rbac">user role</a> from your tenant. Once deleted, it is removed from any user who was previously assigned that role. This action cannot be undone.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Roles.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the role to delete.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Roles.<a href="/src/Auth0.ManagementApi/Roles/RolesClient.cs">UpdateAsync</a>(id, UpdateRoleRequestContent { ... }) -> WithRawResponseTask&lt;UpdateRoleResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Modify the details of a specific <a href="https://auth0.com/docs/manage-users/access-control/rbac">user role</a> specified by ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Roles.UpdateAsync("id", new UpdateRoleRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the role to update.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateRoleRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Rules
<details><summary><code>client.Rules.<a href="/src/Auth0.ManagementApi/Rules/RulesClient.cs">ListAsync</a>(ListRulesRequestParameters { ... }) -> Pager&lt;Rule&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a filtered list of <a href="https://auth0.com/docs/rules">rules</a>. Accepts a list of fields to include or exclude.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Rules.ListAsync(
    new ListRulesRequestParameters
    {
        Page = 1,
        PerPage = 1,
        IncludeTotals = true,
        Enabled = true,
        Fields = "fields",
        IncludeFields = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListRulesRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Rules.<a href="/src/Auth0.ManagementApi/Rules/RulesClient.cs">CreateAsync</a>(CreateRuleRequestContent { ... }) -> WithRawResponseTask&lt;CreateRuleResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a <a href="https://auth0.com/docs/rules#create-a-new-rule-using-the-management-api">new rule</a>.

Note: Changing a rule's stage of execution from the default <code>login_success</code> can change the rule's function signature to have user omitted.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Rules.CreateAsync(new CreateRuleRequestContent { Name = "name", Script = "script" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateRuleRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Rules.<a href="/src/Auth0.ManagementApi/Rules/RulesClient.cs">GetAsync</a>(id, GetRuleRequestParameters { ... }) -> WithRawResponseTask&lt;GetRuleResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve <a href="https://auth0.com/docs/rules">rule</a> details. Accepts a list of fields to include or exclude in the result.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Rules.GetAsync(
    "id",
    new GetRuleRequestParameters { Fields = "fields", IncludeFields = true }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the rule to retrieve.
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetRuleRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Rules.<a href="/src/Auth0.ManagementApi/Rules/RulesClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a rule.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Rules.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the rule to delete.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Rules.<a href="/src/Auth0.ManagementApi/Rules/RulesClient.cs">UpdateAsync</a>(id, UpdateRuleRequestContent { ... }) -> WithRawResponseTask&lt;UpdateRuleResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update an existing rule.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Rules.UpdateAsync("id", new UpdateRuleRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the rule to retrieve.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateRuleRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## RulesConfigs
<details><summary><code>client.RulesConfigs.<a href="/src/Auth0.ManagementApi/RulesConfigs/RulesConfigsClient.cs">ListAsync</a>() -> WithRawResponseTask&lt;IEnumerable&lt;RulesConfig&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve rules config variable keys.

    Note: For security, config variable values cannot be retrieved outside rule execution.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.RulesConfigs.ListAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.RulesConfigs.<a href="/src/Auth0.ManagementApi/RulesConfigs/RulesConfigsClient.cs">SetAsync</a>(key, SetRulesConfigRequestContent { ... }) -> WithRawResponseTask&lt;SetRulesConfigResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Sets a rules config variable.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.RulesConfigs.SetAsync("key", new SetRulesConfigRequestContent { Value = "value" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**key:** `string` — Key of the rules config variable to set (max length: 127 characters).
    
</dd>
</dl>

<dl>
<dd>

**request:** `SetRulesConfigRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.RulesConfigs.<a href="/src/Auth0.ManagementApi/RulesConfigs/RulesConfigsClient.cs">DeleteAsync</a>(key)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a rules config variable identified by its key.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.RulesConfigs.DeleteAsync("key");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**key:** `string` — Key of the rules config variable to delete.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## SelfServiceProfiles
<details><summary><code>client.SelfServiceProfiles.<a href="/src/Auth0.ManagementApi/SelfServiceProfiles/SelfServiceProfilesClient.cs">ListAsync</a>(ListSelfServiceProfilesRequestParameters { ... }) -> Pager&lt;SelfServiceProfile&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves self-service profiles.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SelfServiceProfiles.ListAsync(
    new ListSelfServiceProfilesRequestParameters
    {
        Page = 1,
        PerPage = 1,
        IncludeTotals = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListSelfServiceProfilesRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.SelfServiceProfiles.<a href="/src/Auth0.ManagementApi/SelfServiceProfiles/SelfServiceProfilesClient.cs">CreateAsync</a>(CreateSelfServiceProfileRequestContent { ... }) -> WithRawResponseTask&lt;CreateSelfServiceProfileResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a self-service profile.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SelfServiceProfiles.CreateAsync(
    new CreateSelfServiceProfileRequestContent { Name = "name" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateSelfServiceProfileRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.SelfServiceProfiles.<a href="/src/Auth0.ManagementApi/SelfServiceProfiles/SelfServiceProfilesClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;GetSelfServiceProfileResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a self-service profile by Id.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SelfServiceProfiles.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the self-service profile to retrieve
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.SelfServiceProfiles.<a href="/src/Auth0.ManagementApi/SelfServiceProfiles/SelfServiceProfilesClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a self-service profile by Id.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SelfServiceProfiles.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the self-service profile to delete
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.SelfServiceProfiles.<a href="/src/Auth0.ManagementApi/SelfServiceProfiles/SelfServiceProfilesClient.cs">UpdateAsync</a>(id, UpdateSelfServiceProfileRequestContent { ... }) -> WithRawResponseTask&lt;UpdateSelfServiceProfileResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates a self-service profile.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SelfServiceProfiles.UpdateAsync("id", new UpdateSelfServiceProfileRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the self-service profile to update
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateSelfServiceProfileRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Sessions
<details><summary><code>client.Sessions.<a href="/src/Auth0.ManagementApi/Sessions/SessionsClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;GetSessionResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve session information.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sessions.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of session to retrieve
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sessions.<a href="/src/Auth0.ManagementApi/Sessions/SessionsClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a session by ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sessions.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the session to delete.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sessions.<a href="/src/Auth0.ManagementApi/Sessions/SessionsClient.cs">UpdateAsync</a>(id, UpdateSessionRequestContent { ... }) -> WithRawResponseTask&lt;UpdateSessionResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update session information.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sessions.UpdateAsync("id", new UpdateSessionRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the session to update.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateSessionRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sessions.<a href="/src/Auth0.ManagementApi/Sessions/SessionsClient.cs">RevokeAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Revokes a session by ID and all associated refresh tokens.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sessions.RevokeAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the session to revoke.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Stats
<details><summary><code>client.Stats.<a href="/src/Auth0.ManagementApi/Stats/StatsClient.cs">GetActiveUsersCountAsync</a>() -> WithRawResponseTask&lt;double&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve the number of active users that logged in during the last 30 days.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Stats.GetActiveUsersCountAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Stats.<a href="/src/Auth0.ManagementApi/Stats/StatsClient.cs">GetDailyAsync</a>(GetDailyStatsRequestParameters { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;DailyStats&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve the number of logins, signups and breached-password detections (subscription required) that occurred each day within a specified date range.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Stats.GetDailyAsync(new GetDailyStatsRequestParameters { From = "from", To = "to" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetDailyStatsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## SupplementalSignals
<details><summary><code>client.SupplementalSignals.<a href="/src/Auth0.ManagementApi/SupplementalSignals/SupplementalSignalsClient.cs">GetAsync</a>() -> WithRawResponseTask&lt;GetSupplementalSignalsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get the supplemental signals configuration for a tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SupplementalSignals.GetAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.SupplementalSignals.<a href="/src/Auth0.ManagementApi/SupplementalSignals/SupplementalSignalsClient.cs">PatchAsync</a>(UpdateSupplementalSignalsRequestContent { ... }) -> WithRawResponseTask&lt;PatchSupplementalSignalsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update the supplemental signals configuration for a tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SupplementalSignals.PatchAsync(
    new UpdateSupplementalSignalsRequestContent { AkamaiEnabled = true }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateSupplementalSignalsRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Tickets
<details><summary><code>client.Tickets.<a href="/src/Auth0.ManagementApi/Tickets/TicketsClient.cs">VerifyEmailAsync</a>(VerifyEmailTicketRequestContent { ... }) -> WithRawResponseTask&lt;VerifyEmailTicketResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create an email verification ticket for a given user. An email verification ticket is a generated URL that the user can consume to verify their email address.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Tickets.VerifyEmailAsync(new VerifyEmailTicketRequestContent { UserId = "user_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `VerifyEmailTicketRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Tickets.<a href="/src/Auth0.ManagementApi/Tickets/TicketsClient.cs">ChangePasswordAsync</a>(ChangePasswordTicketRequestContent { ... }) -> WithRawResponseTask&lt;ChangePasswordTicketResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a password change ticket for a given user. A password change ticket is a generated URL that the user can consume to start a reset password flow.

Note: This endpoint does not verify the given user’s identity. If you call this endpoint within your application, you must design your application to verify the user’s identity.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Tickets.ChangePasswordAsync(new ChangePasswordTicketRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ChangePasswordTicketRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## TokenExchangeProfiles
<details><summary><code>client.TokenExchangeProfiles.<a href="/src/Auth0.ManagementApi/TokenExchangeProfiles/TokenExchangeProfilesClient.cs">ListAsync</a>(TokenExchangeProfilesListRequest { ... }) -> Pager&lt;TokenExchangeProfileResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of all Token Exchange Profiles available in your tenant.

By using this feature, you agree to the applicable Free Trial terms in <a href="https://www.okta.com/legal/">Okta’s Master Subscription Agreement</a>. It is your responsibility to securely validate the user’s subject_token. See <a href="https://auth0.com/docs/authenticate/custom-token-exchange">User Guide</a> for more details.

This endpoint supports Checkpoint pagination. To search by checkpoint, use the following parameters:
<ul>
<li><code>from</code>: Optional id from which to start selection.</li>
<li><code>take</code>: The total amount of entries to retrieve when using the from parameter. Defaults to 50.</li>
</ul>

<b>Note</b>: The first time you call this endpoint using checkpoint pagination, omit the <code>from</code> parameter. If there are more results, a <code>next</code> value is included in the response. You can use this for subsequent API calls. When <code>next</code> is no longer included in the response, no pages are remaining.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.TokenExchangeProfiles.ListAsync(
    new TokenExchangeProfilesListRequest { From = "from", Take = 1 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `TokenExchangeProfilesListRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.TokenExchangeProfiles.<a href="/src/Auth0.ManagementApi/TokenExchangeProfiles/TokenExchangeProfilesClient.cs">CreateAsync</a>(CreateTokenExchangeProfileRequestContent { ... }) -> WithRawResponseTask&lt;CreateTokenExchangeProfileResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a new Token Exchange Profile within your tenant.

By using this feature, you agree to the applicable Free Trial terms in <a href="https://www.okta.com/legal/">Okta’s Master Subscription Agreement</a>. It is your responsibility to securely validate the user’s subject_token. See <a href="https://auth0.com/docs/authenticate/custom-token-exchange">User Guide</a> for more details.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.TokenExchangeProfiles.CreateAsync(
    new CreateTokenExchangeProfileRequestContent
    {
        Name = "name",
        SubjectTokenType = "subject_token_type",
        ActionId = "action_id",
        Type = TokenExchangeProfileTypeEnum.CustomAuthentication,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateTokenExchangeProfileRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.TokenExchangeProfiles.<a href="/src/Auth0.ManagementApi/TokenExchangeProfiles/TokenExchangeProfilesClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;GetTokenExchangeProfileResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details about a single Token Exchange Profile specified by ID.

By using this feature, you agree to the applicable Free Trial terms in <a href="https://www.okta.com/legal/">Okta’s Master Subscription Agreement</a>. It is your responsibility to securely validate the user’s subject_token. See <a href="https://auth0.com/docs/authenticate/custom-token-exchange">User Guide</a> for more details.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.TokenExchangeProfiles.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the Token Exchange Profile to retrieve.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.TokenExchangeProfiles.<a href="/src/Auth0.ManagementApi/TokenExchangeProfiles/TokenExchangeProfilesClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a Token Exchange Profile within your tenant.

By using this feature, you agree to the applicable Free Trial terms in <a href="https://www.okta.com/legal/">Okta's Master Subscription Agreement</a>. It is your responsibility to securely validate the user's subject_token. See <a href="https://auth0.com/docs/authenticate/custom-token-exchange">User Guide</a> for more details.

</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.TokenExchangeProfiles.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the Token Exchange Profile to delete.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.TokenExchangeProfiles.<a href="/src/Auth0.ManagementApi/TokenExchangeProfiles/TokenExchangeProfilesClient.cs">UpdateAsync</a>(id, UpdateTokenExchangeProfileRequestContent { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update a Token Exchange Profile within your tenant.

By using this feature, you agree to the applicable Free Trial terms in <a href="https://www.okta.com/legal/">Okta's Master Subscription Agreement</a>. It is your responsibility to securely validate the user's subject_token. See <a href="https://auth0.com/docs/authenticate/custom-token-exchange">User Guide</a> for more details.

</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.TokenExchangeProfiles.UpdateAsync(
    "id",
    new UpdateTokenExchangeProfileRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the Token Exchange Profile to update.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateTokenExchangeProfileRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## UserAttributeProfiles
<details><summary><code>client.UserAttributeProfiles.<a href="/src/Auth0.ManagementApi/UserAttributeProfiles/UserAttributeProfilesClient.cs">ListAsync</a>(ListUserAttributeProfileRequestParameters { ... }) -> Pager&lt;UserAttributeProfile&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of User Attribute Profiles. This endpoint supports Checkpoint pagination.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.UserAttributeProfiles.ListAsync(
    new ListUserAttributeProfileRequestParameters { From = "from", Take = 1 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListUserAttributeProfileRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.UserAttributeProfiles.<a href="/src/Auth0.ManagementApi/UserAttributeProfiles/UserAttributeProfilesClient.cs">CreateAsync</a>(CreateUserAttributeProfileRequestContent { ... }) -> WithRawResponseTask&lt;CreateUserAttributeProfileResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details about a single User Attribute Profile specified by ID. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.UserAttributeProfiles.CreateAsync(
    new CreateUserAttributeProfileRequestContent
    {
        Name = "name",
        UserAttributes = new Dictionary<
            string,
            UserAttributeProfileUserAttributeAdditionalProperties
        >()
        {
            {
                "key",
                new UserAttributeProfileUserAttributeAdditionalProperties
                {
                    Description = "description",
                    Label = "label",
                    ProfileRequired = true,
                    Auth0Mapping = "auth0_mapping",
                }
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateUserAttributeProfileRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.UserAttributeProfiles.<a href="/src/Auth0.ManagementApi/UserAttributeProfiles/UserAttributeProfilesClient.cs">ListTemplatesAsync</a>() -> WithRawResponseTask&lt;ListUserAttributeProfileTemplateResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of User Attribute Profile Templates.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.UserAttributeProfiles.ListTemplatesAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.UserAttributeProfiles.<a href="/src/Auth0.ManagementApi/UserAttributeProfiles/UserAttributeProfilesClient.cs">GetTemplateAsync</a>(id) -> WithRawResponseTask&lt;GetUserAttributeProfileTemplateResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a User Attribute Profile Template.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.UserAttributeProfiles.GetTemplateAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the user-attribute-profile-template to retrieve.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.UserAttributeProfiles.<a href="/src/Auth0.ManagementApi/UserAttributeProfiles/UserAttributeProfilesClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;GetUserAttributeProfileResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details about a single User Attribute Profile specified by ID. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.UserAttributeProfiles.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the user-attribute-profile to retrieve.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.UserAttributeProfiles.<a href="/src/Auth0.ManagementApi/UserAttributeProfiles/UserAttributeProfilesClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a single User Attribute Profile specified by ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.UserAttributeProfiles.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the user-attribute-profile to delete.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.UserAttributeProfiles.<a href="/src/Auth0.ManagementApi/UserAttributeProfiles/UserAttributeProfilesClient.cs">UpdateAsync</a>(id, UpdateUserAttributeProfileRequestContent { ... }) -> WithRawResponseTask&lt;UpdateUserAttributeProfileResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update the details of a specific User attribute profile, such as name, user_id and user_attributes.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.UserAttributeProfiles.UpdateAsync(
    "id",
    new UpdateUserAttributeProfileRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the user attribute profile to update.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateUserAttributeProfileRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## UserBlocks
<details><summary><code>client.UserBlocks.<a href="/src/Auth0.ManagementApi/UserBlocks/UserBlocksClient.cs">ListByIdentifierAsync</a>(ListUserBlocksByIdentifierRequestParameters { ... }) -> WithRawResponseTask&lt;ListUserBlocksByIdentifierResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details of all <a href="https://auth0.com/docs/secure/attack-protection/brute-force-protection">Brute-force Protection</a> blocks for a user with the given identifier (username, phone number, or email).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.UserBlocks.ListByIdentifierAsync(
    new ListUserBlocksByIdentifierRequestParameters
    {
        Identifier = "identifier",
        ConsiderBruteForceEnablement = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListUserBlocksByIdentifierRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.UserBlocks.<a href="/src/Auth0.ManagementApi/UserBlocks/UserBlocksClient.cs">DeleteByIdentifierAsync</a>(DeleteUserBlocksByIdentifierRequestParameters { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Remove all <a href="https://auth0.com/docs/secure/attack-protection/brute-force-protection">Brute-force Protection</a> blocks for the user with the given identifier (username, phone number, or email).

Note: This endpoint does not unblock users that were <a href="https://auth0.com/docs/user-profile#block-and-unblock-a-user">blocked by a tenant administrator</a>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.UserBlocks.DeleteByIdentifierAsync(
    new DeleteUserBlocksByIdentifierRequestParameters { Identifier = "identifier" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeleteUserBlocksByIdentifierRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.UserBlocks.<a href="/src/Auth0.ManagementApi/UserBlocks/UserBlocksClient.cs">ListAsync</a>(id, ListUserBlocksRequestParameters { ... }) -> WithRawResponseTask&lt;ListUserBlocksResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details of all <a href="https://auth0.com/docs/secure/attack-protection/brute-force-protection">Brute-force Protection</a> blocks for the user with the given ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.UserBlocks.ListAsync(
    "id",
    new ListUserBlocksRequestParameters { ConsiderBruteForceEnablement = true }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — user_id of the user blocks to retrieve.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListUserBlocksRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.UserBlocks.<a href="/src/Auth0.ManagementApi/UserBlocks/UserBlocksClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Remove all <a href="https://auth0.com/docs/secure/attack-protection/brute-force-protection">Brute-force Protection</a> blocks for the user with the given ID.

Note: This endpoint does not unblock users that were <a href="https://auth0.com/docs/user-profile#block-and-unblock-a-user">blocked by a tenant administrator</a>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.UserBlocks.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The user_id of the user to update.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Users
<details><summary><code>client.Users.<a href="/src/Auth0.ManagementApi/Users/UsersClient.cs">ListAsync</a>(ListUsersRequestParameters { ... }) -> Pager&lt;UserResponseSchema&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details of users. It is possible to:

- Specify a search criteria for users
- Sort the users to be returned
- Select the fields to be returned
- Specify the number of users to retrieve per page and the page index
 <!-- only v3 is available -->
The <code>q</code> query parameter can be used to get users that match the specified criteria <a href="https://auth0.com/docs/users/search/v3/query-syntax">using query string syntax.</a>

<a href="https://auth0.com/docs/users/search/v3">Learn more about searching for users.</a>

Read about <a href="https://auth0.com/docs/users/search/best-practices">best practices</a> when working with the API endpoints for retrieving users.

Auth0 limits the number of users you can return. If you exceed this threshold, please redefine your search, use the <a href="https://auth0.com/docs/api/management/v2#!/Jobs/post_users_exports">export job</a>, or the <a href="https://auth0.com/docs/extensions/user-import-export">User Import / Export</a> extension.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.ListAsync(
    new ListUsersRequestParameters
    {
        Page = 1,
        PerPage = 1,
        IncludeTotals = true,
        Sort = "sort",
        Connection = "connection",
        Fields = "fields",
        IncludeFields = true,
        Q = "q",
        SearchEngine = SearchEngineVersionsEnum.V1,
        PrimaryOrder = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListUsersRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.<a href="/src/Auth0.ManagementApi/Users/UsersClient.cs">CreateAsync</a>(CreateUserRequestContent { ... }) -> WithRawResponseTask&lt;CreateUserResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a new user for a given <a href="https://auth0.com/docs/connections/database">database</a> or <a href="https://auth0.com/docs/connections/passwordless">passwordless</a> connection.

Note: <code>connection</code> is required but other parameters such as <code>email</code> and <code>password</code> are dependent upon the type of connection.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.CreateAsync(new CreateUserRequestContent { Connection = "connection" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateUserRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.<a href="/src/Auth0.ManagementApi/Users/UsersClient.cs">ListUsersByEmailAsync</a>(ListUsersByEmailRequestParameters { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;UserResponseSchema&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Find users by email. If Auth0 is the identity provider (idP), the email address associated with a user is saved in lower case, regardless of how you initially provided it. 

For example, if you register a user as JohnSmith@example.com, Auth0 saves the user's email as johnsmith@example.com. 

Therefore, when using this endpoint, make sure that you are searching for users via email addresses using the correct case.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.ListUsersByEmailAsync(
    new ListUsersByEmailRequestParameters
    {
        Fields = "fields",
        IncludeFields = true,
        Email = "email",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListUsersByEmailRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.<a href="/src/Auth0.ManagementApi/Users/UsersClient.cs">GetAsync</a>(id, GetUserRequestParameters { ... }) -> WithRawResponseTask&lt;GetUserResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve user details. A list of fields to include or exclude may also be specified. For more information, see <a href="https://auth0.com/docs/manage-users/user-search/retrieve-users-with-get-users-endpoint">Retrieve Users with the Get Users Endpoint</a>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.GetAsync(
    "id",
    new GetUserRequestParameters { Fields = "fields", IncludeFields = true }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the user to retrieve.
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetUserRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.<a href="/src/Auth0.ManagementApi/Users/UsersClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a user by user ID. This action cannot be undone. For Auth0 Dashboard instructions, see <a href="https://auth0.com/docs/manage-users/user-accounts/delete-users">Delete Users</a>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the user to delete.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.<a href="/src/Auth0.ManagementApi/Users/UsersClient.cs">UpdateAsync</a>(id, UpdateUserRequestContent { ... }) -> WithRawResponseTask&lt;UpdateUserResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update a user.

These are the attributes that can be updated at the root level:

<ul>
    <li>app_metadata</li>
    <li>blocked</li>
    <li>email</li>
    <li>email_verified</li>
    <li>family_name</li>
    <li>given_name</li>
    <li>name</li>
    <li>nickname</li>
    <li>password</li>
    <li>phone_number</li>
    <li>phone_verified</li>
    <li>picture</li>
    <li>username</li>
    <li>user_metadata</li>
    <li>verify_email</li>
</ul>

Some considerations:
<ul>
    <li>The properties of the new object will replace the old ones.</li>
    <li>The metadata fields are an exception to this rule (<code>user_metadata</code> and <code>app_metadata</code>). These properties are merged instead of being replaced but be careful, the merge only occurs on the first level.</li>
    <li>If you are updating <code>email</code>, <code>email_verified</code>, <code>phone_number</code>, <code>phone_verified</code>, <code>username</code> or <code>password</code> of a secondary identity, you need to specify the <code>connection</code> property too.</li>
    <li>If you are updating <code>email</code> or <code>phone_number</code> you can specify, optionally, the <code>client_id</code> property.</li>
    <li>Updating <code>email_verified</code> is not supported for enterprise and passwordless sms connections.</li>
    <li>Updating the <code>blocked</code> to <code>false</code> does not affect the user's blocked state from an excessive amount of incorrectly provided credentials. Use the "Unblock a user" endpoint from the "User Blocks" API to change the user's state.</li>
    <li>Supported attributes can be unset by supplying <code>null</code> as the value.</li>
</ul>

<h5>Updating a field (non-metadata property)</h5>
To mark the email address of a user as verified, the body to send should be:
<pre><code>{ "email_verified": true }</code></pre>

<h5>Updating a user metadata root property</h5>Let's assume that our test user has the following <code>user_metadata</code>:
<pre><code>{ "user_metadata" : { "profileCode": 1479 } }</code></pre>

To add the field <code>addresses</code> the body to send should be:
<pre><code>{ "user_metadata" : { "addresses": {"work_address": "100 Industrial Way"} }}</code></pre>

The modified object ends up with the following <code>user_metadata</code> property:<pre><code>{
  "user_metadata": {
    "profileCode": 1479,
    "addresses": { "work_address": "100 Industrial Way" }
  }
}</code></pre>

<h5>Updating an inner user metadata property</h5>If there's existing user metadata to which we want to add  <code>"home_address": "742 Evergreen Terrace"</code> (using the <code>addresses</code> property) we should send the whole <code>addresses</code> object. Since this is a first-level object, the object will be merged in, but its own properties will not be. The body to send should be:
<pre><code>{
  "user_metadata": {
    "addresses": {
      "work_address": "100 Industrial Way",
      "home_address": "742 Evergreen Terrace"
    }
  }
}</code></pre>

The modified object ends up with the following <code>user_metadata</code> property:
<pre><code>{
  "user_metadata": {
    "profileCode": 1479,
    "addresses": {
      "work_address": "100 Industrial Way",
      "home_address": "742 Evergreen Terrace"
    }
  }
}</code></pre>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.UpdateAsync("id", new UpdateUserRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the user to update.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateUserRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.<a href="/src/Auth0.ManagementApi/Users/UsersClient.cs">RegenerateRecoveryCodeAsync</a>(id) -> WithRawResponseTask&lt;RegenerateUsersRecoveryCodeResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Remove an existing multi-factor authentication (MFA) <a href="https://auth0.com/docs/secure/multi-factor-authentication/reset-user-mfa">recovery code</a> and generate a new one. If a user cannot access the original device or account used for MFA enrollment, they can use a recovery code to authenticate. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.RegenerateRecoveryCodeAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the user to regenerate a multi-factor authentication recovery code for.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.<a href="/src/Auth0.ManagementApi/Users/UsersClient.cs">RevokeAccessAsync</a>(id, RevokeUserAccessRequestContent { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Revokes selected resources related to a user (sessions, refresh tokens, ...).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.RevokeAccessAsync("id", new RevokeUserAccessRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the user.
    
</dd>
</dl>

<dl>
<dd>

**request:** `RevokeUserAccessRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Actions Versions
<details><summary><code>client.Actions.Versions.<a href="/src/Auth0.ManagementApi/Actions/Versions/VersionsClient.cs">ListAsync</a>(actionId, ListActionVersionsRequestParameters { ... }) -> Pager&lt;ActionVersion&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all of an action's versions. An action version is created whenever an action is deployed. An action version is immutable, once created.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.Versions.ListAsync(
    "actionId",
    new ListActionVersionsRequestParameters { Page = 1, PerPage = 1 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**actionId:** `string` — The ID of the action.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListActionVersionsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Actions.Versions.<a href="/src/Auth0.ManagementApi/Actions/Versions/VersionsClient.cs">GetAsync</a>(actionId, id) -> WithRawResponseTask&lt;GetActionVersionResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a specific version of an action. An action version is created whenever an action is deployed. An action version is immutable, once created.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.Versions.GetAsync("actionId", "id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**actionId:** `string` — The ID of the action.
    
</dd>
</dl>

<dl>
<dd>

**id:** `string` — The ID of the action version.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Actions.Versions.<a href="/src/Auth0.ManagementApi/Actions/Versions/VersionsClient.cs">DeployAsync</a>(actionId, id, Optional&lt;DeployActionVersionRequestContent?&gt; { ... }) -> WithRawResponseTask&lt;DeployActionVersionResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Performs the equivalent of a roll-back of an action to an earlier, specified version. Creates a new, deployed action version that is identical to the specified version. If this action is currently bound to a trigger, the system will begin executing the newly-created version immediately.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.Versions.DeployAsync(
    "actionId",
    "id",
    new DeployActionVersionRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**actionId:** `string` — The ID of an action.
    
</dd>
</dl>

<dl>
<dd>

**id:** `string` — The ID of an action version.
    
</dd>
</dl>

<dl>
<dd>

**request:** `Optional<DeployActionVersionRequestContent?>` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Actions Executions
<details><summary><code>client.Actions.Executions.<a href="/src/Auth0.ManagementApi/Actions/Executions/ExecutionsClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;GetActionExecutionResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve information about a specific execution of a trigger. Relevant execution IDs will be included in tenant logs generated as part of that authentication flow. Executions will only be stored for 10 days after their creation.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.Executions.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The ID of the execution to retrieve.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Actions Modules
<details><summary><code>client.Actions.Modules.<a href="/src/Auth0.ManagementApi/Actions/Modules/ModulesClient.cs">ListAsync</a>(GetActionModulesRequestParameters { ... }) -> Pager&lt;ActionModuleListItem&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a paginated list of all Actions Modules with optional filtering and totals.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.Modules.ListAsync(
    new GetActionModulesRequestParameters { Page = 1, PerPage = 1 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetActionModulesRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Actions.Modules.<a href="/src/Auth0.ManagementApi/Actions/Modules/ModulesClient.cs">CreateAsync</a>(CreateActionModuleRequestContent { ... }) -> WithRawResponseTask&lt;CreateActionModuleResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a new Actions Module for reusable code across actions.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.Modules.CreateAsync(
    new CreateActionModuleRequestContent { Name = "name", Code = "code" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateActionModuleRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Actions.Modules.<a href="/src/Auth0.ManagementApi/Actions/Modules/ModulesClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;GetActionModuleResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details of a specific Actions Module by its unique identifier.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.Modules.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The ID of the action module to retrieve.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Actions.Modules.<a href="/src/Auth0.ManagementApi/Actions/Modules/ModulesClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Permanently delete an Actions Module. This will fail if the module is still in use by any actions.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.Modules.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The ID of the Actions Module to delete.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Actions.Modules.<a href="/src/Auth0.ManagementApi/Actions/Modules/ModulesClient.cs">UpdateAsync</a>(id, UpdateActionModuleRequestContent { ... }) -> WithRawResponseTask&lt;UpdateActionModuleResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update properties of an existing Actions Module, such as code, dependencies, or secrets.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.Modules.UpdateAsync("id", new UpdateActionModuleRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The ID of the action module to update.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateActionModuleRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Actions.Modules.<a href="/src/Auth0.ManagementApi/Actions/Modules/ModulesClient.cs">ListActionsAsync</a>(id, GetActionModuleActionsRequestParameters { ... }) -> Pager&lt;ActionModuleAction&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Lists all actions that are using a specific Actions Module, showing which deployed action versions reference this Actions Module.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.Modules.ListActionsAsync(
    "id",
    new GetActionModuleActionsRequestParameters { Page = 1, PerPage = 1 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The unique ID of the module.
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetActionModuleActionsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Actions.Modules.<a href="/src/Auth0.ManagementApi/Actions/Modules/ModulesClient.cs">RollbackAsync</a>(id, RollbackActionModuleRequestParameters { ... }) -> WithRawResponseTask&lt;RollbackActionModuleResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Rolls back an Actions Module's draft to a previously created version. This action copies the code, dependencies, and secrets from the specified version into the current draft.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.Modules.RollbackAsync(
    "id",
    new RollbackActionModuleRequestParameters { ModuleVersionId = "module_version_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The unique ID of the module to roll back.
    
</dd>
</dl>

<dl>
<dd>

**request:** `RollbackActionModuleRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Actions Triggers
<details><summary><code>client.Actions.Triggers.<a href="/src/Auth0.ManagementApi/Actions/Triggers/TriggersClient.cs">ListAsync</a>() -> WithRawResponseTask&lt;ListActionTriggersResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve the set of triggers currently available within actions. A trigger is an extensibility point to which actions can be bound.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.Triggers.ListAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Actions Modules Versions
<details><summary><code>client.Actions.Modules.Versions.<a href="/src/Auth0.ManagementApi/Actions/Modules/Versions/VersionsClient.cs">ListAsync</a>(id, GetActionModuleVersionsRequestParameters { ... }) -> Pager&lt;ActionModuleVersion&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List all published versions of a specific Actions Module.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.Modules.Versions.ListAsync(
    "id",
    new GetActionModuleVersionsRequestParameters { Page = 1, PerPage = 1 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The unique ID of the module.
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetActionModuleVersionsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Actions.Modules.Versions.<a href="/src/Auth0.ManagementApi/Actions/Modules/Versions/VersionsClient.cs">CreateAsync</a>(id) -> WithRawResponseTask&lt;CreateActionModuleVersionResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a new immutable version of an Actions Module from the current draft version. This publishes the draft as a new version that can be referenced by actions, while maintaining the existing draft for continued development.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.Modules.Versions.CreateAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The ID of the action module to create a version for.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Actions.Modules.Versions.<a href="/src/Auth0.ManagementApi/Actions/Modules/Versions/VersionsClient.cs">GetAsync</a>(id, versionId) -> WithRawResponseTask&lt;GetActionModuleVersionResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve the details of a specific, immutable version of an Actions Module.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.Modules.Versions.GetAsync("id", "versionId");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The unique ID of the module.
    
</dd>
</dl>

<dl>
<dd>

**versionId:** `string` — The unique ID of the module version to retrieve.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Actions Triggers Bindings
<details><summary><code>client.Actions.Triggers.Bindings.<a href="/src/Auth0.ManagementApi/Actions/Triggers/Bindings/BindingsClient.cs">ListAsync</a>(triggerId, ListActionTriggerBindingsRequestParameters { ... }) -> Pager&lt;ActionBinding&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve the actions that are bound to a trigger. Once an action is created and deployed, it must be attached (i.e. bound) to a trigger so that it will be executed as part of a flow. The list of actions returned reflects the order in which they will be executed during the appropriate flow.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.Triggers.Bindings.ListAsync(
    ActionTriggerTypeEnum.PostLogin,
    new ListActionTriggerBindingsRequestParameters { Page = 1, PerPage = 1 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**triggerId:** `ActionTriggerTypeEnum` — An actions extensibility point.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListActionTriggerBindingsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Actions.Triggers.Bindings.<a href="/src/Auth0.ManagementApi/Actions/Triggers/Bindings/BindingsClient.cs">UpdateManyAsync</a>(triggerId, UpdateActionBindingsRequestContent { ... }) -> WithRawResponseTask&lt;UpdateActionBindingsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update the actions that are bound (i.e. attached) to a trigger. Once an action is created and deployed, it must be attached (i.e. bound) to a trigger so that it will be executed as part of a flow. The order in which the actions are provided will determine the order in which they are executed.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Actions.Triggers.Bindings.UpdateManyAsync(
    ActionTriggerTypeEnum.PostLogin,
    new UpdateActionBindingsRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**triggerId:** `ActionTriggerTypeEnum` — An actions extensibility point.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateActionBindingsRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Anomaly Blocks
<details><summary><code>client.Anomaly.Blocks.<a href="/src/Auth0.ManagementApi/Anomaly/Blocks/BlocksClient.cs">CheckIpAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Check if the given IP address is blocked via the <a href="https://auth0.com/docs/configure/attack-protection/suspicious-ip-throttling">Suspicious IP Throttling</a> due to multiple suspicious attempts.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Anomaly.Blocks.CheckIpAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — IP address to check.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Anomaly.Blocks.<a href="/src/Auth0.ManagementApi/Anomaly/Blocks/BlocksClient.cs">UnblockIpAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Remove a block imposed by <a href="https://auth0.com/docs/configure/attack-protection/suspicious-ip-throttling">Suspicious IP Throttling</a> for the given IP address.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Anomaly.Blocks.UnblockIpAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — IP address to unblock.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## AttackProtection BotDetection
<details><summary><code>client.AttackProtection.BotDetection.<a href="/src/Auth0.ManagementApi/AttackProtection/BotDetection/BotDetectionClient.cs">GetAsync</a>() -> WithRawResponseTask&lt;GetBotDetectionSettingsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get the Bot Detection configuration of your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AttackProtection.BotDetection.GetAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.AttackProtection.BotDetection.<a href="/src/Auth0.ManagementApi/AttackProtection/BotDetection/BotDetectionClient.cs">UpdateAsync</a>(UpdateBotDetectionSettingsRequestContent { ... }) -> WithRawResponseTask&lt;UpdateBotDetectionSettingsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update the Bot Detection configuration of your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AttackProtection.BotDetection.UpdateAsync(
    new UpdateBotDetectionSettingsRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateBotDetectionSettingsRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## AttackProtection BreachedPasswordDetection
<details><summary><code>client.AttackProtection.BreachedPasswordDetection.<a href="/src/Auth0.ManagementApi/AttackProtection/BreachedPasswordDetection/BreachedPasswordDetectionClient.cs">GetAsync</a>() -> WithRawResponseTask&lt;GetBreachedPasswordDetectionSettingsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details of the Breached Password Detection configuration of your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AttackProtection.BreachedPasswordDetection.GetAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.AttackProtection.BreachedPasswordDetection.<a href="/src/Auth0.ManagementApi/AttackProtection/BreachedPasswordDetection/BreachedPasswordDetectionClient.cs">UpdateAsync</a>(UpdateBreachedPasswordDetectionSettingsRequestContent { ... }) -> WithRawResponseTask&lt;UpdateBreachedPasswordDetectionSettingsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update details of the Breached Password Detection configuration of your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AttackProtection.BreachedPasswordDetection.UpdateAsync(
    new UpdateBreachedPasswordDetectionSettingsRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateBreachedPasswordDetectionSettingsRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## AttackProtection BruteForceProtection
<details><summary><code>client.AttackProtection.BruteForceProtection.<a href="/src/Auth0.ManagementApi/AttackProtection/BruteForceProtection/BruteForceProtectionClient.cs">GetAsync</a>() -> WithRawResponseTask&lt;GetBruteForceSettingsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details of the Brute-force Protection configuration of your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AttackProtection.BruteForceProtection.GetAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.AttackProtection.BruteForceProtection.<a href="/src/Auth0.ManagementApi/AttackProtection/BruteForceProtection/BruteForceProtectionClient.cs">UpdateAsync</a>(UpdateBruteForceSettingsRequestContent { ... }) -> WithRawResponseTask&lt;UpdateBruteForceSettingsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update the Brute-force Protection configuration of your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AttackProtection.BruteForceProtection.UpdateAsync(
    new UpdateBruteForceSettingsRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateBruteForceSettingsRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## AttackProtection Captcha
<details><summary><code>client.AttackProtection.Captcha.<a href="/src/Auth0.ManagementApi/AttackProtection/Captcha/CaptchaClient.cs">GetAsync</a>() -> WithRawResponseTask&lt;GetAttackProtectionCaptchaResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get the CAPTCHA configuration for your client.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AttackProtection.Captcha.GetAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.AttackProtection.Captcha.<a href="/src/Auth0.ManagementApi/AttackProtection/Captcha/CaptchaClient.cs">UpdateAsync</a>(UpdateAttackProtectionCaptchaRequestContent { ... }) -> WithRawResponseTask&lt;UpdateAttackProtectionCaptchaResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update existing CAPTCHA configuration for your client.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AttackProtection.Captcha.UpdateAsync(
    new UpdateAttackProtectionCaptchaRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateAttackProtectionCaptchaRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## AttackProtection SuspiciousIpThrottling
<details><summary><code>client.AttackProtection.SuspiciousIpThrottling.<a href="/src/Auth0.ManagementApi/AttackProtection/SuspiciousIpThrottling/SuspiciousIpThrottlingClient.cs">GetAsync</a>() -> WithRawResponseTask&lt;GetSuspiciousIpThrottlingSettingsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details of the Suspicious IP Throttling configuration of your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AttackProtection.SuspiciousIpThrottling.GetAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.AttackProtection.SuspiciousIpThrottling.<a href="/src/Auth0.ManagementApi/AttackProtection/SuspiciousIpThrottling/SuspiciousIpThrottlingClient.cs">UpdateAsync</a>(UpdateSuspiciousIpThrottlingSettingsRequestContent { ... }) -> WithRawResponseTask&lt;UpdateSuspiciousIpThrottlingSettingsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update the details of the Suspicious IP Throttling configuration of your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AttackProtection.SuspiciousIpThrottling.UpdateAsync(
    new UpdateSuspiciousIpThrottlingSettingsRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateSuspiciousIpThrottlingSettingsRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Branding Templates
<details><summary><code>client.Branding.Templates.<a href="/src/Auth0.ManagementApi/Branding/Templates/TemplatesClient.cs">GetUniversalLoginAsync</a>() -> WithRawResponseTask&lt;GetUniversalLoginTemplateResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Branding.Templates.GetUniversalLoginAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Branding.Templates.<a href="/src/Auth0.ManagementApi/Branding/Templates/TemplatesClient.cs">UpdateUniversalLoginAsync</a>(UpdateUniversalLoginTemplateRequestContent { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update the Universal Login branding template.

<p>When <code>content-type</code> header is set to <code>application/json</code>:</p>
<pre>
{
  "template": "&lt;!DOCTYPE html&gt;{% assign resolved_dir = dir | default: "auto" %}&lt;html lang="{{locale}}" dir="{{resolved_dir}}"&gt;&lt;head&gt;{%- auth0:head -%}&lt;/head&gt;&lt;body class="_widget-auto-layout"&gt;{%- auth0:widget -%}&lt;/body&gt;&lt;/html&gt;"
}
</pre>

<p>
  When <code>content-type</code> header is set to <code>text/html</code>:
</p>
<pre>
&lt!DOCTYPE html&gt;
{% assign resolved_dir = dir | default: "auto" %}
&lt;html lang="{{locale}}" dir="{{resolved_dir}}"&gt;
  &lt;head&gt;
    {%- auth0:head -%}
  &lt;/head&gt;
  &lt;body class="_widget-auto-layout"&gt;
    {%- auth0:widget -%}
  &lt;/body&gt;
&lt;/html&gt;
</pre>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Branding.Templates.UpdateUniversalLoginAsync("string");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateUniversalLoginTemplateRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Branding.Templates.<a href="/src/Auth0.ManagementApi/Branding/Templates/TemplatesClient.cs">DeleteUniversalLoginAsync</a>()</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Branding.Templates.DeleteUniversalLoginAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Branding Themes
<details><summary><code>client.Branding.Themes.<a href="/src/Auth0.ManagementApi/Branding/Themes/ThemesClient.cs">CreateAsync</a>(CreateBrandingThemeRequestContent { ... }) -> WithRawResponseTask&lt;CreateBrandingThemeResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create branding theme.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Branding.Themes.CreateAsync(
    new CreateBrandingThemeRequestContent
    {
        Borders = new BrandingThemeBorders
        {
            ButtonBorderRadius = 1.1,
            ButtonBorderWeight = 1.1,
            ButtonsStyle = BrandingThemeBordersButtonsStyleEnum.Pill,
            InputBorderRadius = 1.1,
            InputBorderWeight = 1.1,
            InputsStyle = BrandingThemeBordersInputsStyleEnum.Pill,
            ShowWidgetShadow = true,
            WidgetBorderWeight = 1.1,
            WidgetCornerRadius = 1.1,
        },
        Colors = new BrandingThemeColors
        {
            BodyText = "body_text",
            Error = "error",
            Header = "header",
            Icons = "icons",
            InputBackground = "input_background",
            InputBorder = "input_border",
            InputFilledText = "input_filled_text",
            InputLabelsPlaceholders = "input_labels_placeholders",
            LinksFocusedComponents = "links_focused_components",
            PrimaryButton = "primary_button",
            PrimaryButtonLabel = "primary_button_label",
            SecondaryButtonBorder = "secondary_button_border",
            SecondaryButtonLabel = "secondary_button_label",
            Success = "success",
            WidgetBackground = "widget_background",
            WidgetBorder = "widget_border",
        },
        Fonts = new BrandingThemeFonts
        {
            BodyText = new BrandingThemeFontBodyText { Bold = true, Size = 1.1 },
            ButtonsText = new BrandingThemeFontButtonsText { Bold = true, Size = 1.1 },
            FontUrl = "font_url",
            InputLabels = new BrandingThemeFontInputLabels { Bold = true, Size = 1.1 },
            Links = new BrandingThemeFontLinks { Bold = true, Size = 1.1 },
            LinksStyle = BrandingThemeFontLinksStyleEnum.Normal,
            ReferenceTextSize = 1.1,
            Subtitle = new BrandingThemeFontSubtitle { Bold = true, Size = 1.1 },
            Title = new BrandingThemeFontTitle { Bold = true, Size = 1.1 },
        },
        PageBackground = new BrandingThemePageBackground
        {
            BackgroundColor = "background_color",
            BackgroundImageUrl = "background_image_url",
            PageLayout = BrandingThemePageBackgroundPageLayoutEnum.Center,
        },
        Widget = new BrandingThemeWidget
        {
            HeaderTextAlignment = BrandingThemeWidgetHeaderTextAlignmentEnum.Center,
            LogoHeight = 1.1,
            LogoPosition = BrandingThemeWidgetLogoPositionEnum.Center,
            LogoUrl = "logo_url",
            SocialButtonsLayout = BrandingThemeWidgetSocialButtonsLayoutEnum.Bottom,
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateBrandingThemeRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Branding.Themes.<a href="/src/Auth0.ManagementApi/Branding/Themes/ThemesClient.cs">GetDefaultAsync</a>() -> WithRawResponseTask&lt;GetBrandingDefaultThemeResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve default branding theme.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Branding.Themes.GetDefaultAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Branding.Themes.<a href="/src/Auth0.ManagementApi/Branding/Themes/ThemesClient.cs">GetAsync</a>(themeId) -> WithRawResponseTask&lt;GetBrandingThemeResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve branding theme.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Branding.Themes.GetAsync("themeId");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**themeId:** `string` — The ID of the theme
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Branding.Themes.<a href="/src/Auth0.ManagementApi/Branding/Themes/ThemesClient.cs">DeleteAsync</a>(themeId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete branding theme.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Branding.Themes.DeleteAsync("themeId");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**themeId:** `string` — The ID of the theme
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Branding.Themes.<a href="/src/Auth0.ManagementApi/Branding/Themes/ThemesClient.cs">UpdateAsync</a>(themeId, UpdateBrandingThemeRequestContent { ... }) -> WithRawResponseTask&lt;UpdateBrandingThemeResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update branding theme.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Branding.Themes.UpdateAsync(
    "themeId",
    new UpdateBrandingThemeRequestContent
    {
        Borders = new BrandingThemeBorders
        {
            ButtonBorderRadius = 1.1,
            ButtonBorderWeight = 1.1,
            ButtonsStyle = BrandingThemeBordersButtonsStyleEnum.Pill,
            InputBorderRadius = 1.1,
            InputBorderWeight = 1.1,
            InputsStyle = BrandingThemeBordersInputsStyleEnum.Pill,
            ShowWidgetShadow = true,
            WidgetBorderWeight = 1.1,
            WidgetCornerRadius = 1.1,
        },
        Colors = new BrandingThemeColors
        {
            BodyText = "body_text",
            Error = "error",
            Header = "header",
            Icons = "icons",
            InputBackground = "input_background",
            InputBorder = "input_border",
            InputFilledText = "input_filled_text",
            InputLabelsPlaceholders = "input_labels_placeholders",
            LinksFocusedComponents = "links_focused_components",
            PrimaryButton = "primary_button",
            PrimaryButtonLabel = "primary_button_label",
            SecondaryButtonBorder = "secondary_button_border",
            SecondaryButtonLabel = "secondary_button_label",
            Success = "success",
            WidgetBackground = "widget_background",
            WidgetBorder = "widget_border",
        },
        Fonts = new BrandingThemeFonts
        {
            BodyText = new BrandingThemeFontBodyText { Bold = true, Size = 1.1 },
            ButtonsText = new BrandingThemeFontButtonsText { Bold = true, Size = 1.1 },
            FontUrl = "font_url",
            InputLabels = new BrandingThemeFontInputLabels { Bold = true, Size = 1.1 },
            Links = new BrandingThemeFontLinks { Bold = true, Size = 1.1 },
            LinksStyle = BrandingThemeFontLinksStyleEnum.Normal,
            ReferenceTextSize = 1.1,
            Subtitle = new BrandingThemeFontSubtitle { Bold = true, Size = 1.1 },
            Title = new BrandingThemeFontTitle { Bold = true, Size = 1.1 },
        },
        PageBackground = new BrandingThemePageBackground
        {
            BackgroundColor = "background_color",
            BackgroundImageUrl = "background_image_url",
            PageLayout = BrandingThemePageBackgroundPageLayoutEnum.Center,
        },
        Widget = new BrandingThemeWidget
        {
            HeaderTextAlignment = BrandingThemeWidgetHeaderTextAlignmentEnum.Center,
            LogoHeight = 1.1,
            LogoPosition = BrandingThemeWidgetLogoPositionEnum.Center,
            LogoUrl = "logo_url",
            SocialButtonsLayout = BrandingThemeWidgetSocialButtonsLayoutEnum.Bottom,
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**themeId:** `string` — The ID of the theme
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateBrandingThemeRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Branding Phone Providers
<details><summary><code>client.Branding.Phone.Providers.<a href="/src/Auth0.ManagementApi/Branding/Phone/Providers/ProvidersClient.cs">ListAsync</a>(ListBrandingPhoneProvidersRequestParameters { ... }) -> WithRawResponseTask&lt;ListBrandingPhoneProvidersResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of <a href="https://auth0.com/docs/customize/phone-messages/configure-phone-messaging-providers">phone providers</a> details set for a Tenant. A list of fields to include or exclude may also be specified.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Branding.Phone.Providers.ListAsync(
    new ListBrandingPhoneProvidersRequestParameters { Disabled = true }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListBrandingPhoneProvidersRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Branding.Phone.Providers.<a href="/src/Auth0.ManagementApi/Branding/Phone/Providers/ProvidersClient.cs">CreateAsync</a>(CreateBrandingPhoneProviderRequestContent { ... }) -> WithRawResponseTask&lt;CreateBrandingPhoneProviderResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a <a href="https://auth0.com/docs/customize/phone-messages/configure-phone-messaging-providers">phone provider</a>.
The <code>credentials</code> object requires different properties depending on the phone provider (which is specified using the <code>name</code> property).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Branding.Phone.Providers.CreateAsync(
    new CreateBrandingPhoneProviderRequestContent
    {
        Name = PhoneProviderNameEnum.Twilio,
        Credentials = new TwilioProviderCredentials { AuthToken = "auth_token" },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateBrandingPhoneProviderRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Branding.Phone.Providers.<a href="/src/Auth0.ManagementApi/Branding/Phone/Providers/ProvidersClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;GetBrandingPhoneProviderResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve <a href="https://auth0.com/docs/customize/phone-messages/configure-phone-messaging-providers">phone provider</a> details. A list of fields to include or exclude may also be specified.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Branding.Phone.Providers.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Branding.Phone.Providers.<a href="/src/Auth0.ManagementApi/Branding/Phone/Providers/ProvidersClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete the configured phone provider.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Branding.Phone.Providers.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Branding.Phone.Providers.<a href="/src/Auth0.ManagementApi/Branding/Phone/Providers/ProvidersClient.cs">UpdateAsync</a>(id, UpdateBrandingPhoneProviderRequestContent { ... }) -> WithRawResponseTask&lt;UpdateBrandingPhoneProviderResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update a <a href="https://auth0.com/docs/customize/phone-messages/configure-phone-messaging-providers">phone provider</a>.
The <code>credentials</code> object requires different properties depending on the phone provider (which is specified using the <code>name</code> property).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Branding.Phone.Providers.UpdateAsync(
    "id",
    new UpdateBrandingPhoneProviderRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateBrandingPhoneProviderRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Branding.Phone.Providers.<a href="/src/Auth0.ManagementApi/Branding/Phone/Providers/ProvidersClient.cs">TestAsync</a>(id, CreatePhoneProviderSendTestRequestContent { ... }) -> WithRawResponseTask&lt;CreatePhoneProviderSendTestResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Branding.Phone.Providers.TestAsync(
    "id",
    new CreatePhoneProviderSendTestRequestContent { To = "to" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `CreatePhoneProviderSendTestRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Branding Phone Templates
<details><summary><code>client.Branding.Phone.Templates.<a href="/src/Auth0.ManagementApi/Branding/Phone/Templates/TemplatesClient.cs">ListAsync</a>(ListPhoneTemplatesRequestParameters { ... }) -> WithRawResponseTask&lt;ListPhoneTemplatesResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Branding.Phone.Templates.ListAsync(
    new ListPhoneTemplatesRequestParameters { Disabled = true }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListPhoneTemplatesRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Branding.Phone.Templates.<a href="/src/Auth0.ManagementApi/Branding/Phone/Templates/TemplatesClient.cs">CreateAsync</a>(CreatePhoneTemplateRequestContent { ... }) -> WithRawResponseTask&lt;CreatePhoneTemplateResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Branding.Phone.Templates.CreateAsync(new CreatePhoneTemplateRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreatePhoneTemplateRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Branding.Phone.Templates.<a href="/src/Auth0.ManagementApi/Branding/Phone/Templates/TemplatesClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;GetPhoneTemplateResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Branding.Phone.Templates.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Branding.Phone.Templates.<a href="/src/Auth0.ManagementApi/Branding/Phone/Templates/TemplatesClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Branding.Phone.Templates.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Branding.Phone.Templates.<a href="/src/Auth0.ManagementApi/Branding/Phone/Templates/TemplatesClient.cs">UpdateAsync</a>(id, UpdatePhoneTemplateRequestContent { ... }) -> WithRawResponseTask&lt;UpdatePhoneTemplateResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Branding.Phone.Templates.UpdateAsync("id", new UpdatePhoneTemplateRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdatePhoneTemplateRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Branding.Phone.Templates.<a href="/src/Auth0.ManagementApi/Branding/Phone/Templates/TemplatesClient.cs">ResetAsync</a>(id, object { ... }) -> WithRawResponseTask&lt;ResetPhoneTemplateResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Branding.Phone.Templates.ResetAsync(
    "id",
    new Dictionary<object, object?>() { { "key", "value" } }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `object` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Branding.Phone.Templates.<a href="/src/Auth0.ManagementApi/Branding/Phone/Templates/TemplatesClient.cs">TestAsync</a>(id, CreatePhoneTemplateTestNotificationRequestContent { ... }) -> WithRawResponseTask&lt;CreatePhoneTemplateTestNotificationResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Branding.Phone.Templates.TestAsync(
    "id",
    new CreatePhoneTemplateTestNotificationRequestContent { To = "to" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` 
    
</dd>
</dl>

<dl>
<dd>

**request:** `CreatePhoneTemplateTestNotificationRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## ClientGrants Organizations
<details><summary><code>client.ClientGrants.Organizations.<a href="/src/Auth0.ManagementApi/ClientGrants/Organizations/OrganizationsClient.cs">ListAsync</a>(id, ListClientGrantOrganizationsRequestParameters { ... }) -> Pager&lt;Organization&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.ClientGrants.Organizations.ListAsync(
    "id",
    new ListClientGrantOrganizationsRequestParameters { From = "from", Take = 1 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the client grant
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListClientGrantOrganizationsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Clients Credentials
<details><summary><code>client.Clients.Credentials.<a href="/src/Auth0.ManagementApi/Clients/Credentials/CredentialsClient.cs">ListAsync</a>(clientId) -> WithRawResponseTask&lt;IEnumerable&lt;ClientCredential&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get the details of a client credential.

<b>Important</b>: To enable credentials to be used for a client authentication method, set the <code>client_authentication_methods</code> property on the client. To enable credentials to be used for JWT-Secured Authorization requests set the <code>signed_request_object</code> property on the client.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Clients.Credentials.ListAsync("client_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**clientId:** `string` — ID of the client.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Clients.Credentials.<a href="/src/Auth0.ManagementApi/Clients/Credentials/CredentialsClient.cs">CreateAsync</a>(clientId, PostClientCredentialRequestContent { ... }) -> WithRawResponseTask&lt;PostClientCredentialResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a client credential associated to your application. Credentials can be used to configure Private Key JWT and mTLS authentication methods, as well as for JWT-secured Authorization requests.

<h5>Public Key</h5>Public Key credentials can be used to set up Private Key JWT client authentication and JWT-secured Authorization requests.

Sample: <pre><code>{
  "credential_type": "public_key",
  "name": "string",
  "pem": "string",
  "alg": "RS256",
  "parse_expiry_from_cert": false,
  "expires_at": "2022-12-31T23:59:59Z"
}</code></pre>
<h5>Certificate (CA-signed & self-signed)</h5>Certificate credentials can be used to set up mTLS client authentication. CA-signed certificates can be configured either with a signed certificate or with just the certificate Subject DN.

CA-signed Certificate Sample (pem): <pre><code>{
  "credential_type": "x509_cert",
  "name": "string",
  "pem": "string"
}</code></pre>CA-signed Certificate Sample (subject_dn): <pre><code>{
  "credential_type": "cert_subject_dn",
  "name": "string",
  "subject_dn": "string"
}</code></pre>Self-signed Certificate Sample: <pre><code>{
  "credential_type": "cert_subject_dn",
  "name": "string",
  "pem": "string"
}</code></pre>

The credential will be created but not yet enabled for use until you set the corresponding properties in the client:
<ul>
  <li>To enable the credential for Private Key JWT or mTLS authentication methods, set the <code>client_authentication_methods</code> property on the client. For more information, read <a href="https://auth0.com/docs/get-started/applications/configure-private-key-jwt">Configure Private Key JWT Authentication</a> and <a href="https://auth0.com/docs/get-started/applications/configure-mtls">Configure mTLS Authentication</a></li>
  <li>To enable the credential for JWT-secured Authorization requests, set the <code>signed_request_object</code>property on the client. For more information, read <a href="https://auth0.com/docs/get-started/applications/configure-jar">Configure JWT-secured Authorization Requests (JAR)</a></li>
</ul>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Clients.Credentials.CreateAsync(
    "client_id",
    new PostClientCredentialRequestContent { CredentialType = ClientCredentialTypeEnum.PublicKey }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**clientId:** `string` — ID of the client.
    
</dd>
</dl>

<dl>
<dd>

**request:** `PostClientCredentialRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Clients.Credentials.<a href="/src/Auth0.ManagementApi/Clients/Credentials/CredentialsClient.cs">GetAsync</a>(clientId, credentialId) -> WithRawResponseTask&lt;GetClientCredentialResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get the details of a client credential.

<b>Important</b>: To enable credentials to be used for a client authentication method, set the <code>client_authentication_methods</code> property on the client. To enable credentials to be used for JWT-Secured Authorization requests set the <code>signed_request_object</code> property on the client.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Clients.Credentials.GetAsync("client_id", "credential_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**clientId:** `string` — ID of the client.
    
</dd>
</dl>

<dl>
<dd>

**credentialId:** `string` — ID of the credential.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Clients.Credentials.<a href="/src/Auth0.ManagementApi/Clients/Credentials/CredentialsClient.cs">DeleteAsync</a>(clientId, credentialId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a client credential you previously created. May be enabled or disabled. For more information, read <a href="https://www.auth0.com/docs/get-started/authentication-and-authorization-flow/client-credentials-flow">Client Credential Flow</a>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Clients.Credentials.DeleteAsync("client_id", "credential_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**clientId:** `string` — ID of the client.
    
</dd>
</dl>

<dl>
<dd>

**credentialId:** `string` — ID of the credential to delete.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Clients.Credentials.<a href="/src/Auth0.ManagementApi/Clients/Credentials/CredentialsClient.cs">UpdateAsync</a>(clientId, credentialId, PatchClientCredentialRequestContent { ... }) -> WithRawResponseTask&lt;PatchClientCredentialResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Change a client credential you previously created. May be enabled or disabled. For more information, read <a href="https://www.auth0.com/docs/get-started/authentication-and-authorization-flow/client-credentials-flow">Client Credential Flow</a>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Clients.Credentials.UpdateAsync(
    "client_id",
    "credential_id",
    new PatchClientCredentialRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**clientId:** `string` — ID of the client.
    
</dd>
</dl>

<dl>
<dd>

**credentialId:** `string` — ID of the credential.
    
</dd>
</dl>

<dl>
<dd>

**request:** `PatchClientCredentialRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Clients Connections
<details><summary><code>client.Clients.Connections.<a href="/src/Auth0.ManagementApi/Clients/Connections/ConnectionsClient.cs">GetAsync</a>(id, ConnectionsGetRequest { ... }) -> Pager&lt;ConnectionForList&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all connections that are enabled for the specified <a href="https://www.auth0.com/docs/get-started/applications"> Application</a>, using checkpoint pagination. A list of fields to include or exclude for each connection may also be specified.
<ul>
  <li>
    This endpoint requires the <code>read:connections</code> scope and any one of <code>read:clients</code> or <code>read:client_summary</code>.
  </li>
  <li>
    <b>Note</b>: The first time you call this endpoint, omit the <code>from</code> parameter. If there are more results, a <code>next</code> value is included in the response. You can use this for subsequent API calls. When <code>next</code> is no longer included in the response, no further results are remaining.
  </li>
</ul>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Clients.Connections.GetAsync(
    "id",
    new ConnectionsGetRequest
    {
        From = "from",
        Take = 1,
        Fields = "fields",
        IncludeFields = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the client for which to retrieve enabled connections.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ConnectionsGetRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Connections DirectoryProvisioning
<details><summary><code>client.Connections.DirectoryProvisioning.<a href="/src/Auth0.ManagementApi/Connections/DirectoryProvisioning/DirectoryProvisioningClient.cs">ListAsync</a>(ListDirectoryProvisioningsRequestParameters { ... }) -> Pager&lt;DirectoryProvisioning&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of directory provisioning configurations of a tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.DirectoryProvisioning.ListAsync(
    new ListDirectoryProvisioningsRequestParameters { From = "from", Take = 1 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListDirectoryProvisioningsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Connections.DirectoryProvisioning.<a href="/src/Auth0.ManagementApi/Connections/DirectoryProvisioning/DirectoryProvisioningClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;GetDirectoryProvisioningResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve the directory provisioning configuration of a connection.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.DirectoryProvisioning.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the connection to retrieve its directory provisioning configuration
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Connections.DirectoryProvisioning.<a href="/src/Auth0.ManagementApi/Connections/DirectoryProvisioning/DirectoryProvisioningClient.cs">CreateAsync</a>(id, Optional&lt;CreateDirectoryProvisioningRequestContent?&gt; { ... }) -> WithRawResponseTask&lt;CreateDirectoryProvisioningResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a directory provisioning configuration for a connection.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.DirectoryProvisioning.CreateAsync(
    "id",
    new CreateDirectoryProvisioningRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the connection to create its directory provisioning configuration
    
</dd>
</dl>

<dl>
<dd>

**request:** `Optional<CreateDirectoryProvisioningRequestContent?>` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Connections.DirectoryProvisioning.<a href="/src/Auth0.ManagementApi/Connections/DirectoryProvisioning/DirectoryProvisioningClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete the directory provisioning configuration of a connection.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.DirectoryProvisioning.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the connection to delete its directory provisioning configuration
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Connections.DirectoryProvisioning.<a href="/src/Auth0.ManagementApi/Connections/DirectoryProvisioning/DirectoryProvisioningClient.cs">UpdateAsync</a>(id, Optional&lt;UpdateDirectoryProvisioningRequestContent?&gt; { ... }) -> WithRawResponseTask&lt;UpdateDirectoryProvisioningResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update the directory provisioning configuration of a connection.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.DirectoryProvisioning.UpdateAsync(
    "id",
    new UpdateDirectoryProvisioningRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the connection to create its directory provisioning configuration
    
</dd>
</dl>

<dl>
<dd>

**request:** `Optional<UpdateDirectoryProvisioningRequestContent?>` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Connections.DirectoryProvisioning.<a href="/src/Auth0.ManagementApi/Connections/DirectoryProvisioning/DirectoryProvisioningClient.cs">GetDefaultMappingAsync</a>(id) -> WithRawResponseTask&lt;GetDirectoryProvisioningDefaultMappingResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve the directory provisioning default attribute mapping of a connection.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.DirectoryProvisioning.GetDefaultMappingAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the connection to retrieve its directory provisioning configuration
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Connections.DirectoryProvisioning.<a href="/src/Auth0.ManagementApi/Connections/DirectoryProvisioning/DirectoryProvisioningClient.cs">ListSynchronizedGroupsAsync</a>(id, ListSynchronizedGroupsRequestParameters { ... }) -> Pager&lt;SynchronizedGroupPayload&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve the configured synchronized groups for a connection directory provisioning configuration.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.DirectoryProvisioning.ListSynchronizedGroupsAsync(
    "id",
    new ListSynchronizedGroupsRequestParameters { From = "from", Take = 1 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the connection to list synchronized groups for.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListSynchronizedGroupsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Connections.DirectoryProvisioning.<a href="/src/Auth0.ManagementApi/Connections/DirectoryProvisioning/DirectoryProvisioningClient.cs">SetAsync</a>(id, ReplaceSynchronizedGroupsRequestContent { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create or replace the selected groups for a connection directory provisioning configuration.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.DirectoryProvisioning.SetAsync(
    "id",
    new ReplaceSynchronizedGroupsRequestContent
    {
        Groups = new List<SynchronizedGroupPayload>()
        {
            new SynchronizedGroupPayload { Id = "id" },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the connection to create or replace synchronized groups for
    
</dd>
</dl>

<dl>
<dd>

**request:** `ReplaceSynchronizedGroupsRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Connections ScimConfiguration
<details><summary><code>client.Connections.ScimConfiguration.<a href="/src/Auth0.ManagementApi/Connections/ScimConfiguration/ScimConfigurationClient.cs">ListAsync</a>(ListScimConfigurationsRequestParameters { ... }) -> Pager&lt;ScimConfiguration&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of SCIM configurations of a tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.ScimConfiguration.ListAsync(
    new ListScimConfigurationsRequestParameters { From = "from", Take = 1 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListScimConfigurationsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Connections.ScimConfiguration.<a href="/src/Auth0.ManagementApi/Connections/ScimConfiguration/ScimConfigurationClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;GetScimConfigurationResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a scim configuration by its <code>connectionId</code>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.ScimConfiguration.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the connection to retrieve its SCIM configuration
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Connections.ScimConfiguration.<a href="/src/Auth0.ManagementApi/Connections/ScimConfiguration/ScimConfigurationClient.cs">CreateAsync</a>(id, Optional&lt;CreateScimConfigurationRequestContent?&gt; { ... }) -> WithRawResponseTask&lt;CreateScimConfigurationResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a scim configuration for a connection.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.ScimConfiguration.CreateAsync(
    "id",
    new CreateScimConfigurationRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the connection to create its SCIM configuration
    
</dd>
</dl>

<dl>
<dd>

**request:** `Optional<CreateScimConfigurationRequestContent?>` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Connections.ScimConfiguration.<a href="/src/Auth0.ManagementApi/Connections/ScimConfiguration/ScimConfigurationClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a scim configuration by its <code>connectionId</code>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.ScimConfiguration.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the connection to delete its SCIM configuration
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Connections.ScimConfiguration.<a href="/src/Auth0.ManagementApi/Connections/ScimConfiguration/ScimConfigurationClient.cs">UpdateAsync</a>(id, UpdateScimConfigurationRequestContent { ... }) -> WithRawResponseTask&lt;UpdateScimConfigurationResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update a scim configuration by its <code>connectionId</code>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.ScimConfiguration.UpdateAsync(
    "id",
    new UpdateScimConfigurationRequestContent
    {
        UserIdAttribute = "user_id_attribute",
        Mapping = new List<ScimMappingItem>() { new ScimMappingItem() },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the connection to update its SCIM configuration
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateScimConfigurationRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Connections.ScimConfiguration.<a href="/src/Auth0.ManagementApi/Connections/ScimConfiguration/ScimConfigurationClient.cs">GetDefaultMappingAsync</a>(id) -> WithRawResponseTask&lt;GetScimConfigurationDefaultMappingResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves a scim configuration's default mapping by its <code>connectionId</code>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.ScimConfiguration.GetDefaultMappingAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the connection to retrieve its default SCIM mapping
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Connections Clients
<details><summary><code>client.Connections.Clients.<a href="/src/Auth0.ManagementApi/Connections/Clients/ClientsClient.cs">GetAsync</a>(id, GetConnectionEnabledClientsRequestParameters { ... }) -> Pager&lt;ConnectionEnabledClient&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all clients that have the specified <a href="https://auth0.com/docs/authenticate/identity-providers">connection</a> enabled.

<b>Note</b>: The first time you call this endpoint, omit the <code>from</code> parameter. If there are more results, a <code>next</code> value is included in the response. You can use this for subsequent API calls. When <code>next</code> is no longer included in the response, no further results are remaining.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.Clients.GetAsync(
    "id",
    new GetConnectionEnabledClientsRequestParameters { Take = 1, From = "from" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the connection for which enabled clients are to be retrieved
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetConnectionEnabledClientsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Connections.Clients.<a href="/src/Auth0.ManagementApi/Connections/Clients/ClientsClient.cs">UpdateAsync</a>(id, IEnumerable&lt;UpdateEnabledClientConnectionsRequestContentItem&gt; { ... })</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.Clients.UpdateAsync(
    "id",
    new List<UpdateEnabledClientConnectionsRequestContentItem>()
    {
        new UpdateEnabledClientConnectionsRequestContentItem
        {
            ClientId = "client_id",
            Status = true,
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the connection to modify
    
</dd>
</dl>

<dl>
<dd>

**request:** `IEnumerable<UpdateEnabledClientConnectionsRequestContentItem>` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Connections Keys
<details><summary><code>client.Connections.Keys.<a href="/src/Auth0.ManagementApi/Connections/Keys/KeysClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;IEnumerable&lt;ConnectionKey&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Gets the connection keys for the Okta or OIDC connection strategy.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.Keys.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the connection
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Connections.Keys.<a href="/src/Auth0.ManagementApi/Connections/Keys/KeysClient.cs">CreateAsync</a>(id, Optional&lt;PostConnectionKeysRequestContent?&gt; { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;PostConnectionsKeysResponseContentItem&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Provision initial connection keys for Okta or OIDC connection strategies. This endpoint allows you to create keys before configuring the connection to use Private Key JWT authentication, enabling zero-downtime transitions.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.Keys.CreateAsync("id", new PostConnectionKeysRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the connection
    
</dd>
</dl>

<dl>
<dd>

**request:** `Optional<PostConnectionKeysRequestContent?>` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Connections.Keys.<a href="/src/Auth0.ManagementApi/Connections/Keys/KeysClient.cs">RotateAsync</a>(id, Optional&lt;RotateConnectionKeysRequestContent?&gt; { ... }) -> WithRawResponseTask&lt;RotateConnectionsKeysResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Rotates the connection keys for the Okta or OIDC connection strategies.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.Keys.RotateAsync("id", new RotateConnectionKeysRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the connection
    
</dd>
</dl>

<dl>
<dd>

**request:** `Optional<RotateConnectionKeysRequestContent?>` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Connections Users
<details><summary><code>client.Connections.Users.<a href="/src/Auth0.ManagementApi/Connections/Users/UsersClient.cs">DeleteByEmailAsync</a>(id, DeleteConnectionUsersByEmailQueryParameters { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a specified connection user by its email (you cannot delete all users from specific connection). Currently, only Database Connections are supported.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.Users.DeleteByEmailAsync(
    "id",
    new DeleteConnectionUsersByEmailQueryParameters { Email = "email" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the connection (currently only database connections are supported)
    
</dd>
</dl>

<dl>
<dd>

**request:** `DeleteConnectionUsersByEmailQueryParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Connections DirectoryProvisioning Synchronizations
<details><summary><code>client.Connections.DirectoryProvisioning.Synchronizations.<a href="/src/Auth0.ManagementApi/Connections/DirectoryProvisioning/Synchronizations/SynchronizationsClient.cs">CreateAsync</a>(id) -> WithRawResponseTask&lt;CreateDirectorySynchronizationResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Request an on-demand synchronization of the directory.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.DirectoryProvisioning.Synchronizations.CreateAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the connection to trigger synchronization for
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Connections ScimConfiguration Tokens
<details><summary><code>client.Connections.ScimConfiguration.Tokens.<a href="/src/Auth0.ManagementApi/Connections/ScimConfiguration/Tokens/TokensClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;IEnumerable&lt;ScimTokenItem&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves all scim tokens by its connection <code>id</code>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.ScimConfiguration.Tokens.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the connection to retrieve its SCIM configuration
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Connections.ScimConfiguration.Tokens.<a href="/src/Auth0.ManagementApi/Connections/ScimConfiguration/Tokens/TokensClient.cs">CreateAsync</a>(id, CreateScimTokenRequestContent { ... }) -> WithRawResponseTask&lt;CreateScimTokenResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a scim token for a scim client.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.ScimConfiguration.Tokens.CreateAsync(
    "id",
    new CreateScimTokenRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the connection to create its SCIM token
    
</dd>
</dl>

<dl>
<dd>

**request:** `CreateScimTokenRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Connections.ScimConfiguration.Tokens.<a href="/src/Auth0.ManagementApi/Connections/ScimConfiguration/Tokens/TokensClient.cs">DeleteAsync</a>(id, tokenId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Deletes a scim token by its connection <code>id</code> and <code>tokenId</code>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Connections.ScimConfiguration.Tokens.DeleteAsync("id", "tokenId");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The connection id that owns the SCIM token to delete
    
</dd>
</dl>

<dl>
<dd>

**tokenId:** `string` — The id of the scim token to delete
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Emails Provider
<details><summary><code>client.Emails.Provider.<a href="/src/Auth0.ManagementApi/Emails/Provider/ProviderClient.cs">GetAsync</a>(GetEmailProviderRequestParameters { ... }) -> WithRawResponseTask&lt;GetEmailProviderResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details of the <a href="https://auth0.com/docs/customize/email/smtp-email-providers">email provider configuration</a> in your tenant. A list of fields to include or exclude may also be specified.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Emails.Provider.GetAsync(
    new GetEmailProviderRequestParameters { Fields = "fields", IncludeFields = true }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetEmailProviderRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Emails.Provider.<a href="/src/Auth0.ManagementApi/Emails/Provider/ProviderClient.cs">CreateAsync</a>(CreateEmailProviderRequestContent { ... }) -> WithRawResponseTask&lt;CreateEmailProviderResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create an <a href="https://auth0.com/docs/email/providers">email provider</a>. The <code>credentials</code> object
requires different properties depending on the email provider (which is specified using the <code>name</code> property):
<ul>
  <li><code>mandrill</code> requires <code>api_key</code></li>
  <li><code>sendgrid</code> requires <code>api_key</code></li>
  <li>
    <code>sparkpost</code> requires <code>api_key</code>. Optionally, set <code>region</code> to <code>eu</code> to use
    the SparkPost service hosted in Western Europe; set to <code>null</code> to use the SparkPost service hosted in
    North America. <code>eu</code> or <code>null</code> are the only valid values for <code>region</code>.
  </li>
  <li>
    <code>mailgun</code> requires <code>api_key</code> and <code>domain</code>. Optionally, set <code>region</code> to
    <code>eu</code> to use the Mailgun service hosted in Europe; set to <code>null</code> otherwise. <code>eu</code> or
    <code>null</code> are the only valid values for <code>region</code>.
  </li>
  <li><code>ses</code> requires <code>accessKeyId</code>, <code>secretAccessKey</code>, and <code>region</code></li>
  <li>
    <code>smtp</code> requires <code>smtp_host</code>, <code>smtp_port</code>, <code>smtp_user</code>, and
    <code>smtp_pass</code>
  </li>
</ul>
Depending on the type of provider it is possible to specify <code>settings</code> object with different configuration
options, which will be used when sending an email:
<ul>
  <li>
    <code>smtp</code> provider, <code>settings</code> may contain <code>headers</code> object.
    <ul>
      <li>
        When using AWS SES SMTP host, you may provide a name of configuration set in
        <code>X-SES-Configuration-Set</code> header. Value must be a string.
      </li>
      <li>
        When using Sparkpost host, you may provide value for
        <code>X-MSYS_API</code> header. Value must be an object.
      </li>
    </ul>
  </li>
  <li>
    for <code>ses</code> provider, <code>settings</code> may contain <code>message</code> object, where you can provide
    a name of configuration set in <code>configuration_set_name</code> property. Value must be a string.
  </li>
</ul>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Emails.Provider.CreateAsync(
    new CreateEmailProviderRequestContent
    {
        Name = EmailProviderNameEnum.Mailgun,
        Credentials = new EmailProviderCredentialsSchemaZero { ApiKey = "api_key" },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateEmailProviderRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Emails.Provider.<a href="/src/Auth0.ManagementApi/Emails/Provider/ProviderClient.cs">DeleteAsync</a>()</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete the email provider.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Emails.Provider.DeleteAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Emails.Provider.<a href="/src/Auth0.ManagementApi/Emails/Provider/ProviderClient.cs">UpdateAsync</a>(UpdateEmailProviderRequestContent { ... }) -> WithRawResponseTask&lt;UpdateEmailProviderResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update an <a href="https://auth0.com/docs/email/providers">email provider</a>. The <code>credentials</code> object
requires different properties depending on the email provider (which is specified using the <code>name</code> property):
<ul>
  <li><code>mandrill</code> requires <code>api_key</code></li>
  <li><code>sendgrid</code> requires <code>api_key</code></li>
  <li>
    <code>sparkpost</code> requires <code>api_key</code>. Optionally, set <code>region</code> to <code>eu</code> to use
    the SparkPost service hosted in Western Europe; set to <code>null</code> to use the SparkPost service hosted in
    North America. <code>eu</code> or <code>null</code> are the only valid values for <code>region</code>.
  </li>
  <li>
    <code>mailgun</code> requires <code>api_key</code> and <code>domain</code>. Optionally, set <code>region</code> to
    <code>eu</code> to use the Mailgun service hosted in Europe; set to <code>null</code> otherwise. <code>eu</code> or
    <code>null</code> are the only valid values for <code>region</code>.
  </li>
  <li><code>ses</code> requires <code>accessKeyId</code>, <code>secretAccessKey</code>, and <code>region</code></li>
  <li>
    <code>smtp</code> requires <code>smtp_host</code>, <code>smtp_port</code>, <code>smtp_user</code>, and
    <code>smtp_pass</code>
  </li>
</ul>
Depending on the type of provider it is possible to specify <code>settings</code> object with different configuration
options, which will be used when sending an email:
<ul>
  <li>
    <code>smtp</code> provider, <code>settings</code> may contain <code>headers</code> object.
    <ul>
      <li>
        When using AWS SES SMTP host, you may provide a name of configuration set in
        <code>X-SES-Configuration-Set</code> header. Value must be a string.
      </li>
      <li>
        When using Sparkpost host, you may provide value for
        <code>X-MSYS_API</code> header. Value must be an object.
      </li>
    </ul>
    for <code>ses</code> provider, <code>settings</code> may contain <code>message</code> object, where you can provide
    a name of configuration set in <code>configuration_set_name</code> property. Value must be a string.
  </li>
</ul>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Emails.Provider.UpdateAsync(new UpdateEmailProviderRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateEmailProviderRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## EventStreams Deliveries
<details><summary><code>client.EventStreams.Deliveries.<a href="/src/Auth0.ManagementApi/EventStreams/Deliveries/DeliveriesClient.cs">ListAsync</a>(id, ListEventStreamDeliveriesRequestParameters { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;EventStreamDelivery&gt;&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EventStreams.Deliveries.ListAsync(
    "id",
    new ListEventStreamDeliveriesRequestParameters
    {
        Statuses = "statuses",
        EventTypes = "event_types",
        DateFrom = "date_from",
        DateTo = "date_to",
        From = "from",
        Take = 1,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Unique identifier for the event stream.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListEventStreamDeliveriesRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EventStreams.Deliveries.<a href="/src/Auth0.ManagementApi/EventStreams/Deliveries/DeliveriesClient.cs">GetHistoryAsync</a>(id, eventId) -> WithRawResponseTask&lt;GetEventStreamDeliveryHistoryResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EventStreams.Deliveries.GetHistoryAsync("id", "event_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Unique identifier for the event stream.
    
</dd>
</dl>

<dl>
<dd>

**eventId:** `string` — Unique identifier for the event
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## EventStreams Redeliveries
<details><summary><code>client.EventStreams.Redeliveries.<a href="/src/Auth0.ManagementApi/EventStreams/Redeliveries/RedeliveriesClient.cs">CreateAsync</a>(id, CreateEventStreamRedeliveryRequestContent { ... }) -> WithRawResponseTask&lt;CreateEventStreamRedeliveryResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EventStreams.Redeliveries.CreateAsync(
    "id",
    new CreateEventStreamRedeliveryRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Unique identifier for the event stream.
    
</dd>
</dl>

<dl>
<dd>

**request:** `CreateEventStreamRedeliveryRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.EventStreams.Redeliveries.<a href="/src/Auth0.ManagementApi/EventStreams/Redeliveries/RedeliveriesClient.cs">CreateByIdAsync</a>(id, eventId)</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.EventStreams.Redeliveries.CreateByIdAsync("id", "event_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Unique identifier for the event stream.
    
</dd>
</dl>

<dl>
<dd>

**eventId:** `string` — Unique identifier for the event
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Flows Executions
<details><summary><code>client.Flows.Executions.<a href="/src/Auth0.ManagementApi/Flows/Executions/ExecutionsClient.cs">ListAsync</a>(flowId, ListFlowExecutionsRequestParameters { ... }) -> Pager&lt;FlowExecutionSummary&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Flows.Executions.ListAsync(
    "flow_id",
    new ListFlowExecutionsRequestParameters { From = "from", Take = 1 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**flowId:** `string` — Flow id
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListFlowExecutionsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Flows.Executions.<a href="/src/Auth0.ManagementApi/Flows/Executions/ExecutionsClient.cs">GetAsync</a>(flowId, executionId, GetFlowExecutionRequestParameters { ... }) -> WithRawResponseTask&lt;GetFlowExecutionResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Flows.Executions.GetAsync(
    "flow_id",
    "execution_id",
    new GetFlowExecutionRequestParameters()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**flowId:** `string` — Flow id
    
</dd>
</dl>

<dl>
<dd>

**executionId:** `string` — Flow execution id
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetFlowExecutionRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Flows.Executions.<a href="/src/Auth0.ManagementApi/Flows/Executions/ExecutionsClient.cs">DeleteAsync</a>(flowId, executionId)</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Flows.Executions.DeleteAsync("flow_id", "execution_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**flowId:** `string` — Flows id
    
</dd>
</dl>

<dl>
<dd>

**executionId:** `string` — Flow execution identifier
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Flows Vault Connections
<details><summary><code>client.Flows.Vault.Connections.<a href="/src/Auth0.ManagementApi/Flows/Vault/Connections/ConnectionsClient.cs">ListAsync</a>(ListFlowsVaultConnectionsRequestParameters { ... }) -> Pager&lt;FlowsVaultConnectionSummary&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Flows.Vault.Connections.ListAsync(
    new ListFlowsVaultConnectionsRequestParameters
    {
        Page = 1,
        PerPage = 1,
        IncludeTotals = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListFlowsVaultConnectionsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Flows.Vault.Connections.<a href="/src/Auth0.ManagementApi/Flows/Vault/Connections/ConnectionsClient.cs">CreateAsync</a>(CreateFlowsVaultConnectionRequestContent { ... }) -> WithRawResponseTask&lt;CreateFlowsVaultConnectionResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Flows.Vault.Connections.CreateAsync(
    new CreateFlowsVaultConnectionActivecampaignApiKey
    {
        Name = "name",
        AppId = FlowsVaultConnectionAppIdActivecampaignEnum.Activecampaign,
        Setup = new FlowsVaultConnectioSetupApiKeyWithBaseUrl
        {
            Type = FlowsVaultConnectioSetupTypeApiKeyEnum.ApiKey,
            ApiKey = "api_key",
            BaseUrl = "base_url",
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateFlowsVaultConnectionRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Flows.Vault.Connections.<a href="/src/Auth0.ManagementApi/Flows/Vault/Connections/ConnectionsClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;GetFlowsVaultConnectionResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Flows.Vault.Connections.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Flows Vault connection ID
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Flows.Vault.Connections.<a href="/src/Auth0.ManagementApi/Flows/Vault/Connections/ConnectionsClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Flows.Vault.Connections.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Vault connection id
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Flows.Vault.Connections.<a href="/src/Auth0.ManagementApi/Flows/Vault/Connections/ConnectionsClient.cs">UpdateAsync</a>(id, UpdateFlowsVaultConnectionRequestContent { ... }) -> WithRawResponseTask&lt;UpdateFlowsVaultConnectionResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Flows.Vault.Connections.UpdateAsync(
    "id",
    new UpdateFlowsVaultConnectionRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Flows Vault connection ID
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateFlowsVaultConnectionRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Groups Members
<details><summary><code>client.Groups.Members.<a href="/src/Auth0.ManagementApi/Groups/Members/MembersClient.cs">GetAsync</a>(id, GetGroupMembersRequestParameters { ... }) -> Pager&lt;GroupMember&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List all users that are a member of this group.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Groups.Members.GetAsync(
    "id",
    new GetGroupMembersRequestParameters
    {
        Fields = "fields",
        IncludeFields = true,
        From = "from",
        Take = 1,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Unique identifier for the group (service-generated).
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetGroupMembersRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Guardian Enrollments
<details><summary><code>client.Guardian.Enrollments.<a href="/src/Auth0.ManagementApi/Guardian/Enrollments/EnrollmentsClient.cs">CreateTicketAsync</a>(CreateGuardianEnrollmentTicketRequestContent { ... }) -> WithRawResponseTask&lt;CreateGuardianEnrollmentTicketResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a <a href="https://auth0.com/docs/secure/multi-factor-authentication/auth0-guardian/create-custom-enrollment-tickets">multi-factor authentication (MFA) enrollment ticket</a>, and optionally send an email with the created ticket, to a given user.
Create a <a href="https://auth0.com/docs/secure/multi-factor-authentication/auth0-guardian/create-custom-enrollment-tickets">multi-factor authentication (MFA) enrollment ticket</a>, and optionally send an email with the created ticket to a given user. Enrollment tickets can specify which factor users must enroll with or allow existing MFA users to enroll in additional factors.<br/> 

Note: Users cannot enroll in Email as a factor through custom enrollment tickets. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Enrollments.CreateTicketAsync(
    new CreateGuardianEnrollmentTicketRequestContent { UserId = "user_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateGuardianEnrollmentTicketRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Enrollments.<a href="/src/Auth0.ManagementApi/Guardian/Enrollments/EnrollmentsClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;GetGuardianEnrollmentResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details, such as status and type, for a specific multi-factor authentication enrollment registered to a user account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Enrollments.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the enrollment to be retrieve.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Enrollments.<a href="/src/Auth0.ManagementApi/Guardian/Enrollments/EnrollmentsClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Remove a specific multi-factor authentication (MFA) enrollment from a user's account. This allows the user to re-enroll with MFA. For more information, review <a href="https://auth0.com/docs/secure/multi-factor-authentication/reset-user-mfa">Reset User Multi-Factor Authentication and Recovery Codes</a>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Enrollments.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the enrollment to be deleted.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Guardian Factors
<details><summary><code>client.Guardian.Factors.<a href="/src/Auth0.ManagementApi/Guardian/Factors/FactorsClient.cs">ListAsync</a>() -> WithRawResponseTask&lt;IEnumerable&lt;GuardianFactor&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details of all <a href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors">multi-factor authentication factors</a> associated with your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.ListAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Factors.<a href="/src/Auth0.ManagementApi/Guardian/Factors/FactorsClient.cs">SetAsync</a>(name, SetGuardianFactorRequestContent { ... }) -> WithRawResponseTask&lt;SetGuardianFactorResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update the status (i.e., enabled or disabled) of a specific multi-factor authentication factor.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.SetAsync(
    GuardianFactorNameEnum.PushNotification,
    new SetGuardianFactorRequestContent { Enabled = true }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**name:** `GuardianFactorNameEnum` — Factor name. Can be `sms`, `push-notification`, `email`, `duo` `otp` `webauthn-roaming`, `webauthn-platform`, or `recovery-code`.
    
</dd>
</dl>

<dl>
<dd>

**request:** `SetGuardianFactorRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Guardian Policies
<details><summary><code>client.Guardian.Policies.<a href="/src/Auth0.ManagementApi/Guardian/Policies/PoliciesClient.cs">ListAsync</a>() -> WithRawResponseTask&lt;IEnumerable&lt;MfaPolicyEnum&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve the <a href="https://auth0.com/docs/secure/multi-factor-authentication/enable-mfa">multi-factor authentication (MFA) policies</a> configured for your tenant.

The following policies are supported:
<ul>
<li><code>all-applications</code> policy prompts with MFA for all logins.</li>
<li><code>confidence-score</code> policy prompts with MFA only for low confidence logins.</li>
</ul>

<b>Note</b>: The <code>confidence-score</code> policy is part of the <a href="https://auth0.com/docs/secure/multi-factor-authentication/adaptive-mfa">Adaptive MFA feature</a>. Adaptive MFA requires an add-on for the Enterprise plan; review <a href="https://auth0.com/pricing">Auth0 Pricing</a> for more details.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Policies.ListAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Policies.<a href="/src/Auth0.ManagementApi/Guardian/Policies/PoliciesClient.cs">SetAsync</a>(IEnumerable&lt;MfaPolicyEnum&gt; { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;MfaPolicyEnum&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Set <a href="https://auth0.com/docs/secure/multi-factor-authentication/enable-mfa">multi-factor authentication (MFA) policies</a> for your tenant.

The following policies are supported:
<ul>
<li><code>all-applications</code> policy prompts with MFA for all logins.</li>
<li><code>confidence-score</code> policy prompts with MFA only for low confidence logins.</li>
</ul>

<b>Note</b>: The <code>confidence-score</code> policy is part of the <a href="https://auth0.com/docs/secure/multi-factor-authentication/adaptive-mfa">Adaptive MFA feature</a>. Adaptive MFA requires an add-on for the Enterprise plan; review <a href="https://auth0.com/pricing">Auth0 Pricing</a> for more details.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Policies.SetAsync(
    new List<MfaPolicyEnum>() { MfaPolicyEnum.AllApplications }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `IEnumerable<MfaPolicyEnum>` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Guardian Factors Phone
<details><summary><code>client.Guardian.Factors.Phone.<a href="/src/Auth0.ManagementApi/Guardian/Factors/Phone/PhoneClient.cs">GetMessageTypesAsync</a>() -> WithRawResponseTask&lt;GetGuardianFactorPhoneMessageTypesResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve list of <a href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors/configure-sms-voice-notifications-mfa">phone-type MFA factors</a> (i.e., sms and voice) that are enabled for your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.Phone.GetMessageTypesAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Factors.Phone.<a href="/src/Auth0.ManagementApi/Guardian/Factors/Phone/PhoneClient.cs">SetMessageTypesAsync</a>(SetGuardianFactorPhoneMessageTypesRequestContent { ... }) -> WithRawResponseTask&lt;SetGuardianFactorPhoneMessageTypesResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Replace the list of <a href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors/configure-sms-voice-notifications-mfa">phone-type MFA factors</a> (i.e., sms and voice) that are enabled for your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.Phone.SetMessageTypesAsync(
    new SetGuardianFactorPhoneMessageTypesRequestContent
    {
        MessageTypes = new List<GuardianFactorPhoneFactorMessageTypeEnum>()
        {
            GuardianFactorPhoneFactorMessageTypeEnum.Sms,
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SetGuardianFactorPhoneMessageTypesRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Factors.Phone.<a href="/src/Auth0.ManagementApi/Guardian/Factors/Phone/PhoneClient.cs">GetTwilioProviderAsync</a>() -> WithRawResponseTask&lt;GetGuardianFactorsProviderPhoneTwilioResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve configuration details for a Twilio phone provider that has been set up in your tenant. To learn more, review <a href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors/configure-sms-voice-notifications-mfa">Configure SMS and Voice Notifications for MFA</a>. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.Phone.GetTwilioProviderAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Factors.Phone.<a href="/src/Auth0.ManagementApi/Guardian/Factors/Phone/PhoneClient.cs">SetTwilioProviderAsync</a>(SetGuardianFactorsProviderPhoneTwilioRequestContent { ... }) -> WithRawResponseTask&lt;SetGuardianFactorsProviderPhoneTwilioResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update the configuration of a Twilio phone provider that has been set up in your tenant. To learn more, review <a href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors/configure-sms-voice-notifications-mfa">Configure SMS and Voice Notifications for MFA</a>. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.Phone.SetTwilioProviderAsync(
    new SetGuardianFactorsProviderPhoneTwilioRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SetGuardianFactorsProviderPhoneTwilioRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Factors.Phone.<a href="/src/Auth0.ManagementApi/Guardian/Factors/Phone/PhoneClient.cs">GetSelectedProviderAsync</a>() -> WithRawResponseTask&lt;GetGuardianFactorsProviderPhoneResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details of the multi-factor authentication phone provider configured for your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.Phone.GetSelectedProviderAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Factors.Phone.<a href="/src/Auth0.ManagementApi/Guardian/Factors/Phone/PhoneClient.cs">SetProviderAsync</a>(SetGuardianFactorsProviderPhoneRequestContent { ... }) -> WithRawResponseTask&lt;SetGuardianFactorsProviderPhoneResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.Phone.SetProviderAsync(
    new SetGuardianFactorsProviderPhoneRequestContent
    {
        Provider = GuardianFactorsProviderSmsProviderEnum.Auth0,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SetGuardianFactorsProviderPhoneRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Factors.Phone.<a href="/src/Auth0.ManagementApi/Guardian/Factors/Phone/PhoneClient.cs">GetTemplatesAsync</a>() -> WithRawResponseTask&lt;GetGuardianFactorPhoneTemplatesResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details of the multi-factor authentication enrollment and verification templates for phone-type factors available in your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.Phone.GetTemplatesAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Factors.Phone.<a href="/src/Auth0.ManagementApi/Guardian/Factors/Phone/PhoneClient.cs">SetTemplatesAsync</a>(SetGuardianFactorPhoneTemplatesRequestContent { ... }) -> WithRawResponseTask&lt;SetGuardianFactorPhoneTemplatesResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Customize the messages sent to complete phone enrollment and verification (subscription required).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.Phone.SetTemplatesAsync(
    new SetGuardianFactorPhoneTemplatesRequestContent
    {
        EnrollmentMessage = "enrollment_message",
        VerificationMessage = "verification_message",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SetGuardianFactorPhoneTemplatesRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Guardian Factors PushNotification
<details><summary><code>client.Guardian.Factors.PushNotification.<a href="/src/Auth0.ManagementApi/Guardian/Factors/PushNotification/PushNotificationClient.cs">GetApnsProviderAsync</a>() -> WithRawResponseTask&lt;GetGuardianFactorsProviderApnsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve configuration details for the multi-factor authentication APNS provider associated with your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.PushNotification.GetApnsProviderAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Factors.PushNotification.<a href="/src/Auth0.ManagementApi/Guardian/Factors/PushNotification/PushNotificationClient.cs">SetApnsProviderAsync</a>(SetGuardianFactorsProviderPushNotificationApnsRequestContent { ... }) -> WithRawResponseTask&lt;SetGuardianFactorsProviderPushNotificationApnsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Overwrite all configuration details of the multi-factor authentication APNS provider associated with your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.PushNotification.SetApnsProviderAsync(
    new SetGuardianFactorsProviderPushNotificationApnsRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SetGuardianFactorsProviderPushNotificationApnsRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Factors.PushNotification.<a href="/src/Auth0.ManagementApi/Guardian/Factors/PushNotification/PushNotificationClient.cs">UpdateApnsProviderAsync</a>(UpdateGuardianFactorsProviderPushNotificationApnsRequestContent { ... }) -> WithRawResponseTask&lt;UpdateGuardianFactorsProviderPushNotificationApnsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Modify configuration details of the multi-factor authentication APNS provider associated with your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.PushNotification.UpdateApnsProviderAsync(
    new UpdateGuardianFactorsProviderPushNotificationApnsRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateGuardianFactorsProviderPushNotificationApnsRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Factors.PushNotification.<a href="/src/Auth0.ManagementApi/Guardian/Factors/PushNotification/PushNotificationClient.cs">SetFcmProviderAsync</a>(SetGuardianFactorsProviderPushNotificationFcmRequestContent { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Overwrite all configuration details of the multi-factor authentication FCM provider associated with your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.PushNotification.SetFcmProviderAsync(
    new SetGuardianFactorsProviderPushNotificationFcmRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SetGuardianFactorsProviderPushNotificationFcmRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Factors.PushNotification.<a href="/src/Auth0.ManagementApi/Guardian/Factors/PushNotification/PushNotificationClient.cs">UpdateFcmProviderAsync</a>(UpdateGuardianFactorsProviderPushNotificationFcmRequestContent { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Modify configuration details of the multi-factor authentication FCM provider associated with your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.PushNotification.UpdateFcmProviderAsync(
    new UpdateGuardianFactorsProviderPushNotificationFcmRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateGuardianFactorsProviderPushNotificationFcmRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Factors.PushNotification.<a href="/src/Auth0.ManagementApi/Guardian/Factors/PushNotification/PushNotificationClient.cs">SetFcmv1ProviderAsync</a>(SetGuardianFactorsProviderPushNotificationFcmv1RequestContent { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Overwrite all configuration details of the multi-factor authentication FCMV1 provider associated with your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.PushNotification.SetFcmv1ProviderAsync(
    new SetGuardianFactorsProviderPushNotificationFcmv1RequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SetGuardianFactorsProviderPushNotificationFcmv1RequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Factors.PushNotification.<a href="/src/Auth0.ManagementApi/Guardian/Factors/PushNotification/PushNotificationClient.cs">UpdateFcmv1ProviderAsync</a>(UpdateGuardianFactorsProviderPushNotificationFcmv1RequestContent { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Modify configuration details of the multi-factor authentication FCMV1 provider associated with your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.PushNotification.UpdateFcmv1ProviderAsync(
    new UpdateGuardianFactorsProviderPushNotificationFcmv1RequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateGuardianFactorsProviderPushNotificationFcmv1RequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Factors.PushNotification.<a href="/src/Auth0.ManagementApi/Guardian/Factors/PushNotification/PushNotificationClient.cs">GetSnsProviderAsync</a>() -> WithRawResponseTask&lt;GetGuardianFactorsProviderSnsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve configuration details for an AWS SNS push notification provider that has been enabled for MFA. To learn more, review <a href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors/configure-push-notifications-for-mfa">Configure Push Notifications for MFA</a>. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.PushNotification.GetSnsProviderAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Factors.PushNotification.<a href="/src/Auth0.ManagementApi/Guardian/Factors/PushNotification/PushNotificationClient.cs">SetSnsProviderAsync</a>(SetGuardianFactorsProviderPushNotificationSnsRequestContent { ... }) -> WithRawResponseTask&lt;SetGuardianFactorsProviderPushNotificationSnsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Configure the <a href="https://auth0.com/docs/multifactor-authentication/developer/sns-configuration">AWS SNS push notification provider configuration</a> (subscription required).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.PushNotification.SetSnsProviderAsync(
    new SetGuardianFactorsProviderPushNotificationSnsRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SetGuardianFactorsProviderPushNotificationSnsRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Factors.PushNotification.<a href="/src/Auth0.ManagementApi/Guardian/Factors/PushNotification/PushNotificationClient.cs">UpdateSnsProviderAsync</a>(UpdateGuardianFactorsProviderPushNotificationSnsRequestContent { ... }) -> WithRawResponseTask&lt;UpdateGuardianFactorsProviderPushNotificationSnsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Configure the <a href="https://auth0.com/docs/multifactor-authentication/developer/sns-configuration">AWS SNS push notification provider configuration</a> (subscription required).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.PushNotification.UpdateSnsProviderAsync(
    new UpdateGuardianFactorsProviderPushNotificationSnsRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateGuardianFactorsProviderPushNotificationSnsRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Factors.PushNotification.<a href="/src/Auth0.ManagementApi/Guardian/Factors/PushNotification/PushNotificationClient.cs">GetSelectedProviderAsync</a>() -> WithRawResponseTask&lt;GetGuardianFactorsProviderPushNotificationResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Modify the push notification provider configured for your tenant. For more information, review <a href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors/configure-push-notifications-for-mfa">Configure Push Notifications for MFA</a>. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.PushNotification.GetSelectedProviderAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Factors.PushNotification.<a href="/src/Auth0.ManagementApi/Guardian/Factors/PushNotification/PushNotificationClient.cs">SetProviderAsync</a>(SetGuardianFactorsProviderPushNotificationRequestContent { ... }) -> WithRawResponseTask&lt;SetGuardianFactorsProviderPushNotificationResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Modify the push notification provider configured for your tenant. For more information, review <a href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors/configure-push-notifications-for-mfa">Configure Push Notifications for MFA</a>. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.PushNotification.SetProviderAsync(
    new SetGuardianFactorsProviderPushNotificationRequestContent
    {
        Provider = GuardianFactorsProviderPushNotificationProviderDataEnum.Guardian,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SetGuardianFactorsProviderPushNotificationRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Guardian Factors Sms
<details><summary><code>client.Guardian.Factors.Sms.<a href="/src/Auth0.ManagementApi/Guardian/Factors/Sms/SmsClient.cs">GetTwilioProviderAsync</a>() -> WithRawResponseTask&lt;GetGuardianFactorsProviderSmsTwilioResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve the <a href="https://auth0.com/docs/multifactor-authentication/twilio-configuration">Twilio SMS provider configuration</a> (subscription required).

    A new endpoint is available to retrieve the Twilio configuration related to phone factors (<a href='https://auth0.com/docs/api/management/v2/#!/Guardian/get_twilio'>phone Twilio configuration</a>). It has the same payload as this one. Please use it instead.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.Sms.GetTwilioProviderAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Factors.Sms.<a href="/src/Auth0.ManagementApi/Guardian/Factors/Sms/SmsClient.cs">SetTwilioProviderAsync</a>(SetGuardianFactorsProviderSmsTwilioRequestContent { ... }) -> WithRawResponseTask&lt;SetGuardianFactorsProviderSmsTwilioResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This endpoint has been deprecated. To complete this action, use the <a href="https://auth0.com/docs/api/management/v2/guardian/put-twilio">Update Twilio phone configuration</a> endpoint.

    <b>Previous functionality</b>: Update the Twilio SMS provider configuration.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.Sms.SetTwilioProviderAsync(
    new SetGuardianFactorsProviderSmsTwilioRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SetGuardianFactorsProviderSmsTwilioRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Factors.Sms.<a href="/src/Auth0.ManagementApi/Guardian/Factors/Sms/SmsClient.cs">GetSelectedProviderAsync</a>() -> WithRawResponseTask&lt;GetGuardianFactorsProviderSmsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This endpoint has been deprecated. To complete this action, use the <a href="https://auth0.com/docs/api/management/v2/guardian/get-phone-providers">Retrieve phone configuration</a> endpoint instead.

    <b>Previous functionality</b>: Retrieve details for the multi-factor authentication SMS provider configured for your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.Sms.GetSelectedProviderAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Factors.Sms.<a href="/src/Auth0.ManagementApi/Guardian/Factors/Sms/SmsClient.cs">SetProviderAsync</a>(SetGuardianFactorsProviderSmsRequestContent { ... }) -> WithRawResponseTask&lt;SetGuardianFactorsProviderSmsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This endpoint has been deprecated. To complete this action, use the <a href="https://auth0.com/docs/api/management/v2/guardian/put-phone-providers">Update phone configuration</a> endpoint instead.

    <b>Previous functionality</b>: Update the multi-factor authentication SMS provider configuration in your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.Sms.SetProviderAsync(
    new SetGuardianFactorsProviderSmsRequestContent
    {
        Provider = GuardianFactorsProviderSmsProviderEnum.Auth0,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SetGuardianFactorsProviderSmsRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Factors.Sms.<a href="/src/Auth0.ManagementApi/Guardian/Factors/Sms/SmsClient.cs">GetTemplatesAsync</a>() -> WithRawResponseTask&lt;GetGuardianFactorSmsTemplatesResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This endpoint has been deprecated. To complete this action, use the <a href="https://auth0.com/docs/api/management/v2/guardian/get-factor-phone-templates">Retrieve enrollment and verification phone templates</a> endpoint instead.

    <b>Previous function</b>: Retrieve details of SMS enrollment and verification templates configured for your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.Sms.GetTemplatesAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Factors.Sms.<a href="/src/Auth0.ManagementApi/Guardian/Factors/Sms/SmsClient.cs">SetTemplatesAsync</a>(SetGuardianFactorSmsTemplatesRequestContent { ... }) -> WithRawResponseTask&lt;SetGuardianFactorSmsTemplatesResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

This endpoint has been deprecated. To complete this action, use the <a href="https://auth0.com/docs/api/management/v2/guardian/put-factor-phone-templates">Update enrollment and verification phone templates</a> endpoint instead.

    <b>Previous functionality</b>: Customize the messages sent to complete SMS enrollment and verification.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.Sms.SetTemplatesAsync(
    new SetGuardianFactorSmsTemplatesRequestContent
    {
        EnrollmentMessage = "enrollment_message",
        VerificationMessage = "verification_message",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SetGuardianFactorSmsTemplatesRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Guardian Factors Duo Settings
<details><summary><code>client.Guardian.Factors.Duo.Settings.<a href="/src/Auth0.ManagementApi/Guardian/Factors/Duo/Settings/SettingsClient.cs">GetAsync</a>() -> WithRawResponseTask&lt;GetGuardianFactorDuoSettingsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves the DUO account and factor configuration.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.Duo.Settings.GetAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Factors.Duo.Settings.<a href="/src/Auth0.ManagementApi/Guardian/Factors/Duo/Settings/SettingsClient.cs">SetAsync</a>(SetGuardianFactorDuoSettingsRequestContent { ... }) -> WithRawResponseTask&lt;SetGuardianFactorDuoSettingsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Set the DUO account configuration and other properties specific to this factor.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.Duo.Settings.SetAsync(
    new SetGuardianFactorDuoSettingsRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SetGuardianFactorDuoSettingsRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Guardian.Factors.Duo.Settings.<a href="/src/Auth0.ManagementApi/Guardian/Factors/Duo/Settings/SettingsClient.cs">UpdateAsync</a>(UpdateGuardianFactorDuoSettingsRequestContent { ... }) -> WithRawResponseTask&lt;UpdateGuardianFactorDuoSettingsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Guardian.Factors.Duo.Settings.UpdateAsync(
    new UpdateGuardianFactorDuoSettingsRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateGuardianFactorDuoSettingsRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Hooks Secrets
<details><summary><code>client.Hooks.Secrets.<a href="/src/Auth0.ManagementApi/Hooks/Secrets/SecretsClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;Dictionary&lt;string, string&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a hook's secrets by the ID of the hook. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Hooks.Secrets.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the hook to retrieve secrets from.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Hooks.Secrets.<a href="/src/Auth0.ManagementApi/Hooks/Secrets/SecretsClient.cs">CreateAsync</a>(id, Dictionary&lt;string, string&gt; { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Add one or more secrets to an existing hook. Accepts an object of key-value pairs, where the key is the name of the secret. A hook can have a maximum of 20 secrets. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Hooks.Secrets.CreateAsync(
    "id",
    new Dictionary<string, string>() { { "key", "value" } }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the hook to retrieve
    
</dd>
</dl>

<dl>
<dd>

**request:** `Dictionary<string, string>` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Hooks.Secrets.<a href="/src/Auth0.ManagementApi/Hooks/Secrets/SecretsClient.cs">DeleteAsync</a>(id, IEnumerable&lt;string&gt; { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete one or more existing secrets for a given hook. Accepts an array of secret names to delete. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Hooks.Secrets.DeleteAsync("id", new List<string>() { "string" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the hook whose secrets to delete.
    
</dd>
</dl>

<dl>
<dd>

**request:** `IEnumerable<string>` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Hooks.Secrets.<a href="/src/Auth0.ManagementApi/Hooks/Secrets/SecretsClient.cs">UpdateAsync</a>(id, Dictionary&lt;string, string&gt; { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update one or more existing secrets for an existing hook. Accepts an object of key-value pairs, where the key is the name of the existing secret. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Hooks.Secrets.UpdateAsync(
    "id",
    new Dictionary<string, string>() { { "key", "value" } }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the hook whose secrets to update.
    
</dd>
</dl>

<dl>
<dd>

**request:** `Dictionary<string, string>` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Jobs UsersExports
<details><summary><code>client.Jobs.UsersExports.<a href="/src/Auth0.ManagementApi/Jobs/UsersExports/UsersExportsClient.cs">CreateAsync</a>(CreateExportUsersRequestContent { ... }) -> WithRawResponseTask&lt;CreateExportUsersResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Export all users to a file via a long-running job.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Jobs.UsersExports.CreateAsync(new CreateExportUsersRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateExportUsersRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Jobs UsersImports
<details><summary><code>client.Jobs.UsersImports.<a href="/src/Auth0.ManagementApi/Jobs/UsersImports/UsersImportsClient.cs">CreateAsync</a>(CreateImportUsersRequestContent { ... }) -> WithRawResponseTask&lt;CreateImportUsersResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Import users from a <a href="https://auth0.com/docs/users/references/bulk-import-database-schema-examples">formatted file</a> into a connection via a long-running job. When importing users, with or without upsert, the `email_verified` is set to `false` when the email address is added or updated. Users must verify their email address. To avoid this behavior, set `email_verified` to `true` in the imported data.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Jobs.UsersImports.CreateAsync(
    new CreateImportUsersRequestContent { ConnectionId = "connection_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateImportUsersRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Jobs VerificationEmail
<details><summary><code>client.Jobs.VerificationEmail.<a href="/src/Auth0.ManagementApi/Jobs/VerificationEmail/VerificationEmailClient.cs">CreateAsync</a>(CreateVerificationEmailRequestContent { ... }) -> WithRawResponseTask&lt;CreateVerificationEmailResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Send an email to the specified user that asks them to click a link to <a href="https://auth0.com/docs/email/custom#verification-email">verify their email address</a>.

Note: You must have the `Status` toggle enabled for the verification email template for the email to be sent.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Jobs.VerificationEmail.CreateAsync(
    new CreateVerificationEmailRequestContent { UserId = "user_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateVerificationEmailRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Jobs Errors
<details><summary><code>client.Jobs.Errors.<a href="/src/Auth0.ManagementApi/Jobs/Errors/ErrorsClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;ErrorsGetResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve error details of a failed job.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Jobs.Errors.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the job.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Keys CustomSigning
<details><summary><code>client.Keys.CustomSigning.<a href="/src/Auth0.ManagementApi/Keys/CustomSigning/CustomSigningClient.cs">GetAsync</a>() -> WithRawResponseTask&lt;GetCustomSigningKeysResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get entire jwks representation of custom signing keys.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Keys.CustomSigning.GetAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Keys.CustomSigning.<a href="/src/Auth0.ManagementApi/Keys/CustomSigning/CustomSigningClient.cs">SetAsync</a>(SetCustomSigningKeysRequestContent { ... }) -> WithRawResponseTask&lt;SetCustomSigningKeysResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create or replace entire jwks representation of custom signing keys.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Keys.CustomSigning.SetAsync(
    new SetCustomSigningKeysRequestContent
    {
        Keys = new List<CustomSigningKeyJwk>()
        {
            new CustomSigningKeyJwk { Kty = CustomSigningKeyTypeEnum.Ec },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `SetCustomSigningKeysRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Keys.CustomSigning.<a href="/src/Auth0.ManagementApi/Keys/CustomSigning/CustomSigningClient.cs">DeleteAsync</a>()</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete entire jwks representation of custom signing keys.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Keys.CustomSigning.DeleteAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Keys Encryption
<details><summary><code>client.Keys.Encryption.<a href="/src/Auth0.ManagementApi/Keys/Encryption/EncryptionClient.cs">ListAsync</a>(ListEncryptionKeysRequestParameters { ... }) -> Pager&lt;EncryptionKey&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details of all the encryption keys associated with your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Keys.Encryption.ListAsync(
    new ListEncryptionKeysRequestParameters
    {
        Page = 1,
        PerPage = 1,
        IncludeTotals = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListEncryptionKeysRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Keys.Encryption.<a href="/src/Auth0.ManagementApi/Keys/Encryption/EncryptionClient.cs">CreateAsync</a>(CreateEncryptionKeyRequestContent { ... }) -> WithRawResponseTask&lt;CreateEncryptionKeyResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create the new, pre-activated encryption key, without the key material.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Keys.Encryption.CreateAsync(
    new CreateEncryptionKeyRequestContent { Type = CreateEncryptionKeyType.CustomerProvidedRootKey }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateEncryptionKeyRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Keys.Encryption.<a href="/src/Auth0.ManagementApi/Keys/Encryption/EncryptionClient.cs">RekeyAsync</a>()</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Perform rekeying operation on the key hierarchy.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Keys.Encryption.RekeyAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Keys.Encryption.<a href="/src/Auth0.ManagementApi/Keys/Encryption/EncryptionClient.cs">GetAsync</a>(kid) -> WithRawResponseTask&lt;GetEncryptionKeyResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details of the encryption key with the given ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Keys.Encryption.GetAsync("kid");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**kid:** `string` — Encryption key ID
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Keys.Encryption.<a href="/src/Auth0.ManagementApi/Keys/Encryption/EncryptionClient.cs">ImportAsync</a>(kid, ImportEncryptionKeyRequestContent { ... }) -> WithRawResponseTask&lt;ImportEncryptionKeyResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Import wrapped key material and activate encryption key.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Keys.Encryption.ImportAsync(
    "kid",
    new ImportEncryptionKeyRequestContent { WrappedKey = "wrapped_key" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**kid:** `string` — Encryption key ID
    
</dd>
</dl>

<dl>
<dd>

**request:** `ImportEncryptionKeyRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Keys.Encryption.<a href="/src/Auth0.ManagementApi/Keys/Encryption/EncryptionClient.cs">DeleteAsync</a>(kid)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete the custom provided encryption key with the given ID and move back to using native encryption key.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Keys.Encryption.DeleteAsync("kid");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**kid:** `string` — Encryption key ID
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Keys.Encryption.<a href="/src/Auth0.ManagementApi/Keys/Encryption/EncryptionClient.cs">CreatePublicWrappingKeyAsync</a>(kid) -> WithRawResponseTask&lt;CreateEncryptionKeyPublicWrappingResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create the public wrapping key to wrap your own encryption key material.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Keys.Encryption.CreatePublicWrappingKeyAsync("kid");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**kid:** `string` — Encryption key ID
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Keys Signing
<details><summary><code>client.Keys.Signing.<a href="/src/Auth0.ManagementApi/Keys/Signing/SigningClient.cs">ListAsync</a>() -> WithRawResponseTask&lt;IEnumerable&lt;SigningKeys&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details of all the application signing keys associated with your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Keys.Signing.ListAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Keys.Signing.<a href="/src/Auth0.ManagementApi/Keys/Signing/SigningClient.cs">RotateAsync</a>() -> WithRawResponseTask&lt;RotateSigningKeysResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Rotate the application signing key of your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Keys.Signing.RotateAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Keys.Signing.<a href="/src/Auth0.ManagementApi/Keys/Signing/SigningClient.cs">GetAsync</a>(kid) -> WithRawResponseTask&lt;GetSigningKeysResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details of the application signing key with the given ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Keys.Signing.GetAsync("kid");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**kid:** `string` — Key id of the key to retrieve
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Keys.Signing.<a href="/src/Auth0.ManagementApi/Keys/Signing/SigningClient.cs">RevokeAsync</a>(kid) -> WithRawResponseTask&lt;RevokedSigningKeysResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Revoke the application signing key with the given ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Keys.Signing.RevokeAsync("kid");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**kid:** `string` — Key id of the key to revoke
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Organizations ClientGrants
<details><summary><code>client.Organizations.ClientGrants.<a href="/src/Auth0.ManagementApi/Organizations/ClientGrants/ClientGrantsClient.cs">ListAsync</a>(id, ListOrganizationClientGrantsRequestParameters { ... }) -> Pager&lt;OrganizationClientGrant&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.ClientGrants.ListAsync(
    "id",
    new ListOrganizationClientGrantsRequestParameters
    {
        Audience = "audience",
        ClientId = "client_id",
        Page = 1,
        PerPage = 1,
        IncludeTotals = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Organization identifier.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListOrganizationClientGrantsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.ClientGrants.<a href="/src/Auth0.ManagementApi/Organizations/ClientGrants/ClientGrantsClient.cs">CreateAsync</a>(id, AssociateOrganizationClientGrantRequestContent { ... }) -> WithRawResponseTask&lt;AssociateOrganizationClientGrantResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.ClientGrants.CreateAsync(
    "id",
    new AssociateOrganizationClientGrantRequestContent { GrantId = "grant_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Organization identifier.
    
</dd>
</dl>

<dl>
<dd>

**request:** `AssociateOrganizationClientGrantRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.ClientGrants.<a href="/src/Auth0.ManagementApi/Organizations/ClientGrants/ClientGrantsClient.cs">DeleteAsync</a>(id, grantId)</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.ClientGrants.DeleteAsync("id", "grant_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Organization identifier.
    
</dd>
</dl>

<dl>
<dd>

**grantId:** `string` — The Client Grant ID to remove from the organization
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Organizations Connections
<details><summary><code>client.Organizations.Connections.<a href="/src/Auth0.ManagementApi/Organizations/Connections/ConnectionsClient.cs">ListAsync</a>(id, ListOrganizationAllConnectionsRequestParameters { ... }) -> Pager&lt;OrganizationAllConnectionPost&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.Connections.ListAsync(
    "id",
    new ListOrganizationAllConnectionsRequestParameters
    {
        Page = 1,
        PerPage = 1,
        IncludeTotals = true,
        IsEnabled = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Organization identifier.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListOrganizationAllConnectionsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.Connections.<a href="/src/Auth0.ManagementApi/Organizations/Connections/ConnectionsClient.cs">CreateAsync</a>(id, CreateOrganizationAllConnectionRequestParameters { ... }) -> WithRawResponseTask&lt;CreateOrganizationAllConnectionResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.Connections.CreateAsync(
    "id",
    new CreateOrganizationAllConnectionRequestParameters { ConnectionId = "connection_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Organization identifier.
    
</dd>
</dl>

<dl>
<dd>

**request:** `CreateOrganizationAllConnectionRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.Connections.<a href="/src/Auth0.ManagementApi/Organizations/Connections/ConnectionsClient.cs">GetAsync</a>(id, connectionId) -> WithRawResponseTask&lt;GetOrganizationAllConnectionResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.Connections.GetAsync("id", "connection_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Organization identifier.
    
</dd>
</dl>

<dl>
<dd>

**connectionId:** `string` — Connection identifier.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.Connections.<a href="/src/Auth0.ManagementApi/Organizations/Connections/ConnectionsClient.cs">DeleteAsync</a>(id, connectionId)</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.Connections.DeleteAsync("id", "connection_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Organization identifier.
    
</dd>
</dl>

<dl>
<dd>

**connectionId:** `string` — Connection identifier.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.Connections.<a href="/src/Auth0.ManagementApi/Organizations/Connections/ConnectionsClient.cs">UpdateAsync</a>(id, connectionId, UpdateOrganizationConnectionRequestParameters { ... }) -> WithRawResponseTask&lt;UpdateOrganizationAllConnectionResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.Connections.UpdateAsync(
    "id",
    "connection_id",
    new UpdateOrganizationConnectionRequestParameters()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Organization identifier.
    
</dd>
</dl>

<dl>
<dd>

**connectionId:** `string` — Connection identifier.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateOrganizationConnectionRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Organizations DiscoveryDomains
<details><summary><code>client.Organizations.DiscoveryDomains.<a href="/src/Auth0.ManagementApi/Organizations/DiscoveryDomains/DiscoveryDomainsClient.cs">ListAsync</a>(id, ListOrganizationDiscoveryDomainsRequestParameters { ... }) -> Pager&lt;OrganizationDiscoveryDomain&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve list of all organization discovery domains associated with the specified organization.
This endpoint is subject to eventual consistency; newly created, updated, or deleted discovery domains may not immediately appear in the response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.DiscoveryDomains.ListAsync(
    "id",
    new ListOrganizationDiscoveryDomainsRequestParameters { From = "from", Take = 1 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the organization.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListOrganizationDiscoveryDomainsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.DiscoveryDomains.<a href="/src/Auth0.ManagementApi/Organizations/DiscoveryDomains/DiscoveryDomainsClient.cs">CreateAsync</a>(id, CreateOrganizationDiscoveryDomainRequestContent { ... }) -> WithRawResponseTask&lt;CreateOrganizationDiscoveryDomainResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a new discovery domain for an organization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.DiscoveryDomains.CreateAsync(
    "id",
    new CreateOrganizationDiscoveryDomainRequestContent { Domain = "domain" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the organization.
    
</dd>
</dl>

<dl>
<dd>

**request:** `CreateOrganizationDiscoveryDomainRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.DiscoveryDomains.<a href="/src/Auth0.ManagementApi/Organizations/DiscoveryDomains/DiscoveryDomainsClient.cs">GetByNameAsync</a>(id, discoveryDomain) -> WithRawResponseTask&lt;GetOrganizationDiscoveryDomainByNameResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details about a single organization discovery domain specified by domain name.
This endpoint is subject to eventual consistency; newly created, updated, or deleted discovery domains may not immediately appear in the response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.DiscoveryDomains.GetByNameAsync("id", "discovery_domain");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the organization.
    
</dd>
</dl>

<dl>
<dd>

**discoveryDomain:** `string` — Domain name of the discovery domain.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.DiscoveryDomains.<a href="/src/Auth0.ManagementApi/Organizations/DiscoveryDomains/DiscoveryDomainsClient.cs">GetAsync</a>(id, discoveryDomainId) -> WithRawResponseTask&lt;GetOrganizationDiscoveryDomainResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details about a single organization discovery domain specified by ID.
This endpoint is subject to eventual consistency; newly created, updated, or deleted discovery domains may not immediately appear in the response.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.DiscoveryDomains.GetAsync("id", "discovery_domain_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the organization.
    
</dd>
</dl>

<dl>
<dd>

**discoveryDomainId:** `string` — ID of the discovery domain.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.DiscoveryDomains.<a href="/src/Auth0.ManagementApi/Organizations/DiscoveryDomains/DiscoveryDomainsClient.cs">DeleteAsync</a>(id, discoveryDomainId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Remove a discovery domain from an organization. This action cannot be undone. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.DiscoveryDomains.DeleteAsync("id", "discovery_domain_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the organization.
    
</dd>
</dl>

<dl>
<dd>

**discoveryDomainId:** `string` — ID of the discovery domain.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.DiscoveryDomains.<a href="/src/Auth0.ManagementApi/Organizations/DiscoveryDomains/DiscoveryDomainsClient.cs">UpdateAsync</a>(id, discoveryDomainId, UpdateOrganizationDiscoveryDomainRequestContent { ... }) -> WithRawResponseTask&lt;UpdateOrganizationDiscoveryDomainResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update the verification status and/or use_for_organization_discovery for an organization discovery domain. The <code>status</code> field must be either <code>pending</code> or <code>verified</code>. The <code>use_for_organization_discovery</code> field can be <code>true</code> or <code>false</code> (default: <code>true</code>).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.DiscoveryDomains.UpdateAsync(
    "id",
    "discovery_domain_id",
    new UpdateOrganizationDiscoveryDomainRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the organization.
    
</dd>
</dl>

<dl>
<dd>

**discoveryDomainId:** `string` — ID of the discovery domain to update.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateOrganizationDiscoveryDomainRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Organizations EnabledConnections
<details><summary><code>client.Organizations.EnabledConnections.<a href="/src/Auth0.ManagementApi/Organizations/EnabledConnections/EnabledConnectionsClient.cs">ListAsync</a>(id, ListOrganizationConnectionsRequestParameters { ... }) -> Pager&lt;OrganizationConnection&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details about a specific connection currently enabled for an Organization. Information returned includes details such as connection ID, name, strategy, and whether the connection automatically grants membership upon login.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.EnabledConnections.ListAsync(
    "id",
    new ListOrganizationConnectionsRequestParameters
    {
        Page = 1,
        PerPage = 1,
        IncludeTotals = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Organization identifier.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListOrganizationConnectionsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.EnabledConnections.<a href="/src/Auth0.ManagementApi/Organizations/EnabledConnections/EnabledConnectionsClient.cs">AddAsync</a>(id, AddOrganizationConnectionRequestContent { ... }) -> WithRawResponseTask&lt;AddOrganizationConnectionResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Enable a specific connection for a given Organization. To enable a connection, it must already exist within your tenant; connections cannot be created through this action.

<a href="https://auth0.com/docs/authenticate/identity-providers">Connections</a> represent the relationship between Auth0 and a source of users. Available types of connections include database, enterprise, and social.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.EnabledConnections.AddAsync(
    "id",
    new AddOrganizationConnectionRequestContent { ConnectionId = "connection_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Organization identifier.
    
</dd>
</dl>

<dl>
<dd>

**request:** `AddOrganizationConnectionRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.EnabledConnections.<a href="/src/Auth0.ManagementApi/Organizations/EnabledConnections/EnabledConnectionsClient.cs">GetAsync</a>(id, connectionId) -> WithRawResponseTask&lt;GetOrganizationConnectionResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details about a specific connection currently enabled for an Organization. Information returned includes details such as connection ID, name, strategy, and whether the connection automatically grants membership upon login.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.EnabledConnections.GetAsync("id", "connectionId");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Organization identifier.
    
</dd>
</dl>

<dl>
<dd>

**connectionId:** `string` — Connection identifier.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.EnabledConnections.<a href="/src/Auth0.ManagementApi/Organizations/EnabledConnections/EnabledConnectionsClient.cs">DeleteAsync</a>(id, connectionId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Disable a specific connection for an Organization. Once disabled, Organization members can no longer use that connection to authenticate. 

<b>Note</b>: This action does not remove the connection from your tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.EnabledConnections.DeleteAsync("id", "connectionId");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Organization identifier.
    
</dd>
</dl>

<dl>
<dd>

**connectionId:** `string` — Connection identifier.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.EnabledConnections.<a href="/src/Auth0.ManagementApi/Organizations/EnabledConnections/EnabledConnectionsClient.cs">UpdateAsync</a>(id, connectionId, UpdateOrganizationConnectionRequestContent { ... }) -> WithRawResponseTask&lt;UpdateOrganizationConnectionResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Modify the details of a specific connection currently enabled for an Organization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.EnabledConnections.UpdateAsync(
    "id",
    "connectionId",
    new UpdateOrganizationConnectionRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Organization identifier.
    
</dd>
</dl>

<dl>
<dd>

**connectionId:** `string` — Connection identifier.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateOrganizationConnectionRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Organizations Invitations
<details><summary><code>client.Organizations.Invitations.<a href="/src/Auth0.ManagementApi/Organizations/Invitations/InvitationsClient.cs">ListAsync</a>(id, ListOrganizationInvitationsRequestParameters { ... }) -> Pager&lt;OrganizationInvitation&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a detailed list of invitations sent to users for a specific Organization. The list includes details such as inviter and invitee information, invitation URLs, and dates of creation and expiration. To learn more about Organization invitations, review <a href="https://auth0.com/docs/manage-users/organizations/configure-organizations/invite-members">Invite Organization Members</a>. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.Invitations.ListAsync(
    "id",
    new ListOrganizationInvitationsRequestParameters
    {
        Page = 1,
        PerPage = 1,
        IncludeTotals = true,
        Fields = "fields",
        IncludeFields = true,
        Sort = "sort",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Organization identifier.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListOrganizationInvitationsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.Invitations.<a href="/src/Auth0.ManagementApi/Organizations/Invitations/InvitationsClient.cs">CreateAsync</a>(id, CreateOrganizationInvitationRequestContent { ... }) -> WithRawResponseTask&lt;CreateOrganizationInvitationResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a user invitation for a specific Organization. Upon creation, the listed user receives an email inviting them to join the Organization. To learn more about Organization invitations, review <a href="https://auth0.com/docs/manage-users/organizations/configure-organizations/invite-members">Invite Organization Members</a>. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.Invitations.CreateAsync(
    "id",
    new CreateOrganizationInvitationRequestContent
    {
        Inviter = new OrganizationInvitationInviter { Name = "name" },
        Invitee = new OrganizationInvitationInvitee { Email = "email" },
        ClientId = "client_id",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Organization identifier.
    
</dd>
</dl>

<dl>
<dd>

**request:** `CreateOrganizationInvitationRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.Invitations.<a href="/src/Auth0.ManagementApi/Organizations/Invitations/InvitationsClient.cs">GetAsync</a>(id, invitationId, GetOrganizationInvitationRequestParameters { ... }) -> WithRawResponseTask&lt;GetOrganizationInvitationResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.Invitations.GetAsync(
    "id",
    "invitation_id",
    new GetOrganizationInvitationRequestParameters { Fields = "fields", IncludeFields = true }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Organization identifier.
    
</dd>
</dl>

<dl>
<dd>

**invitationId:** `string` — The id of the user invitation.
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetOrganizationInvitationRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.Invitations.<a href="/src/Auth0.ManagementApi/Organizations/Invitations/InvitationsClient.cs">DeleteAsync</a>(id, invitationId)</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.Invitations.DeleteAsync("id", "invitation_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Organization identifier.
    
</dd>
</dl>

<dl>
<dd>

**invitationId:** `string` — The id of the user invitation.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Organizations Members
<details><summary><code>client.Organizations.Members.<a href="/src/Auth0.ManagementApi/Organizations/Members/MembersClient.cs">ListAsync</a>(id, ListOrganizationMembersRequestParameters { ... }) -> Pager&lt;OrganizationMember&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List organization members.
This endpoint is subject to eventual consistency. New users may not be immediately included in the response and deleted users may not be immediately removed from it.

<ul>
  <li>
    Use the <code>fields</code> parameter to optionally define the specific member details retrieved. If <code>fields</code> is left blank, all fields (except roles) are returned.
  </li>
  <li>
    Member roles are not sent by default. Use <code>fields=roles</code> to retrieve the roles assigned to each listed member. To use this parameter, you must include the <code>read:organization_member_roles</code> scope in the token.
  </li>
</ul>

This endpoint supports two types of pagination:

- Offset pagination
- Checkpoint pagination

Checkpoint pagination must be used if you need to retrieve more than 1000 organization members.

<h2>Checkpoint Pagination</h2>

To search by checkpoint, use the following parameters: - from: Optional id from which to start selection. - take: The total amount of entries to retrieve when using the from parameter. Defaults to 50. Note: The first time you call this endpoint using Checkpoint Pagination, you should omit the <code>from</code> parameter. If there are more results, a <code>next</code> value will be included in the response. You can use this for subsequent API calls. When <code>next</code> is no longer included in the response, this indicates there are no more pages remaining.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.Members.ListAsync(
    "id",
    new ListOrganizationMembersRequestParameters
    {
        From = "from",
        Take = 1,
        Fields = "fields",
        IncludeFields = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Organization identifier.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListOrganizationMembersRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.Members.<a href="/src/Auth0.ManagementApi/Organizations/Members/MembersClient.cs">CreateAsync</a>(id, CreateOrganizationMemberRequestContent { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Set one or more existing users as members of a specific <a href="https://auth0.com/docs/manage-users/organizations">Organization</a>.

To add a user to an Organization through this action, the user must already exist in your tenant. If a user does not yet exist, you can <a href="https://auth0.com/docs/manage-users/organizations/configure-organizations/invite-members">invite them to create an account</a>, manually create them through the Auth0 Dashboard, or use the Management API.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.Members.CreateAsync(
    "id",
    new CreateOrganizationMemberRequestContent { Members = new List<string>() { "members" } }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Organization identifier.
    
</dd>
</dl>

<dl>
<dd>

**request:** `CreateOrganizationMemberRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.Members.<a href="/src/Auth0.ManagementApi/Organizations/Members/MembersClient.cs">DeleteAsync</a>(id, DeleteOrganizationMembersRequestContent { ... })</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.Members.DeleteAsync(
    "id",
    new DeleteOrganizationMembersRequestContent { Members = new List<string>() { "members" } }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Organization identifier.
    
</dd>
</dl>

<dl>
<dd>

**request:** `DeleteOrganizationMembersRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Organizations Members Roles
<details><summary><code>client.Organizations.Members.Roles.<a href="/src/Auth0.ManagementApi/Organizations/Members/Roles/RolesClient.cs">ListAsync</a>(id, userId, ListOrganizationMemberRolesRequestParameters { ... }) -> Pager&lt;Role&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve detailed list of roles assigned to a given user within the context of a specific Organization. 

Users can be members of multiple Organizations with unique roles assigned for each membership. This action only returns the roles associated with the specified Organization; any roles assigned to the user within other Organizations are not included.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.Members.Roles.ListAsync(
    "id",
    "user_id",
    new ListOrganizationMemberRolesRequestParameters
    {
        Page = 1,
        PerPage = 1,
        IncludeTotals = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Organization identifier.
    
</dd>
</dl>

<dl>
<dd>

**userId:** `string` — ID of the user to associate roles with.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListOrganizationMemberRolesRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.Members.Roles.<a href="/src/Auth0.ManagementApi/Organizations/Members/Roles/RolesClient.cs">AssignAsync</a>(id, userId, AssignOrganizationMemberRolesRequestContent { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Assign one or more <a href="https://auth0.com/docs/manage-users/access-control/rbac">roles</a> to a user to determine their access for a specific Organization.

Users can be members of multiple Organizations with unique roles assigned for each membership. This action assigns roles to a user only for the specified Organization. Roles cannot be assigned to a user across multiple Organizations in the same call.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.Members.Roles.AssignAsync(
    "id",
    "user_id",
    new AssignOrganizationMemberRolesRequestContent { Roles = new List<string>() { "roles" } }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Organization identifier.
    
</dd>
</dl>

<dl>
<dd>

**userId:** `string` — ID of the user to associate roles with.
    
</dd>
</dl>

<dl>
<dd>

**request:** `AssignOrganizationMemberRolesRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Organizations.Members.Roles.<a href="/src/Auth0.ManagementApi/Organizations/Members/Roles/RolesClient.cs">DeleteAsync</a>(id, userId, DeleteOrganizationMemberRolesRequestContent { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Remove one or more Organization-specific <a href="https://auth0.com/docs/manage-users/access-control/rbac">roles</a> from a given user.

Users can be members of multiple Organizations with unique roles assigned for each membership. This action removes roles from a user in relation to the specified Organization. Roles assigned to the user within a different Organization cannot be managed in the same call.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Organizations.Members.Roles.DeleteAsync(
    "id",
    "user_id",
    new DeleteOrganizationMemberRolesRequestContent { Roles = new List<string>() { "roles" } }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Organization identifier.
    
</dd>
</dl>

<dl>
<dd>

**userId:** `string` — User ID of the organization member to remove roles from.
    
</dd>
</dl>

<dl>
<dd>

**request:** `DeleteOrganizationMemberRolesRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Prompts Rendering
<details><summary><code>client.Prompts.Rendering.<a href="/src/Auth0.ManagementApi/Prompts/Rendering/RenderingClient.cs">ListAsync</a>(ListAculsRequestParameters { ... }) -> Pager&lt;ListAculsResponseContentItem&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get render setting configurations for all screens.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Prompts.Rendering.ListAsync(
    new ListAculsRequestParameters
    {
        Fields = "fields",
        IncludeFields = true,
        Page = 1,
        PerPage = 1,
        IncludeTotals = true,
        Prompt = "prompt",
        Screen = "screen",
        RenderingMode = AculRenderingModeEnum.Advanced,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListAculsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Prompts.Rendering.<a href="/src/Auth0.ManagementApi/Prompts/Rendering/RenderingClient.cs">BulkUpdateAsync</a>(BulkUpdateAculRequestContent { ... }) -> WithRawResponseTask&lt;BulkUpdateAculResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Learn more about <a href='https://auth0.com/docs/customize/login-pages/advanced-customizations/getting-started/configure-acul-screens'>configuring render settings</a> for advanced customization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Prompts.Rendering.BulkUpdateAsync(
    new BulkUpdateAculRequestContent
    {
        Configs = new List<AculConfigsItem>()
        {
            new AculConfigsItem
            {
                Prompt = PromptGroupNameEnum.Login,
                Screen = ScreenGroupNameEnum.Login,
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BulkUpdateAculRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Prompts.Rendering.<a href="/src/Auth0.ManagementApi/Prompts/Rendering/RenderingClient.cs">GetAsync</a>(prompt, screen) -> WithRawResponseTask&lt;GetAculResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get render settings for a screen.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Prompts.Rendering.GetAsync(PromptGroupNameEnum.Login, ScreenGroupNameEnum.Login);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**prompt:** `PromptGroupNameEnum` — Name of the prompt
    
</dd>
</dl>

<dl>
<dd>

**screen:** `ScreenGroupNameEnum` — Name of the screen
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Prompts.Rendering.<a href="/src/Auth0.ManagementApi/Prompts/Rendering/RenderingClient.cs">UpdateAsync</a>(prompt, screen, UpdateAculRequestContent { ... }) -> WithRawResponseTask&lt;UpdateAculResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Learn more about <a href='https://auth0.com/docs/customize/login-pages/advanced-customizations/getting-started/configure-acul-screens'>configuring render settings</a> for advanced customization.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Prompts.Rendering.UpdateAsync(
    PromptGroupNameEnum.Login,
    ScreenGroupNameEnum.Login,
    new UpdateAculRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**prompt:** `PromptGroupNameEnum` — Name of the prompt
    
</dd>
</dl>

<dl>
<dd>

**screen:** `ScreenGroupNameEnum` — Name of the screen
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateAculRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Prompts CustomText
<details><summary><code>client.Prompts.CustomText.<a href="/src/Auth0.ManagementApi/Prompts/CustomText/CustomTextClient.cs">GetAsync</a>(prompt, language) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve custom text for a specific prompt and language.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Prompts.CustomText.GetAsync(PromptGroupNameEnum.Login, PromptLanguageEnum.Am);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**prompt:** `PromptGroupNameEnum` — Name of the prompt.
    
</dd>
</dl>

<dl>
<dd>

**language:** `PromptLanguageEnum` — Language to update.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Prompts.CustomText.<a href="/src/Auth0.ManagementApi/Prompts/CustomText/CustomTextClient.cs">SetAsync</a>(prompt, language, Dictionary&lt;string, object?&gt; { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Set custom text for a specific prompt. Existing texts will be overwritten.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Prompts.CustomText.SetAsync(
    PromptGroupNameEnum.Login,
    PromptLanguageEnum.Am,
    new Dictionary<string, object?>() { { "key", "value" } }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**prompt:** `PromptGroupNameEnum` — Name of the prompt.
    
</dd>
</dl>

<dl>
<dd>

**language:** `PromptLanguageEnum` — Language to update.
    
</dd>
</dl>

<dl>
<dd>

**request:** `Dictionary<string, object?>` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Prompts Partials
<details><summary><code>client.Prompts.Partials.<a href="/src/Auth0.ManagementApi/Prompts/Partials/PartialsClient.cs">GetAsync</a>(prompt) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get template partials for a prompt
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Prompts.Partials.GetAsync(PartialGroupsEnum.Login);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**prompt:** `PartialGroupsEnum` — Name of the prompt.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Prompts.Partials.<a href="/src/Auth0.ManagementApi/Prompts/Partials/PartialsClient.cs">SetAsync</a>(prompt, Dictionary&lt;string, object?&gt; { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Set template partials for a prompt
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Prompts.Partials.SetAsync(
    PartialGroupsEnum.Login,
    new Dictionary<string, object?>() { { "key", "value" } }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**prompt:** `PartialGroupsEnum` — Name of the prompt.
    
</dd>
</dl>

<dl>
<dd>

**request:** `Dictionary<string, object?>` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## RiskAssessments Settings
<details><summary><code>client.RiskAssessments.Settings.<a href="/src/Auth0.ManagementApi/RiskAssessments/Settings/SettingsClient.cs">GetAsync</a>() -> WithRawResponseTask&lt;GetRiskAssessmentsSettingsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Gets the tenant settings for risk assessments
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.RiskAssessments.Settings.GetAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.RiskAssessments.Settings.<a href="/src/Auth0.ManagementApi/RiskAssessments/Settings/SettingsClient.cs">UpdateAsync</a>(UpdateRiskAssessmentsSettingsRequestContent { ... }) -> WithRawResponseTask&lt;UpdateRiskAssessmentsSettingsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates the tenant settings for risk assessments
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.RiskAssessments.Settings.UpdateAsync(
    new UpdateRiskAssessmentsSettingsRequestContent { Enabled = true }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateRiskAssessmentsSettingsRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## RiskAssessments Settings NewDevice
<details><summary><code>client.RiskAssessments.Settings.NewDevice.<a href="/src/Auth0.ManagementApi/RiskAssessments/Settings/NewDevice/NewDeviceClient.cs">GetAsync</a>() -> WithRawResponseTask&lt;GetRiskAssessmentsSettingsNewDeviceResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Gets the risk assessment settings for the new device assessor
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.RiskAssessments.Settings.NewDevice.GetAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.RiskAssessments.Settings.NewDevice.<a href="/src/Auth0.ManagementApi/RiskAssessments/Settings/NewDevice/NewDeviceClient.cs">UpdateAsync</a>(UpdateRiskAssessmentsSettingsNewDeviceRequestContent { ... }) -> WithRawResponseTask&lt;UpdateRiskAssessmentsSettingsNewDeviceResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates the risk assessment settings for the new device assessor
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.RiskAssessments.Settings.NewDevice.UpdateAsync(
    new UpdateRiskAssessmentsSettingsNewDeviceRequestContent { RememberFor = 1 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateRiskAssessmentsSettingsNewDeviceRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Roles Permissions
<details><summary><code>client.Roles.Permissions.<a href="/src/Auth0.ManagementApi/Roles/Permissions/PermissionsClient.cs">ListAsync</a>(id, ListRolePermissionsRequestParameters { ... }) -> Pager&lt;PermissionsResponsePayload&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve detailed list (name, description, resource server) of permissions granted by a specified user role.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Roles.Permissions.ListAsync(
    "id",
    new ListRolePermissionsRequestParameters
    {
        PerPage = 1,
        Page = 1,
        IncludeTotals = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the role to list granted permissions.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListRolePermissionsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Roles.Permissions.<a href="/src/Auth0.ManagementApi/Roles/Permissions/PermissionsClient.cs">AddAsync</a>(id, AddRolePermissionsRequestContent { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Add one or more <a href="https://auth0.com/docs/manage-users/access-control/configure-core-rbac/manage-permissions">permissions</a> to a specified user role.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Roles.Permissions.AddAsync(
    "id",
    new AddRolePermissionsRequestContent
    {
        Permissions = new List<PermissionRequestPayload>()
        {
            new PermissionRequestPayload
            {
                ResourceServerIdentifier = "resource_server_identifier",
                PermissionName = "permission_name",
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the role to add permissions to.
    
</dd>
</dl>

<dl>
<dd>

**request:** `AddRolePermissionsRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Roles.Permissions.<a href="/src/Auth0.ManagementApi/Roles/Permissions/PermissionsClient.cs">DeleteAsync</a>(id, DeleteRolePermissionsRequestContent { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Remove one or more <a href="https://auth0.com/docs/manage-users/access-control/configure-core-rbac/manage-permissions">permissions</a> from a specified user role.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Roles.Permissions.DeleteAsync(
    "id",
    new DeleteRolePermissionsRequestContent
    {
        Permissions = new List<PermissionRequestPayload>()
        {
            new PermissionRequestPayload
            {
                ResourceServerIdentifier = "resource_server_identifier",
                PermissionName = "permission_name",
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the role to remove permissions from.
    
</dd>
</dl>

<dl>
<dd>

**request:** `DeleteRolePermissionsRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Roles Users
<details><summary><code>client.Roles.Users.<a href="/src/Auth0.ManagementApi/Roles/Users/UsersClient.cs">ListAsync</a>(id, ListRoleUsersRequestParameters { ... }) -> Pager&lt;RoleUser&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve list of users associated with a specific role. For Dashboard instructions, review <a href="https://auth0.com/docs/manage-users/access-control/configure-core-rbac/roles/view-users-assigned-to-roles">View Users Assigned to Roles</a>.

This endpoint supports two types of pagination:
<ul>
<li>Offset pagination</li>
<li>Checkpoint pagination</li>
</ul>

Checkpoint pagination must be used if you need to retrieve more than 1000 organization members.

<h2>Checkpoint Pagination</h2>

To search by checkpoint, use the following parameters:
<ul>
<li><code>from</code>: Optional id from which to start selection.</li>
<li><code>take</code>: The total amount of entries to retrieve when using the from parameter. Defaults to 50.</li>
</ul>

<b>Note</b>: The first time you call this endpoint using checkpoint pagination, omit the <code>from</code> parameter. If there are more results, a <code>next</code> value is included in the response. You can use this for subsequent API calls. When <code>next</code> is no longer included in the response, no pages are remaining.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Roles.Users.ListAsync(
    "id",
    new ListRoleUsersRequestParameters { From = "from", Take = 1 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the role to retrieve a list of users associated with.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListRoleUsersRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Roles.Users.<a href="/src/Auth0.ManagementApi/Roles/Users/UsersClient.cs">AssignAsync</a>(id, AssignRoleUsersRequestContent { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Assign one or more users to an existing user role. To learn more, review <a href="https://auth0.com/docs/manage-users/access-control/rbac">Role-Based Access Control</a>.

<b>Note</b>: New roles cannot be created through this action.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Roles.Users.AssignAsync(
    "id",
    new AssignRoleUsersRequestContent { Users = new List<string>() { "users" } }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the role to assign users to.
    
</dd>
</dl>

<dl>
<dd>

**request:** `AssignRoleUsersRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## SelfServiceProfiles CustomText
<details><summary><code>client.SelfServiceProfiles.CustomText.<a href="/src/Auth0.ManagementApi/SelfServiceProfiles/CustomText/CustomTextClient.cs">ListAsync</a>(id, language, page) -> WithRawResponseTask&lt;Dictionary&lt;string, string&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieves text customizations for a given self-service profile, language and Self Service SSO Flow page.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SelfServiceProfiles.CustomText.ListAsync(
    "id",
    SelfServiceProfileCustomTextLanguageEnum.En,
    SelfServiceProfileCustomTextPageEnum.GetStarted
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the self-service profile.
    
</dd>
</dl>

<dl>
<dd>

**language:** `SelfServiceProfileCustomTextLanguageEnum` — The language of the custom text.
    
</dd>
</dl>

<dl>
<dd>

**page:** `SelfServiceProfileCustomTextPageEnum` — The page where the custom text is shown.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.SelfServiceProfiles.CustomText.<a href="/src/Auth0.ManagementApi/SelfServiceProfiles/CustomText/CustomTextClient.cs">SetAsync</a>(id, language, page, Dictionary&lt;string, string&gt; { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, string&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Updates text customizations for a given self-service profile, language and Self Service SSO Flow page.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SelfServiceProfiles.CustomText.SetAsync(
    "id",
    SelfServiceProfileCustomTextLanguageEnum.En,
    SelfServiceProfileCustomTextPageEnum.GetStarted,
    new Dictionary<string, string>() { { "key", "value" } }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the self-service profile.
    
</dd>
</dl>

<dl>
<dd>

**language:** `SelfServiceProfileCustomTextLanguageEnum` — The language of the custom text.
    
</dd>
</dl>

<dl>
<dd>

**page:** `SelfServiceProfileCustomTextPageEnum` — The page where the custom text is shown.
    
</dd>
</dl>

<dl>
<dd>

**request:** `Dictionary<string, string>` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## SelfServiceProfiles SsoTicket
<details><summary><code>client.SelfServiceProfiles.SsoTicket.<a href="/src/Auth0.ManagementApi/SelfServiceProfiles/SsoTicket/SsoTicketClient.cs">CreateAsync</a>(id, CreateSelfServiceProfileSsoTicketRequestContent { ... }) -> WithRawResponseTask&lt;CreateSelfServiceProfileSsoTicketResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates an SSO access ticket to initiate the Self Service SSO Flow using a self-service profile.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SelfServiceProfiles.SsoTicket.CreateAsync(
    "id",
    new CreateSelfServiceProfileSsoTicketRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The id of the self-service profile to retrieve
    
</dd>
</dl>

<dl>
<dd>

**request:** `CreateSelfServiceProfileSsoTicketRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.SelfServiceProfiles.SsoTicket.<a href="/src/Auth0.ManagementApi/SelfServiceProfiles/SsoTicket/SsoTicketClient.cs">RevokeAsync</a>(profileId, id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Revokes an SSO access ticket and invalidates associated sessions. The ticket will no longer be accepted to initiate a Self-Service SSO session. If any users have already started a session through this ticket, their session will be terminated. Clients should expect a `202 Accepted` response upon successful processing, indicating that the request has been acknowledged and that the revocation is underway but may not be fully completed at the time of response. If the specified ticket does not exist, a `202 Accepted` response is also returned, signaling that no further action is required.
Clients should treat these `202` responses as an acknowledgment that the request has been accepted and is in progress, even if the ticket was not found.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.SelfServiceProfiles.SsoTicket.RevokeAsync("profileId", "id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**profileId:** `string` — The id of the self-service profile
    
</dd>
</dl>

<dl>
<dd>

**id:** `string` — The id of the ticket to revoke
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Tenants Settings
<details><summary><code>client.Tenants.Settings.<a href="/src/Auth0.ManagementApi/Tenants/Settings/SettingsClient.cs">GetAsync</a>(GetTenantSettingsRequestParameters { ... }) -> WithRawResponseTask&lt;GetTenantSettingsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve tenant settings. A list of fields to include or exclude may also be specified.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Tenants.Settings.GetAsync(
    new GetTenantSettingsRequestParameters { Fields = "fields", IncludeFields = true }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetTenantSettingsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Tenants.Settings.<a href="/src/Auth0.ManagementApi/Tenants/Settings/SettingsClient.cs">UpdateAsync</a>(UpdateTenantSettingsRequestContent { ... }) -> WithRawResponseTask&lt;UpdateTenantSettingsResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update settings for a tenant.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Tenants.Settings.UpdateAsync(new UpdateTenantSettingsRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateTenantSettingsRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Users AuthenticationMethods
<details><summary><code>client.Users.AuthenticationMethods.<a href="/src/Auth0.ManagementApi/Users/AuthenticationMethods/AuthenticationMethodsClient.cs">ListAsync</a>(id, ListUserAuthenticationMethodsRequestParameters { ... }) -> Pager&lt;UserAuthenticationMethod&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve detailed list of authentication methods associated with a specified user.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.AuthenticationMethods.ListAsync(
    "id",
    new ListUserAuthenticationMethodsRequestParameters
    {
        Page = 1,
        PerPage = 1,
        IncludeTotals = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The ID of the user in question.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListUserAuthenticationMethodsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.AuthenticationMethods.<a href="/src/Auth0.ManagementApi/Users/AuthenticationMethods/AuthenticationMethodsClient.cs">CreateAsync</a>(id, CreateUserAuthenticationMethodRequestContent { ... }) -> WithRawResponseTask&lt;CreateUserAuthenticationMethodResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create an authentication method. Authentication methods created via this endpoint will be auto confirmed and should already have verification completed.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.AuthenticationMethods.CreateAsync(
    "id",
    new CreateUserAuthenticationMethodRequestContent
    {
        Type = CreatedUserAuthenticationMethodTypeEnum.Phone,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The ID of the user to whom the new authentication method will be assigned.
    
</dd>
</dl>

<dl>
<dd>

**request:** `CreateUserAuthenticationMethodRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.AuthenticationMethods.<a href="/src/Auth0.ManagementApi/Users/AuthenticationMethods/AuthenticationMethodsClient.cs">SetAsync</a>(id, IEnumerable&lt;SetUserAuthenticationMethods&gt; { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;SetUserAuthenticationMethodResponseContent&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Replace the specified user <a href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors"> authentication methods</a> with supplied values.

    <b>Note</b>: Authentication methods supplied through this action do not iterate on existing methods. Instead, any methods passed will overwrite the user&#8217s existing settings.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.AuthenticationMethods.SetAsync(
    "id",
    new List<SetUserAuthenticationMethods>()
    {
        new SetUserAuthenticationMethods { Type = AuthenticationTypeEnum.Phone },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The ID of the user in question.
    
</dd>
</dl>

<dl>
<dd>

**request:** `IEnumerable<SetUserAuthenticationMethods>` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.AuthenticationMethods.<a href="/src/Auth0.ManagementApi/Users/AuthenticationMethods/AuthenticationMethodsClient.cs">DeleteAllAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Remove all authentication methods (i.e., enrolled MFA factors) from the specified user account. This action cannot be undone. 
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.AuthenticationMethods.DeleteAllAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The ID of the user in question.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.AuthenticationMethods.<a href="/src/Auth0.ManagementApi/Users/AuthenticationMethods/AuthenticationMethodsClient.cs">GetAsync</a>(id, authenticationMethodId) -> WithRawResponseTask&lt;GetUserAuthenticationMethodResponseContent&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.AuthenticationMethods.GetAsync("id", "authentication_method_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The ID of the user in question.
    
</dd>
</dl>

<dl>
<dd>

**authenticationMethodId:** `string` — The ID of the authentication methods in question.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.AuthenticationMethods.<a href="/src/Auth0.ManagementApi/Users/AuthenticationMethods/AuthenticationMethodsClient.cs">DeleteAsync</a>(id, authenticationMethodId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Remove the authentication method with the given ID from the specified user. For more information, review <a href="https://auth0.com/docs/secure/multi-factor-authentication/manage-mfa-auth0-apis/manage-authentication-methods-with-management-api">Manage Authentication Methods with Management API</a>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.AuthenticationMethods.DeleteAsync("id", "authentication_method_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The ID of the user in question.
    
</dd>
</dl>

<dl>
<dd>

**authenticationMethodId:** `string` — The ID of the authentication method to delete.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.AuthenticationMethods.<a href="/src/Auth0.ManagementApi/Users/AuthenticationMethods/AuthenticationMethodsClient.cs">UpdateAsync</a>(id, authenticationMethodId, UpdateUserAuthenticationMethodRequestContent { ... }) -> WithRawResponseTask&lt;UpdateUserAuthenticationMethodResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Modify the authentication method with the given ID from the specified user. For more information, review <a href="https://auth0.com/docs/secure/multi-factor-authentication/manage-mfa-auth0-apis/manage-authentication-methods-with-management-api">Manage Authentication Methods with Management API</a>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.AuthenticationMethods.UpdateAsync(
    "id",
    "authentication_method_id",
    new UpdateUserAuthenticationMethodRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — The ID of the user in question.
    
</dd>
</dl>

<dl>
<dd>

**authenticationMethodId:** `string` — The ID of the authentication method to update.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateUserAuthenticationMethodRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Users Authenticators
<details><summary><code>client.Users.Authenticators.<a href="/src/Auth0.ManagementApi/Users/Authenticators/AuthenticatorsClient.cs">DeleteAllAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Remove all authenticators registered to a given user ID, such as OTP, email, phone, and push-notification. This action cannot be undone. For more information, review <a href="https://auth0.com/docs/secure/multi-factor-authentication/manage-mfa-auth0-apis/manage-authentication-methods-with-management-api">Manage Authentication Methods with Management API</a>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Authenticators.DeleteAllAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the user to delete.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Users ConnectedAccounts
<details><summary><code>client.Users.ConnectedAccounts.<a href="/src/Auth0.ManagementApi/Users/ConnectedAccounts/ConnectedAccountsClient.cs">ListAsync</a>(id, GetUserConnectedAccountsRequestParameters { ... }) -> Pager&lt;ConnectedAccount&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all connected accounts associated with the user.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.ConnectedAccounts.ListAsync(
    "id",
    new GetUserConnectedAccountsRequestParameters { From = "from", Take = 1 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the user to list connected accounts for.
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetUserConnectedAccountsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Users Enrollments
<details><summary><code>client.Users.Enrollments.<a href="/src/Auth0.ManagementApi/Users/Enrollments/EnrollmentsClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;IEnumerable&lt;UsersEnrollment&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve the first <a href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors">multi-factor authentication</a> enrollment that a specific user has confirmed.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Enrollments.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the user to list enrollments for.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Users FederatedConnectionsTokensets
<details><summary><code>client.Users.FederatedConnectionsTokensets.<a href="/src/Auth0.ManagementApi/Users/FederatedConnectionsTokensets/FederatedConnectionsTokensetsClient.cs">ListAsync</a>(id) -> WithRawResponseTask&lt;IEnumerable&lt;FederatedConnectionTokenSet&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List active federated connections tokensets for a provided user
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.FederatedConnectionsTokensets.ListAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — User identifier
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.FederatedConnectionsTokensets.<a href="/src/Auth0.ManagementApi/Users/FederatedConnectionsTokensets/FederatedConnectionsTokensetsClient.cs">DeleteAsync</a>(id, tokensetId)</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.FederatedConnectionsTokensets.DeleteAsync("id", "tokenset_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — Id of the user that owns the tokenset
    
</dd>
</dl>

<dl>
<dd>

**tokensetId:** `string` — The tokenset id
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Users Groups
<details><summary><code>client.Users.Groups.<a href="/src/Auth0.ManagementApi/Users/Groups/GroupsClient.cs">GetAsync</a>(id, GetUserGroupsRequestParameters { ... }) -> Pager&lt;UserGroupsResponseSchema&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List all groups to which this user belongs.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Groups.GetAsync(
    "id",
    new GetUserGroupsRequestParameters
    {
        Fields = "fields",
        IncludeFields = true,
        From = "from",
        Take = 1,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the user to list groups for.
    
</dd>
</dl>

<dl>
<dd>

**request:** `GetUserGroupsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Users Identities
<details><summary><code>client.Users.Identities.<a href="/src/Auth0.ManagementApi/Users/Identities/IdentitiesClient.cs">LinkAsync</a>(id, LinkUserIdentityRequestContent { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;UserIdentity&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Link two user accounts together forming a primary and secondary relationship. On successful linking, the endpoint returns the new array of the primary account identities.

Note: There are two ways of invoking the endpoint:

<ul>
  <li>With the authenticated primary account's JWT in the Authorization header, which has the <code>update:current_user_identities</code> scope:
    <pre>
      POST /api/v2/users/PRIMARY_ACCOUNT_USER_ID/identities
      Authorization: "Bearer PRIMARY_ACCOUNT_JWT"
      {
        "link_with": "SECONDARY_ACCOUNT_JWT"
      }
    </pre>
    In this case, only the <code>link_with</code> param is required in the body, which also contains the JWT obtained upon the secondary account's authentication.
  </li>
  <li>With a token generated by the API V2 containing the <code>update:users</code> scope:
    <pre>
    POST /api/v2/users/PRIMARY_ACCOUNT_USER_ID/identities
    Authorization: "Bearer YOUR_API_V2_TOKEN"
    {
      "provider": "SECONDARY_ACCOUNT_PROVIDER",
      "connection_id": "SECONDARY_ACCOUNT_CONNECTION_ID(OPTIONAL)",
      "user_id": "SECONDARY_ACCOUNT_USER_ID"
    }
    </pre>
    In this case you need to send <code>provider</code> and <code>user_id</code> in the body. Optionally you can also send the <code>connection_id</code> param which is suitable for identifying a particular database connection for the 'auth0' provider.
  </li>
</ul>
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Identities.LinkAsync("id", new LinkUserIdentityRequestContent());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the primary user account to link a second user account to.
    
</dd>
</dl>

<dl>
<dd>

**request:** `LinkUserIdentityRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.Identities.<a href="/src/Auth0.ManagementApi/Users/Identities/IdentitiesClient.cs">DeleteAsync</a>(id, provider, userId) -> WithRawResponseTask&lt;IEnumerable&lt;DeleteUserIdentityResponseContentItem&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Unlink a specific secondary account from a target user. This action requires the ID of both the target user and the secondary account. 

Unlinking the secondary account removes it from the identities array of the target user and creates a new standalone profile for the secondary account. To learn more, review <a href="https://auth0.com/docs/manage-users/user-accounts/user-account-linking/unlink-user-accounts">Unlink User Accounts</a>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Identities.DeleteAsync("id", UserIdentityProviderEnum.Ad, "user_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the primary user account.
    
</dd>
</dl>

<dl>
<dd>

**provider:** `UserIdentityProviderEnum` — Identity provider name of the secondary linked account (e.g. `google-oauth2`).
    
</dd>
</dl>

<dl>
<dd>

**userId:** `string` — ID of the secondary linked account (e.g. `123456789081523216417` part after the `|` in `google-oauth2|123456789081523216417`).
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Users Logs
<details><summary><code>client.Users.Logs.<a href="/src/Auth0.ManagementApi/Users/Logs/LogsClient.cs">ListAsync</a>(id, ListUserLogsRequestParameters { ... }) -> Pager&lt;Log&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve log events for a specific user.

Note: For more information on all possible event types, their respective acronyms and descriptions, see <a href="https://auth0.com/docs/logs/log-event-type-codes">Log Event Type Codes</a>.

For more information on the list of fields that can be used in `sort`, see <a href="https://auth0.com/docs/logs/log-search-query-syntax#searchable-fields">Searchable Fields</a>.

Auth0 <a href="https://auth0.com/docs/logs/retrieve-log-events-using-mgmt-api#limitations">limits the number of logs</a> you can return by search criteria to 100 logs per request. Furthermore, you may only paginate through up to 1,000 search results. If you exceed this threshold, please redefine your search.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Logs.ListAsync(
    "id",
    new ListUserLogsRequestParameters
    {
        Page = 1,
        PerPage = 1,
        Sort = "sort",
        IncludeTotals = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the user of the logs to retrieve
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListUserLogsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Users Multifactor
<details><summary><code>client.Users.Multifactor.<a href="/src/Auth0.ManagementApi/Users/Multifactor/MultifactorClient.cs">InvalidateRememberBrowserAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Invalidate all remembered browsers across all <a href="https://auth0.com/docs/multifactor-authentication">authentication factors</a> for a user.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Multifactor.InvalidateRememberBrowserAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the user to invalidate all remembered browsers and authentication factors for.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.Multifactor.<a href="/src/Auth0.ManagementApi/Users/Multifactor/MultifactorClient.cs">DeleteProviderAsync</a>(id, provider)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Remove a <a href="https://auth0.com/docs/multifactor-authentication">multifactor</a> authentication configuration from a user's account. This forces the user to manually reconfigure the multi-factor provider.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Multifactor.DeleteProviderAsync("id", UserMultifactorProviderEnum.Duo);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the user to remove a multifactor configuration from.
    
</dd>
</dl>

<dl>
<dd>

**provider:** `UserMultifactorProviderEnum` — The multi-factor provider. Supported values 'duo' or 'google-authenticator'
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Users Organizations
<details><summary><code>client.Users.Organizations.<a href="/src/Auth0.ManagementApi/Users/Organizations/OrganizationsClient.cs">ListAsync</a>(id, ListUserOrganizationsRequestParameters { ... }) -> Pager&lt;Organization&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve list of the specified user's current Organization memberships. User must be specified by user ID. For more information, review <a href="https://auth0.com/docs/manage-users/organizations">Auth0 Organizations</a>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Organizations.ListAsync(
    "id",
    new ListUserOrganizationsRequestParameters
    {
        Page = 1,
        PerPage = 1,
        IncludeTotals = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the user to retrieve the organizations for.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListUserOrganizationsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Users Permissions
<details><summary><code>client.Users.Permissions.<a href="/src/Auth0.ManagementApi/Users/Permissions/PermissionsClient.cs">ListAsync</a>(id, ListUserPermissionsRequestParameters { ... }) -> Pager&lt;UserPermissionSchema&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all permissions associated with the user.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Permissions.ListAsync(
    "id",
    new ListUserPermissionsRequestParameters
    {
        PerPage = 1,
        Page = 1,
        IncludeTotals = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the user to retrieve the permissions for.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListUserPermissionsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.Permissions.<a href="/src/Auth0.ManagementApi/Users/Permissions/PermissionsClient.cs">CreateAsync</a>(id, CreateUserPermissionsRequestContent { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Assign permissions to a user.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Permissions.CreateAsync(
    "id",
    new CreateUserPermissionsRequestContent
    {
        Permissions = new List<PermissionRequestPayload>()
        {
            new PermissionRequestPayload
            {
                ResourceServerIdentifier = "resource_server_identifier",
                PermissionName = "permission_name",
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the user to assign permissions to.
    
</dd>
</dl>

<dl>
<dd>

**request:** `CreateUserPermissionsRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.Permissions.<a href="/src/Auth0.ManagementApi/Users/Permissions/PermissionsClient.cs">DeleteAsync</a>(id, DeleteUserPermissionsRequestContent { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Remove permissions from a user.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Permissions.DeleteAsync(
    "id",
    new DeleteUserPermissionsRequestContent
    {
        Permissions = new List<PermissionRequestPayload>()
        {
            new PermissionRequestPayload
            {
                ResourceServerIdentifier = "resource_server_identifier",
                PermissionName = "permission_name",
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the user to remove permissions from.
    
</dd>
</dl>

<dl>
<dd>

**request:** `DeleteUserPermissionsRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Users RiskAssessments
<details><summary><code>client.Users.RiskAssessments.<a href="/src/Auth0.ManagementApi/Users/RiskAssessments/RiskAssessmentsClient.cs">ClearAsync</a>(id, ClearAssessorsRequestContent { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Clear risk assessment assessors for a specific user
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.RiskAssessments.ClearAsync(
    "id",
    new ClearAssessorsRequestContent
    {
        Connection = "connection",
        Assessors = new List<AssessorsTypeEnum>() { AssessorsTypeEnum.NewDevice },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the user to clear assessors for.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ClearAssessorsRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Users Roles
<details><summary><code>client.Users.Roles.<a href="/src/Auth0.ManagementApi/Users/Roles/RolesClient.cs">ListAsync</a>(id, ListUserRolesRequestParameters { ... }) -> Pager&lt;Role&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve detailed list of all user roles currently assigned to a user.

<b>Note</b>: This action retrieves all roles assigned to a user in the context of your whole tenant. To retrieve Organization-specific roles, use the following endpoint: <a href="https://auth0.com/docs/api/management/v2/organizations/get-organization-member-roles">Get user roles assigned to an Organization member</a>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Roles.ListAsync(
    "id",
    new ListUserRolesRequestParameters
    {
        PerPage = 1,
        Page = 1,
        IncludeTotals = true,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the user to list roles for.
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListUserRolesRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.Roles.<a href="/src/Auth0.ManagementApi/Users/Roles/RolesClient.cs">AssignAsync</a>(id, AssignUserRolesRequestContent { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Assign one or more existing user roles to a user. For more information, review <a href="https://auth0.com/docs/manage-users/access-control/rbac">Role-Based Access Control</a>.

<b>Note</b>: New roles cannot be created through this action. Additionally, this action is used to assign roles to a user in the context of your whole tenant. To assign roles in the context of a specific Organization, use the following endpoint: <a href="https://auth0.com/docs/api/management/v2/organizations/post-organization-member-roles">Assign user roles to an Organization member</a>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Roles.AssignAsync(
    "id",
    new AssignUserRolesRequestContent { Roles = new List<string>() { "roles" } }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the user to associate roles with.
    
</dd>
</dl>

<dl>
<dd>

**request:** `AssignUserRolesRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.Roles.<a href="/src/Auth0.ManagementApi/Users/Roles/RolesClient.cs">DeleteAsync</a>(id, DeleteUserRolesRequestContent { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Remove one or more specified user roles assigned to a user.

<b>Note</b>: This action removes a role from a user in the context of your whole tenant. If you want to unassign a role from a user in the context of a specific Organization, use the following endpoint: <a href="https://auth0.com/docs/api/management/v2/organizations/delete-organization-member-roles">Delete user roles from an Organization member</a>.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Roles.DeleteAsync(
    "id",
    new DeleteUserRolesRequestContent { Roles = new List<string>() { "roles" } }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the user to remove roles from.
    
</dd>
</dl>

<dl>
<dd>

**request:** `DeleteUserRolesRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Users RefreshToken
<details><summary><code>client.Users.RefreshToken.<a href="/src/Auth0.ManagementApi/Users/RefreshToken/RefreshTokenClient.cs">ListAsync</a>(userId, ListRefreshTokensRequestParameters { ... }) -> Pager&lt;RefreshTokenResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details for a user's refresh tokens.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.RefreshToken.ListAsync(
    "user_id",
    new ListRefreshTokensRequestParameters { From = "from", Take = 1 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — ID of the user to get refresh tokens for
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListRefreshTokensRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.RefreshToken.<a href="/src/Auth0.ManagementApi/Users/RefreshToken/RefreshTokenClient.cs">DeleteAsync</a>(userId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete all refresh tokens for a user.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.RefreshToken.DeleteAsync("user_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — ID of the user to get remove refresh tokens for
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Users Sessions
<details><summary><code>client.Users.Sessions.<a href="/src/Auth0.ManagementApi/Users/Sessions/SessionsClient.cs">ListAsync</a>(userId, ListUserSessionsRequestParameters { ... }) -> Pager&lt;SessionResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details for a user's sessions.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Sessions.ListAsync(
    "user_id",
    new ListUserSessionsRequestParameters { From = "from", Take = 1 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — ID of the user to get sessions for
    
</dd>
</dl>

<dl>
<dd>

**request:** `ListUserSessionsRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Users.Sessions.<a href="/src/Auth0.ManagementApi/Users/Sessions/SessionsClient.cs">DeleteAsync</a>(userId)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete all sessions for a user.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Users.Sessions.DeleteAsync("user_id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**userId:** `string` — ID of the user to get sessions for
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## VerifiableCredentials Verification Templates
<details><summary><code>client.VerifiableCredentials.Verification.Templates.<a href="/src/Auth0.ManagementApi/VerifiableCredentials/Verification/Templates/TemplatesClient.cs">ListAsync</a>(ListVerifiableCredentialTemplatesRequestParameters { ... }) -> Pager&lt;VerifiableCredentialTemplateResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List a verifiable credential templates.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.VerifiableCredentials.Verification.Templates.ListAsync(
    new ListVerifiableCredentialTemplatesRequestParameters { From = "from", Take = 1 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListVerifiableCredentialTemplatesRequestParameters` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.VerifiableCredentials.Verification.Templates.<a href="/src/Auth0.ManagementApi/VerifiableCredentials/Verification/Templates/TemplatesClient.cs">CreateAsync</a>(CreateVerifiableCredentialTemplateRequestContent { ... }) -> WithRawResponseTask&lt;CreateVerifiableCredentialTemplateResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a verifiable credential template.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.VerifiableCredentials.Verification.Templates.CreateAsync(
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
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateVerifiableCredentialTemplateRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.VerifiableCredentials.Verification.Templates.<a href="/src/Auth0.ManagementApi/VerifiableCredentials/Verification/Templates/TemplatesClient.cs">GetAsync</a>(id) -> WithRawResponseTask&lt;GetVerifiableCredentialTemplateResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Get a verifiable credential template.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.VerifiableCredentials.Verification.Templates.GetAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the template to retrieve.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.VerifiableCredentials.Verification.Templates.<a href="/src/Auth0.ManagementApi/VerifiableCredentials/Verification/Templates/TemplatesClient.cs">DeleteAsync</a>(id)</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a verifiable credential template.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.VerifiableCredentials.Verification.Templates.DeleteAsync("id");
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the template to retrieve.
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.VerifiableCredentials.Verification.Templates.<a href="/src/Auth0.ManagementApi/VerifiableCredentials/Verification/Templates/TemplatesClient.cs">UpdateAsync</a>(id, UpdateVerifiableCredentialTemplateRequestContent { ... }) -> WithRawResponseTask&lt;UpdateVerifiableCredentialTemplateResponseContent&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update a verifiable credential template.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.VerifiableCredentials.Verification.Templates.UpdateAsync(
    "id",
    new UpdateVerifiableCredentialTemplateRequestContent()
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**id:** `string` — ID of the template to retrieve.
    
</dd>
</dl>

<dl>
<dd>

**request:** `UpdateVerifiableCredentialTemplateRequestContent` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

