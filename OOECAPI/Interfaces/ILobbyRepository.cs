using OOECAPI.Models;
using OOECAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.Interfaces
{
    public interface ILobbyRepository
    {
        List<LobbyViewModel> GetLobbyById(int? lobbyId);
        IEnumerable<Lobby> GetAll { get; }
        void Create(LobbyViewModel lobbies);
        void Edit(LobbyViewModel lobbies);
        Lobby Delete(int? lobbyId);
        List<LobbyViewModel> GetLobbies(long? tournamentId);
    }
}
