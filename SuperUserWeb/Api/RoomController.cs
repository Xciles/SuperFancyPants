using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperUserWeb.Data;

namespace SuperUserWeb.Api
{
    [Produces("application/json")]
    [Route("api/room")]
    public class RoomController : Controller
    {
        private readonly DbContext _context;

        public RoomController(FancyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rooms = await _context.Set<Domain.Room>().ToListAsync();
            return Ok(rooms);
        }

        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> GetRoom(string id)
        {
            var room = await _context.Set<Domain.Room>().FirstOrDefaultAsync(x => x.Id == id);
            return Ok(room);
        }
    }
}
