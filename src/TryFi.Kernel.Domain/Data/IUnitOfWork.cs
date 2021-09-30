namespace TryFi.Kernel.Domain.Data
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
