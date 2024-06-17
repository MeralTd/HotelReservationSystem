using Application.Features.ReservationHotels.Dtos;
using Application.Interfaces.Repository;
using Application.Wrappers.Results;
using AutoMapper;
using MediatR;

namespace Application.Features.ReservationHotels.Queries;

public class GetAllReservationHotel : IRequest<IDataResult<IEnumerable<ReservationHotelDto>>>
{
    public class GetAllReservationHandler : IRequestHandler<GetAllReservationHotel, IDataResult<IEnumerable<ReservationHotelDto>>>
    {
        private readonly IReservationHotelRepository _reservationHotelRepository;
        private readonly IMapper _mapper;

        public GetAllReservationHandler(IReservationHotelRepository reservationHotelRepository, IMapper mapper)
        {
            _reservationHotelRepository = reservationHotelRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<IEnumerable<ReservationHotelDto>>> Handle(GetAllReservationHotel request, CancellationToken cancellationToken)
        {
            var reservationHotels = await _reservationHotelRepository.GetAllAsync();
            if (reservationHotels.Count <= 0)
                return new ErrorDataResult<IEnumerable<ReservationHotelDto>>("Reservation hotels info not found.");

            var mappedModel = _mapper.Map<IEnumerable<ReservationHotelDto>>(reservationHotels);
            return new SuccessDataResult<IEnumerable<ReservationHotelDto>>(mappedModel);
        }
    }
}
