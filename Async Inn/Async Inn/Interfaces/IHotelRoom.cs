using Async_Inn.Models;
using Async_Inn.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async_Inn.Interfaces
{
    public interface IHotelRoom
    {
        Task<List<HotelRoomDTO>> GetAllRoom(int hotelId);
        Task<int> AddRoomToHotel(int amenityId, HotelRoomDTO hotelRoom);
        Task<int> PutHotelRoom(int hotelId, int roomNum, HotelRoomDTO hotelRoom);
        Task<int> DeleteRoomFromHotel(int amenityId, int roomId);
    }
}
