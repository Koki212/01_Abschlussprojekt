using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OnlineSpielplan.Models
{
    public class Team
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TeamId { get; set; } = "";

        [BsonElement("TeamName")]
        [JsonPropertyName("TeamName")]
        public string TeamName { get; set; }
        public int GamesPlayed { get; set; }
        public int GamesWon { get; set; }
        public int GamesDraw { get; set; }
        public int GamesLost { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsConceded { get; set; }
        public int Points { get; set; }
        [BsonElement("CompetitionId")]
        [JsonPropertyName("CompetitionId")]
        public string CompetitionId { get; set; } = null!;

        public Team(string teamName)
        {
            TeamName = teamName;
            return;
        }

    }
}
