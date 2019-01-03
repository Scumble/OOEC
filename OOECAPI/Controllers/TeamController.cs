using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OOECAPI.Interfaces;
using OOECAPI.Models;

namespace OOECAPI.Controllers
{
    
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        private readonly ITeamRepository _teamRepository;

        public TeamController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }
        [Authorize(Policy = "ApiUser")]
        [Produces("application/json")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_teamRepository.GetAll);
        }
        [Authorize(Policy = "ApiUser")]
        [Produces("application/json")]
        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_teamRepository.GetById(id));
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
        public IActionResult Create([FromBody] Team team)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _teamRepository.Create(team);
                    return Ok(team);
                
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
        public IActionResult Edit([FromBody] Team team)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _teamRepository.Edit(team);
                return Ok(team);
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
                _teamRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [Authorize(Policy = "ApiUser")]
        [HttpGet("getTeams/{id}")]
        public IActionResult GetTeams(int id)
        {
            try
            {
                
                return Ok(_teamRepository.GetTeams(id));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}