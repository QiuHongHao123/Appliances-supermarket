using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/**
 * author Qiu
 * This part of code to implement the function about security
 * 
 */
namespace FIT5032_assignment.Controllers
{
    public class Security

    {
        /**
         * The code is to verify if the yrl from local web applictaion to preventing open-redirection-attacks
         * Sources :https://docs.microsoft.com/zh-cn/aspnet/mvc/overview/security/preventing-open-redirection-attacks
         */
        public bool IsLocalUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return false;
            }
            else
            {
                return ((url[0] == '/' && (url.Length == 1 ||
                        (url[1] != '/' && url[1] != '\\'))) ||   // "/" or "/foo" but not "//" or "/\"
                        (url.Length > 1 &&
                         url[0] == '~' && url[1] == '/'));   // "~/" or "~/foo"
            }
        }
    }
}