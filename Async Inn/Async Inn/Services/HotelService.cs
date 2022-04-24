using Async_Inn.Data;
using Async_Inn.Interfaces;
using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Services
{
    public class HotelService : IHotel
    {
        private readonly AsyncInnDbContext _context;
        public HotelService(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<int> DeleteHotel(Hotel hotel)
        {
            _context.Hotels.Remove(hotel);
            return await _context.SaveChangesAsync();
        }

        public async Task<Hotel> GetHotel(int id)
        {
            return await _context.Hotels.Include(HR => HR.HotelRoom).ThenInclude(r => r).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Hotel>> GetHotels()
        {
            return await _context.Hotels.Include(HR => HR.HotelRoom).ToListAsync();
        }

        public bool HotelExists(int id)
        {
            return _context.Hotels.Any(e => e.Id == id);
        }

        public async Task<int> PostHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> PutHotel(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
        public async Task<int> AddRoomToHotel(int hotelId, int roomNum, HotelRoom hotelRoom)
        {
            hotelRoom.HotelId = hotelId;
            hotelRoom.RoomNum = roomNum;
            _context.Entry(hotelRoom).State = EntityState.Added;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> PutHotelRoom(int hotelId, int roomNum, HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
        public async Task<int> DeleteRoomFromHotel(int hotelId, int roomNum)
        {
            _context.HotelRoom.Remove(_context.HotelRoom.FirstOrDefault(HR => HR.HotelId == hotelId && HR.RoomNum == roomNum));
            return await _context.SaveChangesAsync();
        }
    }
}
