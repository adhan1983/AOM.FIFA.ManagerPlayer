using System.Collections.Generic;

namespace AOM.FIFA.ManagerPlayer.Application.Sync.Entities
{
    public class SyncPage
    {
        public int Id { get; set; }
        public int Page { get; set; }
        public int TotalSynchronized { get; set; }
        public int TotalDosNotSynchronized { get; set; }        
        public bool SyncPageSuccess { get; set; }
        public int SyncId { get; set; }        
        public Sync Sync { get; set; }
        public List<SourceWithoutSync> SourcesWithoutSync { get; set; }
    }
}
