using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

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
    private FormsTestFixture fixture;

    public FormsTest(FormsTestFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async Task Test_forms_crud_sequence()
    {
        // Create a form
        var createRequest = new CreateFormRequestContent
        {
            Ending = new FormEndingNode
            {
                Coordinates = new FormNodeCoordinates
                {
                    X = 10,
                    Y = 20
                },
                Redirection = new FormEndingNodeRedirection
                {
                    Delay = 1,
                    Target = "sample"
                }
            },
            Languages = new FormLanguages
            {
                Default = "en",
                Primary = "en"
            },
            Messages = new FormMessages
            {
                Custom = new Dictionary<string, string>(),
                Errors = new Dictionary<string, string>()
            },
            Style = new FormStyle
            {
                Css = "<>"
            },
            Translations = new Dictionary<string, Dictionary<string, object?>>(),
            Name = "Test-Form"
        };

        var createdForm = await fixture.ApiClient.Forms.CreateAsync(createRequest);

        fixture.TrackIdentifier(CleanUpType.Forms, createdForm.Id);

        try
        {
            var allFormsPager = await fixture.ApiClient.Forms.ListAsync(new ListFormsRequestParameters
            {
                Hydrate = new FormsRequestParametersHydrateEnum?[] { FormsRequestParametersHydrateEnum.Links }
            });

            var allForms = allFormsPager.CurrentPage.Items.ToList();
            allForms.Should().NotBeNull();
            allForms.Count.Should().BeGreaterThan(0);

            var form = await fixture.ApiClient.Forms.GetAsync(createdForm.Id, new GetFormRequestParameters());

            form.Should().NotBeNull();
            form.Id.Should().Be(createdForm.Id);

            var updateRequest = new UpdateFormRequestContent
            {
                Languages = new FormLanguages
                {
                    Primary = "es"
                },
                Ending = new FormEndingNode
                {
                    Redirection = new FormEndingNodeRedirection
                    {
                        Target = "UpdatedSample"
                    }
                }
            };

            var updatedForm = await fixture.ApiClient.Forms.UpdateAsync(createdForm.Id, updateRequest);

            updatedForm.Languages?.Primary.Should().Be(updateRequest.Languages.Value?.Primary);
            updatedForm.Ending?.Redirection?.Target.Should().Be(updateRequest.Ending.Value?.Redirection?.Target);
        }
        finally
        {
            await fixture.ApiClient.Forms.DeleteAsync(createdForm.Id);
            fixture.UnTrackIdentifier(CleanUpType.Forms, createdForm.Id);
        }
    }
}
