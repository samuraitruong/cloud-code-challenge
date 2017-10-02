using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hiring.Kloud.CodeChallenge.MVC.Models;
using Hiring.Kloud.CodeChallenge.Model.Models;
using Microsoft.Extensions.Options;
using Hiring.Kloud.CodeChallenge.Service.Interfaces;
using Hiring.Kloud.CodeChallenge.Common;

namespace Hiring.Kloud.CodeChallenge.MVC.Controllers
{
    public class HomeController : Controller
    {
        readonly ServiceConfig serviceConfig;
        readonly IDataService dataService;

        public HomeController(IOptions<ServiceConfig> serviceConfig, IDataService dataService) {
            this.serviceConfig = serviceConfig.Value;
            this.dataService = dataService;
        }
        //consider to use ASYNC method in here because Controller access to Http Service request, It may take long
        // see API/Cars which implement using async
        /*
        public async Task<IActionResult> Index()
		{
			var data = await this.dataService.FetchDataAsync();

			var viewModel = new HomeViewModel(data.ToSortedDictionary());

			return View(viewModel);
		}
		*/
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
