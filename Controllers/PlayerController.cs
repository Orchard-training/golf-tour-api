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
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepo _player;
        public PlayerController(IPlayerRepo player)
        {
            _player = player;
        }
        // /api/player
        [HttpGet]
        public IActionResult GetPlayers()
        {
            return Ok(_player.GetPlayers());
        }
        // /api/player
        [HttpPost]
        public IActionResult AddPlayer([FromBody] Player player)
        {
            bool isAdded = _player.AddPlayer(player);
            if (isAdded)
                return Created(string.Empty, player);
            return BadRequest();
        }
        // /api/player?name
        [HttpDelete]
        public IActionResult DeletePlayer([FromQuery] string name)
        {
            bool isDeleted = _player.DeleteAmateur(name);
            if (isDeleted)
                return Ok();
            return BadRequest("Player Cant be deleted.");
        }
        // /api/player?name
        [HttpPut]
        public IActionResult UpdateExperience([FromQuery] string name, [FromBody] Player player)
        {
            bool isUpdated = _player.UpdateExperience(name, player);
            if (isUpdated)
                return Ok();
            return BadRequest("Update Failed");
        }

    }
}
