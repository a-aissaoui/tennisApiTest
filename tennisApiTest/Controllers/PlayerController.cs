using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;
using tennisApiTest.Services;

namespace tennisApiTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _service;

        public PlayerController(IPlayerService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetPlayers()
        {
            try
            {
                // retourne les joueurs.La liste est triée du meilleur au moins bon.
                var players = _service.GetSortedPlayers();
                return Ok(players);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Une erreur s'est produite" });
            }
           
        }

        [HttpGet("{id}")]
        public IActionResult GetPlayerById(int id)
        {
            var player = _service.GetPlayerById(id);
            if (player == null)
            {
                return NotFound("Joueur non trouvé");
            }
            return Ok(player);
        }

        [HttpGet("stats")]
        public IActionResult GetStatistics()
        {
            var stats = _service.GetStatistics();
            return Ok(stats);
        }
    }
}
