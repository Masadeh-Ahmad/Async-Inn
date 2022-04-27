using Async_Inn.Data;
using Async_Inn.Interfaces;
using Async_Inn.Models;
using Async_Inn.Models.DTOs;
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

        public async Task<List<AmenityDTO>> GetAmenities()
        {
            return await _context.Amenities.Select(amenity => new AmenityDTO
            {
                ID = amenity.Id,
                Name = amenity.Name
            }).ToListAsync();
        }

        public async Task<AmenityDTO> GetAmenity(int id)
        {
            return await _context.Amenities.Select(amenity => new AmenityDTO
            {

                ID = amenity.Id,
                Name = amenity.Name
            }).FirstOrDefaultAsync(x => x.ID == id);

        }

        public async Task<int> PostAmenity(AmenityDTO amenityDTO)
        {
            Amenity amenity = new Amenity() { Id = amenityDTO.ID, Name = amenityDTO.Name };
            _context.Amenities.Add(amenity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> PutAmenity(AmenityDTO amenityDTO)
        {
            Amenity amenity = new Amenity() { Id = amenityDTO.ID, Name = amenityDTO.Name };
            _context.Entry(amenity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAmenity(Amenity amenity)
        {
            _context.Amenities.Remove(amenity);
            return await _context.SaveChangesAsync();
        }
        public async Task<Amenity> Find(int id)
        {
            return await _context.Amenities.FirstOrDefaultAsync(x => x.Id == id);
        }
        public bool AmenityExists(int id)
        {
            return _context.Amenities.Any(e => e.Id == id);
        }

    }
}
