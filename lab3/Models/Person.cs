using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace lab3.Models;

public class Person
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime Birthday { get; set; }
    public int TicketNumber { get; set; }
}
