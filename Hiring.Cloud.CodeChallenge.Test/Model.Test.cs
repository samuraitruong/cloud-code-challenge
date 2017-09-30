using System;
using Hiring.Cloud.CodeChallenge.Model.Models;
using Newtonsoft.Json;
using Xunit;
using System.Collections.Generic;
using Hiring.Cloud.CodeChallenge.Model.Interfaces;
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

        [Fact]
        public void Car_ShouldDeserialize_WhenMissingProperty()
        {
            string input = "{\"brand1\":\"MG\",\"colour\":\"Blue\"}";
            var car = JsonConvert.DeserializeObject<Car>(input);
            Assert.Equal("Blue", car.Color);
        }

        [Fact]
        public void Owner_ShouldDeserialize_WhenInputValid()
        {
            string input = "{name: \"Truong\", \"cars\": [{\"brand1\":\"MG\",\"colour\":\"Blue\"}]}";
            var owner = JsonConvert.DeserializeObject<Owner>(input);
            Assert.Equal("Truong", owner.Name);
            Assert.Single(owner.Cars);
        }

		[Fact]
		public void Owner_ShouldDeserialize_WhenMissingName()
		{
			string input = "{\"cars\": [{\"brand\":\"MG\",\"colour\":\"Blue\"}]}";
			var owner = JsonConvert.DeserializeObject<Owner>(input);
            Assert.NotNull(owner);
			Assert.Single(owner.Cars);
            Assert.Equal("MG",owner.Cars[0].Brand);
		}

        [Fact]
        public void Owner_ShouldDeserialize_WhenMissingCarsInInput()
        {
            string input = "{name: \"Truong\"}";
            var owner = JsonConvert.DeserializeObject<Owner>(input);
            Assert.Equal("Truong", owner.Name);
            Assert.Empty(owner.Cars);
        }

        [Fact]
        public void Owner_ShouldDeserialize_WhenInputIsEmpty()
        {
            string input = "{}";
            var owner = JsonConvert.DeserializeObject<Owner>(input);
            Assert.NotNull(owner);
            Assert.True(string.IsNullOrEmpty(owner.Name));
            Assert.Empty(owner.Cars);
        }

        [Fact]
        public void List_Owner_ShouldHas2Owner()
        {
            string input = "[{name: \"Truong\", \"cars\": [{\"brand1\":\"MG\",\"colour\":\"Blue\"}]}, {name: \"Jonh\", \"cars\": [{\"brand\":\"Toyota\",\"colour\":\"Red\"}]}]";
            var list = JsonConvert.DeserializeObject<ServiceResponse>(input);
            
            Assert.Equal(2, list.Count);
            Assert.Equal("Truong", list[0].Name);
            Assert.Equal("Jonh", list[1].Name);
        }
        [Fact]
        public void List_Owner_ShouldEmpty_WhenEmptyInput()
        {
            string input = "[]";
            var list = JsonConvert.DeserializeObject<ServiceResponse>(input);
            Assert.Empty(list);
        }
       
    }
}
