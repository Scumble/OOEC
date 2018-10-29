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
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        [Produces("application/json")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_playerRepository.GetAll);
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("create")]
        public IActionResult Create([FromBody] Player player)
        {
            try
            {
                _playerRepository.Create(player);
                return Ok(player);

            }
            catch
            {
                return BadRequest();
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("update")]
        public IActionResult Edit([FromBody] Player player)
        {
            try
            {
                _playerRepository.Edit(player);
                return Ok(player);
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
                _playerRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}