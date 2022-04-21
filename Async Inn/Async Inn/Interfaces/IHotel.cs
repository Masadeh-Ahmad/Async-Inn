using Async_Inn.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Async_Inn.Interfaces
{
    public interface IHotel
    {
        Task<List<Hotel>> GetHotels();
        Task<Hotel> GetHotel(int id);
        Task<int> PostHotel(Hotel hotel);
        Task<int> PutHotel(Hotel hotel);
        Task<int> DeleteHotel(Hotel hotel);
        public bool HotelExists(int id);
    }
}
