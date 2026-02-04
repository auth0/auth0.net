using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.ManagementApi.Emails;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

public class EmailTemplatesTestsFixture : TestBaseFixture
{
    private bool _createdProvider = false;

    public override async Task InitializeAsync()
    {
        await base.InitializeAsync();

        try
        {
            await ApiClient.Emails.Provider.CreateAsync(new CreateEmailProviderRequestContent
            {
                Name = EmailProviderNameEnum.Mandrill,
                Enabled = true,
                Credentials = new EmailProviderCredentialsSchemaZero
                {
                    ApiKey = "ABC"
                }
            });
            _createdProvider = true;
        }
        catch (ConflictError)
        {
            // Provider already exists, that's fine - we can use the existing one
        }
    }

    public override async Task DisposeAsync()
    {
        // Only delete if we created it
        if (_createdProvider)
        {
            await ApiClient.Emails.Provider.DeleteAsync();
        }
        await base.DisposeAsync();
    }
}

public class EmailTemplatesTests : IClassFixture<EmailTemplatesTestsFixture>
{
    private EmailTemplatesTestsFixture fixture;

    public EmailTemplatesTests(EmailTemplatesTestsFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact(Skip = "Requires email template permissions")]
    public async Task Test_email_templates_crud_sequence()
    {
        // All available email template names
        var emailTemplateNames = new List<EmailTemplateNameEnum>
        {
            EmailTemplateNameEnum.VerifyEmail,
            EmailTemplateNameEnum.VerifyEmailByCode,
            EmailTemplateNameEnum.ResetEmail,
            EmailTemplateNameEnum.ResetEmailByCode,
            EmailTemplateNameEnum.WelcomeEmail,
            EmailTemplateNameEnum.BlockedAccount,
            EmailTemplateNameEnum.StolenCredentials,
            EmailTemplateNameEnum.EnrollmentEmail,
            EmailTemplateNameEnum.MfaOobCode,
            EmailTemplateNameEnum.UserInvitation,
            EmailTemplateNameEnum.ChangePassword,
            EmailTemplateNameEnum.PasswordReset,
            EmailTemplateNameEnum.AsyncApproval
        };

        // Create each template
        foreach (var emailTemplateName in emailTemplateNames)
        {
            CreateEmailTemplateResponseContent emailTemplate;
            try
            {
                // Try and create the template. If it already exists, we'll just update it
                emailTemplate = await fixture.ApiClient.EmailTemplates.CreateAsync(new CreateEmailTemplateRequestContent
                {
                    Template = emailTemplateName,
                    Body = "<html>",
                    Enabled = true,
                    Subject = emailTemplateName.ToString(),
                    From = "test@test.com",
                    Syntax = "liquid"
                });
            }
            catch (ManagementApiException)
            {
                // Template already exists, use Set (PUT) to update it
                await fixture.ApiClient.EmailTemplates.SetAsync(emailTemplateName, new SetEmailTemplateRequestContent
                {
                    Template = emailTemplateName,
                    Body = "<html>",
                    Enabled = true,
                    Subject = emailTemplateName.ToString(),
                    From = "test@test.com",
                    Syntax = "liquid"
                });
            }

            // Use Update (PATCH) to modify the template
            await fixture.ApiClient.EmailTemplates.UpdateAsync(emailTemplateName, new UpdateEmailTemplateRequestContent
            {
                Enabled = false,
                From = "test2@test.com"
            });
        }
    }
}
