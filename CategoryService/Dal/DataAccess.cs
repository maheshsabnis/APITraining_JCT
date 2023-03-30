using CategoryService.Database;
using CategoryService.Models;

namespace CategoryService.Dal
{
    public class DataAccess
    {
        CategoriesDb database = new CategoriesDb ();

        public IEnumerable<Category> GetAllCategories() 
        {
            return database;
        }

        public Category GetCategory(int id)
        {
            return database.First(c=>c.CategoryId == id);
        }

        public IEnumerable<Category> CreateCategory(Category category)
        {
            database.Add(category);
            return database;
        }
        public IEnumerable<Category> UpdateCategory(int id, Category category)
        {
            if (id == category.CategoryId)
            {
                // 1. Search Category from Database based in 'id'
                var cat = database.First(c => c.CategoryId == id);
                // 2. Remove the searched category
                database.Remove(cat);
                // 3. Add the new updated category
                database.Add(category);
            }
            return database;
        }

        public IEnumerable<Category> DeleteCategory(int id)
        {
            // 1. Search Category from Database based in 'id'
            var cat = database.First(c => c.CategoryId == id);
            // 2. Remove the searched category
            database.Remove(cat);
            return database;
        }
    }
}
