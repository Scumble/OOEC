using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public string IdentityId { get; set; }
        public AppUser Identity { get; set; }
        public string TournamentName { get; set; }
        public string Place { get; set; }
        public string Type { get; set; }
        public long PrizePool { get; set; }
        public ICollection<Lobby> Lobbies { get; set; }
        public Tournament()
        {
            Lobbies = new List<Lobby>();
        }

        public Tournament(string place, long prizePool, string tournamentName, string type)
        {
            Place = place;
            PrizePool = prizePool;
            TournamentName = tournamentName;
            Type = type;
        }
    }
}
