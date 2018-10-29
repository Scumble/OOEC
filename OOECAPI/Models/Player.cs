using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public int? TeamId { get; set; }
        public Team Team { get; set; }
        public ICollection<GamePlayerInfo> gamePlayerInfo { get; set; }
        public Player()
        {
            gamePlayerInfo = new List<GamePlayerInfo>();
        }
    }
}
