using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RoomAmenity> RoomAmenity { get; set; }
        public DbSet<HotelRoom> HotelRoom { get; set; }

        public AsyncInnDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This calls the base method, but does nothing
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>().HasData(
              new Hotel { Id = 1, Name = "Masadeh" , City = "Irbid", Address = "Irbid,Jordan", PhoneNum ="12536748" },
              new Hotel { Id = 2, Name = "Ahmad", City = "Amman", Address = "Amman,Jordan", PhoneNum = "7596454" },
              new Hotel { Id = 3, Name = "Osama", City = "Alhuson", Address = "Alhuson,Jordan", PhoneNum = "3157569" }
            );
            modelBuilder.Entity<Room>().HasData(
              new Room { Id = 1, Name = "Sleeping Room", layout ="1"  },
              new Room { Id = 2, Name = "View Room", layout = "6" },
              new Room { Id = 3, Name = "Top Room", layout = "4" }
            );
            modelBuilder.Entity<Amenity>().HasData(
              new Amenity { Id = 1, Name = "Air Conditioner" },
              new Amenity { Id = 2, Name = "Multiple Bedrooms " },
              new Amenity { Id = 3, Name = "VIP bed" }
            );
            modelBuilder.Entity<RoomAmenity>().HasKey(
                roomAmenity => new { roomAmenity.AmenityID,roomAmenity.RoomID }
                );
            modelBuilder.Entity<HotelRoom>().HasKey(
                hotelRoom => new { hotelRoom.HotelId,hotelRoom.RoomNum }
                );
        }
      
    }
    
}
