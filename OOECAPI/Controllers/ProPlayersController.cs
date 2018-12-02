using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OOECAPI.Interfaces;

namespace OOECAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProPlayersController : Controller
    {
        private readonly IProPlayersRepository _proPlayersRepository;

        public ProPlayersController(IProPlayersRepository proPlayersRepo)
        {
            _proPlayersRepository = proPlayersRepo;
        }
        [Authorize(Policy = "ApiUser")]
        [HttpGet("getPlayerById/{id}")]
        public IActionResult GetPlayerById(long id)
        {
            var model = _proPlayersRepository.GetPlayerById(id);
            if (model == null)
                return NotFound();

            return Ok(model);
        }
        [Authorize(Policy = "ApiUser")]
        [HttpGet("getPlayerWL/{id}")]
        public IActionResult GetPlayerWL(long id)
        {
            var model = _proPlayersRepository.GetPlayerWL(id);
            if (model == null)
                return NotFound();

            return Ok(model);
        }
        [Authorize(Policy = "ApiUser")]
        [HttpGet("getPlayerMatches/{id}")]
        public IActionResult GetPlayerMatches(long id)
        {
            var model = _proPlayersRepository.GetPlayerMatches(id);
            if (model == null)
                return NotFound();

            return Ok(model);
        }
        [Authorize(Policy = "ApiUser")]
        [HttpGet("getPlayerHeroes/{id}")]
        public IActionResult GetPlayerHeroes(long id)
        {
            var model = _proPlayersRepository.GetPlayerHeroes(id);
            if (model == null)
                return NotFound();

            return Ok(model);
        }
        [Authorize(Policy = "ApiUser")]
        [HttpGet("getPlayerTotals/{id}")]
        public IActionResult GetPlayerTotals(long id)
        {
            var model = _proPlayersRepository.GetPlayerTotals(id);
            if (model == null)
                return NotFound();

            return Ok(model);
        }
    }
}