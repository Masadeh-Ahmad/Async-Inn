using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Async_Inn.Data;
using Async_Inn.Models;
using Async_Inn.Interfaces;
using Async_Inn.Models.DTOs;

namespace Async_Inn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoom _hotelRoom;

        public HotelRoomsController(IHotelRoom hotelRoom)
        {
            _hotelRoom = hotelRoom;
        }

        [HttpGet("{hotelId}/Rooms")]
        public async Task<ActionResult<List<HotelRoomDTO>>> GetAllRoom(int hotelId)
        {
            var hotel = await _hotelRoom.GetAllRoom(hotelId);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        [HttpPost("{hotelId}/Rooms")]
        public async Task<IActionResult> AddRoomToHotel(int hotelId, HotelRoomDTO hotelRoom)
        {
            await _hotelRoom.AddRoomToHotel(hotelId, hotelRoom);
            return NoContent();
        }

        [HttpPut("{hotelId}/Rooms/{roomNum}")]
        public async Task<IActionResult> PutHotelRoom(int hotelId, int roomNum, HotelRoomDTO hotelRoom)
        {
            await _hotelRoom.PutHotelRoom(hotelId, roomNum, hotelRoom);

            return NoContent();
        }

        [HttpDelete("{hotelId}/Rooms/{roomNum}")]
        public async Task<IActionResult> DeleteRoomFromHotel(int hotelId, int roomNum)
        {
            await _hotelRoom.DeleteRoomFromHotel(hotelId, roomNum);
            return NoContent();
        }

        
    }
}
