namespace Async_Inn.Models
{
    public class HotelRoom
    {
        public int HotelId { get; set; }
        public int RoomNum { get; set; }
        public int RoomId { get; set; }
        public int Rate { get; set; }

        public Hotel Hotel { get; set; }
        //public Room Room { get; set; }
    }
}
