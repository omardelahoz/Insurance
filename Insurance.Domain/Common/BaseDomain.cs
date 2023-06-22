using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Common
{
    public class BaseDomain
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public DateTime ExpirationDate { get; set; } = DateTime.MaxValue;
        public bool IsActive { get; set; } = true;
    }
}
