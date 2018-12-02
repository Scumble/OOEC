using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.ViewModels.Pro_Players
{
    public class ProPlayerHeroesViewModel
    {
        public string hero_id { get; set; }
        public long last_played { get; set; }
        public long games { get; set; }
        public int win { get; set; }
        public int with_games { get; set; }
        public int with_win { get; set; }
        public int against_games { get; set; }
        public int against_win { get; set; }
    }
}
