using StockGularBack.Data.DB;

namespace StockGularBack.Data
{
    public interface ICategorieRepository
    {
        public IEnumerable<Category> GetAll();
        public Category GetById(int id);
        public Category Add(Category category);
        public Category Update(Category category);
        public Category Delete(int id);
    }
}
