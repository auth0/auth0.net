using System;
using System.Linq;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class EmailTemplatesTestsFixture : TestBaseFixture
    {
        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            await ApiClient.EmailProvider.ConfigureAsync(new EmailProviderConfigureRequest
            {
                Name = "mandrill",
                IsEnabled = true,
                Credentials = new EmailProviderCredentials
                {
                    ApiKey = "ABC"
                }
            });
        }
        public override async Task DisposeAsync()
        {
            await ApiClient.EmailProvider.DeleteAsync();
            await base.DisposeAsync();
        }
    }

    public class EmailTemplatesTests : IClassFixture<EmailTemplatesTestsFixture>
    {
        EmailTemplatesTestsFixture fixture;

        public EmailTemplatesTests(EmailTemplatesTestsFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task Test_email_templates_crud_sequence()
        {
            var emailTemplateNames = Enum.GetValues(typeof(EmailTemplateName)).Cast<EmailTemplateName>();
            
            // Create each template
            foreach (var emailTemplateName in emailTemplateNames)
            {
                EmailTemplate emailTemplate;
                try
                {
                    // Try and create the template. If it already exisits, we'll just update it
                    emailTemplate = await fixture.ApiClient.EmailTemplates.CreateAsync(new EmailTemplateCreateRequest
                    {
                        Template = emailTemplateName,
                        Body = "<html>",
                        Enabled = true,
                        Subject = emailTemplateName.ToString(),
                        From = "test@test.com",
                        Syntax = EmailTemplateSyntax.Liquid
                    });

                }
                catch (ApiException)
                {
                    emailTemplate = await fixture.ApiClient.EmailTemplates.UpdateAsync(emailTemplateName, new EmailTemplateUpdateRequest
                    {
                        Template = emailTemplateName,
                        Body = "<html>",
                        Enabled = true,
                        Subject = emailTemplateName.ToString(),
                        From = "test@test.com",
                        Syntax = EmailTemplateSyntax.Liquid
                    });
                }
                

                // Patch each template
                foreach (var _emailTemplateName in emailTemplateNames)
                {
                    // Try and create the template. If it already exisits, we'll just update it
                    var _emailTemplate = await fixture.ApiClient.EmailTemplates.PatchAsync(_emailTemplateName, new EmailTemplatePatchRequest
                    {
                        Enabled = false,
                        From = "test2@test.com"
                    });
                }
            }

        }

    }
}
