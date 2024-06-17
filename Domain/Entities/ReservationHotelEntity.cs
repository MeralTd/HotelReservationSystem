using Domain.Common;

namespace Domain.Entities;

public class ReservationHotelEntity : BaseEntity
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

}