using APICQRSDemo.Repository;

namespace APICQRSDemo.UnitOfWork
{
    public interface IUnitOfWorkProduct
    {
        IProductRepository productRepository { get; }
        Task<int> Commit();
        void Rollback();
        Task<int> CommitAsync();
        Task RollbackAsync();
    }
}
