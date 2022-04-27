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
    public class HotelRoomService : IHotelRoom
    {
        private readonly AsyncInnDbContext _context;
        public HotelRoomService(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<List<HotelRoomDTO>> GetAllRoom(int hotelId)
        {
            return await _context.HotelRoom.Where(x => x.HotelId == hotelId).Select(x => new HotelRoomDTO
            {
                HotelID = x.Hotel.Id,
                RoomID = x.Room.Id,
                Rate = x.Rate,
                RoomNumber = x.RoomNum,
                Room = new RoomDTO
                {
                    ID = x.Room.Id,
                    Name = x.Room.Name,
                    Layout = x.Room.layout,
                    Amenities = x.Room.RoomAmenity.Select(x => new AmenityDTO
                    {
                        ID = x.Amenity.Id,
                        Name = x.Amenity.Name,
                    }).ToList()
                }
            }).ToListAsync();
        
        }
        public async Task<int> AddRoomToHotel(int hotelId, HotelRoomDTO hotelRoom)
        {
            HotelRoom newHorelRoom = new HotelRoom
            {
                HotelId = hotelId,
                RoomNum = hotelRoom.RoomNumber,
                Rate = hotelRoom.Rate,
                RoomId = hotelRoom.RoomID,
            };
            _context.Entry(newHorelRoom).State = EntityState.Added;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> PutHotelRoom(int hotelId, int roomNum, HotelRoomDTO hotelRoom)
        {
            HotelRoom newHorelRoom = new HotelRoom
            {
                HotelId = hotelId,
                RoomNum = roomNum,
                Rate = hotelRoom.Rate,
                RoomId = hotelRoom.RoomID,
            };

            _context.Entry(newHorelRoom).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
        public async Task<HotelRoomDTO> GetDetails(int hotelId, int roomNum )
        {
            return await _context.HotelRoom.Where(x => x.HotelId == hotelId).Select(x => new HotelRoomDTO
            {
                HotelID = x.Hotel.Id,
                RoomID = x.Room.Id,
                Rate = x.Rate,
                RoomNumber = x.RoomNum,
                Room = new RoomDTO
                {
                    ID = x.Room.Id,
                    Name = x.Room.Name,
                    Layout = x.Room.layout,
                    Amenities = x.Room.RoomAmenity.Select(x => new AmenityDTO
                    {
                        ID = x.Amenity.Id,
                        Name = x.Amenity.Name,
                    }).ToList()
                }
            }).FirstOrDefaultAsync(x => x.RoomNumber == roomNum);
        }
        public async Task<int> DeleteRoomFromHotel(int hotelId, int roomNum)
        {
            _context.HotelRoom.Remove(_context.HotelRoom.FirstOrDefault(HR => HR.HotelId == hotelId && HR.RoomNum == roomNum));
            return await _context.SaveChangesAsync();
        }
    }
}
