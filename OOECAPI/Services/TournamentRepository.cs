using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OOECAPI.Data;
using OOECAPI.Interfaces;
using OOECAPI.Models;
using OOECAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OOECAPI.Services
{
    public class TournamentRepository:ITournamentRepository
    {
        private readonly ClaimsPrincipal _caller;
        private readonly Context _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public TournamentRepository(Context context, UserManager<AppUser> userManager, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _caller = httpContextAccessor.HttpContext.User;
            _context = context;
            _userManager = userManager;
            _mapper = mapper;

        }

        public IEnumerable<Tournament> GetAll
        {
            get { return _context.Tournaments; }
        }

        public async Task<List<Tournament>> GetCreatedByUser()
        {
            var userId = _caller.Claims.Single(c => c.Type == "id");
            return await _context.Tournaments.Where(g => g.IdentityId == userId.Value).ToListAsync();          
        }

        public void Create(Tournament tournament)
        {
            var userId = _caller.Claims.Single(c => c.Type == "id");
            tournament.IdentityId = userId.Value;
            if (tournament.Id == 0)
               _context.Tournaments.Add(tournament);
            else
            {
                Tournament dbEntry = _context.Tournaments.Find(tournament.Id);
                if (dbEntry != null)
                {
                    dbEntry.IdentityId = userId.Value;
                    dbEntry.TournamentName = tournament.TournamentName;
                    dbEntry.Place = tournament.Place;
                    dbEntry.PrizePool = tournament.PrizePool;
                    dbEntry.Type = tournament.Type;
                    dbEntry.DateStart = tournament.DateStart;
                    dbEntry.DateEnd = tournament.DateEnd;
                    dbEntry.Description = tournament.Description;
                    dbEntry.Game = tournament.Game;
                }
            }
             _context.SaveChanges();
        }

        public void Edit(Tournament tournament)
        {
            _context.Entry(tournament).State =
                Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public Tournament Delete(int? tournamentId)
        {
            Tournament dbEntry = _context.Tournaments.Find(tournamentId);
            if (dbEntry != null)
            {
                _context.Tournaments.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }

        public Tournament GetTournamentById(int? tournamentId)
        {
            Tournament tournament = _context.Tournaments.Find(tournamentId);
            if (tournament == null)
            {
                return null;
            }
            return tournament;
        }
    }
}
