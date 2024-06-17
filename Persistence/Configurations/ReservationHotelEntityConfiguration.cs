using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ReservationHotelEntityConfiguration : BaseConfiguration<ReservationHotelEntity>
{
    public override void Configure(EntityTypeBuilder<ReservationHotelEntity> builder)
    {
        builder.ToTable("reservation_hotels");
        builder.Property(x => x.UserName).HasColumnName("user_name").IsRequired();
        builder.Property(x => x.Email).HasColumnName("email").IsRequired();
        builder.Property(x => x.HotelName).HasColumnName("hotel_name").IsRequired();
        builder.Property(x => x.RoomNumber).HasColumnName("room_number").IsRequired(false);
        builder.Property(x => x.Description).HasColumnName("description").HasMaxLength(250).IsRequired(false);
        builder.Property(x => x.HotelCheckinDate).HasColumnName("hotel_checkin_date").HasColumnType("timestamp with time zone").IsRequired();
        builder.Property(x => x.HotelCheckoutDate).HasColumnName("hotel_checkout_date").HasColumnType("timestamp with time zone").IsRequired();
        builder.Property(x => x.AddressLine1).HasColumnName("address_line1").IsRequired();
        builder.Property(x => x.AddressLine2).HasColumnName("address_line2").IsRequired(false);


        base.Configure(builder);
    }
}
