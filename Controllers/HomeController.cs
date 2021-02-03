using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicroMockApi.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MicroMockApi.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IEnumerable<Client> Get()
        {
            var client = new MongoClient("mongodb+srv://manal:manal@cluster0.8fwgk.mongodb.net/db?retryWrites=true&w=majority");
            var database = client.GetDatabase("");
            /*Client c = new Client();
            c.firstName = "manal";
            c.idPayment = 1;
            c.lastName = "manal";
            c.bills = null;
            database.GetCollection<Client>("Client").InsertOne(c);*/
            var collection = database.GetCollection<Client>("Client");
            return collection.Find(s => s.firstName == "manal").ToList();
        }
        public IActionResult Index()
        {
            var client = new MongoClient("mongodb+srv://manal:manal@cluster0.8fwgk.mongodb.net/db?retryWrites=true&w=majority");
            var database = client.GetDatabase("db");
           
            /*Form f = new Form();
            f.id = 5;
            f.label = "electricité";
            f.codeCreance = "lydec3001";
            Form f2 = new Form();
            f.id = 3;
            f2.label = "eau";
            f2.codeCreance = "lydec3002";
            database.GetCollection<Form>("Form").InsertOne(f);
            database.GetCollection<Form>("Form").InsertOne(f2);*/
            /*Bill b1 = new Bill();
            b1.id = 1001;
            b1.amount = 122;
            b1.payed = false;
            b1.isBatched = false;
            b1.codeCreance="lydec3002";
            database.GetCollection<Bill>("Bill").InsertOne(b1);
            Bill b4 = new Bill();
            b4.id = 1006;
            b4.amount = 122;
            b4.payed = false;
            b4.isBatched = false;
            b4.codeCreance = "lydec3002";
            database.GetCollection<Bill>("Bill").InsertOne(b4);
            Bill b2 = new Bill();
            b2.id = 1002;
            b2.amount = 122;
            b2.payed = true;
            b2.isBatched = false;
            b2.codeCreance = "lydec3002";
            database.GetCollection<Bill>("Bill").InsertOne(b2);
            Bill b3 = new Bill();
            b3.id = 1003;
            b3.amount = 122;
            b3.payed = false;
            b3.isBatched = false;
            b3.codeCreance = "lydec3001";
            database.GetCollection<Bill>("Bill").InsertOne(b3);
            Client c = new Client();
            c.firstName = "manalpp";
            c.idPayment = "12";
            c.lastName = "manalll";
            c.bills.Add(b1);
            c.bills.Add(b2);
            c.bills.Add(b3);
            c.bills.Add(b4);
            */
            //database.GetCollection<Client>("Client").InsertOne(c);
            var collection = database.GetCollection<Client>("Client");
            return View(collection.Find(s => s.firstName !=null).ToList());
        }
    }
       
}
