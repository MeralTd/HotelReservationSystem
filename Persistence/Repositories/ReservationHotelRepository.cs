using Application.Interfaces.Repository;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class ReservationHotelRepository : GenericRepository<ReservationHotelEntity, DataContext>, IReservationHotelRepository
{
}