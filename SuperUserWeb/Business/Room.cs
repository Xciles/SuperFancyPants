using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperUserWeb.Business.Interfaces;
using SuperUserWeb.Data;
using SuperUserWeb.Domain.Enums;
using SuperUserWeb.Models.RoomViewModels;

namespace SuperUserWeb.Business
{
    public class Room : IRoom
    {
        private readonly DbContext _context;

        public Room(FancyDbContext context)
        {
            _context = context;
        }

        public async Task CreatePost(RoomViewModel room)
        {
            var dbRoom = new Domain.Room
            {
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                State = EState.Active,
                Name = room.Name, 
                Description = room.Description, 
                Size = room.Size
            };

            _context.Set<Domain.Room>().Add(dbRoom);
            await _context.SaveChangesAsync();
        }

        public Task<IList<Domain.Room>> ToList()
        {
            throw new NotImplementedException();
        }
    }
}
