using System;
using System.Collections.Generic;

namespace QuanLyKho.Web.ViewModel
{
    public class PostCategoryViewModel
    {
        public int ID { get; set; }
        public string Name { set; get; }
        public string Alias { set; get; }
        public string Description { set; get; }
        public int? ParentID { set; get; }
        public int? DisplayOrder { set; get; }
        public string Image { set; get; }
        public bool? HomeFlag { set; get; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDated { get; set; }
        public string UpdatedBy { get; set; }
        public bool Status { get; set; }
        public string MetaKeyWord { get; set; }
        public string MetaDescription { get; set; }
        public virtual IEnumerable<PostViewModel> Posts { set; get; }
    }
}