using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OOECAPI.Interfaces;
using OOECAPI.Models;

namespace OOECAPI.Controllers
{
    [Route("api/[controller]")]
    public class LobbyController : Controller
    {
        private readonly ILobbyRepository _lobbyRepository;

        public LobbyController(ILobbyRepository lobbyRepository)
        {
            _lobbyRepository = lobbyRepository;
        }

        [Authorize(Policy = "ApiUser")]
        [Produces("application/json")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_lobbyRepository.GetAll);
        }

        [Authorize(Policy = "ApiUser")]
        [Produces("application/json")]
        [HttpGet("getbyid/{id}")]
        public IActionResult GetLobbyById(long id)
        {
            try
            {
                return Ok(_lobbyRepository.GetLobbyById(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Policy = "ApiUser")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("getcreatedbytournament/{tournamentId}")]
        public async Task<IActionResult> GetCreatedByTournament(long tournamentId)
        {
            try
            {
                return Ok(await _lobbyRepository.GetCreatedByTournament(tournamentId));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Policy = "ApiUser")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("create")]
        public IActionResult Create([FromBody] Lobby lobby)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _lobbyRepository.Create(lobby);
                return Ok(lobby);

            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Policy = "ApiUser")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("update")]
        public IActionResult Edit([FromBody] Lobby lobby)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _lobbyRepository.Edit(lobby);
                return Ok(lobby);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Policy = "ApiUser")]
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _lobbyRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}