using AutoMapper;
using Is_Sistem.Application.Models.Reservation;
using Is_Sistem.Core.Entities;

namespace Is_Sistem.Application.MappingProfiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<CreateReservationModel, Reservation>();
            CreateMap<Reservation, ReservationResponseModel>();
        }
    }
}
