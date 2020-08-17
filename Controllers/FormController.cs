using FIT5032_assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FIT5032_assignment.Controllers
{
    public class FormController : Controller
    {

        private String verifycode = "not init";
        private FIT5032Entities db = new FIT5032Entities();
        // GET: Form
        public ActionResult Index()
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

            String userEmail=model.Email;
            String password = model.Password;
            List<User> loginUsers=db.Users.Where(u=> u.Email==userEmail).ToList();
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
        public ActionResult ResetPassword() {
            return View();
        }

        private ActionResult sendVerifyEmail(ResetPasswordView model)
        {
            String email = model.Email;
            getVerifyCode(true, 10);
            if (verifycode != "not init")
            { 
                EmailService emailservice = new EmailService(email, "The verify code", verifycode);
                ViewBag.emailMesage=emailservice.sendEmail();
            }
            else {
                ViewBag.emailMessage = "fail to generate verifycode";
            }
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordView model,String action)
        {
            if (action == "sendVerifyEmail") {
                sendVerifyEmail(model);
            }
            else { 
            if (model.Password != "" && model.verifyCode == verifycode) {
                
            }
            }
            return View();
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
        private void getVerifyCode(bool b, int n)//b：是否有复杂字符，n：生成的字符串长度

        {
            
            string str = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (b = true)
            {
                str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";//复杂字符
            }
            StringBuilder SB = new StringBuilder();
            Random rd = new Random();
            for (int i = 0; i < n; i++)
            {
                SB.Append(str.Substring(rd.Next(0, str.Length), 1));
            }
            verifycode=SB.ToString();

        }
    }
}
