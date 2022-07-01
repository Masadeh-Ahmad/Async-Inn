using Async_Inn.Models;
using Async_Inn.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class Test : Mock
    {
        [Fact]
        public async Task AddHotelTest()
        {
            var hotel = await CreateAndSaveTestHotel();
            
        }
        [Fact]
        public async Task AddRoomTest()
        {
            
            var room = await CreateAndSaveTestRoom();
        }
        [Fact]
        public async Task test()
        {
           
            var servise = new HotelService(_db);
            var hotel1 = await servise.GetHotels();
            var hotel2 = hotel1[0];
            Assert.Equal("Masadeh", hotel2.Name);
            await servise.PutHotel(new Hotel { Id=1,Name="Ahmad",});
             hotel1 = await servise.GetHotels();
             hotel2 = hotel1[0];
            Assert.Equal("Ahmad", hotel2.Name);
        }
    }
}
