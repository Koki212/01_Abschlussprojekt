//using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;
using OnlineSpielplan.Models;
using OnlineSpielplan.Services;

namespace OnlineSpielplan.Controllers
{
    //[EnableCors(origins: "http://localhost:5173/:competitionId/addteams", headers: "*", methods: "*")]
    [ApiController]
    [Route("api/team")]
    public class TeamController : ControllerBase
    {
        private readonly TeamService _teamService;

        public TeamController(TeamService teamService)
        {
            _teamService = teamService;
        }

        // CREATE-TEAM
        [HttpPost("CreateTeam")]
        public async Task<IActionResult> Post(string TeamName, string CompetitionId)
        {
            var team = await _teamService.CreateTeam(TeamName, CompetitionId);
            return Ok(team);
        }

        // CREATE-TEAM with an Object passed from the frontend
        [HttpPost("CreateTeamObject")]
        public async Task<IActionResult> Post(Team team, string CompetitionId)
        {
            var newTeam = await _teamService.CreateTeamObject(team);
            return Ok(newTeam);
        }

        // GET-ALL-TEAMS
        [HttpGet("GetAllTeams")]
        public async Task<IActionResult> GetAllTeams()
        {
            var teams = await _teamService.GetAllTeamsAsync();
            return Ok(teams);
        }

        // GET-ALL-TEAMS-BY-COMPETITION-ID
        [HttpGet("GetAllTeamsByCompetitionId")]
        public async Task<IActionResult> GetAllTeamsByCompetitionId(string id)
        {
            var teams = await _teamService.GetAllTeamsByCompetitionIdAsync(id);
            return Ok(teams);
        }

        // GET-TEAM-BY-ID
        [HttpGet("GetById")]
        public async Task<IActionResult> GetTeamById(string id)
        {
            var team = await _teamService.GetTeamByIdAsync(id);

            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        // GET-TEAM-BY-NAME
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetTeamByName(string TeamName)
        {
            var team = await _teamService.GetTeamByNameAsync(TeamName);

            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        // GET-TWO-TEAMS-BY-ID
        [HttpGet("GetTwoTeamsById")]
        public async Task<IActionResult> GetTwoTeamsById(string team1Id, string team2Id)
        {
            var teams = await _teamService.GetTwoTeamsByIdAsync(team1Id, team2Id);
            if (teams == null)
            {
                return NotFound();
            }
            return Ok(teams);
        }

        // UPDATE-GAMESPLAYED
        [HttpPut("UpdateGamesPlayed")]
        public async Task<IActionResult> UpdateGamesPlayed(string TeamId)
        {
            var team = await _teamService.GetTeamByIdAsync(TeamId);
            if (team == null)
            {
                return NotFound();
            }
            await _teamService.UpdateGamesPlayedAsync(TeamId, team.GamesPlayed + 1);
            return Ok(team);
        }

        // UPDATE-GAMESWON
        [HttpPut("UpdateGamesWon")]
        public async Task<IActionResult> UpdateGamesWon(string TeamId)
        {
            var team = await _teamService.GetTeamByIdAsync(TeamId);
            if (team == null)
            {
                return NotFound();
            }
            await _teamService.UpdateGamesWonAsync(TeamId, team.GamesWon + 1);
            return Ok(team);
        }

        // UPDATE-GAMESDRAW
        [HttpPut("UpdateGamesDraw")]
        public async Task<IActionResult> UpdateGamesDraw(string TeamId)
        {
            var team = await _teamService.GetTeamByIdAsync(TeamId);
            if (team == null)
            {
                return NotFound();
            }
            await _teamService.UpdateGamesDrawAsync(TeamId, team.GamesDraw + 1);
            return Ok(team);
        }

        // UPDATE-GAMESLOST
        [HttpPut("UpdateGamesLost")]
        public async Task<IActionResult> UpdateGamesLost(string TeamId)
        {
            var team = await _teamService.GetTeamByIdAsync(TeamId);
            if (team == null)
            {
                return NotFound();
            }
            await _teamService.UpdateGamesLostAsync(TeamId, team.GamesLost + 1);
            return Ok(team);
        }

        // UPDATE-GOALSSCORED
        [HttpPut("UpdateGoalsScored")]
        public async Task<IActionResult> UpdateGoalsScored(string TeamId, int goals)
        {
            var team = await _teamService.GetTeamByIdAsync(TeamId);
            if (team == null)
            {
                return NotFound();
            }
            await _teamService.UpdateGoalsScoredAsync(TeamId, team.GoalsScored + goals);
            return Ok(team);
        }

        // UPDATE-GOALSCONCEDED
        [HttpPut("UpdateGoalsConceded")]
        public async Task<IActionResult> UpdateGoalsConceded(string TeamId, int goals)
        {
            var team = await _teamService.GetTeamByIdAsync(TeamId);
            if (team == null)
            {
                return NotFound();
            }
            await _teamService.UpdateGoalsConcededAsync(TeamId, team.GoalsConceded + goals);
            return Ok(team);
        }

        // UPDATE-POINTS
        [HttpPut("UpdatePoints")]
        public async Task<IActionResult> UpdatePoints(string TeamId, int points)
        {
            var team = await _teamService.GetTeamByIdAsync(TeamId);
            if (team == null)
            {
                return NotFound();
            }
            await _teamService.UpdatePointsAsync(TeamId, team.Points + points);
            return Ok(team);
        }

        // DELETE-TEAM
        [HttpDelete("DeleteTeam")]
        public async Task<IActionResult> DeleteTeam(string TeamId)
        {
            var team = await _teamService.GetTeamByIdAsync(TeamId);
            if (team == null)
            {
                return NotFound();
            }
            await _teamService.DeleteTeamAsync(TeamId);
            return Ok(team);
        }
    }
}
