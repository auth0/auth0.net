using System;
using System.Linq;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class EmailTemplatesTests : ManagementTestBase, IAsyncLifetime
    {
        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();
            ApiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"), new HttpClientManagementConnection(options: new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 9 }));

            try
            {
                // We need to set an email provider when configuring templates
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
            catch (ApiException)
            {
                // Was likely not cleaned-up in a previously failed test run
            }
        }

        public override async Task DisposeAsync()
        {
            await ApiClient.EmailProvider.DeleteAsync();
            await base.DisposeAsync();
        }

        [Fact]
        public async Task Test_email_templates_crud_sequence()
        {
            var emailTemplateNames = Enum.GetValues(typeof(EmailTemplateName)).Cast<EmailTemplateName>();

            string token = await GenerateManagementApiToken();
            
            // Create each template
            foreach (var emailTemplateName in emailTemplateNames)
            {
                EmailTemplate emailTemplate;
                try
                {
                    // Try and create the template. If it already exisits, we'll just update it
                    emailTemplate = await ApiClient.EmailTemplates.CreateAsync(new EmailTemplateCreateRequest
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
                    emailTemplate = await ApiClient.EmailTemplates.UpdateAsync(emailTemplateName, new EmailTemplateUpdateRequest
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
                    var _emailTemplate = await ApiClient.EmailTemplates.PatchAsync(_emailTemplateName, new EmailTemplatePatchRequest
                    {
                        Enabled = false,
                        From = "test2@test.com"
                    });
                }
            }

        }

    }
}
