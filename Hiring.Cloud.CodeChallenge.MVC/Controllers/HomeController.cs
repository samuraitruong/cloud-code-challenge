using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hiring.Cloud.CodeChallenge.MVC.Models;
using Hiring.Cloud.CodeChallenge.Model.Models;
using Microsoft.Extensions.Options;
using Hiring.Cloud.CodeChallenge.Service.Interfaces;
using Hiring.Cloud.CodeChallenge.Common;

namespace Hiring.Cloud.CodeChallenge.MVC.Controllers
{
    public class HomeController : Controller
    {
        readonly ServiceConfig serviceConfig;
        readonly IDataService dataService;

        public HomeController(IOptions<ServiceConfig> serviceConfig, IDataService dataService) {
            this.serviceConfig = serviceConfig.Value;
            this.dataService = dataService;
        }
        public IActionResult Index()
        {
            var data = this.dataService.FetchData();

            var viewModel = new HomeViewModel(data.ToSortedDictionary());
                
            return View(viewModel);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
