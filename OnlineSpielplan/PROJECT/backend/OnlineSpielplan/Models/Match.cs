using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OnlineSpielplan.Models
{
    public class Match
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MatchId { get; set; } = "";
        public int MatchNumber { get; set; }
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public int ScoreTeam1 { get; set; }
        public int ScoreTeam2 { get; set; }
        public bool IsPlayed { get; set; } = false;
        [BsonElement("CompetitionId")]
        [JsonPropertyName("CompetitionId")]
        public string CompetitionId { get; set; } = null!;

        public Match(Team team1, Team team2, int scoreTeam1, int scoreTeam2)
        {
            Team1 = team1;
            Team2 = team2;
            ScoreTeam1 = scoreTeam1;
            ScoreTeam2 = scoreTeam2;
        }

        public Match(Team team1, Team team2, int matchNumber, int scoreTeam1, int scoreTeam2, bool isPlayed)
        {
            MatchNumber = matchNumber;
            Team1 = team1;
            Team2 = team2;
            ScoreTeam1 = scoreTeam1;
            ScoreTeam2 = scoreTeam2;
            IsPlayed = isPlayed;

        }
    }
}
