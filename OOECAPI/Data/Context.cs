using Microsoft.EntityFrameworkCore;
using OOECAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.Data
{
    public class Context:DbContext
    {
      
        public Context(DbContextOptions<Context> options):base(options)
        {

        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Lobby> Lobbies { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<GamePlayerInfo> gamePlayerInfo { get; set; }

    }
}
