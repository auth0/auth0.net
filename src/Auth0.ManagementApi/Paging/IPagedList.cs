using System.Collections.Generic;

namespace Auth0.ManagementApi.Paging
{
    /// <summary>
    /// Interface for a list that contains items of <typeparamref name="T"/> as well as metadata
    /// about which page of items this is and how many exist.
    /// </summary>
    /// <typeparam name="T">Type of item to list.</typeparam>
    public interface IPagedList<T> : IList<T>
    {
        /// <summary>
        /// Information about how many items exist, which page this is
        /// etc.
        /// </summary>
        PagingInformation Paging { get; set; }
    }
}