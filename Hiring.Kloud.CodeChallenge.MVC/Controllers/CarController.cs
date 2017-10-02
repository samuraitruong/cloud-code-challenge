using System;
using Microsoft.AspNetCore.Mvc;
using Hiring.Kloud.CodeChallenge.Service.Interfaces;
using Hiring.Kloud.CodeChallenge.Common;
using System.Threading.Tasks;

namespace Hiring.Kloud.CodeChallenge.MVC.Controllers
{
    /// <summary>
    /// Car controller.
    /// In .NET core , normal MVC controller and APIController has been combined.
    /// </summary>
    [Route("/api/cars")]
    public class CarController : Controller
    {
        readonly IDataService service;
        public CarController(IDataService dataService)
        {
            this.service = dataService;
        }

        [HttpGet]
		public async Task<JsonResult> Index()
		{
            // We catch all exception inside the FetchData, So we dont need handle exception here, However, Depend on requirement, We may have to implement exception flow inside api layer.

            var data = await this.service.FetchDataAsync();

            // In the real work project, We may handle exception outside of service and return the proper error code /content.
            return Json(data.ToOwnerList());
		}
    }
}
