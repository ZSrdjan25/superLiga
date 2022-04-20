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
    public class TeamController : ControllerBase
    {
        private ApplicationDbContext applicationDbContext;

        public TeamController(ApplicationDbContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }

        //GET: api/Team
        [HttpGet]
        public async Task<List<Team>> GET()
        {
            return await applicationDbContext.Teams.ToListAsync();
        }


        //POST: api/Team
        [HttpPost]
        public async Task<ActionResult<Team>> POST(Team team)
        {
            await applicationDbContext.Teams.AddAsync(team);
            await applicationDbContext.SaveChangesAsync();
            return team;
        }

        //PUT: api/Team
        [HttpPut]
        public async Task<ActionResult<Team>> PUT(Team team)
        {
            if(team.TeamId != 0)
            {
                Team team1 = await applicationDbContext.Teams.SingleOrDefaultAsync(x => x.TeamId == team.TeamId);
                team1.Name = team.Name;
                team1.Wins = team.Wins;
                team1.Draws = team.Draws;
                team1.Losses = team.Losses;
                team1.GoalsFor = team.GoalsFor;
                team1.GoalsAgainst = team.GoalsAgainst;
                team1.Points = team.Points;

                await applicationDbContext.SaveChangesAsync();
                return team1;
            }
            return new Team();
        }

        //DELETE: api/Team
        [HttpDelete]
        [Route("{id}")]
        public async Task DELETE (int id)
        {
            Team team = await applicationDbContext.Teams.SingleOrDefaultAsync(x => x.TeamId == id);
            applicationDbContext.Teams.Remove(team);
            await applicationDbContext.SaveChangesAsync();
        }
    }
}
