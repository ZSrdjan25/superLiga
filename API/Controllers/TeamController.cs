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

    }
}
