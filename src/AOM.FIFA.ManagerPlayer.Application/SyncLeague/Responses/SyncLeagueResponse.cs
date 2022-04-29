using System.Collections.Generic;

namespace AOM.FIFA.ManagerPlayer.Application.SyncLeague.Responses
{
    public class SyncLeagueResponse
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
