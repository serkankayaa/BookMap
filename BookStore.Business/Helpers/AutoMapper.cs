using AutoMapper;
using BookStore.Dto;
using BookStore.Entity.Models;

namespace BookStore.Api.node_modules.automapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
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
        }
    }
}