using APIEFCoreSQLSp.Models;
using APIEFCoreSQLSp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIEFCoreSQLSp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService) 
        {
            this.productService = productService;
        }

        [HttpGet(Name = "GetProductListAsync")]
        public async Task<List<Product>> GetProductListAsync()
        {
            try
            {
                return await productService.GetProductListAsync();
            }
            catch
            {
                throw;
            }
        }

        //[HttpGet(Name = "GetProductByIdAsync")]
        //public async Task<IEnumerable<Product>> GetProductByIdAsync(int productId)
        //{
        //    try
        //    {
        //        var response = await productService.GetProductByIdAsync(productId);

        //        if (response == null)
        //        {
        //            return null;
        //        }

        //        return response;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        [HttpPost( Name ="AddProductAsync")]
        public async Task<IActionResult> AddProductAsync(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            try
            {
                var response = await productService.AddProductAsync(product);

                return Ok(response);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut(Name = "UpdateProductAsync")]
        public async Task<IActionResult> UpdateProductAsync(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await productService.UpdateProductAsync(product);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete(Name = "DeleteProductAsync")]
        public async Task<int> DeleteProductAsync(int Id)
        {
            try
            {
                var response = await productService.DeleteProductAsync(Id);
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}
