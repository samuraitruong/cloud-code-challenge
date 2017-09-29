using System;
using System.Collections.Generic;
using Hiring.Cloud.CodeChallenge.Model.Interfaces;
using Newtonsoft.Json;

namespace Hiring.Cloud.CodeChallenge.Model.Models
{
    public class Owner : IOwner
    {
        public Owner(List<Car> cars)
        {
            this.Cars = new List<ICar>();

            if (cars != null)
            {
                this.Cars.AddRange(cars);
            }
        }

        [JsonProperty("name")]
        public string Name { get; set;  }
        [JsonProperty("cars")]
        //[JsonConverter(typeof(List<Car>))]
        public List<ICar> Cars { get; set; }
    }
}
