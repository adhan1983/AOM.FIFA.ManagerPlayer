using AOM.FIFA.ManagerPlayer.Application.Synchronization.Interfaces.Repositories;

namespace AOM.FIFA.ManagerPlayer.Application.Base.Interfaces
{
    public interface IRepositoryFactory
    {
        ISyncRepository SyncRepository { get; }

        ISyncPageRepository SyncPageRepository { get; }

        ISourceWithoutSyncRepository SourceWithoutSyncRepository { get; }
    }
}
