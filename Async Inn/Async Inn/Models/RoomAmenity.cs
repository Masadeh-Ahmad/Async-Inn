namespace Async_Inn.Models
{
    public class RoomAmenity
    {
        public int AmenityID { get; set; }
        public int RoomID { get; set; }

        public Amenity Amenity { get; set; }
        public Room Room { get; set; }
    }
}
