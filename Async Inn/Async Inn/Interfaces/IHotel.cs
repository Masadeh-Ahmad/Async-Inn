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
        Task<int> AddRoomToHotel(int amenityId, int roomId, HotelRoom hotelRoom);
        Task<int> PutHotelRoom(int hotelId, int roomNum, HotelRoom hotelRoom);
        Task<int> DeleteRoomFromHotel(int amenityId, int roomId);
        public bool HotelExists(int id);
    }
}
