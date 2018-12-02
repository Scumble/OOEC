using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OOECAPI.Data;
using OOECAPI.Models;

namespace OOECAPI.Controllers
{
    [Route("api/[controller]")]
    public class ManageController : Controller
    {
        private readonly Context _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public ManageController(UserManager<AppUser> userManager, IMapper mapper, Context appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }
        [Authorize(Policy = "Admin")]
        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(user);
        }
        [Authorize(Policy = "Admin")]
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = await _userManager.Users.ToListAsync();
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(user);
        }
      //  [Authorize(Policy = "Admin")]
        [HttpPost("lockuser/{id}")]
        public async Task<IActionResult> LockedOut(string id)
        {
            var model = await _userManager.FindByIdAsync(id);
            if (model == null)
            {
                return BadRequest();
            }
            model.LockoutEnabled = true;
            await _userManager.SetLockoutEnabledAsync(model, true);
            await _userManager.SetLockoutEndDateAsync(model, DateTime.Today.AddYears(10));
            await _userManager.UpdateAsync(model);

            return new OkObjectResult("Account Lockedout");
        }
        [HttpPost("unlockuser/{id}")]
        public async Task<IActionResult> Unlock(string id)
        {

            var model = await _userManager.FindByIdAsync(id);
            if (model == null)
            {
                return BadRequest();
            }
            await _userManager.SetLockoutEndDateAsync(model, null);
            await _userManager.UpdateAsync(model);

            return new OkObjectResult("Account unlocked");
        }
    }
}