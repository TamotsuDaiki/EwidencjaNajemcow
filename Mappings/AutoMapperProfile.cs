using AutoMapper;
using EwidencjaNajemcow.Models;
using EwidencjaNajemcow.ViewModels;

namespace EwidencjaNajemcow.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Rental, RentalViewModel>().ReverseMap();
        }
    }
}
