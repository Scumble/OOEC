using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OOECAPI.Data;
using OOECAPI.Interfaces;
using OOECAPI.Models;
using OOECAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.Services
{
    public class LobbyRepository:ILobbyRepository
    {
        private readonly Context _context;
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        public LobbyRepository(Context context,ITeamRepository teamRepository,IMapper mapper)
        {
            _context = context;
            _teamRepository = teamRepository;
            _mapper = mapper;
        }
        public IEnumerable<Lobby> GetAll
        {
            get { return _context.Lobbies; }
        }

        public List<LobbyViewModel> GetLobbies(long? tournamentId)
        {
            var results =  (from p in _context.Lobbies
                           join ps in _context.Teams on p.Team_id_radiant equals ps.Id
                           join v in _context.Teams on p.Team_id_dire equals v.Id
                           where p.TournamentId==tournamentId
                           select new LobbyViewModel()
                           {
                               Id=p.Id,
                               ScoreWinner = p.ScoreWinner,
                               ScoreLoser = p.ScoreLoser,
                               Winner = p.Winner,
                               DateStart=p.DateStart,
                               TournamentId=p.TournamentId,
                               Radiant_team_name=ps.TeamName,
                               Dire_team_name=v.TeamName
                           }).ToList();
            return results;
     
        }

        public void Create(LobbyViewModel lobby)
        {
            var lobbies = new Lobby();
            var teamsRadiant = _context.Teams.Where(x => x.TeamName == lobby.Radiant_team_name).FirstOrDefault();
            var teamsDire = _context.Teams.Where(x => x.TeamName == lobby.Dire_team_name).FirstOrDefault();
            if (lobbies.Id == 0)
            {
                lobbies.ScoreWinner = lobby.ScoreWinner;
                lobbies.DateStart = lobby.DateStart;
                lobbies.Winner = lobby.Winner;
                lobbies.ScoreLoser = lobby.ScoreLoser;
                lobbies.TournamentId = lobby.TournamentId;
                lobbies.Team_id_radiant = teamsRadiant.Id;
                lobbies.Team_id_dire = teamsDire.Id;
                _context.Lobbies.Add(lobbies);
            }
            else
            {
                Lobby dbEntry = _context.Lobbies.Find(lobbies.Id);
                if (dbEntry != null)
                {
                    dbEntry.ScoreWinner = lobby.ScoreWinner;
                    dbEntry.DateStart = lobby.DateStart;
                    dbEntry.Winner = lobby.Winner;
                    dbEntry.ScoreLoser = lobby.ScoreLoser;
                    dbEntry.TournamentId = lobby.TournamentId;
                    dbEntry.Team_id_radiant = teamsRadiant.Id;
                    dbEntry.Team_id_dire = teamsDire.Id;
                    _context.Lobbies.Add(dbEntry);
                }
            }

            _context.SaveChanges();
        
        }
        public void Edit(LobbyViewModel lobby)
        {
            try
            {
                var lobbies = _context.Lobbies.Where(c => c.Id == lobby.Id).FirstOrDefault();
                var teamsRadiant = _context.Teams.Where(x => x.TeamName == lobby.Radiant_team_name).FirstOrDefault();
                var teamsDire = _context.Teams.Where(x => x.TeamName == lobby.Dire_team_name).FirstOrDefault();

                lobbies.Id = lobby.Id;
                lobbies.ScoreWinner = lobby.ScoreWinner;
                lobbies.DateStart = lobby.DateStart;
                lobbies.Winner = lobby.Winner;
                lobbies.ScoreLoser = lobby.ScoreLoser;
                lobbies.TournamentId = lobby.TournamentId;
                lobbies.Team_id_radiant = teamsRadiant.Id;
                lobbies.Team_id_dire = teamsDire.Id;

                _context.SaveChanges();
            }
            catch(Exception ex) {  }
        }
        public Lobby Delete(int? lobbyId)
        {
            Lobby dbEntry = _context.Lobbies.Find(lobbyId);
            if (dbEntry != null)
            {
                _context.Lobbies.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }
        public List<LobbyViewModel> GetLobbyById(int? lobbyid)
        {
            var results = (from p in _context.Lobbies
                           join ps in _context.Teams on p.Team_id_radiant equals ps.Id
                           join v in _context.Teams on p.Team_id_dire equals v.Id
                           where p.Id == lobbyid
                           select new LobbyViewModel()
                           {
                               Id = p.Id,
                               ScoreWinner = p.ScoreWinner,
                               ScoreLoser = p.ScoreLoser,
                               Winner = p.Winner,
                               DateStart = p.DateStart,
                               TournamentId = p.TournamentId,
                               Radiant_team_name = ps.TeamName,
                               Dire_team_name = v.TeamName,
                               Tournament = p.Tournament,
                               DireTeam = p.DireTeam,
                               RadiantTeam=p.RadiantTeam
                           }).ToList();
            return results;
        }

    }
}
