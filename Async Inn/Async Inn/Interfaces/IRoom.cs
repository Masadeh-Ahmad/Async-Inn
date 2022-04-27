using Async_Inn.Models;
using Async_Inn.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Async_Inn.Interfaces
{
    public interface IRoom
    {
        Task<List<RoomDTO>> GetRooms();
        Task<RoomDTO> GetRoom(int id);
        Task<int> PostRoom(RoomDTO room);
        Task<int> PutRoom(RoomDTO room);
        Task<int> DeleteRoom(Room room);
        Task<int> AddAmenityToRoom(int roomId, int amenityId);
        Task<int> DeleteAmenityFromRoom(int amenityId, int roomId);
        Task<Room> Find(int id);
        public bool RoomExists(int id);
    }
}
