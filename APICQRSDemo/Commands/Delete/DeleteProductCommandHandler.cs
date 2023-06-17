using APICQRSDemo.Models;
using APICQRSDemo.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace APICQRSDemo.Commands.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, long>
    {
        private readonly IUnitOfWorkProduct _unitOfWorkProduct;
        public DeleteProductCommandHandler(IUnitOfWorkProduct unitOfWorkProduct)  
        {
            this._unitOfWorkProduct = unitOfWorkProduct;
        }

        public async Task<long> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _unitOfWorkProduct.productRepository.DeleteProduct(command.ProductId);
            return await _unitOfWorkProduct.CommitAsync();
        }
    }
}
