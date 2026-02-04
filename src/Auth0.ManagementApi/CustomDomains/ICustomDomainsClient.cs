namespace Auth0.ManagementApi;

public partial interface ICustomDomainsClient
{
    /// <summary>
    /// Retrieve details on <a href="https://auth0.com/docs/custom-domains">custom domains</a>.
    /// </summary>
    WithRawResponseTask<IEnumerable<CustomDomain>> ListAsync(
        ListCustomDomainsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new custom domain.
    ///
    /// Note: The custom domain will need to be verified before it will accept
    /// requests.
    ///
    /// Optional attributes that can be updated:
    ///
    /// - custom_client_ip_header
    /// - tls_policy
    ///
    ///
    /// TLS Policies:
    ///
    /// - recommended - for modern usage this includes TLS 1.2 only
    /// </summary>
    WithRawResponseTask<CreateCustomDomainResponseContent> CreateAsync(
        CreateCustomDomainRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a custom domain configuration and status.
    /// </summary>
    WithRawResponseTask<GetCustomDomainResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a custom domain and stop serving requests for it.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a custom domain.
    ///
    /// These are the attributes that can be updated:
    ///
    /// - custom_client_ip_header
    /// - tls_policy
    ///
    /// &lt;h5&gt;Updating CUSTOM_CLIENT_IP_HEADER for a custom domain&lt;/h5&gt;To update the <code>custom_client_ip_header</code> for a domain, the body to
    /// send should be:
    /// <pre><code>{ "custom_client_ip_header": "cf-connecting-ip" }</code></pre>
    ///
    /// &lt;h5&gt;Updating TLS_POLICY for a custom domain&lt;/h5&gt;To update the <code>tls_policy</code> for a domain, the body to send should be:
    /// <pre><code>{ "tls_policy": "recommended" }</code></pre>
    ///
    ///
    /// TLS Policies:
    ///
    /// - recommended - for modern usage this includes TLS 1.2 only
    ///
    ///
    /// Some considerations:
    ///
    /// - The TLS ciphers and protocols available in each TLS policy follow industry recommendations, and may be updated occasionally.
    /// - The <code>compatible</code> TLS policy is no longer supported.
    /// </summary>
    WithRawResponseTask<UpdateCustomDomainResponseContent> UpdateAsync(
        string id,
        UpdateCustomDomainRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Run the test process on a custom domain.
    /// </summary>
    WithRawResponseTask<TestCustomDomainResponseContent> TestAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Run the verification process on a custom domain.
    ///
    /// Note: Check the <code>status</code> field to see its verification status. Once verification is complete, it may take up to 10 minutes before the custom domain can start accepting requests.
    ///
    /// For <code>self_managed_certs</code>, when the custom domain is verified for the first time, the response will also include the <code>cname_api_key</code> which you will need to configure your proxy. This key must be kept secret, and is used to validate the proxy requests.
    ///
    /// <a href="https://auth0.com/docs/custom-domains#step-2-verify-ownership">Learn more</a> about verifying custom domains that use Auth0 Managed certificates.
    /// <a href="https://auth0.com/docs/custom-domains/self-managed-certificates#step-2-verify-ownership">Learn more</a> about verifying custom domains that use Self Managed certificates.
    /// </summary>
    WithRawResponseTask<VerifyCustomDomainResponseContent> VerifyAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
