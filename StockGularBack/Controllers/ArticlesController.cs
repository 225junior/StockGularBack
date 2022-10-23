using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockGularBack.Data.DB;

namespace StockGularBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly ILogger<ArticlesController> _logger;
        public StockContext DataContext;

        public ArticlesController(StockContext ctx,ILogger<ArticlesController> logger)
        {
            DataContext = ctx;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Article> GetAll()
        {
            return DataContext.Articles.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticle(int id)
        {
            var article = await DataContext.Articles.FindAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            return article;
        }

        [HttpPost]
        public async Task<ActionResult<Article>> PostArticle(Article article)
        {
            DataContext.Articles.Add(article);
            await DataContext.SaveChangesAsync();

            return CreatedAtAction("GetArticle", new { id = article.Id }, article);
        }
    }
}


// GET: api/Articles1
//[HttpGet]
//public async Task<ActionResult<IEnumerable<Article>>> GetArticles()
//{
//    return await _context.Articles.ToListAsync();
//}

//// GET: api/Articles1/5
//[HttpGet("{id}")]
//public async Task<ActionResult<Article>> GetArticle(int id)
//{
//    var article = await _context.Articles.FindAsync(id);

//    if (article == null)
//    {
//        return NotFound();
//    }

//    return article;
//}

//// PUT: api/Articles1/5
//// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//[HttpPut("{id}")]
//public async Task<IActionResult> PutArticle(int id, Article article)
//{
//    if (id != article.Id)
//    {
//        return BadRequest();
//    }

//    _context.Entry(article).State = EntityState.Modified;

//    try
//    {
//        await _context.SaveChangesAsync();
//    }
//    catch (DbUpdateConcurrencyException)
//    {
//        if (!ArticleExists(id))
//        {
//            return NotFound();
//        }
//        else
//        {
//            throw;
//        }
//    }

//    return NoContent();
//}

//// POST: api/Articles1
//// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//[HttpPost]
//public async Task<ActionResult<Article>> PostArticle(Article article)
//{
//    _context.Articles.Add(article);
//    await _context.SaveChangesAsync();

//    return CreatedAtAction("GetArticle", new { id = article.Id }, article);
//}

//// DELETE: api/Articles1/5
//[HttpDelete("{id}")]
//public async Task<IActionResult> DeleteArticle(int id)
//{
//    var article = await _context.Articles.FindAsync(id);
//    if (article == null)
//    {
//        return NotFound();
//    }

//    _context.Articles.Remove(article);
//    await _context.SaveChangesAsync();

//    return NoContent();
//}

//private bool ArticleExists(int id)
//{
//    return _context.Articles.Any(e => e.Id == id);
//}