using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyKho.Web.ViewModel;

namespace QuanLyKho.WebCMS.ViewModel
{
    public class ProductTagViewModel
    {
        public int ProductID { set; get; }

        public string TagID { set; get; }

        public virtual ProductViewModel Post { set; get; }

        public virtual TagViewModel Tag { set; get; }
    }
}
