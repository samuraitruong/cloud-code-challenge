using System;
using Hiring.Cloud.CodeChallenge.Model.Interfaces;
using Newtonsoft.Json;

namespace Hiring.Cloud.CodeChallenge.Model.Models
{
    public class Car : ICar
    {
        public Car()
        {
        }
        [JsonProperty("brand")]
        public string Brand { get ;set; }
        [JsonProperty("colour")]
        public string Color { get ;set; }
    }
}
