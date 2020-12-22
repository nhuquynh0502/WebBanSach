using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanSach.Models
{
    public class QuanLyViewModel
    {
        public int ID_Order { get; set; }
        public int ID_User { get; set; }
        public string Order_Status { get; set; }
        public DateTime Order_Date { get; set; }
        public DateTime Delivery_Date { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
    }
}