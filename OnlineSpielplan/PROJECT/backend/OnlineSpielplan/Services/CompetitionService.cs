using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OnlineSpielplan.Models;

namespace OnlineSpielplan.Services
{
    public class CompetitionService
    {
        private readonly IMongoCollection<Competition> _competitionCollection;

        public CompetitionService(
            IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
                databaseSettings.Value.ConnectionString);

            var database = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _competitionCollection = database.GetCollection<Competition>(
                databaseSettings.Value.CompetitionCollectionName);
        }

        // Create new competition with name and return ObjectId
        public async Task<List<Competition>> CreateCompetition(string name)
        {
            var competition = new Competition(name);
            await _competitionCollection.InsertOneAsync(competition);
            return await _competitionCollection.Find(competition => competition.Name == name).ToListAsync();
        }
        // Get all competitions
        public async Task<List<Competition>> GetAllCompetitionsAsync() =>
            await _competitionCollection.Find(competition => true).ToListAsync();

        // Get competition by name
        public async Task<Competition?> GetCompetitionByNameAsync(string name) =>
            await _competitionCollection.Find(competition => competition.Name == name).FirstOrDefaultAsync();
    }
}
