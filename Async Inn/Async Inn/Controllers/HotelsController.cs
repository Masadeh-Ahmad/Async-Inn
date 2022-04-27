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

namespace Async_Inn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotel _hotel;

        public HotelsController(IHotel hotel)
        {
            _hotel = hotel;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<List<Hotel>>> GetHotels()
        {
            return await _hotel.GetHotels();
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            var hotel = await _hotel.GetHotel(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, Hotel hotel)
        {
            if (id != hotel.Id)
            {
                return BadRequest();
            }
            try
            {
                await _hotel.PutHotel(hotel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_hotel.HotelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            await _hotel.PostHotel(hotel);

            return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await _hotel.GetHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }

            await _hotel.DeleteHotel(hotel);

            return NoContent();
        }
        [HttpGet("{hotelId}/Rooms")]
        public async Task<ActionResult<Hotel>> GetAllRoom(int hotelId) 
        {
            var hotel = await _hotel.GetAllRoom(hotelId);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        [HttpPost("{hotelId}/Rooms")]
        public async Task<IActionResult> AddRoomToHotel(int hotelId, HotelRoom hotelRoom)
        {
            await _hotel.AddRoomToHotel(hotelId, hotelRoom);
            return NoContent();
        }

        [HttpPut("{hotelId}/Rooms/{roomNum}")]
        public async Task<IActionResult> PutHotelRoom(int hotelId, int roomNum, HotelRoom hotelRoom)
        {
            await _hotel.PutHotelRoom( hotelId,  roomNum, hotelRoom);
           
            return NoContent();
        }

        [HttpDelete("{hotelId}/Rooms/{roomNum}")]
        public async Task<IActionResult> DeleteRoomFromHotel(int hotelId, int roomNum)
        {
            await _hotel.DeleteRoomFromHotel(hotelId, roomNum);
            return NoContent();
        }


    }
}
