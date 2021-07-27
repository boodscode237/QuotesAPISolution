using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuotesAPI.Models;

namespace QuotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        static List<Quotes> _quotes = new List<Quotes>()
        {
            new Quotes() {Id = 0, Author = "Joe", Description = "The sky is blue sometimes", Title = "Inspirational"},
            new Quotes() {Id = 1, Author = "Johnny", Description = "The sky is brown also", Title = "Inspirational"},
        };

        [HttpGet]
        public IEnumerable<Quotes> Get()
        {
            return _quotes;
        }

        [HttpPost]
        public void Post([FromBody]Quotes quote)
        {
            _quotes.Add(quote);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Quotes quote)
        {
            _quotes[id] = quote;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _quotes.RemoveAt(id);
        }
    }
}
