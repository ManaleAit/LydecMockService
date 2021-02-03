using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MicroMockApi.Models;
using MongoDB.Bson;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroMockApi.Controllers
{
    [Route("lydec/")]
    public class ServicePayment : Controller
    {
        
        public IMongoDatabase getColl()
        {
            var client = new MongoClient("mongodb+srv://manal:manal@cluster0.8fwgk.mongodb.net/db?retryWrites=true&w=majority");
            return client.GetDatabase("db");

        }


        [HttpGet("payment/{genericId}/{codeCreance}")]
        public Client getClientWithBills(string genericId,string codeCreance)
        {
            var collection = getColl().GetCollection<Client>("Client");

            if (codeCreance.Equals("lydec3001"))
            {
                try
                {
                    return getClientByNotPayed(collection.Find(s => s.idPayment == genericId).First(),codeCreance);
                }
                catch(Exception e)
                {
                    Console.Out.WriteLine(e.ToString());
                }
            }
            else if(codeCreance.Equals("lydec3002"))
            {
                try
                {
                    return getClientByNotPayed(collection.Find(s => s.idPayment == genericId).First(), codeCreance);
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(e.ToString());
                }

            }
            return null;
        }
        //function for get not payed bills
        Client getClientByNotPayed(Client client,string code)
        {

            ICollection<Bill> bills = client.bills;

            client.bills = bills.Where(x => x.payed == false && x.codeCreance.Equals(code)).ToList();
            return client;
        }
        [HttpGet]
        public IEnumerable<Client> Get()
        {
            var collection = getColl().GetCollection<Client>("Client");
            return collection.Find(s => s.id !=null).ToList();
        }
       
        
        [HttpGet("{id}")]
        public Client Get(string id)
        {
            var collection = getColl().GetCollection<Client>("Client");
            return collection.Find(s => s.idPayment == id).First();
        }
        
        [HttpPost]
        public void Post([FromBody]Client cl)
        {
            getColl().GetCollection<Client>("Client").InsertOne(cl);
        }

        
        [HttpDelete("{id}")]
        public void Delete(string id)
        {

            getColl().GetCollection<Client>("Client").DeleteOne(p => p.idPayment == id);
            
        }
    }
}
