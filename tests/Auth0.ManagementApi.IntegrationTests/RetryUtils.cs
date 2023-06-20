using System;
using System.Threading.Tasks;


namespace Auth0.ManagementApi.IntegrationTests
{
    public class RetryUtils
    {
        public static async Task<TResult> Retry<TResult>(Func<Task<TResult>> retryable, Func<TResult, bool> retryWhen, int numberOfHttpRetries = 3)
        {
            var nrOfTries = 0;
            var nrOfTriesToAttempt = numberOfHttpRetries;

            while (true)
            {
                nrOfTries++;

                var result = await retryable();

                if (!retryWhen(result) || nrOfTries >= nrOfTriesToAttempt)
                {
                    return result;
                }

                await Task.Delay(1000);
            }
        }
    }
}
