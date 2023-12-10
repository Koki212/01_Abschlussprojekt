using Microsoft.AspNetCore.Mvc;
using OnlineSpielplan.Models;
using OnlineSpielplan.Services;

namespace OnlineSpielplan.Controllers
{
    //[EnableCors(origins: "http://localhost:5173/competition", headers: "*", methods: "*")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly MatchService _matchService;

        public MatchController(MatchService matchService)
        {
            _matchService = matchService;
        }

        // get two teams by id and calculate points of the match between them and update the teams in the database and return the updated teams
        [HttpPost("CalculatePointsObject")]
        public async Task<List<Team>> CalculatePointsObject(string team1Id, string team2Id, int scoreTeam1, int scoreTeam2)
        {
            var teams = await _matchService.CalculatePoints(team1Id, team2Id, scoreTeam1, scoreTeam2);
            return teams;
        }    
    }
}
