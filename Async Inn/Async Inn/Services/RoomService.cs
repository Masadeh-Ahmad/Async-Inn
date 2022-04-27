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
    public class RoomService : IRoom
    {
        private readonly AsyncInnDbContext _context;

        public RoomService(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<int> DeleteRoom(Room room)
        {
            _context.Rooms.Remove(room);
            return await _context.SaveChangesAsync();
        }

        public async Task<RoomDTO> GetRoom(int id)
        {
            return await _context.Rooms.Select(r => new RoomDTO
            {
                ID = r.Id,
                Name = r.Name,
                Layout = r.layout,
                Amenities = r.RoomAmenity.Select(x => new AmenityDTO
                {
                    ID = x.Amenity.Id,
                    Name = x.Amenity.Name
                }).ToList()
            }).FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<List<RoomDTO>> GetRooms()
        {
            return await _context.Rooms.Select(r => new RoomDTO
            {
                ID = r.Id,
                Name = r.Name,
                Layout = r.layout,
                Amenities = r.RoomAmenity.Select(x => new AmenityDTO
                {
                    ID = x.Amenity.Id,
                    Name = x.Amenity.Name
                }).ToList()
            }).ToListAsync();
        }

        public async Task<int> PostRoom(RoomDTO roomDTO)
        {
            Room room = new Room()
            {
                Name = roomDTO.Name,
                layout = roomDTO.Layout,

            };
            _context.Rooms.Add(room);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> PutRoom(RoomDTO roomDTO)
        {
            Room room = new Room()
            {
                Id = roomDTO.ID,
                Name = roomDTO.Name,
                layout = roomDTO.Layout,

            };
            _context.Entry(room).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenity roomAmenity = new RoomAmenity
            {
                AmenityID = amenityId,
                RoomID = roomId
            };
            _context.Entry(roomAmenity).State = EntityState.Added;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAmenityFromRoom(int roomId, int amenityId)
        {
            _context.RoomAmenity.Remove(_context.RoomAmenity.FirstOrDefault(RM => RM.RoomID == roomId && RM.AmenityID == amenityId));
            return await _context.SaveChangesAsync();
        }
        public async Task<Room> Find(int id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }
    }
}
