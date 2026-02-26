using System;
using System.Threading.Tasks;
using Auth0.ManagementApi.Emails;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests;

public class EmailProviderTests : TestBase
{
    [Fact(Skip = "Temporary")]
    public async Task Test_mandrill_email_provider_crud_sequence()
    {
        var managementApiUrl = GetVariable("AUTH0_MANAGEMENT_API_URL");
        var domain = managementApiUrl.Replace("https://", "").TrimEnd('/');

        using (var apiClient = new ManagementClient(new ManagementClientOptions
        {
            Domain = domain,
            TokenProvider = new ClientCredentialsTokenProvider(domain, GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID"), GetVariable("AUTH0_MANAGEMENT_API_CLIENT_SECRET")),
            MaxRetries = 9
        }))
        {
            // Delete the email provider to ensure we start on a clean slate
            await apiClient.Emails.Provider.DeleteAsync();

            // Getting the email provider now should throw, since none is configured
            Func<Task> getFunc = async () => await apiClient.Emails.Provider.GetAsync(new GetEmailProviderRequestParameters
            {
                Fields = "name,enabled,credentials,settings"
            });
            getFunc.Should().ThrowAsync<NotFoundError>();

            // Configure the email provider
            var createResponse = await apiClient.Emails.Provider.CreateAsync(new CreateEmailProviderRequestContent
            {
                Name = EmailProviderNameEnum.Mandrill,
                Enabled = true,
                Credentials = new EmailProviderCredentialsSchemaZero
                {
                    ApiKey = "ABC"
                }
            });
            createResponse.Name.Should().Be(EmailProviderNameEnum.Mandrill.Value);
            createResponse.Enabled.Should().Be(true);

            // Check that we can get the email provider details
            var provider = await apiClient.Emails.Provider.GetAsync(new GetEmailProviderRequestParameters
            {
                Fields = "name,enabled,credentials,settings"
            });
            provider.Name.Should().Be(EmailProviderNameEnum.Mandrill.Value);
            provider.Enabled.Should().Be(true);

            // Update the email provider
            var updateResponse = await apiClient.Emails.Provider.UpdateAsync(new UpdateEmailProviderRequestContent
            {
                Name = EmailProviderNameEnum.Mandrill,
                Enabled = true,
                Credentials = new EmailProviderCredentialsSchemaZero
                {
                    ApiKey = "XYZ"
                }
            });
            updateResponse.Name.Should().Be(EmailProviderNameEnum.Mandrill.Value);
            updateResponse.Enabled.Should().Be(true);

            // Delete the email provider again
            await apiClient.Emails.Provider.DeleteAsync();

            // Check than once again the email provider should throw, since none is configured
            getFunc = async () => await apiClient.Emails.Provider.GetAsync(new GetEmailProviderRequestParameters
            {
                Fields = "name,enabled,credentials,settings"
            });
            getFunc.Should().ThrowAsync<NotFoundError>();
        }
    }

    [Fact(Skip = "Temporary")]
    public async Task Test_smtp_email_provider_crud_sequence()
    {
        var managementApiUrl = GetVariable("AUTH0_MANAGEMENT_API_URL");
        var domain = managementApiUrl.Replace("https://", "").TrimEnd('/');

        using (var apiClient = new ManagementClient(new ManagementClientOptions
        {
            Domain = domain,
            TokenProvider = new ClientCredentialsTokenProvider(domain, GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID"), GetVariable("AUTH0_MANAGEMENT_API_CLIENT_SECRET"))
        }))
        {
            // Delete the email provider to ensure we start on a clean slate
            await apiClient.Emails.Provider.DeleteAsync();

            // Getting the email provider now should throw, since none is configured
            Func<Task> getFunc = async () => await apiClient.Emails.Provider.GetAsync(new GetEmailProviderRequestParameters
            {
                Fields = "name,enabled,credentials,settings"
            });
            getFunc.Should().ThrowAsync<NotFoundError>();

            // Configure the email provider
            var createResponse = await apiClient.Emails.Provider.CreateAsync(new CreateEmailProviderRequestContent
            {
                Name = EmailProviderNameEnum.Smtp,
                Enabled = true,
                Credentials = new EmailProviderCredentialsSchemaSmtpHost
                {
                    SmtpHost = "smtp1.test.com",
                    SmtpPort = 25,
                    SmtpUser = "username1",
                    SmtpPass = "password1"
                }
            });
            createResponse.Name.Should().Be(EmailProviderNameEnum.Smtp.Value);
            createResponse.Enabled.Should().Be(true);

            // Check that we can get the email provider details
            var provider = await apiClient.Emails.Provider.GetAsync(new GetEmailProviderRequestParameters
            {
                Fields = "name,enabled,credentials,settings"
            });
            provider.Name.Should().Be(EmailProviderNameEnum.Smtp.Value);
            provider.Enabled.Should().Be(true);

            // Update the email provider
            var updateResponse = await apiClient.Emails.Provider.UpdateAsync(new UpdateEmailProviderRequestContent
            {
                Name = EmailProviderNameEnum.Smtp,
                Enabled = true,
                Credentials = new EmailProviderCredentialsSchemaSmtpHost
                {
                    SmtpHost = "smtp2.test.com",
                    SmtpPort = 587,
                    SmtpUser = "username2",
                    SmtpPass = "password2"
                }
            });
            updateResponse.Name.Should().Be(EmailProviderNameEnum.Smtp.Value);
            updateResponse.Enabled.Should().Be(true);

            // Delete the email provider again
            await apiClient.Emails.Provider.DeleteAsync();

            // Check than once again the email provider should throw, since none is configured
            getFunc = async () => await apiClient.Emails.Provider.GetAsync(new GetEmailProviderRequestParameters
            {
                Fields = "name,enabled,credentials,settings"
            });
            getFunc.Should().ThrowAsync<NotFoundError>();
        }
    }
}
