using APICQRSDemo.Commands.Create;
using APICQRSDemo.Commands.Update;
using APICQRSDemo.Models;

namespace APICQRSDemo.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<long> AddProduct(CreateProductCommand createProductCommand);
        Task<long> UpdateProduct(UpdateProductCommand updateProductCommand);
        Task<Product> GetProductById(long id);
        Task<long> DeleteProduct(long prodcutId);
    }
}
