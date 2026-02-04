using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Emails;

public partial interface IProviderClient
{
    /// <summary>
    /// Retrieve details of the <a href="https://auth0.com/docs/customize/email/smtp-email-providers">email provider configuration</a> in your tenant. A list of fields to include or exclude may also be specified.
    /// </summary>
    WithRawResponseTask<GetEmailProviderResponseContent> GetAsync(
        GetEmailProviderRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create an <a href="https://auth0.com/docs/email/providers">email provider</a>. The <code>credentials</code> object
    /// requires different properties depending on the email provider (which is specified using the <code>name</code> property):
    /// <ul>
    ///   <li><code>mandrill</code> requires <code>api_key</code></li>
    ///   <li><code>sendgrid</code> requires <code>api_key</code></li>
    ///   <li>
    ///     <code>sparkpost</code> requires <code>api_key</code>. Optionally, set <code>region</code> to <code>eu</code> to use
    ///     the SparkPost service hosted in Western Europe; set to <code>null</code> to use the SparkPost service hosted in
    ///     North America. <code>eu</code> or <code>null</code> are the only valid values for <code>region</code>.
    ///   </li>
    ///   <li>
    ///     <code>mailgun</code> requires <code>api_key</code> and <code>domain</code>. Optionally, set <code>region</code> to
    ///     <code>eu</code> to use the Mailgun service hosted in Europe; set to <code>null</code> otherwise. <code>eu</code> or
    ///     <code>null</code> are the only valid values for <code>region</code>.
    ///   </li>
    ///   <li><code>ses</code> requires <code>accessKeyId</code>, <code>secretAccessKey</code>, and <code>region</code></li>
    ///   <li>
    ///     <code>smtp</code> requires <code>smtp_host</code>, <code>smtp_port</code>, <code>smtp_user</code>, and
    ///     <code>smtp_pass</code>
    ///   </li>
    /// </ul>
    /// Depending on the type of provider it is possible to specify <code>settings</code> object with different configuration
    /// options, which will be used when sending an email:
    /// <ul>
    ///   <li>
    ///     <code>smtp</code> provider, <code>settings</code> may contain <code>headers</code> object.
    ///     <ul>
    ///       <li>
    ///         When using AWS SES SMTP host, you may provide a name of configuration set in
    ///         <code>X-SES-Configuration-Set</code> header. Value must be a string.
    ///       </li>
    ///       <li>
    ///         When using Sparkpost host, you may provide value for
    ///         <code>X-MSYS_API</code> header. Value must be an object.
    ///       </li>
    ///     </ul>
    ///   </li>
    ///   <li>
    ///     for <code>ses</code> provider, <code>settings</code> may contain <code>message</code> object, where you can provide
    ///     a name of configuration set in <code>configuration_set_name</code> property. Value must be a string.
    ///   </li>
    /// </ul>
    /// </summary>
    WithRawResponseTask<CreateEmailProviderResponseContent> CreateAsync(
        CreateEmailProviderRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete the email provider.
    /// </summary>
    Task DeleteAsync(RequestOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update an <a href="https://auth0.com/docs/email/providers">email provider</a>. The <code>credentials</code> object
    /// requires different properties depending on the email provider (which is specified using the <code>name</code> property):
    /// <ul>
    ///   <li><code>mandrill</code> requires <code>api_key</code></li>
    ///   <li><code>sendgrid</code> requires <code>api_key</code></li>
    ///   <li>
    ///     <code>sparkpost</code> requires <code>api_key</code>. Optionally, set <code>region</code> to <code>eu</code> to use
    ///     the SparkPost service hosted in Western Europe; set to <code>null</code> to use the SparkPost service hosted in
    ///     North America. <code>eu</code> or <code>null</code> are the only valid values for <code>region</code>.
    ///   </li>
    ///   <li>
    ///     <code>mailgun</code> requires <code>api_key</code> and <code>domain</code>. Optionally, set <code>region</code> to
    ///     <code>eu</code> to use the Mailgun service hosted in Europe; set to <code>null</code> otherwise. <code>eu</code> or
    ///     <code>null</code> are the only valid values for <code>region</code>.
    ///   </li>
    ///   <li><code>ses</code> requires <code>accessKeyId</code>, <code>secretAccessKey</code>, and <code>region</code></li>
    ///   <li>
    ///     <code>smtp</code> requires <code>smtp_host</code>, <code>smtp_port</code>, <code>smtp_user</code>, and
    ///     <code>smtp_pass</code>
    ///   </li>
    /// </ul>
    /// Depending on the type of provider it is possible to specify <code>settings</code> object with different configuration
    /// options, which will be used when sending an email:
    /// <ul>
    ///   <li>
    ///     <code>smtp</code> provider, <code>settings</code> may contain <code>headers</code> object.
    ///     <ul>
    ///       <li>
    ///         When using AWS SES SMTP host, you may provide a name of configuration set in
    ///         <code>X-SES-Configuration-Set</code> header. Value must be a string.
    ///       </li>
    ///       <li>
    ///         When using Sparkpost host, you may provide value for
    ///         <code>X-MSYS_API</code> header. Value must be an object.
    ///       </li>
    ///     </ul>
    ///     for <code>ses</code> provider, <code>settings</code> may contain <code>message</code> object, where you can provide
    ///     a name of configuration set in <code>configuration_set_name</code> property. Value must be a string.
    ///   </li>
    /// </ul>
    /// </summary>
    WithRawResponseTask<UpdateEmailProviderResponseContent> UpdateAsync(
        UpdateEmailProviderRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
