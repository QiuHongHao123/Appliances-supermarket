using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Web;

namespace FIT5032_assignment.Controllers
{
    public class EmailService
    {
        private String to;
        private String title;
        private String content;
        public EmailService(String to,String title,String content) {
            this.to = to;
            this.title = title;
            this.content = content;

        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="to">收件人（多人由;隔开）</param>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="cc">抄送</param>
        /// <returns></returns>
        public string sendEmail(string cc = "")
        {
            try
            {
                System.Net.Mail.MailMessage myMail = new System.Net.Mail.MailMessage();
                myMail.From = new System.Net.Mail.MailAddress("3158874848@qq.com", "Reset your password", System.Text.Encoding.UTF8); //发件人地址，发件人姓名，编码
                string[] tos = to.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < tos.Length; i++)
                {
                    myMail.To.Add(new System.Net.Mail.MailAddress(tos[i]));
                }
                string[] ccs = cc.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < ccs.Length; i++)
                {
                    myMail.CC.Add(new System.Net.Mail.MailAddress(ccs[i]));
                }
                myMail.Subject = title;
                myMail.SubjectEncoding = Encoding.UTF8;
                myMail.Body = content;
                myMail.BodyEncoding = Encoding.UTF8;
                myMail.IsBodyHtml = true;
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                smtp.Host = "smtp.qq.com"; smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("3158874848@qq.com", "mjsnsykkvqfidejd");
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Send(myMail);
                return "Successfull send the Email, please enter the verifycode";
            }
            catch (Exception ee)
            {
                return ee.ToString();
            }
        }
    }
}