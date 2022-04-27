using Async_Inn.Models;
using Async_Inn.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Async_Inn.Interfaces
{
    public interface IHotel
    {
        Task<List<HotelDTO>> GetHotels();
        Task<HotelDTO> GetHotel(int id);
        Task<int> PostHotel(Hotel hotel);
        Task<int> PutHotel(Hotel hotel);
        Task<int> DeleteHotel(Hotel hotel);
        Task<Hotel> Find(int id);

        public bool HotelExists(int id);
    }
}
