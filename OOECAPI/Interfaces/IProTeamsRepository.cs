using OOECAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.Interfaces
{
    public interface IProTeamsRepository
    {
        List<ProTeamsViewModel> GetTeams();
        List<ProTeamsViewModel> GetTeamById(long id);
        List<ProTeamMatchesViewModel> GetTeamMatches(long id);
        List<ProTeamPlayersViewModel> GetTeamPlayers(long id);
    }
}
