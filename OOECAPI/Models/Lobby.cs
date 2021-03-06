﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OOECAPI.Models
{
    public class Lobby
    {
        public int Id { get; set; }
        public int ScoreWinner { get; set; }
        public int ScoreLoser { get; set; }
        public string Winner { get; set; }
        public string DateStart { get; set; }
        [ForeignKey("Tournament")]
        public int? TournamentId { get; set; }
        public virtual Tournament Tournament { get; set; }
        [ForeignKey("RadiantTeam")]
        public int? Team_id_radiant { get; set; }
        [ForeignKey("DireTeam")]
        public int? Team_id_dire { get; set; }
        public virtual Team RadiantTeam { get; set; }
        public virtual Team DireTeam { get; set; }
    }
}
