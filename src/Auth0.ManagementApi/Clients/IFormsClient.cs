using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models.Forms;
using Auth0.ManagementApi.Paging;

namespace Auth0.ManagementApi.Clients;

public interface IFormsClient
{
    /// <summary>
    /// Get all Forms
    /// </summary>
    /// <param name="request"><see cref="FormsGetRequest"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>All available <see cref="Form" />s.</returns>
    Task<IPagedList<FormBase>> GetAllAsync(FormsGetRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get A form.
    /// </summary>
    /// <param name="request"><see cref="FormsGetRequest"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>All available <see cref="Form" />s.</returns>
    Task<Form> GetAsync(FormsGetRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a form.
    /// </summary>
    /// <param name="request"><see cref="FormCreateRequest"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task<Form> CreateAsync(FormCreateRequest request, CancellationToken cancellationToken = default);
        
    /// <summary>
    /// Update a form.
    /// </summary>
    /// <param name="id">ID of the form to be updated</param>
    /// <param name="request"><see cref="FormUpdateRequest"/></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Form> UpdateAsync(string id, FormUpdateRequest request, CancellationToken cancellationToken = default);
        
    /// <summary>
    /// Delete a form.
    /// </summary>
    /// <param name="id">ID of the form to be deleted</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);
}