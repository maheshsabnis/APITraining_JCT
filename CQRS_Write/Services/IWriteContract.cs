using CQRS_Write.Models;

namespace CQRS_Write.Services
{
    public interface IWriteContract
    {
        ProductInfo AddProduct(ProductInfo product);
        ProductInfo UpdateProdut(int id,ProductInfo product);
        bool DeleteProduct(int id);
    }
}
