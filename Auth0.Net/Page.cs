using System.Collections;
using System.Collections.Generic;

namespace Auth0
{
    public class Page<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> results;
 
        internal Page(IEnumerable<T> results)
        {
            this.results = results;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return results.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
