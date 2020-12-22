using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanSach.ViewModels
{
    public class ThemSachViewModel
    {
        public List<Genre> Genres { get; set; }
        public List<Publisher> Publishers { get; set; }
        public List<Provider> Providers { get; set; }
    }
}