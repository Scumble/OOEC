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
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        [Authorize(Policy = "ApiUser")]
        [Produces("application/json")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_playerRepository.GetAll);
        }
        [Authorize(Policy = "ApiUser")]
        [Produces("application/json")]
        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_playerRepository.GetById(id));
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
        public IActionResult Create([FromBody] Player player)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _playerRepository.Create(player);
                return Ok(player);

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
        public IActionResult Edit([FromBody] Player player)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _playerRepository.Edit(player);
                return Ok(player);
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
                _playerRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [Authorize(Policy = "ApiUser")]
        [Produces("application/json")]
        [HttpGet("getPlayers/{teamId}")]
        public IActionResult GetPlayers(int teamId)
        {
            try
            {
                return Ok(_playerRepository.GetPlayers(teamId));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}