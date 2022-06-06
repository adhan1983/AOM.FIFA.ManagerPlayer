using AOM.FIFA.ManagerPlayer.Application.Base.Interfaces;
using AOM.FIFA.ManagerPlayer.Persistence.Synchronization.Context;
using AOM.FIFA.ManagerPlayer.Application.Synchronization.Interfaces.Repositories;

namespace AOM.FIFA.ManagerPlayer.Persistence.Synchronization.Synchronization.Repository
{
    public class RepositoryFactory : IRepositoryFactory
    {
        #region Privates
        
        private FIFASynchronizationDbContext _context;

        private ISyncRepository _syncRepository;

        private ISyncPageRepository _syncPageRepository;

        private ISourceWithoutSyncRepository _sourceWithoutSyncRepository;

        #endregion

        #region Public's
        public ISourceWithoutSyncRepository SourceWithoutSyncRepository
        {
            get
            {
                if (_sourceWithoutSyncRepository == null)
                {
                    _sourceWithoutSyncRepository = new SourceWithoutSyncRepository(_context);

                }
                return _sourceWithoutSyncRepository;
            }
        }

        public ISyncPageRepository SyncPageRepository
        {
            get
            {
                if (_syncPageRepository == null)
                {
                    _syncPageRepository = new SyncPageRepository(_context);

                }
                return _syncPageRepository;
            }
        }

        public ISyncRepository SyncRepository
        {
            get
            {
                if (_syncRepository == null)
                {
                    _syncRepository = new SyncRepository(_context);

                }
                return _syncRepository;
            }
        }

        #endregion
    }
}
