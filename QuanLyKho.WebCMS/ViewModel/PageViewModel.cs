using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyKho.WebCMS.ViewModel
{
    public class PageViewModel
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Alias { set; get; }
        public string Content { set; get; }
        public bool Status { set; get; }
    }
}
