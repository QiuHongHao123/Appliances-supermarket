using FIT5032_assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIT5032_assignment.Controllers
{
    public class ShowViewModelController : Controller
    {
        // GET: ShowViewModel
       
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ApplienceShow()
        {
            Appliances appliance = (Appliances)TempData["curAppliance"];
            Models.ApplienceShowViewModel applienceShowViewModel = new Models.ApplienceShowViewModel();
            applienceShowViewModel.amount = 0;
            applienceShowViewModel.describe = "";
            applienceShowViewModel.applienceName = "not init";
            applienceShowViewModel.imgUrl = "/Img/default400.jpg";
            applienceShowViewModel.price = 0;
            
            return View(applienceShowViewModel);
        }
    }
}