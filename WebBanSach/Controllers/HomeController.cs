using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSach.ViewModels;

namespace WebBanSach.Controllers
{
    public class HomeController : Controller
    {
        private WebBanSachEntities webBanSach = new WebBanSachEntities();
        public ActionResult Index()
        {
            return View();
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
        public ActionResult TrangQuanLySach()
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
        [HttpPost]
        public ActionResult TrangQuanLySach(string chuoi)
        {
            try
            {
                var data = webBanSach.TimKiemThongTin1(chuoi).ToList();
                ViewBag.value = chuoi;
                return View(data);
            }
            catch
            {
                return View("TrangQuanLySach");
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
        public ActionResult TrangThemSach()
        {
            ThemSachViewModel themSach = new ThemSachViewModel();
            themSach.Genres = webBanSach.HienThiDanhSachTheLoaiSach1().ToList();
            themSach.Publishers = webBanSach.HienThiDanhSachNhaSanXuat1().ToList();
            themSach.Providers = webBanSach.HienThiDanhSachNhaCungCap1().ToList();

            return View(themSach);
        }
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
        public ActionResult TrangSuaSach(int id)
        {
            SuaSachViewModel suaSach = new SuaSachViewModel();
            suaSach.Genres = webBanSach.HienThiDanhSachTheLoaiSach1().ToList();
            suaSach.Publishers = webBanSach.HienThiDanhSachNhaSanXuat1().ToList();
            suaSach.Providers = webBanSach.HienThiDanhSachNhaCungCap1().ToList();
            suaSach.Book = webBanSach.LaySach1(id).ToList().First();

            return View(suaSach);
        }
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
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(string userName)
        {
            webBanSach.getdangnhap(userName);
            return RedirectToAction("TrangNguoiDung");
        }
        public ActionResult KiemTraDangNhap(string userName, string pass)
        {
            //var data = webBanSach.dangnha;
            return View();
        }
    }
}