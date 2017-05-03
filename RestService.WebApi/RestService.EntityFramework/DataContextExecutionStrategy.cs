using System;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;


namespace RestService.EntityFramework
{
    public class DataContextExecutionStrategy : DbExecutionStrategy
    {
        /// <summary>
        /// The default retry limit is 5, which means that the total amount of time spent 
        /// between retries is 26 seconds plus the random factor.
        /// </summary>
        public DataContextExecutionStrategy()
        {
        }

        /// <summary>
        /// Creates a new instance of "DataContextContextStrategy" with the specified limits for
        /// number of retries and the delay between retries.
        /// </summary>
        /// <param name="maxRetryCount"> The maximum number of retry attempts. </param>
        /// <param name="maxDelay"> The maximum delay in milliseconds between retries. </param>
        public DataContextExecutionStrategy(int maxRetryCount, TimeSpan maxDelay)
            : base(maxRetryCount, maxDelay)
        {
        }

        protected override bool ShouldRetryOn(Exception ex)
        {
            bool retry = false;

            SqlException sqlException = ex as SqlException;
            if (sqlException != null)
            {
                int[] errorsToRetry =
                {
                    1205,  //Deadlock
                    -2,    //Timeout
                };
                if (sqlException.Errors.Cast<SqlError>().Any(x => errorsToRetry.Contains(x.Number)))
                {
                    retry = true;
                }
                else
                {
                    //Add some error logging on this line for errors we aren't retrying.
                    //Make sure you record the Number property of sqlError. 
                    //If you see an error pop up that you want to retry, you can look in 
                    //your log and add that number to the list above.
                }
            }
            if (ex is TimeoutException)
            {
                retry = true;
            }
            return retry;
        }
    }
}
