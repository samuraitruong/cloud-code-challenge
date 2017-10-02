using System;
using Hiring.Kloud.CodeChallenge.Model.Interfaces;

namespace Hiring.Kloud.CodeChallenge.Model.Models
{
    public class Data :IData
    {
        public Data()
        {
        }
		public string OwnerName { get; set; }
		public string BrandName { get; set; }
		public string Color { get; set; }
    }
}
