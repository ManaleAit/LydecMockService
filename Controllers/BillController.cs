using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroMockApi.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroMockApi.Controllers
{
    [Route("/lydec/bill")]
    public class BillController : Controller
    {
        public IMongoDatabase getColl()
        {
            var client = new MongoClient("mongodb+srv://manal:manal@cluster0.8fwgk.mongodb.net/db?retryWrites=true&w=majority");
            return client.GetDatabase("db");

        }
        [HttpGet]
        public IEnumerable<Bill> Get()
        {
            var collection = getColl().GetCollection<Bill>("Bill");
            return collection.Find(s => s.id != null).ToList();
        }
        [HttpGet("{id}")]
        public Bill Get(long id)
        {
            var collection = getColl().GetCollection<Bill>("Bill");
            return collection.Find(s => s.id == id).First();
        }
        [HttpGet("batch/{id}")]
        public Bill get(long id)
        {
            var collection = getColl().GetCollection<Bill>("Bill");
            Bill b= collection.Find(s => s.id == id).First();
            b.isBatched = true;
            collection.ReplaceOne(bi => bi.id == id, b);

            return b;
        }
        [HttpGet("pay/{id}")]
        public Bill payBill(long id)
        {
            var collection = getColl().GetCollection<Bill>("Bill");
            Bill b = collection.Find(s => s.id == id).First();
            b.payed = true;
            b.payedDate = new DateTime();
            collection.ReplaceOne(bi => bi.id == b.id, b);
            return b;
        }

        [HttpPost]
        public void Post([FromBody]Bill bill)
        {
           
            getColl().GetCollection<Bill>("Bill").InsertOne(bill);
        }
        
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            getColl().GetCollection<Bill>("Bill").DeleteOne(p => p.id == id);
        }
    }
}
