using Application.Interfaces.Repository;
using Application.Wrappers.Results;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ReservationHotels.Commands;

public class UpdateReservationHotel : IRequest<IResponseResult>
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string HotelName { get; set; }
    public string? RoomNumber { get; set; }
    public DateTime HotelCheckinDate { get; set; }
    public DateTime HotelCheckoutDate { get; set; }
    public string AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? Description { get; set; }

    public class UpdateReservationHotelCommandHandler : IRequestHandler<UpdateReservationHotel, IResponseResult>
    {
        private readonly IReservationHotelRepository _reservationHotelRepository;
        private readonly IMapper _mapper;

        public UpdateReservationHotelCommandHandler(IMapper mapper, IReservationHotelRepository reservationHotelRepository)
        {
            _mapper = mapper;
            _reservationHotelRepository = reservationHotelRepository;
        }

        public async Task<IResponseResult> Handle(UpdateReservationHotel request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationHotelRepository.GetAsync(x => x.Id == request.Id);
            if (reservation == null)
                return new ErrorResult("Reservation not found.");

            reservation = _mapper.Map<ReservationHotelEntity>(request);
            await _reservationHotelRepository.UpdateAsync(reservation);
            return new SuccessResult("Reservation updated");
        }
    }
}