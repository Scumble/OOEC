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
    public class LobbyController : Controller
    {
        private readonly ILobbyRepository _lobbyRepository;

        public LobbyController(ILobbyRepository lobbyRepository)
        {
            _lobbyRepository = lobbyRepository;
        }
        [Produces("application/json")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_lobbyRepository.GetAll);
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("create")]
        public IActionResult Create([FromBody] Lobby lobby)
        {
            try
            {
                _lobbyRepository.Create(lobby);
                return Ok(lobby);

            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("update")]
        public IActionResult Edit([FromBody] Lobby lobby)
        {
            try
            {
                _lobbyRepository.Edit(lobby);
                return Ok(lobby);
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