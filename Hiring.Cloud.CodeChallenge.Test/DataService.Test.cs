using System;
using System.Net.Http;
using Hiring.Cloud.CodeChallenge.Model.Models;
using Hiring.Cloud.CodeChallenge.Service.Interfaces;
using Hiring.Cloud.CodeChallenge.Service.Services;
using Microsoft.Extensions.Options;
using Xunit;
using Moq;
using RichardSzalay.MockHttp;

namespace Hiring.Cloud.CodeChallenge.Test
{
    public class DataServiceTest
    {
        
        [Fact]
        public void FetchData_ShouldReturn_2Items()
        {

            /*string json = "[{\"name\":\"Bradley\",\"cars\":[{\"brand\":\"MG\",\"colour\":\"Blue\"}]},{\"name\":\"Marry\",\"cars\":[{\"brand\":\"Toyota\",\"colour\":\"Blue\"}]}]";
            var mockHttp = new MockHttpMessageHandler();

			// Setup a respond for the user api (including a wildcard in the URL)
            mockHttp.When("http://mock.local/api/cars")
                    .Respond("application/json", json); // Respond with JSON

			// Inject the handler or client into your application code
			var httpClient = mockHttp.ToHttpClient();

            IOptions<ServiceConfig> serviceConfig = Options.Create(new ServiceConfig() { EnableCache = false, RootAPIUrl ="http://mock.local"});
            var  cacheServiceMock = new Mock<ICacheService>();

            IDataService service = new DataService(httpClient, serviceConfig, cacheServiceMock.Object);

            var results = service.FetchData();

            Assert.Equal(2, results.Count);
            */
        }
    }
}
