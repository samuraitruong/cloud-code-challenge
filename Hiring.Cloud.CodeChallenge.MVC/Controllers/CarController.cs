﻿using System;
using Microsoft.AspNetCore.Mvc;
using Hiring.Cloud.CodeChallenge.Service.Interfaces;
using Hiring.Cloud.CodeChallenge.Common;

namespace Hiring.Cloud.CodeChallenge.MVC.Controllers
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
		public JsonResult Get()
		{
            return Json(this.service.FetchData().ToOwnerList());
		}
    }
}