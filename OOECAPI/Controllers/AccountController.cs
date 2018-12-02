using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OOECAPI.Data;
using OOECAPI.Helpers;
using OOECAPI.Models;
using OOECAPI.Services;
using OOECAPI.ViewModels;

namespace OOECAPI.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly Context _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AccountController(UserManager<AppUser> userManager, IMapper mapper, Context appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        // POST api/account
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
            //checking for model registration
            if (!ModelState.IsValid)
            {
                //exception throw if model is not valid
                return BadRequest(ModelState);
            }
        
            var userIdentity = _mapper.Map<AppUser>(model);
            //creating new user to the system
            var result = await _userManager.CreateAsync(userIdentity, model.Password);
            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));
            //adding new data to database
            await _appDbContext.Users.AddAsync(new User { IdentityId = userIdentity.Id, Location = model.Location });
            await _appDbContext.SaveChangesAsync();

            return new OkObjectResult("Account created");
        }
        [HttpPost("updateuser")]
        public async Task<IActionResult> Update([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<AppUser>(model);
            userIdentity.SecurityStamp = Guid.NewGuid().ToString();

            var result = await _userManager.UpdateAsync(userIdentity);
            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

             _appDbContext.Users.Update(new User { IdentityId = userIdentity.Id, Location = model.Location });
             await _appDbContext.SaveChangesAsync();

            return new OkObjectResult("Account updated");
        }
    }
}