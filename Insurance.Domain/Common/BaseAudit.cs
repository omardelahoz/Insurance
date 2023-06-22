using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Common
{
    internal class BaseAudit
    {
        public ObjectId CreatedBy { get; set; }
        public DateTime CeatedOn { get;}
        public ObjectId UpdateBy { get; set; }
        public DateTime UpdatedOn { get;}
    }
}
