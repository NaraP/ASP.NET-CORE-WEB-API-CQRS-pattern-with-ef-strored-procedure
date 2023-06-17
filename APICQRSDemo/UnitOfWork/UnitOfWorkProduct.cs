using APICQRSDemo.Models;
using APICQRSDemo.Repository;

namespace APICQRSDemo.UnitOfWork
{
    public class UnitOfWorkProduct : IUnitOfWorkProduct
    {
        private readonly ProductDBContext _dbContext;
        private IProductRepository? _productRepository; 

        public UnitOfWorkProduct(ProductDBContext dbContext)  
        {
            _dbContext= dbContext;
        }

        public IProductRepository productRepository 
        {
            get { return _productRepository = _productRepository ?? new ProductRepository(_dbContext); }
        }

        public async Task<int> Commit()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Rollback()
            => _dbContext.Dispose();

        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();
    }
}
