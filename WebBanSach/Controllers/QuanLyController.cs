using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebBanSach.Models;

namespace WebBanSach.Controllers
{
    public class QuanLyController : Controller
    {
        List<string> lstStatus = new List<string> { "Hủy", "Đã đặt hàng", "Đã giao hàng", "Đổi trả" };
        List<string> lstView = new List<string> { "DaHuy", "DaDat", "DaGiao", "DaHuy" };
        // GET: QuanLy
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DaDat()
        {

            return View(GetListQL(1));
        }
        public ActionResult DaGiao()
        {
            return View(GetListQL(2));
        }
        public ActionResult DaHuy()
        {
            return View(GetListQL(0));
        }
        public ActionResult DoiTra()
        {
            return View(GetListQL(3));
        }
        public List<QuanLyViewModel> GetListQL(int status)
        {
            List<QuanLyViewModel> lstQL = new List<QuanLyViewModel>();
            var _context = new WebBanSachEntities();
            var lst = _context.f_GetListQL(status).Select(x => new
            {
                x.ID_Order,
                x.ID_User,
                x.Last_Name,
                x.First_Name,
                x.Order_Date,
                x.Delivery_Date,
                x.Order_Status
            }).ToList();
            lst.ForEach(u =>
            {
                QuanLyViewModel q = new QuanLyViewModel();
                q.ID_Order = u.ID_Order;
                q.ID_User = (int)u.ID_User;
                q.Last_Name = u.Last_Name;
                q.First_Name = u.First_Name;
                q.Order_Status = lstStatus[(int)u.Order_Status];
                q.Delivery_Date = (DateTime)u.Delivery_Date;
                q.Order_Date = (DateTime)u.Order_Date;
                lstQL.Add(q);
            });
            return lstQL;
        }
        [HttpGet]
        public ActionResult DuyetDonHang(int? id)
        {
            var _context = new WebBanSachEntities();
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var model = _context.Orders.SingleOrDefault(n => n.ID_Order == id);
            if (model == null)
            {
                return HttpNotFound();
            }
            var orderdetail = _context.Order_Detail.Where(n => n.ID_Order == id).ToList();
            ViewBag.Order_Detail = orderdetail;
            return View(model);
        }
        [HttpPost]
        public ActionResult DuyetDonHang(Order od)
        {
            using (var _context = new WebBanSachEntities())
            {
                _context.p_DuyetDonHang(od.ID_Order, od.Order_Status, od.Puschase);
                var orderdetail = _context.Order_Detail.Where(n => n.ID_Order == od.ID_Order).ToList();
                ViewBag.Order_Detail = orderdetail;
                GuiMail("Cập nhật đơn hàng",
                        "nguyenminhsangnms328@gmail.com",
                        "sang04407@gmail.com",
                        "74423245Sang",
                        "Hệ thống vừa xác nhận đơn hàng quý khách vui lòng kiểm tra trước 72 giờ");
                return RedirectToAction(lstView[(int)od.Order_Status], "QuanLy");
            }
        }
        public void GuiMail(string Title, string ToMail, string FromMail, string Passwd, string Content)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(ToMail);
            mail.From = new MailAddress(ToMail);
            mail.Subject = Title;
            mail.Body = Content;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(FromMail, Passwd);
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
    }
}