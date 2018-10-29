using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.Models
{
    public class GamePlayerInfo
    {
        public int Id { get; set; }
        public int? LobbyId { get; set; }
        public Lobby Lobby;
        public int? PlayerId { get; set; }
        public Player Player;
    }
}
