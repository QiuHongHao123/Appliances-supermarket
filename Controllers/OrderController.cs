using FIT5032_assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIT5032_assignment.Controllers
{
    public class OrderController : Controller
    {
        private FIT5032Entities db = new FIT5032Entities();

        // GET: Order
        public ActionResult Order()
        {
            List<Order> orders = db.Orders.ToList();
            ViewData["orders"] = orders;
            return View();
        }

        public ActionResult CreateOrder()
        {
            System.Diagnostics.Debug.WriteLine("create order");
            // get order info from detail page
            int userId = int.Parse(Request["UserId"]);
            int applianceId = int.Parse(Request["ApplianceId"]);
            int amount = int.Parse(Request["Amount"]);
            String address = Request["Address"];

            //add order to database
            Order order = new Order();
            order.UserId = userId;
            order.AppliancesId = applianceId;
            order.Amount = amount;
            order.CurrentLocation = address;
            order.Date = DateTime.Now;
            db.Orders.Add(order);
            db.SaveChanges();

            return RedirectToAction("Order", "Order");
        }

        public ActionResult DeleteOrder(int orderId) 
        {
            Order order = db.Orders.Where(o => o.Id == orderId).ToList()[0];
            db.Orders.Remove(order);
            db.SaveChanges();

            return RedirectToAction("Order", "Order");
        }

        public ActionResult UpdateOrder(int orderId, int rate)
        {
            Order order = db.Orders.Where(o => o.Id == orderId).ToList()[0];
            order.Rate = rate;
            db.SaveChanges();
            return RedirectToAction("Order", "Order");
        }
    }
}