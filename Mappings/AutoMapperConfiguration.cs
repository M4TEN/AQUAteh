using AutoMapper;
using AutoMapper.Configuration;
using ShopGiacomini.Areas.Admin.ViewModels.ProductViewModels;
using ShopGiacomini.Extentions;
using ShopGiacomini.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopGiacomini.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {

            var config = new MapperConfigurationExpression();
            config.AddProfile<AdminToViewModel>();
            config.AddProfile<AdminFromViewModel>();
            config.AddProfile<ToViewModel>();
            config.AddProfile<FromViewModel>();
            AutoMapper.Mapper.Initialize(config);
        }
    }
    public class AdminToViewModel : Profile
    {
        public AdminToViewModel()//всё что в админке в области типо ареас папка и там будет папка вьюмоделс. И это типо всё что мы будем передавать из таблицы бд в вьюмодел
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<Product, DetailsProductViewModel>();
            ////Article
            //CreateMap<Article, ArticleViewModel>(); //из таблицы артикл передаю в артиклвьюмодел
            //CreateMap<Article, DetailsArticleViewModel>();
            //CreateMap<Article, IndexArticleViewModel>();
            //CreateMap<Article, EditArticleViewModel>();

            ////Category
            //CreateMap<Category, CategoryViewModel>();
            //CreateMap<Category, EditCategoryViewModel>();
            //CreateMap<Category, ArticleCategoryViewModel>();
            ////Log
            //CreateMap<Log, LogViewModel>()
            //    .ForMember(
            //    m => m.Message,
            //    opt => opt.MapFrom(
            //        p => p.Message.Substring(0, p.Message.Length > 200 ? 200 : p.Message.Length) + "..."));

            ////User
            //CreateMap<User, UserViewModel>().ForMember(
            //    m => m.IsBlocked,
            //    opt => opt.MapFrom(src => src.LockoutEnabled)
            //    );
            //CreateMap<User, DetailsUserViewModel>();
        }
    }
    public class AdminFromViewModel : Profile
    {
        public AdminFromViewModel()//из вьюмодел в артикл
        {
            CreateMap<ProductViewModel, Product>();
            CreateMap<CreateProductViewModel, Product>()
                .ForMember(
                m => m.Image,
                opt => opt.MapFrom(src => src.Image.ToByteArray()));

            ////Article
            //CreateMap<ArticleViewModel, Article>();
            //CreateMap<ArticleCategoryViewModel, Category>();
            //CreateMap<CreateArticleViewModel, Article>()
            //    .ForMember(
            //    m => m.MainImage,
            //    opt => opt.MapFrom(src => src.Image.ToByteArray()))
            //    .ForMember(m => m.PublicationDate,
            //    opt => opt.MapFrom(src => DateTime.Now))
            //    .ForMember(m => m.SearchValues,
            //    opt => opt.MapFrom(src => src.SearchValues.ToListSplit()));
            //CreateMap<EditArticleViewModel, Article>()
            //    .ForMember(
            //    m => m.MainImage,
            //    opt => opt.MapFrom(src => src.Image == null ? src.MainImage : src.Image.ToByteArray()));

            ////Category
            //CreateMap<CreateCategoryViewModel, Category>();
            //CreateMap<EditCategoryViewModel, Category>();


        }


    }
    public class FromViewModel : Profile
    {
        public FromViewModel()
        {

        }
    }
    public class ToViewModel : Profile
    {
        public ToViewModel()
        {
            //CreateMap<Article, ArticleViewModel>();
            //CreateMap<Category, ArticleCategoryViewModel>();
            //CreateMap<Category, CategoryViewModel>();

            //CreateMap<Article, ArticleDetailsViewModel>();
            //CreateMap<User, ContactInfoViewModel>().ForMember(
            //    x => x.Image,
            //    opt => opt.MapFrom(src => src.AccountImage));
        }
    }


}