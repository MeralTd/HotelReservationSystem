using Application.Features.ReservationHotels.Dtos;
using Application.Interfaces.Repository;
using Application.Wrappers.Results;
using AutoMapper;
using MediatR;

namespace Application.Features.ReservationHotels.Queries;

public class GetReservationHotelById : IRequest<IDataResult<ReservationHotelDto>>
{
    public int Id { get; set; }

    public class GetReservationByIdHandler : IRequestHandler<GetReservationHotelById, IDataResult<ReservationHotelDto>>
    {
        private readonly IReservationHotelRepository _reservationHotelRepository;
        private readonly IMapper _mapper;

        public GetReservationByIdHandler(IMapper mapper, IReservationHotelRepository reservationHotelRepository)
        {
            _mapper = mapper;
            _reservationHotelRepository = reservationHotelRepository;
        }

        public async Task<IDataResult<ReservationHotelDto>> Handle(GetReservationHotelById request, CancellationToken cancellationToken)
        {
            var reservationHotel = await _reservationHotelRepository.GetAsync(x => x.Id == request.Id);
            if (reservationHotel == null)
                return new ErrorDataResult<ReservationHotelDto>("Reservation Hotel not found");

            var mappedModel = _mapper.Map<ReservationHotelDto>(reservationHotel);
            return new SuccessDataResult<ReservationHotelDto>(mappedModel);
        }
    }
}