namespace Auth0.ManagementApi.Paging
{
    /// <summary>
    /// Specifies checkpoint pagination info to use when requesting paged results.
    /// </summary>
    public class CheckpointPaginationInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckpointPaginationInfo"/> class.
        /// </summary>
        /// <param name="from">When using checkpoint pagination, an Id from which to begin the next page of results.</param>
        /// <param name="take">When using checkpoint pagination, the number of results per page.</param>
        public CheckpointPaginationInfo(string from = null, int? take = null)
        {
            From = from;
            Take = take;
        }

        /// <summary>
        /// When using checkpoint pagination, an Id from which to begin the next page of results.
        /// </summary>
        public string From { get; } = null;

        /// <summary>
        /// When using checkpoint pagination, the number of results per page. Required to use checkpoint pagination.
        /// </summary>
        public int? Take { get; } = null;
    }
}
