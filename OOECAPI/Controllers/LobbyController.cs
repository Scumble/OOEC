using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OOECAPI.Interfaces;
using OOECAPI.Models;
using OOECAPI.ViewModels;

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
        public IActionResult GetLobbyById(int id)
        {
            try
            {
                var list = _lobbyRepository.GetLobbyById(id);
                return Ok(list);
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
        public IActionResult Create([FromBody] LobbyViewModel lobby)
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
        [HttpPost("update")]
        public IActionResult Edit([FromBody] LobbyViewModel lobby)
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
        [Authorize(Policy = "ApiUser")]
        [HttpGet("getLobbies/{tournamentId}")]
        public IActionResult GetLobbies(long? tournamentId)
        {
            try
            {
                return Ok(_lobbyRepository.GetLobbies(tournamentId));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}