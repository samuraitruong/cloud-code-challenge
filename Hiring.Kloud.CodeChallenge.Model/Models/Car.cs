using System;
using Hiring.Kloud.CodeChallenge.Model.Interfaces;
using Newtonsoft.Json;

namespace Hiring.Kloud.CodeChallenge.Model.Models
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
