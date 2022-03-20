using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAPITeste.Models
{
    public class User
    {
    //    [BsonId]
    //    [BsonRepresentation(BsonType.ObjectId)]
    //    public string Id { get; set; }
        public int UniqueId { get; set; }
        public string Username { get; set; }
        public string Passowrd { get; set; }
        public string Role { get; set; }
    }
}
