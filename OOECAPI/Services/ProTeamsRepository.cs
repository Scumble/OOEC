using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OOECAPI.Interfaces;
using OOECAPI.ViewModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.Services
{
    public class ProTeamsRepository:IProTeamsRepository
    {
        public List<ProTeamsViewModel> GetTeams()
        {
            var client = new RestClient($"https://api.opendota.com/api/teams");
            var request = new RestRequest(Method.GET);
            IRestResponse<List<ProTeamsViewModel>> response = client.Execute<List<ProTeamsViewModel>>(request);
            return response.Data;
        }
        public List<ProTeamsViewModel> GetTeamById(long id)
        {
            var client = new RestClient($"https://api.opendota.com/api/teams/{id}");
            var request = new RestRequest(Method.GET);
            IRestResponse<List<ProTeamsViewModel>> response = client.Execute<List<ProTeamsViewModel>>(request);
            return response.Data;
        }
        public List<ProTeamMatchesViewModel> GetTeamMatches(long id)
        {
            var client = new RestClient($"https://api.opendota.com/api/teams/{id}/matches");
            var request = new RestRequest(Method.GET);
            IRestResponse<List<ProTeamMatchesViewModel>> response = client.Execute<List<ProTeamMatchesViewModel>>(request);
            return response.Data;
        }
        public List<ProTeamPlayersViewModel> GetTeamPlayers(long id)
        {
            var client = new RestClient($"https://api.opendota.com/api/teams/{id}/players");
            var request = new RestRequest(Method.GET);
            IRestResponse<List<ProTeamPlayersViewModel>> response = client.Execute<List<ProTeamPlayersViewModel>>(request);
            return response.Data;
        }
    }
}
