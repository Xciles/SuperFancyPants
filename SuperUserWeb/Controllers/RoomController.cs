using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using SuperUserWeb.Business;
using SuperUserWeb.Business.Interfaces;
using SuperUserWeb.Data;
using SuperUserWeb.Domain.Enums;
using SuperUserWeb.Models.RoomViewModels;
using Room = SuperUserWeb.Domain.Room;

namespace SuperUserWeb.Controllers
{
    [Authorize(Roles = "Admin, Receptionist")]
    public class RoomController : Controller
    {
        private readonly IRoom _room;
        private readonly FancyDbContext _context;
        private readonly IStringLocalizer<RoomController> _localizer;
        private readonly ILogger<RoomController> _logger;

        public RoomController(FancyDbContext context, IRoom room, IStringLocalizer<RoomController> localizer,
            ILogger<RoomController> logger)
        {
            _room = room;
            _context = context;
            
            _localizer = localizer;
            _logger = logger;
        }

        // GET: Room
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation(_localizer["Hello"]);

            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var requestCulture = requestCultureFeature.RequestCulture;
            var loc = _localizer.WithCulture(requestCulture.Culture);
            var hello = loc["Hello"];

            _logger.LogInformation(hello);


            return View(await _context.Rooms.Where(x=> x.State == EState.Active).ToListAsync());
        }

        // GET: Room/Details/5
        // GET: Room/Details/5/guestId
        // GET: Room/Details/guestid
        // GET: guestId
        // GET: Room/Index/guestId
        // GET: Room?guestId
        [Route("details/{id}/{guestId}")]
        public async Task<IActionResult> Details(string id, string guestId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms.SingleOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Room/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Room/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Size")] RoomViewModel room)
        {
            if (ModelState.IsValid)
            {
                await _room.CreatePost(room);

                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Room/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms.SingleOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            var roomVm = Mapper.Map<Room, RoomViewModel>(room);
            //var roomVm = new RoomViewModel
            //{
            //    Name = room.Name, 
            //    Description = room.Description, 
            //    Id = room.Id, 
            //    Size = room.Size
            //};

            return View(roomVm);
        }

        // POST: Room/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Description,Size,Id")] RoomViewModel room)
        {
            if (id != room.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var dbRoom = await _context.Rooms.FirstAsync(x => x.Id == room.Id);
                    dbRoom.Name = room.Name;
                    dbRoom.Description = room.Description;
                    dbRoom.Size = room.Size;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Room/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms.SingleOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var room = await _context.Rooms.SingleOrDefaultAsync(m => m.Id == id);

            room.DeletedDate = DateTime.UtcNow;
            room.State = EState.Deleted;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(string id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }
    }
}
