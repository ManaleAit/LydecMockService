using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroMockApi.Models
{
    public class Bill
    {
        [BsonId]
        public long id { get; set; }
        [BsonElement("amount")]
        public double amount { get; set; }
        [BsonElement("billingDate")]
        public DateTime billingDate { get; set; }
        [BsonElement("payedDate")]
        public DateTime payedDate { get; set; }
        [BsonElement("payed")]
        public Boolean payed { get; set; }
        [BsonElement("isBatched")]
        public Boolean isBatched { get; set; }
        [BsonElement("codeCreance")]
        public string codeCreance { get; set; }
        public Nullable<int> id_Client { get; set; }
        public virtual Client client { get; set; }


    }
}
