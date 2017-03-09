using System;

namespace QuanLyKho.Model.Abstract
{
    public interface IAuditable
    {
        string CreatedBy { get; set; }

        DateTime CreatedDate { get; set; }

        string UpdatedBy { get; set; }

        DateTime? UpdatedDate { get; set; }

        string MetaKeyWord { get; set; }

        string MetaDescription { get; set; }

        bool Status { get; set; }
    }
}