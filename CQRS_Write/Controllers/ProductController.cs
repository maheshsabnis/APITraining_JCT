using CQRS_Write.Models;
using CQRS_Write.publisher;
using CQRS_Write.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Write.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IWriteContract contract;

        QueuePublisher publish;

        public ProductController(IWriteContract contract)
        {
            this.contract = contract;
            publish = new QueuePublisher();
        }
        [HttpPost]
        public IActionResult Post(ProductInfo product)
        { 
            var prod = contract.AddProduct(product);
            publish.PublishMessage(prod);
            return Ok(prod);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, ProductInfo product) 
        {
            var prod = contract.UpdateProdut(id, product);
            if (prod == null)
                return BadRequest("The Updated Failed");
            return Ok(prod);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var result = contract.DeleteProduct(id);
            if (!result)
                return BadRequest("Delete Product is failed");
            return Ok("Product Is deleted Successfuly");
        }
    }
}
