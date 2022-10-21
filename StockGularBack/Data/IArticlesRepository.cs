using StockGularBack.Data.DB;

namespace StockGularBack.Data
{
    public interface IArticlesRepository
    {
        public IEnumerable<Article> GetAll();
        public Article GetById(int id);
        public Article Add(Article article);
        public Article Update(Article article);
        public Article Delete(int id);
    }
}
