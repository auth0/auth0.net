using System.Collections.Generic;

namespace Auth0.ManagementApi.Paging
{
    /// <summary>
    /// A list which contains paged data from the API.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPagedList<T> : IList<T>
    {
        PagingInformation Paging { get; set; }
    }
}