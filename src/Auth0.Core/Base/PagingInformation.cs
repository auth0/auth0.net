using Newtonsoft.Json;

namespace Auth0.Core
{
    public class PagingInformation
    {
        [JsonProperty("length")]
        public int Length { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("start")]
        public int Start { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        public PagingInformation(int start, int limit, int length, int total)
        {
            Start = start;
            Limit = limit;
            Length = length;
            Total = total;
        }
    }
}