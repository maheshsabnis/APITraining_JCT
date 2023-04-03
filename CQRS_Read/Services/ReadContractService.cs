using CQRS_Read.Models;

namespace CQRS_Read.Services
{
    public class ReadContractService : IReadContract
    {
        private readonly ProductInfoDbContext context;

        public ReadContractService(ProductInfoDbContext context)
        {
            this.context = context;           
        }

        ProductInfo IReadContract.GetProduct(int id)
        {
            return context.Products.Find(id);
        }

        List<ProductInfo> IReadContract.GetProducts()
        {
            return context.Products.ToList();
        }

        List<ProductInfo> IReadContract.GetProducts(string catname, string codition, string desc)
        {
            throw new NotImplementedException();
        }

        List<ProductInfo> IReadContract.GetProducts(string name, string manufacturer)
        {
            var products = (from prd in context.Products
                           where prd.ProductName == name && prd.Manufacturer == manufacturer
                           select prd).ToList();
            return products;
        }

        List<ProductInfo> IReadContract.GetProducts(string criteria)
        {
            throw new NotImplementedException();
        }
    }
}
