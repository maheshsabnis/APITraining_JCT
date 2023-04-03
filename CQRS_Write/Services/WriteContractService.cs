using CQRS_Write.Models;

namespace CQRS_Write.Services
{
    public class WriteContractService : IWriteContract
    {
        private readonly ProductInfoDbContext context;

        public WriteContractService(ProductInfoDbContext context)
        {
            this.context = context;
        }

        ProductInfo IWriteContract.AddProduct(ProductInfo product)
        {
            var result = context.Products.Add(product);
            context.SaveChanges();
            return result.Entity;

        }

        bool IWriteContract.DeleteProduct(int id)
        {
            var prd = context.Products.Find(id);
            if (prd != null)
            {
                context.Products.Remove(prd);
                context.SaveChanges();
                return true;
            }
            return false;

        }

        ProductInfo IWriteContract.UpdateProdut(int id, ProductInfo product)
        {
            var prd = context.Products.Find(id);
            if (prd != null)
            {
                prd.ProductId = product.ProductId;
                prd.ProductName = product.ProductName;
                prd.Manufacturer = product.Manufacturer;
                prd.BasePrice = product.BasePrice;
                prd.Description = product.Description;
                context.SaveChanges();
                return prd;
            }
            return null;
        }
    }
}
