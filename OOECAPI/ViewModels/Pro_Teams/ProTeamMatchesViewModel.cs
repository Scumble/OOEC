using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.ViewModels
{
    public class ProTeamMatchesViewModel
    {
        public long Match_id { get; set; }
        public bool Radiant_win { get; set; }
        public bool Radiant { get; set; }
       // public long Radiant_team_id { get; set; } 
       // public string Radiant_name { get; set; }
       // public long Dire_team_id { get; set; }
    //    public string Dire_name { get; set; }
        public long Duration { get; set; }
        public long Start_time { get; set; }
        public long Leagueid { get; set; }
        public string League_name { get; set; }
        public long Cluster { get; set; }
        public int Opposing_team_id { get; set; }
        public string Opposing_team_name { get; set; }
        public string Opposing_team_logo { get; set; }
        // public long Series_id { get; set; }
         //public long Series_type { get; set; }
         //public long Radiant_score { get; set; }
         //public long Dire_score { get; set; }
         

    }
}
