using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OOECAPI.Interfaces;
using OOECAPI.Models;
using OOECAPI.ViewModels;

namespace OOECAPI.Controllers
{
    [Route("api/[controller]")]
    public class TournamentController : Controller
    {
        private readonly ITournamentRepository _tournamentRepository;

        public TournamentController(ITournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        [Authorize(Policy = "ApiUser")]
        [Produces("application/json")]
        [HttpGet("get-tournaments-by-id/{id}")]
        public IActionResult GetTournamentsById(int id)
        {
            try
            {
                return Ok(_tournamentRepository.GetTournamentById(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Policy = "ApiUser")]
        [Produces("application/json")]
        [HttpGet("getcreatedbyuser")]
        public async Task<IActionResult> GetCreatedByUser()
        {
            try
            {
                return Ok(await _tournamentRepository.GetCreatedByUser());
            }
            catch
            {
                return BadRequest();
            }
        }

       // [Authorize(Policy = "ApiUser")]
        [Produces("application/json")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tournamentRepository.GetAll);
        }

        [Authorize(Policy = "ApiUser")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("create")]
        public IActionResult Create([FromBody] Tournament tournament)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _tournamentRepository.Create(tournament);
                return Ok(tournament);
            }
            catch
            {
                return BadRequest();
            }
        }

        //[Authorize(Policy = "ApiUser")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("update")]
        public IActionResult Edit([FromBody] Tournament tournament)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _tournamentRepository.Edit(tournament);
                return Ok(tournament);
            }
            catch
            {
                return BadRequest();
            }
        }

       // [Authorize(Policy = "ApiUser")]
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _tournamentRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}