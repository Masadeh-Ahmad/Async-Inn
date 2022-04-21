using Async_Inn.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Async_Inn.Interfaces
{
    public interface IRoom
    {
        Task<List<Room>> GetRooms();
        Task<Room> GetRoom(int id);
        Task<int> PostRoom(Room room);
        Task<int> PutRoom(Room room);
        Task<int> DeleteRoom(Room room);
        public bool RoomExists(int id);
    }
}
