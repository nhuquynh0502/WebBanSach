using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanSach.Models
{
    public class QuanLySachModel
    {
        public int ID_Book { get; set; }
        public string Name { get; set; }
        public string Images { get; set; }
        public string Author { get; set; }
        public DateTime Release_Date { get; set; }
        public int Amount { get; set; }
        public string Discription { get; set; }
        public int Age_Limit { get; set; }
        public float Price { get; set; }
    }
}