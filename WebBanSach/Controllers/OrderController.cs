using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSach.Models;

namespace WebBanSach.Controllers
{
    public class OrderController : Controller
    {

        // GET: QuanLy
        public List<ItemGioHang> GetGioHang()
        {
            //var id = (Session["UserLogin"] as User).ID_User;
            List<ItemGioHang> lstGioHang = new List<ItemGioHang>();
            using (var _context = new WebBanSachEntities())
            {
                var lstGH = _context.f_GetAllCart(1).Select(x => new
                {
                    
                    x.ID_Book,
                    x.Name,
                    x.Image,
                    x.Quantity,
                    x.Price
                }).ToList();
                lstGH.ForEach(i =>
                {
                    ItemGioHang it = new ItemGioHang();
                    it.Id = (int)i.ID_Book;
                    it.Image = i.Image;
                    it.Name = i.Name;
                    it.Price = (double)i.Price;
                    it.Quantity = (int)i.Quantity;
                    it.Total = it.Price * it.Quantity;
                    lstGioHang.Add(it);
                });
            }
            return lstGioHang;
        }
        public ActionResult ThemGioHang(int? id, string strURL)
        {
            var _context = new WebBanSachEntities();
            Book b = _context.Books.SingleOrDefault(n => n.ID_Book == id);
            if (b == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<ItemGioHang> lstGH = GetGioHang();
            ItemGioHang bcheck = lstGH.SingleOrDefault(n => n.Id == id);
            if (bcheck != null)
            {
                _context.p_AddToCart(1, id, 1);
            }
            if (b.Amount < 1)
            {
                return View("ThongBao", "Message");
            }
            _context.p_AddToCart(1, b.ID_Book, 0);
            return Redirect(strURL);
        }
        public void AddOrder_Detail(int id, Book b)
        {
            using (var _context = new WebBanSachEntities())
            {
                var i = _context.Orders.SingleOrDefault(n => n.ID_Order == id);
                Order_Detail od = new Order_Detail();
                od.ID_Order = i.ID_Order;
                od.ID_Book = b.ID_Book;
                od.Book_Name = b.Name;
                od.Price = b.Price;
                od.Quantity = 1;
                _context.Order_Detail.Add(od);
                _context.SaveChanges();
            }

        }
        public int AddOrder(Book b)
        {
            using (var _context = new WebBanSachEntities())
            {
                Order i = new Order();
                i.ID_Order = _context.Orders.ToList().Count() + 1;
                //i.ID_User = (Session["UserLogin"] as User).ID_User;
                i.ID_User = 1;
                i.Order_Date = DateTime.Now.Date;
                i.Delivery_Date = DateTime.Now.Date;
                i.Order_Status = -1;
                i.Puschase = false;
                _context.Orders.Add(i);
                _context.SaveChanges();
                return i.ID_Order;
            }

        }
        public int Quantity()
        {
            List<ItemGioHang> lstGH = GetGioHang();
            if (lstGH.Count == 0)
            {
                return 0;
            }
            return lstGH.Sum(n => n.Quantity);
        }

        public double Total()
        {
            List<ItemGioHang> lstGH = GetGioHang();
            if (lstGH.Count == 0)
            {
                return 0;
            }
            return lstGH.Sum(n => n.Total);
        }
        public ActionResult GioHangPartial()
        {
            ViewBag.Quantity = Quantity();

            return PartialView();
        }
        public ActionResult XemChiTiet()
        {
            ViewBag.Total = Total();
            return View(GetGioHang());
        }
        [HttpGet]
        public ActionResult EditGioHang(int id)
        {
            if (GetGioHang().Count() == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            var _context = new WebBanSachEntities();
            Book b = _context.Books.SingleOrDefault(n => n.ID_Book == id);
            if (b == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<ItemGioHang> lstGH = GetGioHang();
            ItemGioHang bcheck = lstGH.SingleOrDefault(n => n.Id == id);
            if (bcheck == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.GioHang = lstGH;
            ViewBag.OldQuantity = bcheck.Quantity;
            return View(bcheck);
        }
        [HttpPost]
        public ActionResult UpdateGioHang(ItemGioHang item, int OldQuantity)
        {
            var _context = new WebBanSachEntities();
            //sửa lại id user
            var it = _context.Orders.Where(n => n.ID_User == 1 && n.Order_Status == -1).ToList();
            int quantity = OldQuantity - item.Quantity;
            Book check = _context.Books.SingleOrDefault(n => n.ID_Book == item.Id);
            if (item.Quantity <= 0)
            {
                //sửa lại id user
                _context.XoaSachTrongOrder_Detail(1, check.ID_Book);
            }
            else
            {
                if (check.Amount < item.Quantity)
                {
                    return RedirectToAction("ThongBao", "Message");
                }

                if (it.Count != 0)
                {
                    _context.p_UpdateCart(1, check.ID_Book, item.Quantity, quantity);
                    //sửa lại id user
                }
            }
            return RedirectToAction("XemChiTiet", "Order");
        }
        public ActionResult DeleteGioHang(int id)
        {
            ItemGioHang bcheck = GetGioHang().SingleOrDefault(n => n.Id == id);
            var _context = new WebBanSachEntities();
            var item = _context.Orders.Where(n => n.ID_User == 1 && n.Order_Status == -1).ToList();
            if (item.Count != 0)
            {
                _context.XoaSachTrongOrder_Detail(1, id);
            }
            return RedirectToAction("XemChiTiet", "Order");
        }
        public ActionResult OrderDetails()
        {
            using (var _context = new WebBanSachEntities())
            {
                ViewBag.GioHang = GetGioHang();
                ViewBag.Total = Total();
                return View(/*(Session["UserLogin"] as User).ID_User*/_context.Users.Single(n => n.ID_User == 1));
            }

        }
        public ActionResult DatHang()
        {
            var _context = new WebBanSachEntities();
            var id =/* (Session["UserLogin"] as User).ID_User*/1;
            _context.p_CheckOrder(id);
            return RedirectToAction("Index", "Home");

        }
    }
}