﻿namespace QuanLyKho.Web.ViewModel
{
    public class PostTagViewModel
    {
        public int PostID { set; get; }
        public string TagID { set; get; }

        public virtual PostViewModel Post { set; get; }
    }
}