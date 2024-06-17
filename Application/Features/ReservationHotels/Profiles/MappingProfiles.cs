using Application.Features.ReservationHotels.Commands;
using Application.Features.ReservationHotels.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.ReservationHotels.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ReservationHotelEntity, ReservationHotelDto>().ReverseMap();
        CreateMap<ReservationHotelEntity, UpdateReservationHotel>().ReverseMap();
        CreateMap<ReservationHotelEntity, CreateReservationHotel>().ReverseMap();

    }
}