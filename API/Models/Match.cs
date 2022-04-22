using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Match
    {
        public int MatchId { get; set; }
        public int NumberRounds { get; set; }
        [StringLength(50)]
        public string HomeTeam { get; set; }
        [StringLength(50)]
        public string GuestTeam { get; set; }
        public int HomeGoals { get; set; }
        public int GuestGoals { get; set; }
    }
}
