using AutoMapper;
using Guest_BO.DataModel;
using Guest_BO.DTOModel.GuestModel;
using Guest_BO.DTOModel.PhoneNumber;
using Guest_BO.DTOModel.User;

namespace GuestApp
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Guest, GuestDTO>().ReverseMap();
            CreateMap<Guest, CreateGuestDTO>().ReverseMap();
            CreateMap<Guest, UpdateGuestDTO>().ReverseMap();

            CreateMap<PhoneNumber, CreatePhoneNumberDTO>().ReverseMap();
            CreateMap<GuestPhoneNumber, CreatePhoneNumberDTO>().ReverseMap();
            
            CreateMap<ApplicationUser, UserDTO>().ReverseMap();
        }
    }
}
