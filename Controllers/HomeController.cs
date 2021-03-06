﻿using FIT5032_assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/**
 * author Si Yinbo
 * 
 */
namespace FIT5032_assignment.Controllers
{
    public class HomeController : Controller
    {
        private FIT5032Entities db = new FIT5032Entities();

        public ActionResult Index()
        {
            //get appliance data
            List<Appliances> appliances = db.Appliances.ToList();
            //pass appliance data to view
            ViewData["appliances"] = appliances;
            return View();
        }

        public ActionResult Detail(int applianceId)
        {
            //System.Diagnostics.Debug.WriteLine("appliance: " + applianceId);
            //get the appliance by id
            Appliances appliance = db.Appliances.Where(app => app.Id == applianceId).ToList()[0];
            //System.Diagnostics.Debug.WriteLine("appliance: " + appliance.Id + appliance.AppName + appliance.Price);
            //pass the appliance to the detail page
            ViewData["appliance"] = appliance;
            return View();
        }
    }
}