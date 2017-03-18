using AutoMapper;
using QuanLyKho.Model.Entities;
using QuanLyKho.WebCMS.Models;
using QuanLyKho.WebCMS.Models.AccountViewModels;

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

                cfg.CreateMap<ApplicationUser, LoginViewModel>();
            });
        }
    }
}