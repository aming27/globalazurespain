using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace FootballAPI.Controllers

{
    [Route("api/[controller]")]
    [ApiController]

    public class FootballPlayerController : ControllerBase
    {
        
        private readonly DataContext _context;
        //private readonly DataContext context;

        public FootballPlayerController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<FootballPlayer>>> Get()
        {
            
            return Ok(await _context.FootballPlayers.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<FootballPlayer>> Get(int id)
        {
            var player = await _context.FootballPlayers.FindAsync(id);
              if(player == null)
                return BadRequest("Player not found");
              return Ok(player);
        }

        [HttpPost]
        public async Task<ActionResult<List<FootballPlayer>>> AddPlayer(FootballPlayer player)
        {
            //players.Add(player);
            _context.FootballPlayers.Add(player);
            await _context.SaveChangesAsync();
            return Ok(await _context.FootballPlayers.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<FootballPlayer>>> UpdatePlayer(FootballPlayer request)
        {
            //var player = players.Find(h => h.Id == request.Id);
            var player = await _context.FootballPlayers.FindAsync(request.Id);
            if (player == null)
                return BadRequest("Player not found");
            player.Name = request.Name;
            player.FirstName = request.FirstName;
            player.LastName = request.LastName;
            player.Position = request.LastName;

            await _context.SaveChangesAsync();



            return Ok(await _context.FootballPlayers.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FootballPlayer>> Delete(int id)
        {
            //var player = players.Find(h => h.Id == id);
            var player = await _context.FootballPlayers.FindAsync(id);
            if (player == null)
                return BadRequest("Player not found");
            _context.FootballPlayers.Remove(player);
            await _context.SaveChangesAsync();
            return Ok(await _context.FootballPlayers.ToListAsync());

        }

    }
}