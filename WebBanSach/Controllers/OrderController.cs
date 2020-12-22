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
            List<ItemGioHang> lstGioHang = new List<ItemGioHang>();
            if(Session["UserLogin"] != null) 
            {
                var idUser = (Session["UserLogin"] as User).ID_User;
                using (var _context = new WebBanSachEntities())
                {
                    var lstGH = _context.f_GetAllCart(idUser).Select(x => new
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
                
            }
            return lstGioHang;
        }
        public ActionResult ThemGioHang(int? id, string strURL)
        {
            var _context = new WebBanSachEntities();
            if (Session["UserLogin"] != null)
            {
                var idUser = (Session["UserLogin"] as User).ID_User;
                
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
                    _context.p_AddToCart(idUser, id, 0);
                    return Redirect(strURL);
                }
                if (b.Amount < 1)
                {
                    return View("ThongBao", "Message");
                }
                _context.p_AddToCart(idUser, b.ID_Book, 1);
            }
            return Redirect(strURL);
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
            if(Session["UserLogin"] != null)
            {
                var idUser = (Session["UserLogin"] as User).ID_User;

                var it = _context.Orders.Where(n => n.ID_User == idUser && n.Order_Status == -1).ToList();
                int quantity = OldQuantity - item.Quantity;
                Book check = _context.Books.SingleOrDefault(n => n.ID_Book == item.Id);
                if (item.Quantity <= 0)
                {
                    _context.p_DeleteCart(idUser, check.ID_Book);
                }
                else
                {
                    if (check.Amount < item.Quantity)
                    {
                        return RedirectToAction("ThongBao", "Message");
                    }

                    if (it.Count != 0)
                    {
                        _context.p_UpdateCart(idUser, check.ID_Book, item.Quantity, quantity);
                    }
                }
            }
            return RedirectToAction("XemChiTiet", "Order");
        }
        public ActionResult DeleteGioHang(int id)
        {
            if(Session["UserLogin"] != null)
            {
                var idUser = (Session["UserLogin"] as User).ID_User;
                ItemGioHang bcheck = GetGioHang().SingleOrDefault(n => n.Id == id);
                var _context = new WebBanSachEntities();
                var item = _context.Orders.Where(n => n.ID_User == 1 && n.Order_Status == -1).ToList();
                if (item.Count != 0)
                {
                    _context.p_DeleteCart(idUser, id);
                }
            }
            return RedirectToAction("XemChiTiet", "Order");
        }
        public ActionResult OrderDetails()
        {
            using (var _context = new WebBanSachEntities())
            {
                ViewBag.GioHang = GetGioHang();
                ViewBag.Total = Total();
                return View((Session["UserLogin"] as User).ID_User);
            }

        }
        public ActionResult DatHang()
        {
            var _context = new WebBanSachEntities();
            if(Session["UserLogin"] != null)
            {
                var id = (Session["UserLogin"] as User).ID_User;
                _context.p_CheckOrder(id);
            }
            return RedirectToAction("Index", "Home");

        }
    }
}