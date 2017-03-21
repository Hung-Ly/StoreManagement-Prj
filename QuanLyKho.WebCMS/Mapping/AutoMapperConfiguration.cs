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
                cfg.CreateMap<Post, PostViewModel>().ReverseMap();
                cfg.CreateMap<PostCategory, PostCategoryViewModel>().ReverseMap();
                cfg.CreateMap<Tag, TagViewModel>();
                cfg.CreateMap<ProductCategory, ProductCategoryViewModel>().ReverseMap();
                cfg.CreateMap<Product, ProductViewModel>().ReverseMap();
                cfg.CreateMap<ProductTag, ProductTagViewModel>().ReverseMap();
                cfg.CreateMap<Footer, FooterViewModel>().ReverseMap();
                cfg.CreateMap<Slide, SlideViewModel>().ReverseMap();
                cfg.CreateMap<Page, PageViewModel>().ReverseMap();

                cfg.CreateMap<ApplicationUser, LoginViewModel>().ReverseMap();
            });
        }
    }
}