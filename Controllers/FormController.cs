using FIT5032_assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIT5032_assignment.Controllers
{
    public class FormController : Controller
    {

        private HomeController homeController=new HomeController();
        private FIT5032Entities db = new FIT5032Entities();
        // GET: Form
        public ActionResult Index()
        {
            return View();
        }

        // GET: Form/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Form/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterView model)
        {
            try
            {
                Credential credential = new Credential();
                credential.Password = model.Password;

                User user = new User();
                user.Address = model.Address;
                user.Age = model.Age;
                user.Email = model.Email;
                user.Username = model.Name;

                credential.User = user;
                user.Credential = credential;
                db.Credentials.Add(credential);
                db.Users.Add(user);

                db.SaveChanges();
                return RedirectToAction("../Home/Index");
            }
            catch {
                return RedirectToAction("../Shared/Error");
            }
        }
        public ActionResult Login()
        { 
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login model)
        {

            String userName=model.Username;
            String password = model.Password;
            List<User> loginUsers=db.Users.Where(u=> u.Username==userName).ToList();
            if (loginUsers.Count == 0)
            {
                ViewBag.Message = "User does not exist";
            }
            else {
                User loginUser = loginUsers[0];
                if (loginUser.Credential.Password == password)
                {

                    return RedirectToAction("../Home/Index");
                }
                else {
                    ViewBag.Message = "Password is wrong";
                }
            }



            return View();
        }
        // POST: Form/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Form/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Form/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Form/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Form/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
