using StockGularBack.Data.DB;

namespace StockGularBack.Data
{
    public class ArticleRepository : IArticlesRepository
    {
        public StockContext DataContext;
        public ArticleRepository(StockContext ctx)
        {
            DataContext = ctx;
        }

        public Article Add(Article article)
        {
            throw new NotImplementedException();
        }

        public Article Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetAll()
        {
            throw new NotImplementedException();
        }

        public Article GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Article Update(Article article)
        {
            throw new NotImplementedException();
        }
    }
}
