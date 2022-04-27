using Async_Inn.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async_Inn.Interfaces
{
    public interface IAmenity
    {
        Task<List<Amenity>> GetAmenities();
        Task<Amenity> GetAmenity(int id);
        Task<int> PostAmenity(Amenity amenity);
        Task<int> PutAmenity(Amenity amenity);
        Task<int> DeleteAmenity(Amenity amenity);
        bool AmenityExists(int id);
    }
}
