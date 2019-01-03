using OOECAPI.Models;
using OOECAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.Interfaces
{
    public interface ITournamentRepository
    {
        Tournament GetTournamentById(int? tournamentId);
        IEnumerable<Tournament> GetAll { get; }
        void Create(Tournament tournament);
        void Edit(Tournament tournament);
        Tournament Delete(int? tournamentId);
        Task<List<Tournament>> GetCreatedByUser();

    }
}
