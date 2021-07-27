using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuotesAPI.Data;
using QuotesAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesEntityController : ControllerBase
    {
        private QuotesDbContext _quotesDbContext;

        public QuotesEntityController(QuotesDbContext quotesDbContext)
        {
            _quotesDbContext = quotesDbContext;
        }
        // GET: api/<QuotesEntityController>
        [HttpGet]
        public IActionResult Get()
        {
            // return _quotesDbContext.Quotes;
            // return Ok(_quotesDbContext.Quotes);
            // return BadRequest(_quotesDbContext.Quotes);
            return StatusCode(200);
        }

        // GET api/<QuotesEntityController>/5
        [HttpGet("{id}")]
        public Quotes Get(int id)
        {
            var quote = _quotesDbContext.Quotes.Find(id);
            return quote;
        }

        // POST api/<QuotesEntityController>
        [HttpPost]
        public void Post([FromBody] Quotes quote)
        {
            _quotesDbContext.Quotes.Add(quote);
            _quotesDbContext.SaveChanges();
        }

        // PUT api/<QuotesEntityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Quotes quote)
        {
            var entity = _quotesDbContext.Quotes.Find(id);
            entity.Title = quote.Title;
            entity.Author = quote.Author;
            entity.Description = quote.Description;
            _quotesDbContext.SaveChanges();
        }

        // DELETE api/<QuotesEntityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var quote = _quotesDbContext.Quotes.Find(id);
            _quotesDbContext.Quotes.Remove(quote);
            _quotesDbContext.SaveChanges();
        }
    }
}
