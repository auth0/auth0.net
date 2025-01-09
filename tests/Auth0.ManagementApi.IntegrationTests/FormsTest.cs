using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

using FluentAssertions;
using Xunit;

using Auth0.ManagementApi.Models.Forms;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class FormsTestFixture : TestBaseFixture
    {
        public override async Task DisposeAsync()
        {
            foreach (KeyValuePair<CleanUpType, IList<string>> entry in identifiers)
            {
                await ManagementTestBaseUtils.CleanupAsync(ApiClient, entry.Key, entry.Value);
            }

            ApiClient.Dispose();
        }
    }

    public class FormsTest : IClassFixture<FormsTestFixture>
    {
        FormsTestFixture fixture;

        public FormsTest(FormsTestFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task Test_forms_crud_sequence()
        {
            // Create a form 
            var createRequest = new FormCreateRequest()
            {
                Ending = new Ending()
                {
                    Coordinates = new Coordinates()
                    {
                        X = 10,
                        Y = 20
                    },
                    Redirection = new Redirection()
                    {
                        Delay = 1,
                        Target = "sample"
                    }
                },
                Languages = new Languages()
                {
                    Default = "en",
                    Primary = "en"
                },
                Messages = new Messages()
                {
                    Custom = new object(),
                    Errors = new object()
                },
                Style = new Style()
                {
                    Css = "<>"
                },
                Translations = new object(),
                Name = "Test-Form"
            };
            
            var createdForm = await fixture.ApiClient.FormsClient.CreateAsync(createRequest);

            var allForms = await fixture.ApiClient.FormsClient.GetAllAsync(new FormsGetRequest()
            {
                Hydrate = new [] {  Hydrate.LINKS}
            });

            allForms.Should().NotBeNull();
            allForms.Count.Should().Be(1);
            
            var form = await fixture.ApiClient.FormsClient.GetAsync(new FormsGetRequest { Id = allForms.First().Id });
            
            form.Should().BeEquivalentTo(createdForm, options => options.ExcludingMissingMembers());

            var updateRequest = new FormUpdateRequest()
            {
                Languages = new Languages()
                {
                    Primary = "es"
                },
                Ending = new Ending()
                {
                    Redirection = new Redirection()
                    {
                        Target = "UpdatedSample"
                    }
                }
            };
            
            var updatedForm = await fixture.ApiClient.FormsClient.UpdateAsync(createdForm.Id, updateRequest);
            
            updatedForm.Languages.Primary.Should().Be(updateRequest.Languages.Primary);
            updatedForm.Ending.Redirection.Target.Should().Be(updateRequest.Ending.Redirection.Target);

            await fixture.ApiClient.FormsClient.DeleteAsync(allForms.First().Id);
        }
    }
}