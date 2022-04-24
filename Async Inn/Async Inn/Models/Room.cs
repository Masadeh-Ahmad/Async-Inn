using System.Collections.Generic;

namespace Async_Inn.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string layout { get; set; }
        public List<RoomAmenity> RoomAmenity { get; set; }
    }
}
