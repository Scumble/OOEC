using OOECAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.Interfaces
{
    public interface ILobbyRepository
    {
        Lobby GetById(int? lobbyId);
        IEnumerable<Lobby> GetAll { get; }
        void Create(Lobby lobbies);
        void Edit(Lobby lobbies);
        Lobby Delete(int? lobbyId);
    }
}
