using SampleAPI.Entities;

namespace SampleAPI.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IOrderRepository OrderRepository { get; private set; }
        private readonly SampleApiDbContext _sampleApiDbContext;

        public UnitOfWork(SampleApiDbContext sampleApiDbContext)
        {
            _sampleApiDbContext = sampleApiDbContext;
            OrderRepository = new OrderRepository(_sampleApiDbContext);
        }
        public async Task CompleteAsync()
        {
            await _sampleApiDbContext.SaveChangesAsync();
        }
    }
}
