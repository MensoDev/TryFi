using TryFi.Kernel.Domain.DomainObjects;

namespace TryFi.Kernel.Domain.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }

    }
}
