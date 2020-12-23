using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanSach.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult ThongBao()
        {
            return View();
        }
        public ActionResult ThongBaoDatHang()
        {
            return View();
        }
    }
}