using APICQRSDemo.Models;
using APICQRSDemo.Repository;
using APICQRSDemo.UnitOfWork;
using MediatR;

namespace APICQRSDemo.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, long>
    {
        private readonly IUnitOfWorkProduct _unitOfWorkProduct; 

        public CreateProductCommandHandler(IUnitOfWorkProduct unitOfWorkProducty)  
        {
            this._unitOfWorkProduct = unitOfWorkProducty;
        }
        public async Task<long> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var productId = _unitOfWorkProduct.productRepository.AddProduct(command).ConfigureAwait(false); 
            return await _unitOfWorkProduct.CommitAsync();
        }
    }
}
