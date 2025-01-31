using Couchbase.KeyValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.EntranceCounter.Persistence.SharedFunctionality
{
    public static class Counters
    {
        /// <summary>
        /// Update the counter value by incrementing or decrementing it.
        /// </summary>
        /// <param name="collection">Couchbase collection</param>
        /// <param name="counterName">Name of the counter</param>
        /// <param name="counterValueChange">Value to change the counter</param>
        /// <returns></returns>
        public static async Task<int> UpdateCounter(ICouchbaseCollection collection, string counterName, int counterValueChange)
        {
            bool incrementFlag = counterValueChange > 0;
            ulong delta = (ulong)Math.Abs(counterValueChange);
            var result = incrementFlag ? await collection.Binary.IncrementAsync(counterName, 
                options => { 
                    options.Delta(delta);
                    options.Initial(0);
                }) 
                : await collection.Binary.DecrementAsync(counterName, options => {
                    options.Delta(delta);
                    options.Initial(0);
                });
            return (int)result.Content;
        }

        /// <summary>
        /// Update the counter value by incrementing or decrementing it.
        /// </summary>
        /// <param name="collection">Couchbase collection</param>
        /// <param name="counterName">Name of the counter</param>
        /// <returns></returns>
        public static async Task<int> GetCounter(ICouchbaseCollection collection, string counterName)
        {
            var results =  await collection.GetAsync(counterName); 
            return results.ContentAs<int>();// Convert.ToInt32(results.Content);
        }
    }
}
