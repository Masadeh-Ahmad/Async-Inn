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
            throw new System.NotImplementedException();
        }

        public async Task<Hotel> GetHotel(int id)
        {
            return await _context.Hotels.FindAsync(id);
        }

        public async Task<List<Hotel>> GetHotels()
        {
            return await _context.Hotels.ToListAsync();
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
    }
}
