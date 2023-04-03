using CQRS_Read.Models;

namespace CQRS_Read.Services
{
    public interface IReadContract
    {
        List<ProductInfo> GetProducts();
        ProductInfo GetProduct(int id);
        List<ProductInfo> GetProducts(string catname, string codition, string desc);
        List<ProductInfo> GetProducts(string name, string manufacturer);
        /// <summary>
        /// ctiteria vaue will be anything as follows
        /// ProductName="Laptop" and Category="Electronics"
        /// Manufacturer="HP"
        /// ProductName="Laptop" andManufacturer="HP"
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        List<ProductInfo> GetProducts(string criteria);
    }
}
