using APICQRSDemo.Commands.Create;
using APICQRSDemo.Commands.Update;
using APICQRSDemo.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace APICQRSDemo.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDBContext _productDBContext; 
        public ProductRepository(ProductDBContext productDBContext) 
        { 
            _productDBContext = productDBContext;
        }

        public async Task<long> AddProduct(CreateProductCommand createProductCommand)
        {
            var product = new Product();
            product.ProductName = createProductCommand.ProductName;
            product.ProductPrice = createProductCommand.ProductPrice;
            product.ProductDescription = createProductCommand.ProductDescription;
            product.ProductStock = createProductCommand.ProductStock;
            await _productDBContext.Products.AddAsync(product);
            return product.ProductId;
        }

        public async Task<long> DeleteProduct(long prodcutId)
        {
            var product = await _productDBContext.Products.Where(a => a.ProductId == prodcutId).FirstOrDefaultAsync();
            _productDBContext.Products.Remove(product);
            return product.ProductId;
        }

        public async Task<int> DeleteProductAsync(int Id)
        {
            return await Task.Run(() => _productDBContext.Database.ExecuteSqlInterpolatedAsync($"DeletePrductByID {Id}"));
        }

        public async Task<Product> GetProductById(long id)
        {
            return await _productDBContext.Products.Where(x=>x.ProductId==id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
          return await  _productDBContext.Products.ToListAsync();
        }

        public async Task<long> UpdateProduct(UpdateProductCommand updateProductCommand)
        {
            var product = await _productDBContext.Products.Where(a => a.ProductId == updateProductCommand.ProductId).FirstOrDefaultAsync();

            if (product == null)
            {
                return default;
            }
            else
            {
                product.ProductName = updateProductCommand.ProductName;
                product.ProductPrice = updateProductCommand.ProductPrice;
                product.ProductDescription = updateProductCommand.ProductDescription;
                product.ProductStock = updateProductCommand.ProductStock;
                _productDBContext.Products.Update(product);
                return product.ProductId;
            }
        }
    }
}
