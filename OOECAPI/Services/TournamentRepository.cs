using OOECAPI.Data;
using OOECAPI.Interfaces;
using OOECAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.Services
{
    public class TournamentRepository:ITournamentRepository
    {
        private readonly Context _context;
        public TournamentRepository(Context context)
        {
            _context = context;

        }

        public IEnumerable<Tournament> GetAll
        {
            get { return _context.Tournaments; }
        }
        public void Create(Tournament tournament)
        {
            if (tournament.Id == 0)
                _context.Tournaments.Add(tournament);
            else
            {
                Tournament dbEntry = _context.Tournaments.Find(tournament.Id);
                if (dbEntry != null)
                {
                    dbEntry.TournamentName = tournament.TournamentName;
                    dbEntry.Place = tournament.Place;
                    dbEntry.PrizePool = tournament.PrizePool;
                    dbEntry.Type = tournament.Type;

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
        public Tournament GetById(int? tournamentId)
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
