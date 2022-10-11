using Domain.Entities.Common;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserOperationClaim : BaseEntity
    {
        public string UserId { get; set; }
        public string[] UserClaims { get; set; }
    }
}