using OOECAPI.Interfaces;
using OOECAPI.ViewModels.Pro_Players;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.Services
{
    public class ProPlayersRepository:IProPlayersRepository
    {
        public List<ProPlayersViewModel> GetPlayerById(long id)
        {
            //get the address of the Odota API to retrieve pro players stats
            var client = new RestClient($"https://api.opendota.com/api/players/{id}");
            var request = new RestRequest(Method.GET);
            IRestResponse<List<ProPlayersViewModel>> response = client.Execute<List<ProPlayersViewModel>>(request);
            return response.Data;
        }
        public List<ProPlayerWLViewModel> GetPlayerWL(long id)
        {
            var client = new RestClient($"https://api.opendota.com/api/players/{id}/wl");
            var request = new RestRequest(Method.GET);
            IRestResponse<List<ProPlayerWLViewModel>> response = client.Execute<List<ProPlayerWLViewModel>>(request);
            return response.Data;
        }
        public List<ProPlayerMatchesViewModel> GetPlayerMatches(long id)
        {
            var client = new RestClient($"https://api.opendota.com/api/players/{id}/recentMatches");
            var request = new RestRequest(Method.GET);
            IRestResponse<List<ProPlayerMatchesViewModel>> response = client.Execute<List<ProPlayerMatchesViewModel>>(request);
            return response.Data;
        }
        public List<ProPlayerHeroesViewModel> GetPlayerHeroes(long id)
        {
            var client = new RestClient($"https://api.opendota.com/api/players/{id}/heroes");
            var request = new RestRequest(Method.GET);
            IRestResponse<List<ProPlayerHeroesViewModel>> response = client.Execute<List<ProPlayerHeroesViewModel>>(request);
            return response.Data;
        }
        public List<ProPlayerTotalsViewModel> GetPlayerTotals(long id)
        {
            var client = new RestClient($"https://api.opendota.com/api/players/{id}/totals");
            var request = new RestRequest(Method.GET);
            IRestResponse<List<ProPlayerTotalsViewModel>> response = client.Execute<List<ProPlayerTotalsViewModel>>(request);
            return response.Data;
        }
    }
}
