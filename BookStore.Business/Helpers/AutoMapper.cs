using AutoMapper;
using BookStore.Dto;
using BookStore.Entity.Models;

namespace BookStore.Api.node_modules.automapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            //Category<->DtoCategory Mapping
            CreateMap<Category, DtoCategory>()
            .ForMember(destination => destination.CategoryId, opt =>
            {
                opt.MapFrom(src => src.Id);
            })
            .ForMember(destination => destination.CategoryName, opt =>
            {
                opt.MapFrom(src => src.Name);
            })
            .ForMember(destination => destination.CategorySummary, opt =>
            {
                opt.MapFrom(src => src.Summary);
            })
            .ReverseMap();

            //Author<->DtoAuthor Mapping
            CreateMap<Author, DtoAuthor>()
            .ForMember(destination => destination.AuthorId, opt =>
            {
                opt.MapFrom(src => src.Id);
            })
            .ForMember(destination => destination.AuthorName, opt =>
            {
                opt.MapFrom(src => src.Name);
            })
            .ReverseMap();

            //Publisher<->DtoPublisher Mapping
            CreateMap<Publisher, DtoPublisher>()
            .ForMember(destination => destination.PublisherId, opt =>
            {
                opt.MapFrom(src => src.Id);
            })
            .ForMember(destination => destination.PublisherName, opt =>
            {
                opt.MapFrom(src => src.Name);
            })
            .ReverseMap();

            //Shop<->DtoShop Mapping
            CreateMap<Shop, DtoShop>()
            .ForMember(destination => destination.ShopId, opt =>
            {
                opt.MapFrom(src => src.Id);
            })
            .ForMember(destination => destination.ShopName, opt =>
            {
                opt.MapFrom(src => src.Name);
            })
            .ReverseMap();

            //User<->DtoUser Mapping
            CreateMap<User, DtoUser>()
            .ForMember(destination => destination.UserId, opt =>
            {
                opt.MapFrom(src => src.Id);
            })
            .ReverseMap();

        }
    }
}