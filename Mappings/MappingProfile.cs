using AutoMapper;
using EwidencjaNajemcow.Models;
using EwidencjaNajemcow.ViewModels;


namespace EwidencjaNajemcow.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Rental, RentalDTO>().ReverseMap();
            CreateMap<Rental, RentalViewModel>().ReverseMap();
        }
    }
}
