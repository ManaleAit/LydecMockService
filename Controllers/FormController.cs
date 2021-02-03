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
    [Route("lydec/form")]
    public class FormController : Controller
    {
        public IMongoDatabase getColl()
        {
            var client = new MongoClient("mongodb+srv://manal:manal@cluster0.8fwgk.mongodb.net/db?retryWrites=true&w=majority");
            return client.GetDatabase("db");

        }

        [HttpGet("{codeCreance}")]
        public Form getbyCreanceForm(string codeCreance)
        {
            var collection = getColl().GetCollection<Form>("Form");
            return collection.Find(s => s.codeCreance == codeCreance).First();
        }

        [HttpGet]
        public IEnumerable<Form> Get()
        {
            var collection = getColl().GetCollection<Form>("Form");
            return collection.Find(s => s.id != null).ToList();
        }
        [HttpGet("{id}")]
        public Form Get(long id)
        {
            var collection = getColl().GetCollection<Form>("Form");
            return collection.Find(s => s.id == id).First();
        }
        [HttpPost]
        public void Post([FromBody]Form form)
        {

            getColl().GetCollection<Form>("Form").InsertOne(form);
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            getColl().GetCollection<Form>("Form").DeleteOne(p => p.id == id);
        }
    }
}
