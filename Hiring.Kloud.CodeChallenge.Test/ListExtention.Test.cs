using System;
using System.Collections.Generic;
using Xunit;
using Hiring.Kloud.CodeChallenge.Common;
using Hiring.Kloud.CodeChallenge.Model.Interfaces;
using Hiring.Kloud.CodeChallenge.Model.Models;
using System.Linq;

namespace Hiring.Kloud.CodeChallenge.Test
{
    public class ListExtention
    {
        [Fact]
        public void AddItemToDictionary_ShouldAddItem_WhenInputValid()
        {
            SortedDictionary<string, SortedList<string, string>> dict = new SortedDictionary<string, SortedList<string, string>>();
            var name = "Toyota";
            var owerName = "Truong Nguyen";

            ListExtentions.AddItemToDictionary(dict, name, owerName);

            Assert.True(dict.ContainsKey(name));

            Assert.NotNull(dict[name]);

            Assert.Single(dict[name]);

            Assert.True(dict[name].ContainsKey(owerName));
		}
		
		[Fact]
		public void AddItemToDictionary_ShouldAppendItem_WhenInputValid()
		{
			SortedDictionary<string, SortedList<string, string>> dict = new SortedDictionary<string, SortedList<string, string>>();
			var name = "Toyota";
			var owerName1 = "Truong Nguyen";
            var owerName2 = "Truong Nguyen 3";

			ListExtentions.AddItemToDictionary(dict, name, owerName1);
            ListExtentions.AddItemToDictionary(dict, name, owerName2);

            Assert.True(dict.ContainsKey(name));
			Assert.NotNull(dict[name]);
			Assert.Equal(2, dict[name].Count);
		}
		
		[Fact]
		public void AddItemToDictionary_ShouldAddMutipkeKey_WhenInputValid()
		{
			SortedDictionary<string, SortedList<string, string>> dict = new SortedDictionary<string, SortedList<string, string>>();
			var name1 = "Toyota";
            var name2 = "BMW";
			var owerName1 = "Truong Nguyen";

			ListExtentions.AddItemToDictionary(dict, name1, owerName1);

			Assert.True(dict.ContainsKey(name1));

            ListExtentions.AddItemToDictionary(dict, name2, owerName1);

            Assert.True(dict.ContainsKey(name2));

            Assert.True(dict[name2].ContainsKey(owerName1));
		}
		
		[Fact]
		public void AddItemToDictionary_ShouldIgnore_WhenKeyEmpty()
		{
			SortedDictionary<string, SortedList<string, string>> dict = new SortedDictionary<string, SortedList<string, string>>();
			var owerName1= "Truong Nguyen";

			ListExtentions.AddItemToDictionary(dict, null, owerName1);

            Assert.Empty(dict.Keys);
		}

		
		[Fact]
		public void AddItemToDictionary_ShouldIgnore_WhenValueEmpty()
		{
			SortedDictionary<string, SortedList<string, string>> dict = new SortedDictionary<string, SortedList<string, string>>();
			var owerName1 = "Truong Nguyen";
            var name = "Toyota";

            ListExtentions.AddItemToDictionary(dict, name, null);
			Assert.Empty(dict.Keys);

            ListExtentions.AddItemToDictionary(dict, name, owerName1);
            Assert.Single(dict.Keys);
            Assert.Single(dict[name]);

            ListExtentions.AddItemToDictionary(dict, name, null);
            Assert.Single(dict[name]);
		}
		
		[Fact]
		public void ToSortedDictionary_ShouldHas2Brand_WhenInputsValid()
		{
            List<IOwner> input = new List<IOwner>() {
                new Owner(new List<Car>(){ new Car(){Brand= "Toyota"}}) {Name = "Truong Nguyen"},
                new Owner(new List<Car>(){ new Car(){Brand= "Toyota"}, new Car() { Brand = "BMW" } }) {Name = "Truong Nguyen"}
            };

            var dict = input.ToFlattenList().ToSortedDictionary();

            Assert.Equal(2, dict.Keys.Count);
            Assert.NotNull(dict["Toyota"]);
            Assert.NotNull(dict["BMW"]);
		}
		[Fact]
		public void ToSortedDictionary_ShouldHas2Owner_WhenInputsValid()
		{
			List<IOwner> input = new List<IOwner>() {
				new Owner(new List<Car>(){ new Car(){Brand= "Toyota"}}) {Name = "Truong Nguyen"},
				new Owner(new List<Car>(){ new Car(){Brand= "Toyota"}, new Car() { Brand = "BMW" } }) {Name = "Jonh Doe"}
			};

			var dict = input.ToFlattenList().ToSortedDictionary();

			Assert.Equal(2, dict["Toyota"].Count);
            Assert.Single(dict["BMW"]);

		}

		
		[Fact]
		public void ToFlattenList_ShouldHas3Item_WhenInputsValid()
		{
			List<IOwner> input = new List<IOwner>() {
				new Owner(new List<Car>(){ new Car(){Brand= "Toyota"}}) {Name = "Truong Nguyen"},
				new Owner(new List<Car>(){ new Car(){Brand= "Toyota"}, new Car() { Brand = "BMW" } }) {Name = "Truong Nguyen"}
			};

            var flatten = input.ToFlattenList();

			Assert.Equal(3, flatten.Count);
		}

        [Fact]
        public void ToFlattenList_ShouldReturnEmptyList_WhenInputIsNull()
        {
            List<IOwner> input = null;
            var flatten = input.ToFlattenList();

            Assert.Empty(flatten);
        }

        [Fact]
		public void ToFlattenList_ShouldConvertCorrectValue_WhenInputsValid()
		{
			List<IOwner> input = new List<IOwner>() {
                new Owner(new List<Car>(){ new Car(){Brand= "Toyota", Color = "Red"}}) {Name = "Truong Nguyen"}
			};

			var flatten = input.ToFlattenList();

            var result = flatten.First();
			Assert.Single(flatten);

            Assert.Equal("Red", result.Color);

            Assert.Equal("Truong Nguyen", result.OwnerName);
		}
        [Fact]
        public void ToOwnerList_ShouldHas2Item()
        {
            List<IData> data = new List<IData>()
            {
                new Data() {BrandName = "Toyota", Color="Red", OwnerName = "User1"},
                new Data() {BrandName = "BMW", Color="Red", OwnerName = "User2"},
            };

            var owners = data.ToOwnerList();

            Assert.Equal(2, owners.Count);
        }
        // In the real project, To make unit test code clean and reuse, We may have to build the data sample insite the json file and using it inside the code.

        [Fact]
        public void ToOwnerList_ShouldHas1Item()
        {
            List<IData> data = new List<IData>()
            {
                new Data() {BrandName = "Toyota", Color="Red", OwnerName = "User1"},
                new Data() {BrandName = "BMW", Color="Red", OwnerName = "User1"},
            };

            var owners = data.ToOwnerList();

            Assert.Single(owners);
            Assert.Equal(2, owners.First().Cars.Count);
        }

    }
}
