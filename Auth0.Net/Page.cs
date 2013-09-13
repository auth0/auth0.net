using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Auth0
{
    /// <summary>
    /// Represents a single page of results that have been returned from an Auth0 API call, such as
    /// /users/ or /connections/.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A page maintains a 'next' link, allowing the next page to be retrieved should one exist. If
    /// a page is enumerated it will <em>not</em> automatically load the next page when reaching the
    /// end of data. In order to enumerate through all results, with automatic paging, use the 
    /// <see cref="AutoPaged"/> method on the first page that is returned from a <see cref="Client"/> 
    /// instance.
    /// </para>
    /// </remarks>
    /// <typeparam name="T">The type of this page.</typeparam>
    public class Page<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> results;
        private readonly bool hasNextPage;
        private readonly Func<Page<T>> loadNext;

        internal Page(IEnumerable<T> results, bool hasNextPage, Func<Page<T>> loadNext)
        {
            this.results = results;
            this.hasNextPage = hasNextPage;
            this.loadNext = loadNext;
        }

        /// <summary>
        /// Returns a boolean indicating whether or not there are more items to fetch. If this
        /// value is <c>true</c> then a call to <see cref="GetNextPage"/> will return another <see cref="Page{T}"/>
        /// with the results of the next page.
        /// </summary>
        public bool HasNextPage
        {
            get { return hasNextPage; }
        }

        /// <summary>
        /// If there are more items to fetch they will be loaded and returned, this page is not modified and
        /// subsequent calls to this method will result in the fetch being executed again.
        /// </summary>
        /// <returns>The next page of data, or an empty <see cref="Page{T}"/> if there is no more data to return.</returns>
        public Page<T> GetNextPage()
        {
            if (hasNextPage)
            {
                return loadNext();
            }

            return new Page<T>(Enumerable.Empty<T>(), false, null);
        }

        /// <summary>
        /// Returns an <see cref="IEnumerator{T}"/> that will automatically page in all results
        /// as they are enumerated.
        /// </summary>
        /// <remarks>
        /// Looping through all pages can result in a number of network calls, which makes the execution
        /// time of this loop non-deterministic. If you want more control over loading then the <see cref="HasNextPage"/> property
        /// and <see cref="GetNextPage"/> method should be used.
        /// </remarks>
        /// <returns>An enumerator that will loop through <em>all</em> results, loading in new pages automatically.</returns>
        public IEnumerable<T> AutoPaged()
        {
            return new AutomaticallyPagedListEnumerator(this);
        }

        /// <summary>
        /// Gets the enumerator for this page, an enumerator which will loop around this page <em>only</em>, see the
        /// <see cref="AutoPaged"/> method if you wish to enumerate around all results, regardless of number of pages or page
        /// size.
        /// </summary>
        /// <returns>An enumerator for this page.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return results.GetEnumerator();
        }

        /// <summary>
        /// Gets the enumerator for this page, an enumerator which will loop around this page <em>only</em>, see the
        /// <see cref="AutoPaged"/> method if you wish to enumerate around all results, regardless of number of pages or page
        /// size.
        /// </summary>
        /// <returns>An enumerator for this page.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        class AutomaticallyPagedListEnumerator : IEnumerator<T>, IEnumerable<T>
        {
            private readonly Page<T> startingPage;
            private Page<T> currentPage;
            private int pageIndex;

            private T current;

            internal AutomaticallyPagedListEnumerator(Page<T> startingPage)
            {
                this.startingPage = startingPage;
                currentPage = startingPage;

                pageIndex = 0;
                current = default(T);
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                // We are at the end of this page, so load the next one (if available)
                if (pageIndex >= currentPage.results.Count())
                {
                    if (!currentPage.HasNextPage)
                    {
                        current = default(T);
                        return false;
                    }
                    
                    currentPage = currentPage.GetNextPage();
                    current = currentPage.ElementAt(0);
                    pageIndex = 1;

                    return true;
                }

                current = currentPage.ElementAt(pageIndex);
                ++pageIndex;
                return true;
            }

            public void Reset()
            {
                pageIndex = 0;
                currentPage = startingPage;
                current = default(T);
            }

            public T Current { get { return current; } }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public IEnumerator<T> GetEnumerator()
            {
                return this;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
