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
    public class HotelService : IHotel
    {
        private readonly AsyncInnDbContext _context;

        public HotelService(AsyncInnDbContext context)
        {
            _context = context;
            
        }

        public async Task<int> DeleteHotel(Hotel hotel)
        {
            _context.Hotels.Remove(hotel);
            return await _context.SaveChangesAsync();
        }

        public async Task<HotelDTO> GetHotel(int id)
        {
            return await _context.Hotels.Select( x => new HotelDTO()
            { 
                ID = x.Id,
                Name = x.Name,
                City = x.City,
                StreetAddress = x.Address,
                Phone = x.PhoneNum,
                Rooms = x.HotelRoom.Select( x =>  new HotelRoomDTO()
                {
                    HotelID = x.Hotel.Id,
                    RoomNumber = x.RoomNum,
                    Rate = x.Rate,
                    RoomID = x.Room.Id,
                    Room =  new RoomDTO
                    {
                        ID = x.Room.Id,
                        Name = x.Room.Name,
                        Layout = x.Room.layout,
                        Amenities = x.Room.RoomAmenity.Select(x => new AmenityDTO 
                        {
                            ID = x.Amenity.Id,
                            Name = x.Amenity.Name,
                        }).ToList(),
                    }
                }).ToList()
            }).FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<List<HotelDTO>> GetHotels()
        {
            return await _context.Hotels.Select(x => new HotelDTO()
            {
                ID = x.Id,
                Name = x.Name,
                City = x.City,
                StreetAddress = x.Address,
                Phone = x.PhoneNum,
                Rooms = x.HotelRoom.Select(x => new HotelRoomDTO()
                {
                    HotelID = x.Hotel.Id,
                    RoomNumber = x.RoomNum,
                    Rate = x.Rate,
                    RoomID = x.Room.Id,
                    Room = new RoomDTO
                    {
                        ID = x.Room.Id,
                        Name = x.Room.Name,
                        Layout = x.Room.layout,
                        Amenities = x.Room.RoomAmenity.Select(x => new AmenityDTO
                        {
                            ID = x.Amenity.Id,
                            Name = x.Amenity.Name,
                        }).ToList(),
                    }
                }).ToList()
            }).ToListAsync();
        }

        public bool HotelExists(int id)
        {
            return _context.Hotels.Any(e => e.Id == id);
        }

        public async Task<int> PostHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> PutHotel(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
        public async Task<Hotel> Find(int id)
        {
            return await _context.Hotels.FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
