using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.ViewModels
{
    public class ProTeamPlayersViewModel
    {
        public string Account_id { get; set; }
        public string Name { get; set; }
        public int Games_played { get; set; }
        public int Wins { get; set; }
        public bool Is_current_team_member { get; set; }
    }
}
