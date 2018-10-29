using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public string TournamentName { get; set; }
        public string Place { get; set; }
        public string Type { get; set; }
        public string PrizePool { get; set; }
        public ICollection<Lobby> Lobbies { get; set; }
        public Tournament()
        {
            Lobbies = new List<Lobby>();
        }
    }
}
