using System;
using System.Threading.Tasks;
using Auth0.Core;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using NUnit.Framework;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests
{
    [TestFixture]
    public class EmailProviderTests : TestBase
    {
        [Test]
        public async Task Test_email_provider_crud_sequence()
        {
            var scopes = new
            {
                email_provider = new
                {
                    actions = new string[] { "read", "create", "delete", "update" }
                }
            };
            string token = GenerateToken(scopes);

            var apiClient = new ManagementApiClient(token, new Uri(GetVariable("AUTH0_MANAGEMENT_API_URL")));

            // Delete the email provider to ensure we start on a clean slate
            await apiClient.EmailProvider.Delete();

            // Getting the email provider now should throw, since none is configured
            Func<Task> getFunc = async () => await apiClient.EmailProvider.Get("name,enabled,credentials,settings");
            getFunc.ShouldThrow<ApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_email_provider");

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
            var configureResponse = await apiClient.EmailProvider.Configure(configureRequest);
            configureResponse.Name.Should().Be(configureRequest.Name);
            configureResponse.IsEnabled.Should().Be(configureRequest.IsEnabled);
            configureResponse.Credentials.ApiKey.Should().Be(configureRequest.Credentials.ApiKey);

            // Check that we can get the email provider details 
            var provider = await apiClient.EmailProvider.Get("name,enabled,credentials,settings");
            provider.Name.Should().Be(configureRequest.Name);
            provider.IsEnabled.Should().Be(configureRequest.IsEnabled);
            provider.Credentials.ApiKey.Should().Be(configureRequest.Credentials.ApiKey);

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
            var updateResponse = await apiClient.EmailProvider.Update(updateRequest);
            updateResponse.Name.Should().Be(updateRequest.Name);
            updateResponse.IsEnabled.Should().Be(updateRequest.IsEnabled);
            updateResponse.Credentials.ApiKey.Should().Be(updateRequest.Credentials.ApiKey);

            // Delete the email provider again
            await apiClient.EmailProvider.Delete();

            // Check than once again the email provider should throw, since none is configured
            getFunc = async () => await apiClient.EmailProvider.Get("name,enabled,credentials,settings");
            getFunc.ShouldThrow<ApiException>().And.ApiError.ErrorCode.Should().Be("inexistent_email_provider");

        }
    }
}