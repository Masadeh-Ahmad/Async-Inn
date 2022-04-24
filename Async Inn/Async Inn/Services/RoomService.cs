using Async_Inn.Data;
using Async_Inn.Interfaces;
using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Services
{
    public class RoomService : IRoom
    {
        private readonly AsyncInnDbContext _context;

        public RoomService(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<int> DeleteRoom(Room room)
        {
            _context.Rooms.Remove(room);
            return await _context.SaveChangesAsync();
        }

        public async Task<Room> GetRoom(int id)
        {
            return await _context.Rooms.Include(RM => RM.RoomAmenity).ThenInclude(a => a.Amenity).Include(HR => HR.HotelRoom).ThenInclude(a => a.Hotel).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Room>> GetRooms()
        {
            return await _context.Rooms.Include(RM => RM.RoomAmenity).ThenInclude(a => a.Amenity).Include(HR => HR.HotelRoom).ThenInclude(a => a.Hotel).ToListAsync();
        }

        public async Task<int> PostRoom(Room room)
        {
            _context.Rooms.Add(room);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> PutRoom(Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }
    }
}
