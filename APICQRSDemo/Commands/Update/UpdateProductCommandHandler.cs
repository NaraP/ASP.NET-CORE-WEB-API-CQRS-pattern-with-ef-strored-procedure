using APICQRSDemo.Models;
using APICQRSDemo.Repository;
using APICQRSDemo.UnitOfWork;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace APICQRSDemo.Commands.Update
{
    public class UpdateProductCommandHandler:IRequestHandler<UpdateProductCommand,long>
    {
        private readonly IUnitOfWorkProduct _unitOfWorkProduct;
        public UpdateProductCommandHandler(IUnitOfWorkProduct unitOfWorkProduct)  
        {
            this._unitOfWorkProduct = unitOfWorkProduct;
        }

        public async Task<long> Handle(UpdateProductCommand command, CancellationToken cancellationToken) 
        {
             await _unitOfWorkProduct.productRepository.UpdateProduct(command);
            return await _unitOfWorkProduct.CommitAsync();
        }
    }
}
