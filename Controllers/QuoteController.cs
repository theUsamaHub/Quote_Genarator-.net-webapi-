using Microsoft.AspNetCore.Mvc;
using Quote_genarator.Data;
using Quote_genarator.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Quote_generator.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly AppDbContext _context;

        private readonly IHttpClientFactory _httpClientFactory;

        public QuoteController(AppDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

       

        // GET: api/quote
        // Returns all quotes in the database
        [HttpGet]
        public IActionResult GetQuotes()
        {
            var quotes = _context.Quotes.ToList();
            return Ok(quotes);
        }

        // GET: api/quote/5
        // Returns a single quote by its Id
        [HttpGet("{id}")]
        public IActionResult GetQuote(int id)
        {
            var quote = _context.Quotes.Find(id);

            if (quote == null)
                return NotFound();

            return Ok(quote);
        }

        // POST: api/quote
        // Creates a new quote in the database
        [HttpPost]
        public IActionResult CreateQuote(Quote quote)
        {
            _context.Quotes.Add(quote);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetQuote), new { id = quote.Id }, quote);
        }

        // PUT: api/quote/5
        // Updates an existing quote by Id
        [HttpPut("{id}")]
        public IActionResult UpdateQuote(int id, Quote updatedQuote)
        {
            var quote = _context.Quotes.Find(id);

            if (quote == null)
                return NotFound();

            quote.Text = updatedQuote.Text;
            quote.Author = updatedQuote.Author;
           

            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/quote/5
        // Deletes a quote from the database by Id
        [HttpDelete("{id}")]
        public IActionResult DeleteQuote(int id)
        {
            var quote = _context.Quotes.Find(id);

            if (quote == null)
                return NotFound();

            _context.Quotes.Remove(quote);
            _context.SaveChanges();

            return NoContent();
        }

        // GET: api/quote/random
        // Returns a random quote from the database
        [HttpGet("random")]
        public IActionResult GetRandomQuote()
        {
            var total = _context.Quotes.Count();
            if (total == 0) return NotFound();

            var random = new Random();
            var skip = random.Next(0, total);
            var quote = _context.Quotes.Skip(skip).FirstOrDefault();

            return Ok(quote);
        }

        /// POST: api/quote/fill-random
        // Fetches 100 random quotes from quotable.io and adds them to the database
        //[HttpPost("fill-random")]
        //public async Task<IActionResult> FillRandomQuotes()
        //{
        //    // Inside FillRandomQuotes
        //    var client = _httpClientFactory.CreateClient("NoSSL");
        //    var quotesToAdd = new List<Quote>();

        //    for (int i = 0; i < 100; i++)
        //    {
        //        var response = await client.GetAsync("https://zenquotes.io/api/quotes");
        //        if (!response.IsSuccessStatusCode)
        //            continue;

        //        var json = await response.Content.ReadAsStringAsync();

        //        // Deserialize to a temporary object
        //        var apiQuote = JsonSerializer.Deserialize<ApiQuote>(json);

        //        if (apiQuote != null)
        //        {
        //            quotesToAdd.Add(new Quote
        //            {
        //                Text = apiQuote.content,
        //                Author = apiQuote.author,
        //                CreatedAt = DateTime.UtcNow
        //            });
        //        }
        //    }

        //    if (quotesToAdd.Count > 0)
        //    {
        //        _context.Quotes.AddRange(quotesToAdd);
        //        _context.SaveChanges();
        //    }

        //    return Ok(new { Added = quotesToAdd.Count });
        //}





        [HttpPost("fill-random")]
        public async Task<IActionResult> FillRandomQuotes()
        {
            var client = _httpClientFactory.CreateClient();
            var allQuotes = new List<ZenQuote>();

            // Make two requests to get 100 total quotes
            for (int i = 0; i < 2; i++)
            {
                var response = await client.GetAsync("https://zenquotes.io/api/quotes");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var quotes = JsonSerializer.Deserialize<List<ZenQuote>>(json);
                    if (quotes != null)
                        allQuotes.AddRange(quotes);
                }

                // Small delay to be respectful to the free API
                await Task.Delay(1000);
            }

            var quotesToAdd = allQuotes
                .Take(100) // Ensure we don't exceed 100 if API changes
                .Select(q => new Quote
                {
                    Text = q.q,
                    Author = q.a,
                    CreatedAt = DateTime.UtcNow
                })
                .ToList();

            if (quotesToAdd.Any())
            {
                _context.Quotes.AddRange(quotesToAdd);
                await _context.SaveChangesAsync();
            }

            return Ok(new { Added = quotesToAdd.Count });
        }

        public class ZenQuote
        {
            public string q { get; set; }
            public string a { get; set; }
        }
        // Temporary helper class for deserializing API response
        private class ApiQuote
        {
            public string content { get; set; }
            public string author { get; set; }
        }
    }
}
