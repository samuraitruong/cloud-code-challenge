using System;
using System.Collections.Generic;
using Hiring.Cloud.CodeChallenge.Model.Interfaces;
using System.Linq;
using Hiring.Cloud.CodeChallenge.Model.Models;

namespace Hiring.Cloud.CodeChallenge.Common
{
    public static class ListExtentions
    {
        /// <summary>
        /// This function to transform the ICollection to Ordered Data structure
        /// </summary>
        /// <returns>The dictionary.</returns>
        /// <param name="data">A list of object , intance of IList<IOwner>
        /// This function can be also implement as generic to increase re-use code ability in larger size of code, in this example, we write this simple function
        /// 
        public static SortedDictionary<string, SortedList<string, string>> ToSortedDictionary(this List<IData> data) {
            var result = new SortedDictionary<string, SortedList<string, string>>();

            data.ForEach((item) => AddItemToDictionary(result, item.BrandName, item.OwnerName));

            //We can also use LinQ Group By here, However, SortedList &Dictionary Sorted will improve perfomance , It also support Reverse function to support sort DESC

            return result;
        }
        /// <summary>
        /// Adds the item to dictionary.
        /// </summary>
        /// <param name="dictionary">Dictionary.</param>
        /// <param name="key">A unique string for key :ex Toyota</param>
        /// <param name="value">A string for value items list, ex : brand name</param>
        public static void AddItemToDictionary(SortedDictionary<string, SortedList<string, string>> dictionary, string key, string value) {

            //Ignore if brand or name is empty
            if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(value)) return;

            if(dictionary.ContainsKey(key)) {
                if (!dictionary[key].ContainsKey(value))
                {
                    dictionary[key].Add(value, value);
                }
            }
            else{
                var newItem = new SortedList<string, string>();
                newItem.Add(value, value);
                dictionary.Add(key, newItem);
            }
        }

		/// <summary>
		/// This functon to break the data from nest structure to a flat struct, this quite good for this this simple project because we can apply sort/groupby later
		/// </summary>
		/// <returns>The flatten list with IData type</returns>
		/// <param name="data">Input is he list of IOwner, this is raw structure return from service example here - https://kloudcodingtest.azurewebsites.net/api/cars.</param>
		public static List<IData> ToFlattenList(this List<IOwner> data) {

            var flattenData = data.SelectMany(owner => owner.Cars.Select(car => new Data() {
                OwnerName = owner.Name,
                BrandName = car.Brand,
                Color = car.Color
                
            }));
            return new List<IData>(flattenData);
            
        }
    }
}
