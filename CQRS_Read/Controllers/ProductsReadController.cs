using CQRS_Read.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace CQRS_Read.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsReadController : ControllerBase
    {
        private readonly IReadContract contract;
        public ProductsReadController(IReadContract contract)
        {
            this.contract = contract;
        }

        [HttpGet]
        [ActionName("products/all")]
        public IActionResult Get()
        {
            var products = contract.GetProducts();
            return Ok(products);
        }
        [HttpGet("{id}")]
        [ActionName("single")]
        public IActionResult Get(int id)
        {
            var product = contract.GetProduct(id);
            return Ok(product);
        }

        [HttpGet("{name}/{manufacturer}")]
        [ActionName("criteria")]
        public IActionResult Get(string name, string manufacturer) 
        {
            var produts = contract.GetProducts(name, manufacturer);
            return Ok(produts);
        }

    }
}
