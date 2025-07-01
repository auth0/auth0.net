using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Auth0.ManagementApi.Models.Forms;
using Auth0.ManagementApi.Paging;

using Newtonsoft.Json;

namespace Auth0.ManagementApi.Clients;

public class FormsClient : BaseClient, IFormsClient
{
    private readonly JsonConverter[] formsConverters = [new PagedListConverter<FormBase>("forms")];
        
    /// <summary>
    /// Initializes a new instance of <see cref="FormsClient"/>.
    /// </summary>
    /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
    /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
    /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
    public FormsClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders) : base(connection, baseUri, defaultHeaders)
    {

    }

    /// <inheritdoc />
    public Task<IPagedList<FormBase>> GetAllAsync(FormsGetRequest request, CancellationToken cancellationToken = default)
    {
        request.ThrowIfNull();

        var queryStrings = new Dictionary<string, string>();

        if (request.Hydrate != null && request.Hydrate.Any())
        {
            var hydrateValues = string.Join(",",  request.Hydrate.Select( x => x.ToString().ToLower()));
            queryStrings["hydrate"] = hydrateValues;
        }

        if (request.PaginationInfo != null)
        {
            queryStrings["page"] = request.PaginationInfo.PageNo.ToString();
            queryStrings["per_page"] = request.PaginationInfo.PerPage.ToString();
            queryStrings["include_totals"] = request.PaginationInfo.IncludeTotals.ToString().ToLower();
        }

        return Connection.GetAsync<IPagedList<FormBase>>(BuildUri("forms", queryStrings), DefaultHeaders, formsConverters, cancellationToken);
    }

    /// <inheritdoc />
    public Task<Form> GetAsync(FormsGetRequest request, CancellationToken cancellationToken = default)
    {
        request.ThrowIfNull();
        request.Id.ThrowIfNull();

        var queryStrings = new Dictionary<string, string>();

        if (request.Hydrate != null && request.Hydrate.Any())
        {
            var hydrateValues = string.Join(",",  request.Hydrate.Select( x => x.ToString().ToLower()));
            queryStrings["hydrate"] = hydrateValues;
        }

        return Connection.GetAsync<Form>(BuildUri($"forms/{EncodePath(request.Id)}", queryStrings), DefaultHeaders, null, cancellationToken);
    }

    /// <inheritdoc />
    public Task<Form> CreateAsync(FormCreateRequest request, CancellationToken cancellationToken = default)
    {
        return Connection.SendAsync<Form>(HttpMethod.Post, BuildUri("forms"), request, DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task<Form> UpdateAsync(string id, FormUpdateRequest request, CancellationToken cancellationToken = default)
    {
        id.ThrowIfNull();
        return Connection.SendAsync<Form>(new HttpMethod("PATCH"), BuildUri($"forms/{EncodePath(id)}"), request, DefaultHeaders, cancellationToken: cancellationToken);
    }

    /// <inheritdoc />
    public Task DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        id.ThrowIfNull();
            
        return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"forms/{EncodePath(id)}"), null, DefaultHeaders, cancellationToken: cancellationToken);
    }
}