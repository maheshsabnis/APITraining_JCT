using CategoryService.Models;

namespace CategoryService.Database
{
    public class CategoriesDb : List<Category>
    {
        public CategoriesDb()
        {
            Add(new Category() { CategoryId = 1, CategoryName = "C1", BasePrice = 11000 });
            Add(new Category() { CategoryId = 2, CategoryName = "C2", BasePrice = 12000 });
            Add(new Category() { CategoryId = 3, CategoryName = "C3", BasePrice = 13000 });
            Add(new Category() { CategoryId = 4, CategoryName = "C4", BasePrice = 14000 });
        }
    }
}
