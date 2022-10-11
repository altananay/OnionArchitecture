using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OperationClaim
    {
    //    [BsonId]
    //    [BsonRepresentation(BsonType.ObjectId)]
    //    public string? _id { get; set; }
        public string[] Name { get; set; }

        public string[] GetClaims()
        {
            return Name;
        }
    }
}