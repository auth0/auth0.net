namespace Auth0.ManagementApi;

public partial interface IEmailTemplatesClient
{
    /// <summary>
    /// Create an email template.
    /// </summary>
    WithRawResponseTask<CreateEmailTemplateResponseContent> CreateAsync(
        CreateEmailTemplateRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve an email template by pre-defined name. These names are `verify_email`, `verify_email_by_code`, `reset_email`, `reset_email_by_code`, `welcome_email`, `blocked_account`, `stolen_credentials`, `enrollment_email`, `mfa_oob_code`, `user_invitation`, and `async_approval`. The names `change_password`, and `password_reset` are also supported for legacy scenarios.
    /// </summary>
    WithRawResponseTask<GetEmailTemplateResponseContent> GetAsync(
        EmailTemplateNameEnum templateName,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an email template.
    /// </summary>
    WithRawResponseTask<SetEmailTemplateResponseContent> SetAsync(
        EmailTemplateNameEnum templateName,
        SetEmailTemplateRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Modify an email template.
    /// </summary>
    WithRawResponseTask<UpdateEmailTemplateResponseContent> UpdateAsync(
        EmailTemplateNameEnum templateName,
        UpdateEmailTemplateRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
