namespace SampleAPI.Repositories
{
    public interface IUnitOfWork
    {
        IOrderRepository OrderRepository { get; }
        Task CompleteAsync();
        // Task CommitAsync();
    }
}
