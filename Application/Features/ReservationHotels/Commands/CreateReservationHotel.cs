using Application.Hubs;
using Application.Interfaces.Repository;
using Application.Wrappers.Results;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Service;

namespace Application.Features.ReservationHotels.Commands;

public class CreateReservationHotel : IRequest<IDataResult<ReservationHotelEntity>>
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string HotelName { get; set; }
    public string? RoomNumber { get; set; }
    public DateTime HotelCheckinDate { get; set; }
    public DateTime HotelCheckoutDate { get; set; }
    public string AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? Description { get; set; }

    public class CreateReservationHotelCommandHandler : IRequestHandler<CreateReservationHotel, IDataResult<ReservationHotelEntity>>
    {
        private readonly IMapper _mapper;
        private readonly IReservationHotelRepository _reservationHotelRepository;
        private readonly IMessageProducer _messageProducer;
        private readonly IHubContext<NotificationHub> _hubContext;

        public CreateReservationHotelCommandHandler(IMapper mapper, IReservationHotelRepository reservationHotelRepository, IMessageProducer messageProducer, IHubContext<NotificationHub> hubContext)
        {
            _mapper = mapper;
            _reservationHotelRepository = reservationHotelRepository;
            _messageProducer = messageProducer;
            _hubContext = hubContext;
        }

        public async Task<IDataResult<ReservationHotelEntity>> Handle(CreateReservationHotel request, CancellationToken cancellationToken)
        {
            try
            {

                var reservationHotel = _mapper.Map<ReservationHotelEntity>(request);

                await _reservationHotelRepository.AddAsync(reservationHotel);

                _messageProducer.SendingMessage<ReservationHotelEntity>(reservationHotel);

                string message = $"Created a new reservation with number {reservationHotel.Id + reservationHotel.RoomNumber}";
                await _hubContext.Clients.All.SendAsync("ReceiveReservationNotification", message);

                return new SuccessDataResult<ReservationHotelEntity>(reservationHotel);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ReservationHotelEntity>(ex.Message + "\n" + ex.InnerException.Message);
            }
        }
    }
}