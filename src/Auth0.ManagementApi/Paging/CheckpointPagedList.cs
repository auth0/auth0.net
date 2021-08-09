using System.Collections.Generic;

namespace Auth0.ManagementApi.Paging
{
    /// List that contains items of <typeparamref name="T"/> as well as metadata
    /// about which page of items this is and how many exist.
    /// <typeparam name="T">Type of item to list.</typeparam>
    public class CheckpointPagedList<T> : List<T>, ICheckpointPagedList<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class that is empty.
        /// </summary>
        public CheckpointPagedList()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class that contains elements copied from the specified collection.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="collection"/> is null.</exception>
        public CheckpointPagedList(IEnumerable<T> collection)
            : base(collection)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class that contains elements copied from the specified collection.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        /// <param name="paging">Information about the current page of information contained in the list.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="collection"/> is null.</exception>
        public CheckpointPagedList(IEnumerable<T> collection, CheckpointPagingInformation paging) : base(collection)
        {
            Paging = paging;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class that is empty.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="capacity"/> is less than 0. </exception>
        public CheckpointPagedList(int capacity) : base(capacity)
        {
        }

        /// <inheritdoc />
        public CheckpointPagingInformation Paging { get; set; }
    }
}
