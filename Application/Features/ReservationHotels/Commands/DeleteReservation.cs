using Application.Interfaces.Repository;
using Application.Wrappers.Results;
using MediatR;

namespace Application.Features.ReservationHotels.Commands;

public class DeleteReservation : IRequest<IResponseResult>
{
    public int Id { get; set; }

    public class DeleteReservationHandler : IRequestHandler<DeleteReservation, IResponseResult>
    {
        private readonly IReservationHotelRepository _reservationHotelRepository;

        public DeleteReservationHandler(IReservationHotelRepository reservationHotelRepository)
        {
            _reservationHotelRepository = reservationHotelRepository;
        }

        public async Task<IResponseResult> Handle(DeleteReservation request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationHotelRepository.GetAsync(x => x.Id == request.Id);
            if (reservation == null)
                return new ErrorResult("Reservation not found.");

            await _reservationHotelRepository.RemoveAsync(reservation);
            return new SuccessResult("Your reservation has been successfully deleted.");
        }
    }
}