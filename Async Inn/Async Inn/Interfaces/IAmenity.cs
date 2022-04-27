using Async_Inn.Models;
using Async_Inn.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async_Inn.Interfaces
{
    public interface IAmenity
    {
        Task<List<AmenityDTO>> GetAmenities();
        Task<AmenityDTO> GetAmenity(int id);
        Task<int> PostAmenity(AmenityDTO amenity);
        Task<int> PutAmenity(AmenityDTO amenity);
        Task<int> DeleteAmenity(Amenity amenity);
        Task<Amenity> Find(int id);
        bool AmenityExists(int id);
    }
}
