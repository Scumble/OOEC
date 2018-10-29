using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OOECAPI.Interfaces;
using OOECAPI.Models;

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

        [Produces("application/json")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tournamentRepository.GetAll);
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("create")]
        public IActionResult Create([FromBody] Tournament tournament)
        {
            try
            {
                _tournamentRepository.Create(tournament);
                return Ok(tournament);

            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("update")]
        public IActionResult Edit([FromBody] Tournament tournament)
        {
            try
            {
                _tournamentRepository.Edit(tournament);
                return Ok(tournament);
            }
            catch
            {
                return BadRequest();
            }
        }

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