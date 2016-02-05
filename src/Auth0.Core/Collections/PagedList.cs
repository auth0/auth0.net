using System.Collections.Generic;

namespace Auth0.Core.Collections
{
    /// <summary>
    /// A list which contains paged data from the API.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedList<T> : List<T>, IPagedList<T>, IList<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class that is empty and has the default initial capacity.
        /// </summary>
        public PagedList()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class that contains elements copied from the specified collection and has sufficient capacity to accommodate the number of elements copied.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param><exception cref="T:System.ArgumentNullException"><paramref name="collection"/> is null.</exception>
        public PagedList(IEnumerable<T> collection) : base(collection)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class that contains elements copied from the specified collection and has sufficient capacity to accommodate the number of elements copied.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        /// <param name="paging">Information about the current page of information contained in the list.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="collection"/> is null.</exception>
        public PagedList(IEnumerable<T> collection, PagingInformation paging) : base(collection)
        {
            Paging = paging;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Collections.Generic.List`1"/> class that is empty and has the specified initial capacity.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="capacity"/> is less than 0. </exception>
        public PagedList(int capacity) : base(capacity)
        {
        }

        /// <summary>
        /// Contains information about the current page of data which is contained in the list.
        /// </summary>
        public PagingInformation Paging { get; set; }
    }
}