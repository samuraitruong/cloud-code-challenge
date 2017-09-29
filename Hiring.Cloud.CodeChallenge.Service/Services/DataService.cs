using System;
using System.Collections.Generic;
using System.Net.Http;
using Hiring.Cloud.CodeChallenge.Model.Interfaces;
using Hiring.Cloud.CodeChallenge.Model.Models;
using Hiring.Cloud.CodeChallenge.Service.Interfaces;
using Hiring.Cloud.CodeChallenge.Common;
using Newtonsoft.Json;
using RestSharp;
using System.Linq;
using Microsoft.Extensions.Options;

namespace Hiring.Cloud.CodeChallenge.Service.Services
{
    public class DataService : IDataService
    {
		const string GET_CARS_ENDPOINT = "api/cars";

		readonly HttpClient client;
        readonly ServiceConfig config;
        readonly ICacheService cacheService;

        public DataService(HttpClient client,
                           IOptions<ServiceConfig> serviceConfig, 
                           ICacheService cacheService
                          )
        {
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
            if(config.EnableCache) {
				// Sometime , Depend on the project , I may add the callback is the Func<T> to re-cache expired object
				var cachedData = cacheService.GetServiceData();
                if (cachedData != null) return cachedData;
            }

            // .Result will block thread
            var content = this.client.GetStringAsync(GET_CARS_ENDPOINT).Result;
            var result = JsonConvert.DeserializeObject<ServiceResponse>(content);
            var castedList = new List<IOwner>(result);
            var flatten = castedList.ToFlattenList();

            cacheService.CacheServiceData((flatten));

            return flatten;
        }

    }
}
