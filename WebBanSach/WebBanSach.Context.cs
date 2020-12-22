﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebBanSach
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class WebBanSachEntities : DbContext
    {
        public WebBanSachEntities()
            : base("name=WebBanSachEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Order_Detail> Order_Detail { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<HienThiSachKinhDi> HienThiSachKinhDis { get; set; }
        public virtual DbSet<HienThiSachTrinhTham> HienThiSachTrinhThams { get; set; }
        public virtual DbSet<ViewModel> ViewModels { get; set; }
    
        [DbFunction("WebBanSachEntities", "f_GetAllCart")]
        public virtual IQueryable<f_GetAllCart_Result> f_GetAllCart(Nullable<int> iD_User)
        {
            var iD_UserParameter = iD_User.HasValue ?
                new ObjectParameter("ID_User", iD_User) :
                new ObjectParameter("ID_User", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<f_GetAllCart_Result>("[WebBanSachEntities].[f_GetAllCart](@ID_User)", iD_UserParameter);
        }
    
        [DbFunction("WebBanSachEntities", "f_GetListQL")]
        public virtual IQueryable<f_GetListQL_Result> f_GetListQL(Nullable<int> status)
        {
            var statusParameter = status.HasValue ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<f_GetListQL_Result>("[WebBanSachEntities].[f_GetListQL](@status)", statusParameter);
        }
    
        [DbFunction("WebBanSachEntities", "getdangnhap")]
        public virtual IQueryable<getdangnhap_Result> getdangnhap(string userName)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<getdangnhap_Result>("[WebBanSachEntities].[getdangnhap](@UserName)", userNameParameter);
        }
    
        public virtual ObjectResult<adduser1_Result> adduser1(string first_Name, string last_Name, Nullable<System.DateTime> doB, Nullable<bool> sex, string address, string email, string phone, string userName, string passwd)
        {
            var first_NameParameter = first_Name != null ?
                new ObjectParameter("First_Name", first_Name) :
                new ObjectParameter("First_Name", typeof(string));
    
            var last_NameParameter = last_Name != null ?
                new ObjectParameter("Last_Name", last_Name) :
                new ObjectParameter("Last_Name", typeof(string));
    
            var doBParameter = doB.HasValue ?
                new ObjectParameter("DoB", doB) :
                new ObjectParameter("DoB", typeof(System.DateTime));
    
            var sexParameter = sex.HasValue ?
                new ObjectParameter("Sex", sex) :
                new ObjectParameter("Sex", typeof(bool));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwdParameter = passwd != null ?
                new ObjectParameter("Passwd", passwd) :
                new ObjectParameter("Passwd", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<adduser1_Result>("adduser1", first_NameParameter, last_NameParameter, doBParameter, sexParameter, addressParameter, emailParameter, phoneParameter, userNameParameter, passwdParameter);
        }
    
        public virtual int CapNhatSach(Nullable<int> iD_Book, string name, string images, string author, Nullable<System.DateTime> release_Date, Nullable<int> amount, string discription, Nullable<int> age_Limit, Nullable<double> price, Nullable<int> iD_Genre, Nullable<int> iD_Publisher, Nullable<int> iD_Provider)
        {
            var iD_BookParameter = iD_Book.HasValue ?
                new ObjectParameter("ID_Book", iD_Book) :
                new ObjectParameter("ID_Book", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var imagesParameter = images != null ?
                new ObjectParameter("Images", images) :
                new ObjectParameter("Images", typeof(string));
    
            var authorParameter = author != null ?
                new ObjectParameter("Author", author) :
                new ObjectParameter("Author", typeof(string));
    
            var release_DateParameter = release_Date.HasValue ?
                new ObjectParameter("Release_Date", release_Date) :
                new ObjectParameter("Release_Date", typeof(System.DateTime));
    
            var amountParameter = amount.HasValue ?
                new ObjectParameter("Amount", amount) :
                new ObjectParameter("Amount", typeof(int));
    
            var discriptionParameter = discription != null ?
                new ObjectParameter("Discription", discription) :
                new ObjectParameter("Discription", typeof(string));
    
            var age_LimitParameter = age_Limit.HasValue ?
                new ObjectParameter("Age_Limit", age_Limit) :
                new ObjectParameter("Age_Limit", typeof(int));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("Price", price) :
                new ObjectParameter("Price", typeof(double));
    
            var iD_GenreParameter = iD_Genre.HasValue ?
                new ObjectParameter("ID_Genre", iD_Genre) :
                new ObjectParameter("ID_Genre", typeof(int));
    
            var iD_PublisherParameter = iD_Publisher.HasValue ?
                new ObjectParameter("ID_Publisher", iD_Publisher) :
                new ObjectParameter("ID_Publisher", typeof(int));
    
            var iD_ProviderParameter = iD_Provider.HasValue ?
                new ObjectParameter("ID_Provider", iD_Provider) :
                new ObjectParameter("ID_Provider", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CapNhatSach", iD_BookParameter, nameParameter, imagesParameter, authorParameter, release_DateParameter, amountParameter, discriptionParameter, age_LimitParameter, priceParameter, iD_GenreParameter, iD_PublisherParameter, iD_ProviderParameter);
        }
    
        public virtual ObjectResult<HienThiDanhSachNhaCungCap_Result> HienThiDanhSachNhaCungCap()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HienThiDanhSachNhaCungCap_Result>("HienThiDanhSachNhaCungCap");
        }
    
        public virtual ObjectResult<HienThiDanhSachNhaSanXuat_Result> HienThiDanhSachNhaSanXuat()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HienThiDanhSachNhaSanXuat_Result>("HienThiDanhSachNhaSanXuat");
        }
    
        public virtual ObjectResult<HienThiDanhSachTheLoaiSach_Result> HienThiDanhSachTheLoaiSach()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HienThiDanhSachTheLoaiSach_Result>("HienThiDanhSachTheLoaiSach");
        }
    
        public virtual ObjectResult<HienThiSachNgonTinh_Result> HienThiSachNgonTinh()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HienThiSachNgonTinh_Result>("HienThiSachNgonTinh");
        }
    
        public virtual ObjectResult<HienThiSachTieuThuyet_Result> HienThiSachTieuThuyet()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HienThiSachTieuThuyet_Result>("HienThiSachTieuThuyet");
        }
    
        public virtual ObjectResult<HienThiThongTinSach_Result> HienThiThongTinSach()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HienThiThongTinSach_Result>("HienThiThongTinSach");
        }
    
        public virtual ObjectResult<LaySach_Result> LaySach(Nullable<int> iD_Book)
        {
            var iD_BookParameter = iD_Book.HasValue ?
                new ObjectParameter("ID_Book", iD_Book) :
                new ObjectParameter("ID_Book", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LaySach_Result>("LaySach", iD_BookParameter);
        }
    
        public virtual int p_AddToCart(Nullable<int> iD_User, Nullable<int> iD_Book, Nullable<int> status)
        {
            var iD_UserParameter = iD_User.HasValue ?
                new ObjectParameter("ID_User", iD_User) :
                new ObjectParameter("ID_User", typeof(int));
    
            var iD_BookParameter = iD_Book.HasValue ?
                new ObjectParameter("ID_Book", iD_Book) :
                new ObjectParameter("ID_Book", typeof(int));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("p_AddToCart", iD_UserParameter, iD_BookParameter, statusParameter);
        }
    
        public virtual int p_CheckOrder(Nullable<int> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("p_CheckOrder", userIDParameter);
        }
    
        public virtual int p_DeleteCart(Nullable<int> iD_User, Nullable<int> iD_Book)
        {
            var iD_UserParameter = iD_User.HasValue ?
                new ObjectParameter("ID_User", iD_User) :
                new ObjectParameter("ID_User", typeof(int));
    
            var iD_BookParameter = iD_Book.HasValue ?
                new ObjectParameter("ID_Book", iD_Book) :
                new ObjectParameter("ID_Book", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("p_DeleteCart", iD_UserParameter, iD_BookParameter);
        }
    
        public virtual int p_DuyetDonHang(Nullable<int> id, Nullable<int> status, Nullable<bool> puschase)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(int));
    
            var puschaseParameter = puschase.HasValue ?
                new ObjectParameter("puschase", puschase) :
                new ObjectParameter("puschase", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("p_DuyetDonHang", idParameter, statusParameter, puschaseParameter);
        }
    
        public virtual int p_UpdateCart(Nullable<int> iD_User, Nullable<int> iD_Book, Nullable<int> quantity, Nullable<int> bookQuantity)
        {
            var iD_UserParameter = iD_User.HasValue ?
                new ObjectParameter("ID_User", iD_User) :
                new ObjectParameter("ID_User", typeof(int));
    
            var iD_BookParameter = iD_Book.HasValue ?
                new ObjectParameter("ID_Book", iD_Book) :
                new ObjectParameter("ID_Book", typeof(int));
    
            var quantityParameter = quantity.HasValue ?
                new ObjectParameter("Quantity", quantity) :
                new ObjectParameter("Quantity", typeof(int));
    
            var bookQuantityParameter = bookQuantity.HasValue ?
                new ObjectParameter("BookQuantity", bookQuantity) :
                new ObjectParameter("BookQuantity", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("p_UpdateCart", iD_UserParameter, iD_BookParameter, quantityParameter, bookQuantityParameter);
        }
    
        public virtual ObjectResult<ThemSachMoi_Result> ThemSachMoi(string name, string images, string author, Nullable<System.DateTime> release_Date, Nullable<int> amount, string discription, Nullable<int> age_Limit, Nullable<double> price, Nullable<int> iD_Genre, Nullable<int> iD_Publisher, Nullable<int> iD_Provider)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var imagesParameter = images != null ?
                new ObjectParameter("Images", images) :
                new ObjectParameter("Images", typeof(string));
    
            var authorParameter = author != null ?
                new ObjectParameter("Author", author) :
                new ObjectParameter("Author", typeof(string));
    
            var release_DateParameter = release_Date.HasValue ?
                new ObjectParameter("Release_Date", release_Date) :
                new ObjectParameter("Release_Date", typeof(System.DateTime));
    
            var amountParameter = amount.HasValue ?
                new ObjectParameter("Amount", amount) :
                new ObjectParameter("Amount", typeof(int));
    
            var discriptionParameter = discription != null ?
                new ObjectParameter("Discription", discription) :
                new ObjectParameter("Discription", typeof(string));
    
            var age_LimitParameter = age_Limit.HasValue ?
                new ObjectParameter("Age_Limit", age_Limit) :
                new ObjectParameter("Age_Limit", typeof(int));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("Price", price) :
                new ObjectParameter("Price", typeof(double));
    
            var iD_GenreParameter = iD_Genre.HasValue ?
                new ObjectParameter("ID_Genre", iD_Genre) :
                new ObjectParameter("ID_Genre", typeof(int));
    
            var iD_PublisherParameter = iD_Publisher.HasValue ?
                new ObjectParameter("ID_Publisher", iD_Publisher) :
                new ObjectParameter("ID_Publisher", typeof(int));
    
            var iD_ProviderParameter = iD_Provider.HasValue ?
                new ObjectParameter("ID_Provider", iD_Provider) :
                new ObjectParameter("ID_Provider", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ThemSachMoi_Result>("ThemSachMoi", nameParameter, imagesParameter, authorParameter, release_DateParameter, amountParameter, discriptionParameter, age_LimitParameter, priceParameter, iD_GenreParameter, iD_PublisherParameter, iD_ProviderParameter);
        }
    
        public virtual ObjectResult<TimKiemThongTin_Result> TimKiemThongTin(string chuoi)
        {
            var chuoiParameter = chuoi != null ?
                new ObjectParameter("chuoi", chuoi) :
                new ObjectParameter("chuoi", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TimKiemThongTin_Result>("TimKiemThongTin", chuoiParameter);
        }
    
        public virtual int XoaSach(Nullable<int> iD_Book)
        {
            var iD_BookParameter = iD_Book.HasValue ?
                new ObjectParameter("ID_Book", iD_Book) :
                new ObjectParameter("ID_Book", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("XoaSach", iD_BookParameter);
        }
    
        public virtual int XoaSachTrongOrder_Detail(Nullable<int> iD_Order, Nullable<int> iD_Book)
        {
            var iD_OrderParameter = iD_Order.HasValue ?
                new ObjectParameter("ID_Order", iD_Order) :
                new ObjectParameter("ID_Order", typeof(int));
    
            var iD_BookParameter = iD_Book.HasValue ?
                new ObjectParameter("ID_Book", iD_Book) :
                new ObjectParameter("ID_Book", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("XoaSachTrongOrder_Detail", iD_OrderParameter, iD_BookParameter);
        }
    
        public virtual ObjectResult<Provider> HienThiDanhSachNhaCungCap1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Provider>("HienThiDanhSachNhaCungCap1");
        }
    
        public virtual ObjectResult<Provider> HienThiDanhSachNhaCungCap1(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Provider>("HienThiDanhSachNhaCungCap1", mergeOption);
        }
    
        public virtual ObjectResult<Publisher> HienThiDanhSachNhaSanXuat1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Publisher>("HienThiDanhSachNhaSanXuat1");
        }
    
        public virtual ObjectResult<Publisher> HienThiDanhSachNhaSanXuat1(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Publisher>("HienThiDanhSachNhaSanXuat1", mergeOption);
        }
    
        public virtual ObjectResult<Genre> HienThiDanhSachTheLoaiSach1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Genre>("HienThiDanhSachTheLoaiSach1");
        }
    
        public virtual ObjectResult<Genre> HienThiDanhSachTheLoaiSach1(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Genre>("HienThiDanhSachTheLoaiSach1", mergeOption);
        }
    
        public virtual ObjectResult<Book> HienThiThongTinSach1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Book>("HienThiThongTinSach1");
        }
    
        public virtual ObjectResult<Book> HienThiThongTinSach1(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Book>("HienThiThongTinSach1", mergeOption);
        }
    
        public virtual ObjectResult<Book> HienThiSachNgonTinh1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Book>("HienThiSachNgonTinh1");
        }
    
        public virtual ObjectResult<Book> HienThiSachNgonTinh1(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Book>("HienThiSachNgonTinh1", mergeOption);
        }
    
        public virtual ObjectResult<Book> HienThiSachTieuThuyet1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Book>("HienThiSachTieuThuyet1");
        }
    
        public virtual ObjectResult<Book> HienThiSachTieuThuyet1(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Book>("HienThiSachTieuThuyet1", mergeOption);
        }
    
        public virtual ObjectResult<Book> TimKiemThongTin1(string chuoi)
        {
            var chuoiParameter = chuoi != null ?
                new ObjectParameter("chuoi", chuoi) :
                new ObjectParameter("chuoi", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Book>("TimKiemThongTin1", chuoiParameter);
        }
    
        public virtual ObjectResult<Book> TimKiemThongTin1(string chuoi, MergeOption mergeOption)
        {
            var chuoiParameter = chuoi != null ?
                new ObjectParameter("chuoi", chuoi) :
                new ObjectParameter("chuoi", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Book>("TimKiemThongTin1", mergeOption, chuoiParameter);
        }
    
        public virtual ObjectResult<Book> LaySach1(Nullable<int> iD_Book)
        {
            var iD_BookParameter = iD_Book.HasValue ?
                new ObjectParameter("ID_Book", iD_Book) :
                new ObjectParameter("ID_Book", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Book>("LaySach1", iD_BookParameter);
        }
    
        public virtual ObjectResult<Book> LaySach1(Nullable<int> iD_Book, MergeOption mergeOption)
        {
            var iD_BookParameter = iD_Book.HasValue ?
                new ObjectParameter("ID_Book", iD_Book) :
                new ObjectParameter("ID_Book", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Book>("LaySach1", mergeOption, iD_BookParameter);
        }
    
        public virtual ObjectResult<LayUser_Result> LayUser(string userName, string pass)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("userName", userName) :
                new ObjectParameter("userName", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LayUser_Result>("LayUser", userNameParameter, passParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> LayQuyenUser(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("LayQuyenUser", idParameter);
        }
    }
}
