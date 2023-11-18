using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace OnlineSpielplan.Models
{
    public class Competition
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("CompetitionId")]
        public string? CompetitionId { get; set; }

        [BsonRepresentation(BsonType.String)]
        [BsonElement("Name")]
        [JsonPropertyName("Name")]
        public string? Name { get; set; } = null!;

        public Competition(string name)
        {
            Name = name;
        }

        public Competition()
        {
        }
    }
}
