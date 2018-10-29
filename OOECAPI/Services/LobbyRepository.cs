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
        public Lobby Delete(int? lobbyId)
        {
            Lobby dbEntry = _context.Lobbies.Find(lobbyId);
            if (dbEntry != null)
            {
                _context.Lobbies.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
