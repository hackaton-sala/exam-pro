using BACK.CORE.Interfaces.Repositories;

namespace BACK.CORE.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }

        int Complete();
        void Dispose();
    }
}