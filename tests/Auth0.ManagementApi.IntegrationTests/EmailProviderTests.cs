using System;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class EmailProviderTests : TestBase
    {
        [Fact(Skip = "Temporary")]
        public async Task Test_mandrill_email_provider_crud_sequence()
        {
            string token = await GenerateManagementApiToken();

            using (var apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"), new HttpClientManagementConnection(options: new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 9 })))
            {
                // Delete the email provider to ensure we start on a clean slate
                await apiClient.EmailProvider.DeleteAsync();

                // Getting the email provider now should throw, since none is configured
                Func<Task> getFunc = async () => await apiClient.EmailProvider.GetAsync("name,enabled,credentials,settings");
                getFunc.Should().Throw<ErrorApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_email_provider");

                // Configure the email provider
                var configureRequest = new EmailProviderConfigureRequest
                {
                    Name = "mandrill",
                    IsEnabled = true,
                    Credentials = new EmailProviderCredentials
                    {
                        ApiKey = "ABC"
                    }
                };
                var configureResponse = await apiClient.EmailProvider.ConfigureAsync(configureRequest);
                configureResponse.Name.Should().Be(configureRequest.Name);
                configureResponse.IsEnabled.Should().Be(configureRequest.IsEnabled);
                configureResponse.Credentials.ApiKey.Should().BeNull(); // API no longer returns creds

                // Check that we can get the email provider details 
                var provider = await apiClient.EmailProvider.GetAsync("name,enabled,credentials,settings");
                provider.Name.Should().Be(configureRequest.Name);
                provider.IsEnabled.Should().Be(configureRequest.IsEnabled);
                provider.Credentials.ApiKey.Should().BeNull(); // API no longer returns creds

                // Update the email provider
                var updateRequest = new EmailProviderUpdateRequest
                {
                    Name = "mandrill",
                    IsEnabled = true,
                    Credentials = new EmailProviderCredentials
                    {
                        ApiKey = "XYZ"
                    }
                };
                var updateResponse = await apiClient.EmailProvider.UpdateAsync(updateRequest);
                updateResponse.Name.Should().Be(updateRequest.Name);
                updateResponse.IsEnabled.Should().Be(updateRequest.IsEnabled);
                updateResponse.Credentials.ApiKey.Should().BeNull(); // API no longer returns creds

                // Delete the email provider again
                await apiClient.EmailProvider.DeleteAsync();

                // Check than once again the email provider should throw, since none is configured
                getFunc = async () => await apiClient.EmailProvider.GetAsync("name,enabled,credentials,settings");
                getFunc.Should().Throw<ErrorApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_email_provider");
            }
        }

        [Fact(Skip = "Temporary")]
        public async Task Test_smtp_email_provider_crud_sequence()
        {
            string token = await GenerateManagementApiToken();

            using (var apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL")))
            {
                // Delete the email provider to ensure we start on a clean slate
                await apiClient.EmailProvider.DeleteAsync();

                // Getting the email provider now should throw, since none is configured
                Func<Task> getFunc = async () => await apiClient.EmailProvider.GetAsync("name,enabled,credentials,settings");
                getFunc.Should().Throw<ErrorApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_email_provider");

                // Configure the email provider
                var configureRequest = new EmailProviderConfigureRequest
                {
                    Name = "smtp",
                    IsEnabled = true,
                    Credentials = new EmailProviderCredentials
                    {
                        SmtpHost = "smtp1.test.com",
                        SmtpPort = 25,
                        SmtpUsername = "username1",
                        SmtpPassword = "password1"
                    }
                };
                var configureResponse = await apiClient.EmailProvider.ConfigureAsync(configureRequest);
                configureResponse.Name.Should().Be(configureRequest.Name);
                configureResponse.IsEnabled.Should().Be(configureRequest.IsEnabled);
                configureResponse.Credentials.SmtpHost.Should().Be(configureRequest.Credentials.SmtpHost);
                configureResponse.Credentials.SmtpPort.Should().Be(configureRequest.Credentials.SmtpPort);
                configureResponse.Credentials.SmtpUsername.Should().Be(configureRequest.Credentials.SmtpUsername);
                configureResponse.Credentials.SmtpPassword.Should().BeNull(); // API no longer returns creds

                // Check that we can get the email provider details 
                var provider = await apiClient.EmailProvider.GetAsync("name,enabled,credentials,settings");
                provider.Name.Should().Be(configureRequest.Name);
                provider.IsEnabled.Should().Be(configureRequest.IsEnabled);
                provider.Credentials.ApiKey.Should().BeNull(); // API no longer returns creds

                // Update the email provider
                var updateRequest = new EmailProviderUpdateRequest
                {
                    Name = "smtp",
                    IsEnabled = true,
                    Credentials = new EmailProviderCredentials
                    {
                        SmtpHost = "smtp2.test.com",
                        SmtpPort = 587,
                        SmtpUsername = "username2",
                        SmtpPassword = "password2"
                    }
                };
                var updateResponse = await apiClient.EmailProvider.UpdateAsync(updateRequest);
                updateResponse.Name.Should().Be(updateRequest.Name);
                updateResponse.IsEnabled.Should().Be(updateRequest.IsEnabled);
                updateResponse.Credentials.SmtpHost.Should().Be(updateRequest.Credentials.SmtpHost);
                updateResponse.Credentials.SmtpPort.Should().Be(updateRequest.Credentials.SmtpPort);
                updateResponse.Credentials.SmtpUsername.Should().Be(updateRequest.Credentials.SmtpUsername);
                updateResponse.Credentials.SmtpPassword.Should().BeNull(); // API no longer returns creds

                // Delete the email provider again
                await apiClient.EmailProvider.DeleteAsync();

                // Check than once again the email provider should throw, since none is configured
                getFunc = async () => await apiClient.EmailProvider.GetAsync("name,enabled,credentials,settings");
                getFunc.Should().Throw<ErrorApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_email_provider");
            }
        }
    }
}