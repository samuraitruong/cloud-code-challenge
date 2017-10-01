using System;
using System.Collections.Generic;
using System.Net.Http;
using Hiring.Cloud.CodeChallenge.Model.Interfaces;
using Hiring.Cloud.CodeChallenge.Model.Models;
using Hiring.Cloud.CodeChallenge.Service.Interfaces;
using Hiring.Cloud.CodeChallenge.Common;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace Hiring.Cloud.CodeChallenge.Service.Services
{
    public class DataService : IDataService
    {
		const string GET_CARS_ENDPOINT = "api/cars";

		readonly HttpClient client;
        readonly ServiceConfig config;
        readonly ICacheService cacheService;
        readonly ILogger<DataService> logger;
        Object threadSafeLock = new object();

        public DataService(HttpClient client,
                           IOptions<ServiceConfig> serviceConfig, 
                           ICacheService cacheService,
                           ILogger<DataService> logger
                          )
        {
            this.logger = logger;
            this.client = client;
            this.config = serviceConfig.Value;
            this.cacheService = cacheService;
        }
        /// <summary>
        /// This will fetch data from Rest service , then transform data into flatten list that we can use to display in UI, transform for other services....
        /// 
        /// </summary>
        /// <returns>List Of flatten object </returns>
        ///
        public List<IData> FetchData()
        {
            lock (threadSafeLock)
            {
                if (config.EnableCache)
                {
                    // Sometime , Depend on the project , I may add the callback is the Func<T> to re-cache expired object
                    var cachedData = cacheService.GetServiceData();
                    if (cachedData != null) return cachedData;
                }
                List<IOwner> ownersList = null;
                try
                {
                    var content = this.client.GetStringAsync(GET_CARS_ENDPOINT).Result;
                    var response = JsonConvert.DeserializeObject<ServiceResponse>(content);
                    ownersList = new List<IOwner>(response);
                }
                catch (JsonReaderException ex)
                {
                    // Because in real application, Each type of Exceptions will have separate logic to haldle Login so we have to catch all exception separately instead of using just Exception object
                    logger.LogWarning(ex, ex.Message);
                }
                catch (AggregateException ex)
                {
                    logger.LogError(ex, ex.Message);
                }
                var flatten = ownersList.ToFlattenList();

                cacheService.CacheServiceData((flatten));

                return flatten;
            }
        }

    }
}
