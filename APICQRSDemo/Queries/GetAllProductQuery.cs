using APICQRSDemo.Models;
using APICQRSDemo.Repository;
using APICQRSDemo.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace APICQRSDemo.Queries
{
    public class GetAllProductQuery : IRequestHandler<GetProduct, IEnumerable<Product>>
    {
        private readonly IUnitOfWorkProduct _unitOfWorkProduct; 
        
        public GetAllProductQuery(IUnitOfWorkProduct unitOfWorkProduct)  
        {
            _unitOfWorkProduct= unitOfWorkProduct;
        }
        public async Task<IEnumerable<Product>> Handle(GetProduct query, CancellationToken cancellationToken)
        {
            var productList = await _unitOfWorkProduct.productRepository.GetProducts();
            return productList;
        }
    }
}
