using OOECAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.Interfaces
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetAll { get; }
        void Create(Player player);
        void Edit(Player player);
        Player Delete(int? playerId);
    }
}
