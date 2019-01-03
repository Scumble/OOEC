using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string DateStart { get; set; }
        public string DateEnd { get; set; }
        public string Description { get; set; }
        public string Game { get; set; }
        [InverseProperty("Tournament")]
        public virtual ICollection<Lobby> Lobbies { get; set; }
        public Tournament()
        {
            Lobbies = new List<Lobby>();
        }
    }
}
