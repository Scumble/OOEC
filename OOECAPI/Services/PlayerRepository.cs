using OOECAPI.Data;
using OOECAPI.Interfaces;
using OOECAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.Services
{
    public class PlayerRepository:IPlayerRepository
    {
        private readonly Context _context;
        public PlayerRepository(Context context)
        {
            _context = context;
        }
        public IEnumerable<Player> GetAll
        {
            get { return _context.Players; }
        }
        public void Create(Player player)
        {
            if (player.Id == 0)
                _context.Players.Add(player);
            else
            {
                Player dbEntry = _context.Players.Find(player.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = player.Name;
                    dbEntry.Age = player.Age;
                    dbEntry.Position = player.Position;
                    dbEntry.TeamId = player.TeamId;
                }
            }
            _context.SaveChanges();

        }
        public List<Player> GetPlayers(long? teamId)
        {
            return _context.Players.Where(x => x.TeamId == teamId).ToList();
        }
        public void Edit(Player player)
        {
            _context.Entry(player).State =
                Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
        public Player Delete(int? playerId)
        {
            Player dbEntry = _context.Players.Find(playerId);
            if (dbEntry != null)
            {
                _context.Players.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }
        public Player GetById(int? playerid)
        {
            Player player = _context.Players.Find(playerid);
            if (player == null)
            {
                return null;
            }
            return player;
        }

    }
}
