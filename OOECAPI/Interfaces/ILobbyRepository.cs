using OOECAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.Interfaces
{
    public interface ILobbyRepository
    {
        Lobby GetLobbyById(long? lobbyId);
        IEnumerable<Lobby> GetAll { get; }
        void Create(Lobby lobbies);
        void Edit(Lobby lobbies);
        Lobby Delete(long? lobbyId);
        Task<List<Lobby>> GetCreatedByTournament(long? tournamentId);
    }
}
