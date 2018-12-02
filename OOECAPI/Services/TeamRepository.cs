using OOECAPI.Data;
using OOECAPI.Interfaces;
using OOECAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.Services
{
    public class TeamRepository:ITeamRepository
    {
        private readonly Context _context;
        public TeamRepository(Context context)
        {
            _context = context;
          
        }
     
        public IEnumerable<Team> GetAll
        {
            //get all teams in the system
            get { return _context.Teams; }
        }
        public void Create(Team team)
        {
            //checking id
             if (team.Id == 0)
                 _context.Teams.Add(team);
             else
             {
                 //find the id of the each team
                 Team dbEntry = _context.Teams.Find(team.Id);
                 if (dbEntry != null)
                 {
                    // adding new team
                     dbEntry.Name = team.Name;
                     dbEntry.NumberOfPlayers = team.NumberOfPlayers;          
                 }
             }
             _context.SaveChanges();
            
        }
        public void Edit(Team team)
        {
            _context.Entry(team).State =
                Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
        public Team Delete(int? itemId)
        {
            Team dbEntry = _context.Teams.Find(itemId);
            if (dbEntry != null)
            {
                _context.Teams.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }
        public Team GetById(int? id)
        {
            Team team=_context.Teams.Find(id);
            if(team==null)
            {
                return null;
            }
            return team;
        }
    }
}
