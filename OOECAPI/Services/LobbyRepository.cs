using Microsoft.EntityFrameworkCore;
using OOECAPI.Data;
using OOECAPI.Interfaces;
using OOECAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.Services
{
    public class LobbyRepository:ILobbyRepository
    {
        private readonly Context _context;
        public LobbyRepository(Context context)
        {
            _context = context;
        }
        public IEnumerable<Lobby> GetAll
        {
            get { return _context.Lobbies; }
        }
        public async Task<List<Lobby>> GetCreatedByTournament(long? tournamentId)
        {
            /* var lobbies = _context.Lobbies.Join(_context.Tournaments,
                 x => x.TournamentId,
                 y => y.Id,
                 (x, y) => new Lobby
                 {
                     Id=x.Id,
                     DateStart = x.DateStart,
                     ScoreWinner = x.ScoreWinner,
                     ScoreLoser = x.ScoreLoser,
                     Winner = x.Winner,
                     TournamentId = y.Id
                 });*/
        
            return await _context.Lobbies.Where(x => x.TournamentId == tournamentId).ToListAsync();
       
        }
        public void Create(Lobby lobby)
        {
            if (lobby.Id == 0)
                _context.Lobbies.Add(lobby);
            else
            {
                Lobby dbEntry = _context.Lobbies.Find(lobby.Id);
                if (dbEntry != null)
                {
                    dbEntry.DateStart = lobby.DateStart;
                    dbEntry.ScoreWinner = lobby.ScoreWinner;
                    dbEntry.TournamentId = lobby.TournamentId;
                    dbEntry.Winner = lobby.Winner;
                    dbEntry.ScoreLoser = lobby.ScoreLoser;
                }
            }
            _context.SaveChanges();

        }
        public void Edit(Lobby lobby)
        {
            _context.Entry(lobby).State =
                Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
        public Lobby Delete(long? lobbyId)
        {
            Lobby dbEntry = _context.Lobbies.Find(lobbyId);
            if (dbEntry != null)
            {
                _context.Lobbies.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }
        public Lobby GetLobbyById(long? lobbyid)
        {
            Lobby lobby = _context.Lobbies.Find(lobbyid);
            if (lobby == null)
            {
                return null;
            }
            return lobby ;
        }

    }
}
