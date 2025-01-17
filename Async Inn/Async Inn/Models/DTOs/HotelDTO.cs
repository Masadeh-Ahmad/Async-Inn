﻿using System.Collections.Generic;

namespace Async_Inn.Models.DTOs
{
    public class HotelDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string StreetAddress { get; set; }
        public string Phone { get; set; }
        public List<HotelRoomDTO> Rooms { get; set; }
    }
}
