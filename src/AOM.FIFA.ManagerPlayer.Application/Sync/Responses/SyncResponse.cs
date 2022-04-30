using System.Collections.Generic;

namespace AOM.FIFA.ManagerPlayer.Application.Sync.Responses
{
    public class SyncResponse
    {
        public string TypeOfSyncName { get; set; }
        public bool AllItemsSynchronized { get; set; }
        public bool Synchronized { get; set; }
        public int TotalPagesSynchronized { get; set; }
        public int TotalItemsSynchronized { get; set; }
        public int TotalItemDoNotSynchronized { get; set; }
        public List<int> SourceIdsDoNotSynchronized { get; set; }
    }
}
