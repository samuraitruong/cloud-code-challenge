using System;
using Hiring.Cloud.CodeChallenge.Model.Models;
using Newtonsoft.Json;
using Xunit;

namespace Hiring.Cloud.CodeChallenge.Test
{
    /// <summary>
    /// All those unit test below to make sure that the meta attibute is correct 
    /// Assume we use JSON.NET cross the application to do desirialize string to oject with default config.
    /// </summary>
    /// [

    public class Model
    {
        [Fact]
        public void Car_ShouldDeserialize_WhenInputValid()
        {
            string input = "{\"brand\":\"MG\",\"colour\":\"Blue\"}";
            var car = JsonConvert.DeserializeObject<Car>(input);
            Assert.Equal("MG", car.Brand);
            Assert.Equal("Blue", car.Color);
        }

    }
}
