using OnlineSpielplan.Models;

namespace OnlineSpielplan.Services
{
    public class MatchService
    {
        // use the team service to update the teams in the database
        private readonly TeamService _teamService;

        public MatchService(TeamService teamService)
        {
            _teamService = teamService;
        }


        // Task to calculate the points of a match between two teams which are passed as objects from the frontend and their scores which are passed as integers from the frontend and return the updated teams
        public async Task<List<Team>> CalculatePoints(string team1Id, string team2Id, int scoreTeam1, int scoreTeam2)
        {
            // get the teams by their ids
            Team team1 = await _teamService.GetTeamByIdAsync(team1Id);
            Team team2 = await _teamService.GetTeamByIdAsync(team2Id);

            // if team1 wins
            if (scoreTeam1 > scoreTeam2)
            {
                // update teams using the team service and the methods from the team service
                await _teamService.UpdateGamesPlayedAsync(team1.TeamId, team1.GamesPlayed += 1);
                await _teamService.UpdateGamesWonAsync(team1.TeamId, team1.GamesWon += 1);
                await _teamService.UpdateGoalsScoredAsync(team1.TeamId, team1.GoalsScored += scoreTeam1);
                await _teamService.UpdateGoalsConcededAsync(team1.TeamId, team1.GoalsConceded += scoreTeam2);
                await _teamService.UpdatePointsAsync(team1.TeamId, team1.Points += 3);

                await _teamService.UpdateGamesPlayedAsync(team2.TeamId, team2.GamesPlayed += 1);
                await _teamService.UpdateGamesLostAsync(team2.TeamId, team2.GamesLost += 1);
                await _teamService.UpdateGoalsScoredAsync(team2.TeamId, team2.GoalsScored += scoreTeam2);
                await _teamService.UpdateGoalsConcededAsync(team2.TeamId, team2.GoalsConceded += scoreTeam1);
            }
            // if team2 wins
            else if (scoreTeam1 < scoreTeam2)
            {
                // update teams using the team service and the methods from the team service
                await _teamService.UpdateGamesPlayedAsync(team2.TeamId, team2.GamesPlayed += 1);
                await _teamService.UpdateGamesWonAsync(team2.TeamId, team2.GamesWon += 1);
                await _teamService.UpdateGoalsScoredAsync(team2.TeamId, team2.GoalsScored += scoreTeam2);
                await _teamService.UpdateGoalsConcededAsync(team2.TeamId, team2.GoalsConceded += scoreTeam1);
                await _teamService.UpdatePointsAsync(team2.TeamId, team2.Points += 3);

                await _teamService.UpdateGamesPlayedAsync(team1.TeamId, team1.GamesPlayed += 1);
                await _teamService.UpdateGamesLostAsync(team1.TeamId, team1.GamesLost += 1);
                await _teamService.UpdateGoalsScoredAsync(team1.TeamId, team1.GoalsScored += scoreTeam1);
                await _teamService.UpdateGoalsConcededAsync(team1.TeamId, team1.GoalsConceded += scoreTeam2);

            }
            // if draw
            else
            {
                // update teams using the team service and the methods from the team service
                await _teamService.UpdateGamesPlayedAsync(team1.TeamId, team1.GamesPlayed += 1);
                await _teamService.UpdateGamesDrawAsync(team1.TeamId, team1.GamesDraw += 1);
                await _teamService.UpdateGoalsScoredAsync(team1.TeamId, team1.GoalsScored += scoreTeam1);
                await _teamService.UpdateGoalsConcededAsync(team1.TeamId, team1.GoalsConceded += scoreTeam2);
                await _teamService.UpdatePointsAsync(team1.TeamId, team1.Points += 1);

                await _teamService.UpdateGamesPlayedAsync(team2.TeamId, team2.GamesPlayed += 1);
                await _teamService.UpdateGamesDrawAsync(team2.TeamId, team2.GamesDraw += 1);
                await _teamService.UpdateGoalsScoredAsync(team2.TeamId, team2.GoalsScored += scoreTeam2);
                await _teamService.UpdateGoalsConcededAsync(team2.TeamId, team2.GoalsConceded += scoreTeam1);
                await _teamService.UpdatePointsAsync(team2.TeamId, team2.Points += 1);

            }
            // return the updated teams
            return new List<Team> { team1, team2 };
        }
    }
}
