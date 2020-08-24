using FIT5032_assignment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/**
 * author Si Yinbo
 * For administrator to manage appliances
 * 
 */

namespace FIT5032_assignment.Controllers
{
    public class AdminController : Controller
    {
        private FIT5032Entities db = new FIT5032Entities();
        // GET: Admin
        public ActionResult Admin()
        {
            User curUser = Session["LoginUser"] as User;
            if (curUser == null || !curUser.Email.Equals("001@admin.com")) {
                return RedirectToAction("Index", "Home");
            }
            //get appliance data
            List<Appliances> appliances = db.Appliances.ToList();
            //pass appliance data to view
            ViewData["appliances"] = appliances;

            return View();
        }

        public ActionResult DeleteAppliance(int appId)
        {
            Appliances appliance = db.Appliances.Where(app => app.Id == appId).ToList()[0];
            List<Order> orders = db.Orders.Where(o => o.AppliancesId == appId).ToList();
            db.Orders.RemoveRange(orders);
            db.Appliances.Remove(appliance);
            db.SaveChanges();

            return RedirectToAction("Admin", "Admin");
        }

        public ActionResult UpdateAppliance()
        {
            System.Diagnostics.Debug.WriteLine("UpdateAppliance");
            // get appliance info from admin page
            int appId = int.Parse(Request["appId"]);
            string appName = Request["appName"];
            float appPrice = float.Parse(Request["appPrice"]);
            int appAmount = int.Parse(Request["appAmount"]);
            string appDesc = Request["appDesc"];
            string appImgUrl = "";
            // save img file
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase appPic = Request.Files["appPic"];
                string picName = Path.GetFileName(appPic.FileName);
                System.Diagnostics.Debug.WriteLine(picName);
                string savePath = "/Img/" + picName;
                if (!Directory.Exists(savePath))
                {
                    appImgUrl = savePath;
                    appPic.SaveAs(Server.MapPath(savePath));
                }
                else {
                    System.Diagnostics.Debug.WriteLine("Path exists: " + savePath );
                }
                
            }

            //update the appliance in the database
            Appliances appliance = db.Appliances.Where(app => app.Id == appId).ToList()[0];
            appliance.AppName = appName;
            appliance.Price = appPrice;
            appliance.Amount = appAmount;
            appliance.Description = appDesc;
            appliance.Img_Url = appImgUrl;
            db.SaveChanges();

            return RedirectToAction("Admin", "Admin");
        }

        public ActionResult AddAppliance()
        {
            System.Diagnostics.Debug.WriteLine("AddAppliance");
            // get appliance info from admin page
            string appName = Request["appName"];
            float appPrice = float.Parse(Request["appPrice"]);
            int appAmount = int.Parse(Request["appAmount"]);
            string appDesc = Request["appDesc"];
            string appImgUrl = "";
            // save img file
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase appPic = Request.Files["appPic"];
                string picName = Path.GetFileName(appPic.FileName);
                System.Diagnostics.Debug.WriteLine(picName);
                string savePath = "/Img/" + picName;
                if (!Directory.Exists(savePath))
                {
                    appImgUrl = savePath;
                    appPic.SaveAs(Server.MapPath(savePath));
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Path exists: " + savePath);
                }

            }

            //add the appliance in the database
            Appliances appliance = new Appliances();
            appliance.AppName = appName;
            appliance.Price = appPrice;
            appliance.Amount = appAmount;
            appliance.Description = appDesc;
            appliance.Img_Url = appImgUrl;
            db.Appliances.Add(appliance);
            db.SaveChanges();

            return RedirectToAction("Admin", "Admin");
        }
    }
}