using OOECAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.Interfaces
{
    public interface ITournamentRepository
    {
        IEnumerable<Tournament> GetAll { get; }
        void Create(Tournament tournament);
        void Edit(Tournament tournament);
        Tournament Delete(int? tournamentId);
    }
}
