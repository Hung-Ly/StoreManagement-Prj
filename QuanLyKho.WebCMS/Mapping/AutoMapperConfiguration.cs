using AutoMapper;
using QuanLyKho.Model.Models;
using QuanLyKho.Web.ViewModel;
using QuanLyKho.WebCMS.ViewModel;

namespace QuanLyKho.WebCMS.Mapping
{
    public class AutoMapperConfiguration
    {
        public static void Configuration()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Post, PostViewModel>();
                cfg.CreateMap<PostCategory, PostCategoryViewModel>();
                cfg.CreateMap<Tag, TagViewModel>();
                cfg.CreateMap<ProductCategory, ProductCategoryViewModel>();
                cfg.CreateMap<Product, ProductViewModel>();
                cfg.CreateMap<ProductTag, ProductTagViewModel>();
                cfg.CreateMap<Footer, FooterViewModel>();
                cfg.CreateMap<Slide, SlideViewModel>();
                cfg.CreateMap<Page, PageViewModel>();
            });
        }
    }
}