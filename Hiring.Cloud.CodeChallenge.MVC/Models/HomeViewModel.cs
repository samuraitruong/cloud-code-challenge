﻿using System;
using System.Collections.Generic;

namespace Hiring.Cloud.CodeChallenge.MVC.Models
{
    public class HomeViewModel
    {
        public SortedDictionary<string, SortedList<string, string>> Brands;
        public HomeViewModel(SortedDictionary<string, SortedList<string, string>> brands)
        {
            this.Brands = brands;
        }
    }
}
