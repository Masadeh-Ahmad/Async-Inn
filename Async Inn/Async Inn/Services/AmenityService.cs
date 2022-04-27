using Async_Inn.Data;
using Async_Inn.Interfaces;
using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Services
{
    public class AmenityService : IAmenity
    {
        private readonly AsyncInnDbContext _context;
        public AmenityService(AsyncInnDbContext context)
        {
            _context = context;
        }
       
        public async Task<List<Amenity>> GetAmenities()
        {
            return await _context.Amenities.Include(RM => RM.RoomAmenity).ThenInclude(r => r.Room).ToListAsync();
        }

        public async Task<Amenity> GetAmenity(int id)
        {
            return await _context.Amenities.Include(RM => RM.RoomAmenity).ThenInclude(r => r.Room).FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<int> PostAmenity(Amenity amenity)
        {
            _context.Amenities.Add(amenity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> PutAmenity(Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAmenity(Amenity amenity)
        {
            _context.Amenities.Remove(amenity);
            return await _context.SaveChangesAsync();
        }
        public bool AmenityExists(int id)
        {
            return _context.Amenities.Any(e => e.Id == id);
        }

    }
}
