using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OnlineSpielplan.Models;

namespace OnlineSpielplan.Services
{
    public class TeamService
    {
        private readonly IMongoCollection<Team> _teamsCollection;

        public TeamService(
            IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
                databaseSettings.Value.ConnectionString);

            var database = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _teamsCollection = database.GetCollection<Team>(
                databaseSettings.Value.TeamCollectionName);
        }

        // Create new team with name
        public async Task<List<Team>> CreateTeam(string TeamName, string id)
        {
            var team = new Team(TeamName);
            team.CompetitionId = id;
            await _teamsCollection.InsertOneAsync(team);
            return await _teamsCollection.Find(team => team.TeamName == TeamName).ToListAsync();
        }

        // Create new team with object
        public async Task<Team> CreateTeamObject(Team team)
        {
            await _teamsCollection.InsertOneAsync(team);
            return team;
        }

        // Get all teams
        public async Task<List<Team>> GetAllTeamsAsync() =>
            await _teamsCollection.Find(team => true).ToListAsync();

        // Get all teams by competitionId
        public async Task<List<Team>> GetAllTeamsByCompetitionIdAsync(string id) =>
            await _teamsCollection.Find(team => team.CompetitionId == id).ToListAsync();

        //Get team by name
        public async Task<List<Team>> GetTeamByNameAsync(string Name) =>
            await _teamsCollection.Find(team => team.TeamName == Name).ToListAsync();

        // Get team by id
        public async Task<Team> GetTeamByIdAsync(string id) =>
            await _teamsCollection.Find(team => team.TeamId == id).FirstAsync();

        // Get two teams by id
        public async Task<List<Team>> GetTwoTeamsByIdAsync(string team1Id, string team2Id)
        {
            var team1 = await _teamsCollection.Find(team => team.TeamId == team1Id).FirstAsync();
            var team2 = await _teamsCollection.Find(team => team.TeamId == team2Id).FirstAsync();
            var teams = new List<Team>();
            teams.Add(team1);
            teams.Add(team2);
            return teams;
        }

        // Update GamesPlayed
        public async Task UpdateGamesPlayedAsync(string id, int gamesPlayed) =>
            await _teamsCollection.UpdateOneAsync(team => team.TeamId == id, Builders<Team>.Update.Set(team => team.GamesPlayed, gamesPlayed));

        // Update GamesWon
        public async Task UpdateGamesWonAsync(string id, int gamesWon) =>
            await _teamsCollection.UpdateOneAsync(team => team.TeamId == id, Builders<Team>.Update.Set(team => team.GamesWon, gamesWon));

        // Update GamesDraw
        public async Task UpdateGamesDrawAsync(string id, int gamesDraw) =>
            await _teamsCollection.UpdateOneAsync(team => team.TeamId == id, Builders<Team>.Update.Set(team => team.GamesDraw, gamesDraw));

        // Update GamesLost
        public async Task UpdateGamesLostAsync(string id, int gamesLost) =>
            await _teamsCollection.UpdateOneAsync(team => team.TeamId == id, Builders<Team>.Update.Set(team => team.GamesLost, gamesLost));

        // Update GoalsScored
        public async Task UpdateGoalsScoredAsync(string id, int goalsScored) =>
            await _teamsCollection.UpdateOneAsync(team => team.TeamId == id, Builders<Team>.Update.Set(team => team.GoalsScored, goalsScored));

        // Update GoalsConceded
        public async Task UpdateGoalsConcededAsync(string id, int goalsConceded) =>
            await _teamsCollection.UpdateOneAsync(team => team.TeamId == id, Builders<Team>.Update.Set(team => team.GoalsConceded, goalsConceded));

        // Update Points
        public async Task UpdatePointsAsync(string id, int points) =>
            await _teamsCollection.UpdateOneAsync(team => team.TeamId == id, Builders<Team>.Update.Set(team => team.Points, points));

        // Delete team
        public async Task DeleteTeamAsync(string id) =>
            await _teamsCollection.DeleteOneAsync(team => team.TeamId == id);
    }
}
