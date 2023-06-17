using APICQRSDemo.Commands.Create;
using APICQRSDemo.Commands.Delete;
using APICQRSDemo.Commands.Update;
using APICQRSDemo.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace APICQRSDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IMediator _mediator; 

        public ProductController(IMediator mediator)
        { 
            _mediator = mediator;
        }

        [HttpPost(Name = "AddProduct")]
        public async Task<IActionResult> AddProduct(CreateProductCommand command) 
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut(Name = "UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command) 
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete(Name = "DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommand command) 
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet(Name = "GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var productResult = await _mediator.Send(new GetProduct());

            return Ok(productResult);
        }

        //[HttpGet(Name = "GetAllProductById")]
        //public async Task<IActionResult> GetAllProductById( long productId) 
        //{
        //    return Ok(await _mediator.Send(new GetProduct()));
        //}
    }
}
