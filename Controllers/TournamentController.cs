using GolfCourse.Entity;
using GolfCourse.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfCourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentRepo _tournament;

        public TournamentController(ITournamentRepo tournament)
        {
            _tournament = tournament;
        }

        [HttpGet]
        public IActionResult GetTournaments()
        {
            return Ok(_tournament.GetTournaments());
        }
        [HttpGet("prize")]
        public IActionResult GetTournamentsByPrize()
        {
            return Ok(_tournament.GetTournamentsWithPrize());
        }

        [HttpPost]
        public IActionResult AddTounament([FromBody] Tournament tournament)
        {
            _tournament.AddTournament(tournament);
            return Created(string.Empty, tournament);
        }

        [HttpGet("search")]
        public IActionResult GetPlayersInTournament([FromQuery] int tourId)
        {
            List<Player> players = _tournament.GetPlayersInTournament(tourId);
            if (players is null)
                return BadRequest("Invalid");
            return Ok(players);
        }
    }
}
