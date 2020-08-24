using FIT5032_assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/**
 * author Qiu
 * The controller to show the appliances
 */
namespace FIT5032_assignment.Controllers
{
    public class ShowViewModelController : Controller
    {
        // GET: ShowViewModel
       
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult ApplianceShow()
        {



            Appliances appliance = (Appliances)TempData["curAppliance"];


            return View();
        }
    }
}