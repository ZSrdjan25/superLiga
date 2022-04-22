using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private ApplicationDbContext applicationDbContext;
        public MatchController(ApplicationDbContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }

        //GET: api/Match
        [HttpGet]
        public async Task<List<Match>> GET()
        {
            return await applicationDbContext.Match.ToListAsync();
        }

        //POST: api/Match
        [HttpPost]
        public async Task<ActionResult<Match>> POST(Match match)
        {
            await applicationDbContext.Match.AddAsync(match);
            await applicationDbContext.SaveChangesAsync();
            return match;
        }

        //PUT: api/Match
        [HttpPut]
        public async Task<ActionResult<Match>> PUT(Match match)
        {
            if(match.MatchId != 0)
            {
                Match match1 = await applicationDbContext.Match.SingleOrDefaultAsync(x => x.MatchId == match.MatchId);
                match1.NumberRounds = match.NumberRounds;
                match1.HomeTeam = match.HomeTeam;
                match1.GuestTeam = match.GuestTeam;
                match1.HomeGoals = match.HomeGoals;
                match1.GuestGoals = match.GuestGoals;

                await applicationDbContext.SaveChangesAsync();
                return match1;
            }
            return new Match();
        }

        //DELETE: api/Match/{id}
        [HttpDelete("{id}")]
        public async Task DELETE(int id)
        {
            Match match = await applicationDbContext.Match.SingleOrDefaultAsync(x => x.MatchId == id);
            applicationDbContext.Match.Remove(match);
            await applicationDbContext.SaveChangesAsync();
        }
    }
}
