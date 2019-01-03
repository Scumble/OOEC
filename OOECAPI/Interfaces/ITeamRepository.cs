using OOECAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.Interfaces
{
    public interface ITeamRepository
    {
        Team GetById(int? teamId);
        IEnumerable<Team> GetAll { get; }
        void Create(Team team);
        void Edit(Team team);
        Team Delete(int? teamId);
        List<Team> GetTeams(long? tournamentId);
    }
}
