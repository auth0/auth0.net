using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Emails;

public partial interface IProviderClient
{
    /// <summary>
    /// Retrieve details of the [email provider configuration](https://auth0.com/docs/customize/email/smtp-email-providers) in your tenant. A list of fields to include or exclude may also be specified.
    /// </summary>
    WithRawResponseTask<GetEmailProviderResponseContent> GetAsync(
        GetEmailProviderRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create an [email provider](https://auth0.com/docs/email/providers). The `credentials` object
    /// requires different properties depending on the email provider (which is specified using the `name` property):
    ///
    /// - `mandrill` requires `api_key`
    /// - `sendgrid` requires `api_key`
    /// - `sparkpost` requires `api_key`. Optionally, set `region` to `eu` to use
    ///     the SparkPost service hosted in Western Europe; set to `null` to use the SparkPost service hosted in
    ///     North America. `eu` or `null` are the only valid values for `region`.
    /// - `mailgun` requires `api_key` and `domain`. Optionally, set `region` to
    ///     `eu` to use the Mailgun service hosted in Europe; set to `null` otherwise. `eu` or
    ///     `null` are the only valid values for `region`.
    /// - `ses` requires `accessKeyId`, `secretAccessKey`, and `region`
    /// - `smtp` requires `smtp_host`, `smtp_port`, `smtp_user`, and
    ///     `smtp_pass`
    ///
    /// Depending on the type of provider it is possible to specify `settings` object with different configuration
    /// options, which will be used when sending an email:
    ///
    /// - `smtp` provider, `settings` may contain `headers` object.
    ///     - When using AWS SES SMTP host, you may provide a name of configuration set in
    ///       `X-SES-Configuration-Set` header. Value must be a string.
    ///     - When using Sparkpost host, you may provide value for
    ///       `X-MSYS_API` header. Value must be an object.
    /// - For `ses` provider, `settings` may contain `message` object, where you can provide
    ///   a name of configuration set in `configuration_set_name` property. Value must be a string.
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
    /// Update an [email provider](https://auth0.com/docs/email/providers). The `credentials` object
    /// requires different properties depending on the email provider (which is specified using the `name` property):
    ///
    /// - `mandrill` requires `api_key`
    /// - `sendgrid` requires `api_key`
    /// - `sparkpost` requires `api_key`. Optionally, set `region` to `eu` to use
    ///     the SparkPost service hosted in Western Europe; set to `null` to use the SparkPost service hosted in
    ///     North America. `eu` or `null` are the only valid values for `region`.
    /// - `mailgun` requires `api_key` and `domain`. Optionally, set `region` to
    ///     `eu` to use the Mailgun service hosted in Europe; set to `null` otherwise. `eu` or
    ///     `null` are the only valid values for `region`.
    /// - `ses` requires `accessKeyId`, `secretAccessKey`, and `region`
    /// - `smtp` requires `smtp_host`, `smtp_port`, `smtp_user`, and
    ///     `smtp_pass`
    ///
    /// Depending on the type of provider it is possible to specify `settings` object with different configuration
    /// options, which will be used when sending an email:
    ///
    /// - `smtp` provider, `settings` may contain `headers` object.
    ///     - When using AWS SES SMTP host, you may provide a name of configuration set in
    ///       `X-SES-Configuration-Set` header. Value must be a string.
    ///     - When using Sparkpost host, you may provide value for
    ///       `X-MSYS_API` header. Value must be an object.
    ///
    ///   For `ses` provider, `settings` may contain `message` object, where you can provide
    ///   a name of configuration set in `configuration_set_name` property. Value must be a string.
    /// </summary>
    WithRawResponseTask<UpdateEmailProviderResponseContent> UpdateAsync(
        UpdateEmailProviderRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
