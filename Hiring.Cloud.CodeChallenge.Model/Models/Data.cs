using System;
using Hiring.Cloud.CodeChallenge.Model.Interfaces;

namespace Hiring.Cloud.CodeChallenge.Model.Models
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
