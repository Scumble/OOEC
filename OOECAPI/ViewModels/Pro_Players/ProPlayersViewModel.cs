using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.ViewModels.Pro_Players
{
    public class ProPlayersViewModel
    {
        public string Tracked_until { get; set; }
        public string Solo_competitive_rank { get; set; }
        public string Competitive_rank { get; set; }
        public long Rank_tier { get; set; }
        public long Leaderboard_rank { get; set; }
        public List<MmrEstimate> Mmr_estimate { get; set; }
        public List<Profile> Profile { get; set; }
    }
    public class Profile
    {
        public long Account_id { get; set; }
        public string Personaname { get; set; }
        public string Name { get; set; }
        public long Cheese { get; set; }
        public string SteamId { get; set; }
        public string Avatar { get; set; }
        public string AvatarMedium { get; set; }
        public string AvatarFull { get; set; }
        public string ProfileUrl { get; set; }
        public string Last_Login { get; set; }
        public string Loccountrycode { get; set; }
        public bool Is_contributor { get; set; }
    }
    public class MmrEstimate
    {
        public long Estimate { get; set; }
        public long stdDev { get; set; }
        public long N { get; set; }
    }
}
