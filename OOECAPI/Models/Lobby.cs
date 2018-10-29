using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.Models
{
    public class Lobby
    {
        public int Id { get; set; }
        public string DateStart { get; set; }
        public int ScoreWinner { get; set; }
        public int ScoreLoser { get; set; }
        public string Winner { get; set; }
        public int? TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public ICollection<GamePlayerInfo> gamePlayerInfo { get; set; }
        public Lobby()
        {
            gamePlayerInfo = new List<GamePlayerInfo>();
        }
    }
}
