using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroMockApi.Models
{
    public class Client
    {
        public Client()
        {
            this.bills = new HashSet<Bill>();
        }
        [BsonId]
        [BsonElement("id")]
        public long id { get; set; }
        [BsonElement("idPayment")]
        public String idPayment { get; set; }
        [BsonElement("fixeNumber")]
        public string fixeNumber { get; set; }
        [BsonElement("phoneNumber")]
        public string phoneNumber { get; set; }
        [BsonElement("firstName")]
        public string firstName { get; set; }
        [BsonElement("lastName")]
        public string lastName { get; set; }
        [BsonElement("bills")]
        public virtual ICollection<Bill> bills { get; set; }
    }
}
