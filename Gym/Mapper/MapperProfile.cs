using AutoMapper;
using Gym.DTO;
using Gym.Models;

namespace Gym.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<AddTrainerDTO, Trainer>();
            CreateMap<Trainer, GetTrainerDTO>();
            CreateMap<AddTrainingDTO, Training>();
            CreateMap<Training, GetTrainingDTO>();
            CreateMap<AddMembershipDTO, Membership>();
            CreateMap<Membership, GetMembershipDTO>();
            CreateMap<Reservation, GetReservationDTO>();
            CreateMap<UserMembership, GetUserMembershipDTO>();
           
        }
    }
}
