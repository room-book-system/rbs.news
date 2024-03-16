using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RBS.News.Domain.Entities;

public class News
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    
    public string Title { get; set; }

    public DateTime CreatedAt { get; set; }
    
    public DateTime EditedAt { get; set; }
    
    public string ShortDescription { get; set; }
    
    public string Html { get; set; }
    
    public string ImageSrc { get; set; }
}