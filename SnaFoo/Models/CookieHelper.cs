using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace SnaFoo.Models
{
    public class CookieHelper
    {
        public static string CookieName { get; set; }
        public virtual Application App { get; set; }

        public MyCookie(Application app)
        {
            CookieName = "MyCookie" + app;
        }

        public static void SetCookie(User user, Community community, int cookieExpireDate = 30)
        {
            HttpCookie myCookie = new HttpCookie(CookieName);
            myCookie["UserId"] = user.UserId.ToString();
            myCookie.Expires = DateTime.Now.AddDays(cookieExpireDate);
            HttpContext.Current.Response.Cookies.Add(myCookie);
        }
    }
}
