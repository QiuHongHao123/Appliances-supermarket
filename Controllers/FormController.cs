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
        
        public ActionResult SendVerifyEmail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendVerifyEmail(SendVerifyEmailView model)
        {
            string verifycode = "not init";
            string email = model.Email;
            List<User> Users=db.Users.Where(u => u.Email == email).ToList();
            
            if (Users.Count != 0)
            {
                verifycode=getVerifyCode(false, 10);
                if (verifycode != "not init")
                {

                    EmailService emailservice = new EmailService(email, "The verify code", verifycode);
                    ViewBag.emailMesage = emailservice.sendEmail();
                    TempData["verifyCode"] = verifycode;
                    TempData["Email"] = email;
                    return  Content("<script>alert('The email has been send');window.location.href='../Form/ResetPassword';</script>");
                }
                else
                {
                    ViewBag.emailMessage = "fail to generate verifycode";
                }
            }
            else {
                ViewBag.emailMessage = "This email not been registed";
            }
            return View();
        }
        public ActionResult ResetPassword()
        {
            string email = (string)TempData["Email"];
            
            if (email == null) { return RedirectToAction("SendVerifyEmail"); }
            ViewBag.userEmail = "Wellcome "+email;
            TempData["Email"] = email;
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordView model)
        {
            string newPassword = model.Password;
            string inputVerify = model.verifyCode;
            string email = (string)TempData["Email"];
            
            string verifyCode = (string)TempData["verifyCode"];
            if (verifyCode == inputVerify)
            {
                //List<User> user=db.Users.Where(u => u.Email == email).ToList();
                Credential credential = db.Credentials.Where(c => c.User.Email == email).FirstOrDefault();
                credential.Password = newPassword;
                db.SaveChanges();

                return Content("<script>alert('The password successfully reset');window.location.href='../Form/Login';</script>");
            }
            else {
                TempData["verifyCode"] = verifyCode;
                TempData["Email"] = email;
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
        private string getVerifyCode(bool b, int n)//b：是否有复杂字符，n：生成的字符串长度

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
            return SB.ToString();

        }
    }
}
