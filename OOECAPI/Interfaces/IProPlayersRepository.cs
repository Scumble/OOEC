using OOECAPI.ViewModels.Pro_Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.Interfaces
{
    public interface IProPlayersRepository
    {
        List<ProPlayersViewModel> GetPlayerById(long id);
        List<ProPlayerWLViewModel> GetPlayerWL(long id);
        List<ProPlayerMatchesViewModel> GetPlayerMatches(long id);
        List<ProPlayerHeroesViewModel> GetPlayerHeroes(long id);
        List<ProPlayerTotalsViewModel> GetPlayerTotals(long id);
    }
}
