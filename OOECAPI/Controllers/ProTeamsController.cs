using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OOECAPI.Interfaces;
using OOECAPI.Services;

namespace OOECAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProTeamsController : Controller
    {
        private readonly IProTeamsRepository _proTeamsRepository;

        public ProTeamsController(IProTeamsRepository proTeamsRepo)
        {
            _proTeamsRepository = proTeamsRepo;
        }
        [Authorize(Policy = "ApiUser")]
        [HttpGet("getTeams")]
        public IActionResult GetTeams()
        {
            var model = _proTeamsRepository.GetTeams();
            if (model == null)
                return NotFound(); 

            return Ok(model);
        }
        [Authorize(Policy = "ApiUser")]
        [HttpGet("getTeamById/{id}")]
        public IActionResult GetTeamById(long id)
        {
            var model = _proTeamsRepository.GetTeamById(id);
            if (model == null)
                return NotFound();

            return Ok(model);
        }
        [Authorize(Policy = "ApiUser")]
        [HttpGet("getTeamMatches/{id}")]
        public IActionResult GetTeamMatches(long id)
        {
            var model = _proTeamsRepository.GetTeamMatches(id);
            if (model == null)
               return NotFound();

            return Ok(model);
        }
        [Authorize(Policy = "ApiUser")]
        [HttpGet("getTeamPlayers/{id}")]
        public IActionResult GetTeamPlayers(long id)
        {
            var model = _proTeamsRepository.GetTeamPlayers(id);
            if (model == null)
              return NotFound();

            return Ok(model);
        }
    }
}