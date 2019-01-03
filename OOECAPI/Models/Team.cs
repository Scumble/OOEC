using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string Tag { get; set; }
        public int NumberOfPlayers { get; set; }
        public ICollection<Player> Players { get; set; }
        [InverseProperty("RadiantTeam")]
        public virtual ICollection<Lobby> RadiantLobbies { get; set; }
        [InverseProperty("DireTeam")]
        public virtual ICollection<Lobby> DireLobbies { get; set; }
        public Team()
        {
            Players = new List<Player>();
            RadiantLobbies = new List<Lobby>();
            RadiantLobbies = new List<Lobby>();
        }
    }
}
