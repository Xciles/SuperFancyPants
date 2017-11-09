using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperUserWeb.Business.Interfaces;
using SuperUserWeb.Data;
using SuperUserWeb.Domain.Enums;

namespace SuperUserWeb.Business
{
    public class Room : IRoom
    {
        private readonly DbContext _context;

        public Room(FancyDbContext context)
        {
            _context = context;
        }

        public async Task CreatePost(Domain.Room room)
        {
            room.CreatedDate = DateTime.UtcNow;
            room.ModifiedDate = DateTime.UtcNow;
            room.State = EState.Active;

            _context.Set<Domain.Room>().Add(room);
            await _context.SaveChangesAsync();
        }

        public Task<IList<Domain.Room>> ToList()
        {
            throw new NotImplementedException();
        }
    }
}
