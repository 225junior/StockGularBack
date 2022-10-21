using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
