using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebBanSach.ViewModels;

namespace WebBanSach.Controllers
{
    public class HomeController : Controller
    {
        private WebBanSachEntities webBanSach = new WebBanSachEntities();

        public object ID_User { get; private set; }

        public ActionResult Index()
        {
            try
            {
                var data = webBanSach.HienThiThongTinSach1().ToList();
                return View(data);
            }
            catch
            {
                return View();
            }
        }
        public ActionResult XemSach(int id)
        {
            switch(id)
            {
                case 1: return View(webBanSach.p_HienThiSachKinhDi1().ToList());
                case 2: return View(webBanSach.HienThiSachTieuThuyet1().ToList());
                case 3: return View(webBanSach.p_HienThiSachTrinhTham1().ToList());
                case 4: return View(webBanSach.HienThiSachNgonTinh1().ToList());
                default: return View("TrangNguoiDung");
            }    
        }
        public ActionResult TrangNguoiDung()
        {
            try
            {
                var data = webBanSach.HienThiThongTinSach1().ToList();
                return View(data);
            }
            catch
            {
                return View("TrangQuanLySach");
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult TrangQuanLySach()
        {
            try
            {
                var data = webBanSach.HienThiThongTinSach1().ToList();
                return View(data);
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult TimKiemAdmin(string chuoi)
        {
            try
            {
                var data = webBanSach.TimKiemThongTin1(chuoi).ToList();
                ViewBag.value = chuoi;
                return View("TrangQuanLySach", data);
            }
            catch
            {
                return View("TrangQuanLySach");
            }
        }
        [HttpPost]
        public ActionResult TimKiemUser(string chuoi)
        {
            try
            {
                var data = webBanSach.TimKiemThongTin1(chuoi).ToList();
                ViewBag.value = chuoi;
                return View("TrangNguoiDung", data);
            }
            catch
            {
                return View("TrangNguoiDung");
            }
        }
        [HttpPost]
        public ActionResult TimKiemTrangChu(string chuoi)
        {
            try
            {
                var data = webBanSach.TimKiemThongTin1(chuoi).ToList();
                ViewBag.value = chuoi;
                return View("Index", data);
            }
            catch
            {
                return View("Index");
            }
        }
        public ViewResult TrangSachKinhDi()
        {
            try
            {
                var data = webBanSach.HienThiSachKinhDis.ToList();
                return View(data);
            }
            catch
            {
                return View("TrangSachKinhDi");
            }
        }
        public ActionResult TrangSachTieuThuyet()
        {
            try
            {
                var data = webBanSach.HienThiSachTieuThuyet1().ToList();
                return View(data);
            }
            catch
            {
                return View("TrangSachTieuThuyet");
            }
        }
        public ActionResult TrangSachTrinhTham()
        {
            try
            {
                var data = webBanSach.HienThiSachTrinhThams.ToList();
                return View(data);
            }
            catch
            {
                return View("TrangSachTrinhTham");
            }
        }
        public ActionResult TrangSachNgonTinh()
        {
            try
            {
                var data = webBanSach.HienThiSachNgonTinh1().ToList();
                return View(data);
            }
            catch
            {
                return View("TrangSachNgonTinh");
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult TrangThemSach()
        {
            ThemSachViewModel themSach = new ThemSachViewModel();
            themSach.Genres = webBanSach.HienThiDanhSachTheLoaiSach1().ToList();
            themSach.Publishers = webBanSach.HienThiDanhSachNhaSanXuat1().ToList();
            themSach.Providers = webBanSach.HienThiDanhSachNhaCungCap1().ToList();

            return View(themSach);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult TrangThemSach(Book book)
        {
            //kiem tra input
            webBanSach.ThemSachMoi(
                                    book.Name, 
                                    book.Images, 
                                    book.Author, 
                                    book.Release_Date, 
                                    book.Amount,
                                    book.Discription, 
                                    book.Age_Limit, 
                                    book.Price, 
                                    book.ID_Genre, 
                                    book.ID_Publisher, 
                                    book.ID_Provider);
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult TrangSuaSach(int id)
        {
            SuaSachViewModel suaSach = new SuaSachViewModel();
            suaSach.Genres = webBanSach.HienThiDanhSachTheLoaiSach1().ToList();
            suaSach.Publishers = webBanSach.HienThiDanhSachNhaSanXuat1().ToList();
            suaSach.Providers = webBanSach.HienThiDanhSachNhaCungCap1().ToList();
            suaSach.Book = webBanSach.LaySach1(id).ToList().First();

            return View(suaSach);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult TrangSuaSach(Book book)
        {
            //kiem tra input
            webBanSach.CapNhatSach(
                                    book.ID_Book,
                                    book.Name,
                                    book.Images,
                                    book.Author,
                                    book.Release_Date,
                                    book.Amount,
                                    book.Discription,
                                    book.Age_Limit,
                                    book.Price,
                                    book.ID_Genre,
                                    book.ID_Publisher,
                                    book.ID_Provider);
            return RedirectToAction("TrangQuanLySach");
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult XoaSach(int id)
        {
            webBanSach.XoaSach(id);
            return RedirectToAction("TrangQuanLySach");
        }
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(User user)
        {
            var u = webBanSach.Users.SingleOrDefault(x => x.UserName == user.UserName);
            if (u == null)
            {
                webBanSach.adduser1(
                                user.First_Name,
                                user.Last_Name,
                                user.DoB,
                                user.Sex,
                                user.Address,
                                user.Email,
                                user.Phone,
                                user.UserName,
                                user.PassWd
                                );
                return RedirectToAction("DangNhap");
            }
            else
            {
                ViewBag.mess = "Tài khoản đã tồn tại!!!";
                return View();
            }
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(User user)
        {
            var data = webBanSach.LayUser1(user.UserName, user.PassWd).FirstOrDefault();
            if(data == null)
            {
                return View();
            }
            else
            {
                if(HttpContext.User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.SignOut();
                }

                FormsAuthentication.SetAuthCookie(data.ID_User.ToString(), true);
                Session["UserLogin"] = data;
                var quyen = webBanSach.LayQuyenUser(data.ID_User).ToList().FirstOrDefault();
                if(quyen == 1)
                {
                    return RedirectToAction("TrangNguoiDung");
                }
                else if(quyen == 2)
                {
                    return RedirectToAction("TrangQuanLySach");
                }
                return View();
            }
        }
        public ActionResult getAllOrderByID()
        {
            int id = (Session["UserLogin"] as User).ID_User;
            using (var _context = new WebBanSachEntities())
            {
                var lstOrder = _context.Orders.Where(n => n.ID_User == id).ToList();
                return View(lstOrder);
            }
            
        }
    }
}