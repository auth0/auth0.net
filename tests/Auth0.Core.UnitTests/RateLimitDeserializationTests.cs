using Auth0.Core.Exceptions;
using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Xunit;

namespace Auth0.Core.UnitTests
{
    public class RateLimitDeserializationTests
    {
        [Theory]
        [ClassData(typeof(RateLimitDeserializationData))]
        public void Should_deserialize_all_rate_limit_headers_correctly(HttpHeaders content, RateLimit expected)
        {
            var actual = RateLimit.Parse(content);

            actual.Should().BeEquivalentTo(expected);
        }
    }

    public class RateLimitDeserializationData : IEnumerable<object[]>
    {
        private static HttpHeaders CreateHeaders(
            int? limit, int? remaining, long? reset,long? retryAfter = null, string clientQuota = null, string orgQuota = null)
        {
            var client = new HttpRequestMessage(HttpMethod.Get, "https://fake");
            if (limit != null)
                client.Headers.Add("x-ratelimit-limit", limit.ToString());
            if (remaining != null)
                client.Headers.Add("x-ratelimit-remaining", remaining.ToString());
            if (reset != null)
                client.Headers.Add("x-ratelimit-reset", reset.ToString());
            if (retryAfter != null)
                client.Headers.Add("Retry-After", retryAfter.ToString());
            if (clientQuota != null)
                client.Headers.Add("Auth0-Client-Quota-Limit", clientQuota);
            if (orgQuota != null)
                client.Headers.Add("Auth0-Organization-Quota-Limit", orgQuota);
            return client.Headers;
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                CreateHeaders(100, 10, 1585694338),
                new RateLimit
                {
                    Limit = 100,
                    Remaining = 10,
                    Reset = new DateTimeOffset(2020, 3, 31, 22, 38, 58, TimeSpan.Zero)
                }
            };

            yield return new object[]
            {
                CreateHeaders(5, 100, 1585694338),
                new RateLimit
                {
                    Limit = 5,
                    Remaining = 100,
                    Reset = new DateTimeOffset(2020, 3, 31, 22, 38, 58, TimeSpan.Zero)
                }
            };

            yield return new object[]
            {
                CreateHeaders(null, 10, null),
                new RateLimit
                {
                    Limit = 0,
                    Remaining = 10,
                    Reset = null
                }
            };
            yield return new object[]
            {
                CreateHeaders(null, 10, null, 34567,
                    "b=per_hour;q=10;r=9;t=774,b=per_day;q=100;r=99;t=22374", null),
                new RateLimit
                {
                    Limit = 0,
                    Remaining = 10,
                    Reset = null,
                    RetryAfter = 34567,
                    ClientQuotaLimit = new ClientQuotaLimit()
                    {
                        PerHour = new QuotaLimit
                        {
                            Quota = 10,
                            Remaining = 9,
                            Time = 774
                        },
                        PerDay = new QuotaLimit
                        {
                            Quota = 100,
                            Remaining = 99,
                            Time = 22374
                        }
                    }
                }
            };
            yield return new object[]
            {
                CreateHeaders(null, 10, null,
                    45678,null, "b=per_hour;q=10;r=9;t=774,b=per_day;q=100;r=99;t=22374"),
                new RateLimit
                {
                    Limit = 0,
                    Remaining = 10,
                    Reset = null,
                    RetryAfter = 45678,
                    OrganizationQuotaLimit = new OrganizationQuotaLimit()
                    {
                        PerHour = new QuotaLimit
                        {
                            Quota = 10,
                            Remaining = 9,
                            Time = 774
                        },
                        PerDay = new QuotaLimit
                        {
                            Quota = 100,
                            Remaining = 99,
                            Time = 22374
                        }
                    }
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}