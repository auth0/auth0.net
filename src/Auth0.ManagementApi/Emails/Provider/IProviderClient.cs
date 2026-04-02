using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Emails;

public partial interface IProviderClient
{
    /// <summary>
    /// Retrieve details of the <see href="https://auth0.com/docs/customize/email/smtp-email-providers">email provider configuration</see> in your tenant. A list of fields to include or exclude may also be specified.
    /// </summary>
    WithRawResponseTask<GetEmailProviderResponseContent> GetAsync(
        GetEmailProviderRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create an <see href="https://auth0.com/docs/email/providers">email provider</see>. The <c>credentials</c> object
    /// requires different properties depending on the email provider (which is specified using the <c>name</c> property):
    /// <list type="bullet">
    ///   <item><description><c>mandrill</c> requires <c>api_key</c></description></item>
    ///   <item><description><c>sendgrid</c> requires <c>api_key</c></description></item>
    ///   <item><description>
    ///     <c>sparkpost</c> requires <c>api_key</c>. Optionally, set <c>region</c> to <c>eu</c> to use
    ///     the SparkPost service hosted in Western Europe; set to <c>null</c> to use the SparkPost service hosted in
    ///     North America. <c>eu</c> or <c>null</c> are the only valid values for <c>region</c>.
    ///   </description></item>
    ///   <item><description>
    ///     <c>mailgun</c> requires <c>api_key</c> and <c>domain</c>. Optionally, set <c>region</c> to
    ///     <c>eu</c> to use the Mailgun service hosted in Europe; set to <c>null</c> otherwise. <c>eu</c> or
    ///     <c>null</c> are the only valid values for <c>region</c>.
    ///   </description></item>
    ///   <item><description><c>ses</c> requires <c>accessKeyId</c>, <c>secretAccessKey</c>, and <c>region</c></description></item>
    ///   <item><description>
    ///     <c>smtp</c> requires <c>smtp_host</c>, <c>smtp_port</c>, <c>smtp_user</c>, and
    ///     <c>smtp_pass</c>
    ///   </description></item>
    /// </list>
    /// Depending on the type of provider it is possible to specify <c>settings</c> object with different configuration
    /// options, which will be used when sending an email:
    /// <list type="bullet">
    ///   <item><description>
    ///     <c>smtp</c> provider, <c>settings</c> may contain <c>headers</c> object.
    ///     <list type="bullet">
    ///       <item><description>
    ///         When using AWS SES SMTP host, you may provide a name of configuration set in
    ///         <c>X-SES-Configuration-Set</c> header. Value must be a string.
    ///       </description></item>
    ///       <item><description>
    ///         When using Sparkpost host, you may provide value for
    ///         <c>X-MSYS_API</c> header. Value must be an object.
    ///       </description></item>
    ///     </list>
    ///   </description></item>
    ///   <item><description>
    ///     for <c>ses</c> provider, <c>settings</c> may contain <c>message</c> object, where you can provide
    ///     a name of configuration set in <c>configuration_set_name</c> property. Value must be a string.
    ///   </description></item>
    /// </list>
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
    /// Update an <see href="https://auth0.com/docs/email/providers">email provider</see>. The <c>credentials</c> object
    /// requires different properties depending on the email provider (which is specified using the <c>name</c> property):
    /// <list type="bullet">
    ///   <item><description><c>mandrill</c> requires <c>api_key</c></description></item>
    ///   <item><description><c>sendgrid</c> requires <c>api_key</c></description></item>
    ///   <item><description>
    ///     <c>sparkpost</c> requires <c>api_key</c>. Optionally, set <c>region</c> to <c>eu</c> to use
    ///     the SparkPost service hosted in Western Europe; set to <c>null</c> to use the SparkPost service hosted in
    ///     North America. <c>eu</c> or <c>null</c> are the only valid values for <c>region</c>.
    ///   </description></item>
    ///   <item><description>
    ///     <c>mailgun</c> requires <c>api_key</c> and <c>domain</c>. Optionally, set <c>region</c> to
    ///     <c>eu</c> to use the Mailgun service hosted in Europe; set to <c>null</c> otherwise. <c>eu</c> or
    ///     <c>null</c> are the only valid values for <c>region</c>.
    ///   </description></item>
    ///   <item><description><c>ses</c> requires <c>accessKeyId</c>, <c>secretAccessKey</c>, and <c>region</c></description></item>
    ///   <item><description>
    ///     <c>smtp</c> requires <c>smtp_host</c>, <c>smtp_port</c>, <c>smtp_user</c>, and
    ///     <c>smtp_pass</c>
    ///   </description></item>
    /// </list>
    /// Depending on the type of provider it is possible to specify <c>settings</c> object with different configuration
    /// options, which will be used when sending an email:
    /// <list type="bullet">
    ///   <item><description>
    ///     <c>smtp</c> provider, <c>settings</c> may contain <c>headers</c> object.
    ///     <list type="bullet">
    ///       <item><description>
    ///         When using AWS SES SMTP host, you may provide a name of configuration set in
    ///         <c>X-SES-Configuration-Set</c> header. Value must be a string.
    ///       </description></item>
    ///       <item><description>
    ///         When using Sparkpost host, you may provide value for
    ///         <c>X-MSYS_API</c> header. Value must be an object.
    ///       </description></item>
    ///     </list>
    ///     for <c>ses</c> provider, <c>settings</c> may contain <c>message</c> object, where you can provide
    ///     a name of configuration set in <c>configuration_set_name</c> property. Value must be a string.
    ///   </description></item>
    /// </list>
    /// </summary>
    WithRawResponseTask<UpdateEmailProviderResponseContent> UpdateAsync(
        UpdateEmailProviderRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
