using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroMockApi.Models
{
    public class Form
    {

        [BsonId]
        [BsonElement("id")]
        public long id { get; set; }
        [BsonElement("label")]
        public string label { get; set; }
        [BsonElement("codeCreance")]
        public string codeCreance { get; set; }

    }
}
