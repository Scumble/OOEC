using OOECAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.ViewModels
{
    public class LobbyViewModel
    {
        public int Id { get; set; }
        public int ScoreWinner { get; set; }
        public int ScoreLoser { get; set; }
        public string Winner { get; set; }
        public string DateStart { get; set; }
        public int? TournamentId { get; set; }
        public virtual Tournament Tournament { get; set; }
        public string Radiant_team_name { get; set; }
        public string Dire_team_name { get; set; }
        public virtual Team RadiantTeam { get; set; }
        public virtual Team DireTeam { get; set; }
    }
}
